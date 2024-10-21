using Microsoft.AspNetCore.Mvc;
using statistics_api.Src.Core.Models;

namespace statistics_api.Src.Features.Customers.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly CustomersRepository _customersRepository;


    public CustomersController(CustomersRepository customersRepository)
    {
        _customersRepository = customersRepository;
    }

    [HttpGet("customers-in-country")]
    public async Task<IActionResult> GetCustomersInCountry()
    {
        return Ok(await _customersRepository.GetCountryCustomers());
    }
}