// See https://aka.ms/new-console-template for more information

using AbstractFactory;
using AbstractFactory.Enums;

var choice = Menu();

while (choice.ToUpper() != "0")
{
    if (Enum.TryParse(choice, out EOperatingSystem operatingSystem) && Enum.IsDefined(typeof(EOperatingSystem), operatingSystem))
    {
        var app = new Application(operatingSystem);
        app.RenderUI();
    }
    else
    {
        Console.WriteLine("Opção inválida.");
    }

    Console.ReadLine();

    choice = Menu();
}

Console.WriteLine("Finalizando o sistema...");

Console.ReadLine();

string Menu()
{
    Console.Clear();
    Console.WriteLine("=== Framework UI ===");
    Console.WriteLine($"[{(int)EOperatingSystem.Windows}] - Windows");
    Console.WriteLine($"[{(int)EOperatingSystem.MacOS}] - Mac OS");
    Console.WriteLine($"[{(int)EOperatingSystem.Linux}] - Linux");
    Console.WriteLine("[0] - Sair");
    Console.WriteLine("Selecione o sistema operacional: ");
    
    return Console.ReadLine() ?? "";
}