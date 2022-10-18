using dynamic_appsettings.Services;
using Microsoft.AspNetCore.Mvc;

namespace dynamic_appsettings.Controllers;

[ApiController]
[Route("[controller]")]
public class Main : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ConfigurationService _configurationService;

    private readonly string _property100;

    public Main(IConfiguration configuration, ConfigurationService configurationService)
    {
        _configuration = configuration;
        _configurationService = configurationService;

        // This is the property that I want to change dynamically from Database
        configurationService.GetValue<string>("Property100", ref _property100);
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_property100);
    }
}