namespace Singleton;

public class ConfigurationManagerNivel2
{
    private static ConfigurationManagerNivel2? _instance;
    private static readonly object _lockObj = new();
    private Dictionary<string, string> _configs;

    private ConfigurationManagerNivel2()
    {
        _configs = new Dictionary<string, string>();
    }

    public static ConfigurationManagerNivel2 Instance
    {
        get
        {
            if (_instance is null)
                lock (_lockObj)
                    if  (_instance is null)
                        _instance = new ConfigurationManagerNivel2();
            
            return _instance;
        }
    }

    public void Set(string key, string value) => _configs[key] = value;
    public string? Get(string key) => _configs.GetValueOrDefault(key);
    public bool Hass(string key) => _configs.ContainsKey(key);
    public IReadOnlyDictionary<string, string> GetAll() => _configs;
}