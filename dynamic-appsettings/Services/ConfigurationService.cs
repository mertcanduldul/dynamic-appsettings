using dynamic_appsettings.Model;
using dynamic_appsettings.Repository;

namespace dynamic_appsettings.Services;

public class ConfigurationService
{
    private readonly ILogger<ConfigurationService> _logger;
    private readonly ConfigurationRepository _configurationRepository;
    private readonly Dictionary<string, object> _appSettings;

    public ConfigurationService(ILogger<ConfigurationService> logger, ConfigurationRepository configurationRepository)
    {
        _logger = logger;
        _configurationRepository = configurationRepository;
        _appSettings = _configurationRepository.ConfigurationList().Result;
    }

    public bool GetValue<T>(string key, ref T value)
    {
        if (_appSettings.TryGetValue(key, out var result))
        {
            value = (T)result;
            return true;
        }
        else
        {
            return false;
        }
    }
}