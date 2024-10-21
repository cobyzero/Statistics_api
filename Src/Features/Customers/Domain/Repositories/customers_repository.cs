using statistics_api.Src.Core.Models;

public abstract class CustomersRepository
{
    public abstract Task<List<CountryCustomersEntity>> GetCountryCustomers();
    public abstract Task<List<CustomersTopOrdersEntity>> GetCustomersTopInOrders();
}