using Microsoft.EntityFrameworkCore;
using statistics_api.Src.Core.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<StatisticsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlserver")));


builder.Services.AddSingleton<CustomersService>(sp => new CustomersService(sp.GetRequiredService<StatisticsContext>()));
builder.Services.AddSingleton<CustomersRepository>(sp => new CustomersIRepository(sp.GetRequiredService<CustomersService>()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();