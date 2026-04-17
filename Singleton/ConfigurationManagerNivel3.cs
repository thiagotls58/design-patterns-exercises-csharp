namespace Singleton;

public class ConfigurationManagerNivel3
{
    private static readonly Lazy<ConfigurationManagerNivel3> _lazyInstance = new(() => new ConfigurationManagerNivel3());
    private readonly Dictionary<string, string> _configs  = new();

    private ConfigurationManagerNivel3() { }

    public static ConfigurationManagerNivel3 Instance => _lazyInstance.Value;

    public void Set(string key, string value) => _configs[key] = value;
    public string? Get(string key) => _configs.GetValueOrDefault(key);
    public bool Hass(string key) => _configs.ContainsKey(key);
    public IReadOnlyDictionary<string, string> GetAll() => _configs;
}