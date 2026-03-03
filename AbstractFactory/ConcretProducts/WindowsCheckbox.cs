using AbstractFactory.ProductsInterfaces;

namespace AbstractFactory.ConcretProducts;

public class WindowsCheckbox : ICheckbox
{
    public void Toggle() => Console.WriteLine("[Windows] Alternando checkbox estilo Windows");
}