using AbstractFactory.ProductsInterfaces;

namespace AbstractFactory.ConcretProducts;

public class LinuxCheckbox : ICheckbox
{
    public void Toggle() => Console.WriteLine("[Linux] Alternando checkbox estilo Linux");
}