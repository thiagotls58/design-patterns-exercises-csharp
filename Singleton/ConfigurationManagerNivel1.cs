namespace Singleton;

public class ConfigurationManagerNivel1
{
    private static ConfigurationManagerNivel1? _instance;
    private readonly Dictionary<string, string> _configs;

    private ConfigurationManagerNivel1()
    {
        _configs = new Dictionary<string, string>();
    }

    public static ConfigurationManagerNivel1 Instance
    {
        get
        {
            if (_instance is null)
                _instance = new ConfigurationManagerNivel1();
            
            return _instance;
        }
    }

    public void Set(string key, string value) => _configs[key] = value;
    public string? Get(string key) => _configs.GetValueOrDefault(key);
    public bool Hass(string key) => _configs.ContainsKey(key);
    public IReadOnlyDictionary<string, string> GetAll() => _configs;
}