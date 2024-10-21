
public class CustomersIRepository : CustomersRepository
{
    private readonly CustomersService _customersService;

    public CustomersIRepository(CustomersService customersService)
    {
        _customersService = customersService;
    }

    public override async Task<List<CountryCustomersEntity>> GetCountryCustomers()
    {
        return await _customersService.GetCountryCustomersEntities();
    }
}