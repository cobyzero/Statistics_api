using Microsoft.EntityFrameworkCore;
using statistics_api.Src.Core.Models;

public class CustomersService
{
    private readonly StatisticsContext _context;

    public CustomersService(StatisticsContext context)
    {
        _context = context;
    }


    public async Task<List<CountryCustomersEntity>> GetCountryCustomersEntities()
    {
        return await _context.Customers.GroupBy(c => c.Country)
            .Select(g => new CountryCustomersEntity { Country = g.Key ?? "Unknown", NumberOfCustomers = g.Count() })
            .ToListAsync();
    }
}
