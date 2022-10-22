using dynamic_appsettings.Repository;
using dynamic_appsettings.Repository.Interface;

namespace dynamic_appsettings.Services;

public class ConfigurationService : IConfigurationService
{
    private Dictionary<string, object> _appSettings;
    public ConfigurationService(ConfigurationRepository configurationRepository)
    {
        _appSettings = configurationRepository.ConfigurationList().Result;
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
    public Dictionary<string, object> GetAllData() => _appSettings;
    public void ReloadData()
    {
        ConfigurationRepository configurationRepository = new ConfigurationRepository();
        var res = configurationRepository.ConfigurationList().Result;
        _appSettings = res;
    }
}