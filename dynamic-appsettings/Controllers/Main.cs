using dynamic_appsettings.Services;
using Microsoft.AspNetCore.Mvc;

namespace dynamic_appsettings.Controllers;

[ApiController]
[Route("[controller]")]
public class Main : ControllerBase
{
    private readonly ConfigurationService _configurationService;

    private readonly string _property100;

    public Main(ConfigurationService configurationService)
    {
        _configurationService = configurationService;

        // This is the one property that I want to change dynamically from Database
        _configurationService.GetValue("Property100", ref _property100!);
    }

    [HttpGet]
    [Route("GetStaticVariable")]
    public IActionResult GetStaticVariable()
    {
        return Ok(_property100);
    }

    [HttpGet]
    [Route("GetDynamicVariable")]
    public IActionResult GetDynamicVariable(string key)
    {
        if (!String.IsNullOrEmpty(_configurationService.GetValue(key)))
        {
            var value = _configurationService.GetValue(key);
            return Ok(new { AppKey = key, AppValue = value });
        }
        else
        {
            return NotFound();
        }
    }
}