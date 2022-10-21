using dynamic_appsettings.Services;
using Microsoft.AspNetCore.Mvc;

namespace dynamic_appsettings.Controllers;

[ApiController]
[Route("[controller]")]
public class Main : ControllerBase
{
    private readonly ConfigurationService _configurationService;

    public Main(ConfigurationService configurationService)
    {
        _configurationService = configurationService;
    }

    [HttpGet]
    [Route("GetStaticVariable")]
    public IActionResult GetAllData()
    {
        return Ok(_configurationService.GetAllData());
    }
    
    [HttpGet]
    [Route("ReloadData")]
    public IActionResult ReloadData()
    {
        _configurationService.Reload();
        return Ok(_configurationService.GetAllData());
    }
}