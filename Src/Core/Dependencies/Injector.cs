
public static class Injector
{
    public static void Inject(IServiceCollection services)
    {
        services.AddScoped<CustomersService>();
        services.AddScoped<CustomersRepository, CustomersIRepository>();
    }
}
