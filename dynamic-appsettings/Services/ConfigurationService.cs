using dynamic_appsettings.Repository;

namespace dynamic_appsettings.Services;

public class ConfigurationService
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
    public string GetValue(string key)
    {
        if (_appSettings.TryGetValue(key, out var result))
        {
            return result.ToString()!;
        }
        else
        {
            return string.Empty;
        }
    }
    public Dictionary<string,object> GetAllData()
    {
        return _appSettings;
    }
    public void Reload()
    {
        ConfigurationRepository configurationRepository = new();
        var res = configurationRepository.ConfigurationList().Result;
        _appSettings = res;
    }
}