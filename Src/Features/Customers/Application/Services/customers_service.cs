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

    public async Task<List<CustomersTopOrdersEntity>> GetCustomersTopInOrders()
    {
        return await _context.Customers.Join(_context.Orders, c => c.CustomerId, o => o.CustomerId, (c, o) => new { c.ContactName, o.OrderId })
            .GroupBy(x => x.ContactName)
            .Select(g => new CustomersTopOrdersEntity { ContactName = g.Key ?? "Unknown", CountOrders = g.Count() })
            .OrderByDescending(x => x.CountOrders)
            .Take(5)
            .ToListAsync();
    }

}
