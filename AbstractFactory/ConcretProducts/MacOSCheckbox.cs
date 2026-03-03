using AbstractFactory.ProductsInterfaces;

namespace AbstractFactory.ConcretProducts;

public class MacOSCheckbox : ICheckbox
{
    public void Toggle() => Console.WriteLine("[macOS] Alternando checkbox estilo macOS");
}