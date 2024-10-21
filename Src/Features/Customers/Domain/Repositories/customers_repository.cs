using statistics_api.Src.Core.Models;

public abstract class CustomersRepository
{
    protected abstract Task<List<CountryCustomersEntity>> GetCountryCustomers();
}