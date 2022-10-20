namespace dynamic_appsettings.Model;

public class ConfigurationModel
{
    public int Id { get; set; }
    public string AppKey { get; set; } = null!;
    public string AppValue { get; set; } = null!;
}