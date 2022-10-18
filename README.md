
# Dynamicly Edit AppSettings From Database Realtime

Since the constants in appsettings take up a lot of space in the service layer over time, it is aimed to provide a more organized development environment by keeping these constants in a table on the database.


## Kullanım/Örnekler
#### Services Layer
```c#
private readonly ConfigurationRepository _configurationRepository;
private readonly Dictionary<string, object> _appSettings;

 public ConfigurationService(ConfigurationRepository configurationRepository)
    {
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
```



  
## Ekran Görüntüleri

![Uygulama Ekran Görüntüsü](https://user-images.githubusercontent.com/32902525/196387573-f0ca38e8-8d41-4f2a-b0c4-b2634969ae6b.png)

#### You can change AppSettings value from database

  #### MainController
```c#
private readonly ConfigurationService _configurationService;

public Main(IConfiguration configuration, ConfigurationService configurationService)
{
    _configurationService = configurationService;

    // This is the property that I want to change dynamically 
    //from Database Example : Propert100
    
    configurationService.GetValue<string>("Property100", ref _property100);
}
```
