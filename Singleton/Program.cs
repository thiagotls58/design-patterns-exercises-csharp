// See https://aka.ms/new-console-template for more information

using System.Threading.Tasks;
using Singleton;

// Teste básico
var a = ConfigurationManagerNivel3.Instance;
var b = ConfigurationManagerNivel3.Instance;
a.Set("Env", "Production");

Console.WriteLine(b.Get("Env"));   // Production
Console.WriteLine(a == b);         // True

// Teste multi-thread (para Níveis 2 e 3)
ConfigurationManagerNivel3[] instances = new ConfigurationManagerNivel3[10];

Parallel.For(0, 10, i =>
{
    instances[i] = ConfigurationManagerNivel3.Instance;
});

bool allSame = System.Array.TrueForAll(instances, inst => inst == instances[0]);
System.Console.WriteLine($"Todas as instâncias são iguais: {allSame}"); // True

Console.WriteLine("=== Configurações ===");
foreach (var cfg in a.GetAll())
    Console.WriteLine($"Key: {cfg.Key} - value: {cfg.Value}");

Console.ReadLine();