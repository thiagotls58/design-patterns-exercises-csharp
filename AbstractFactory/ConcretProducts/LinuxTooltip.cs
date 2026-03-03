using AbstractFactory.ProductsInterfaces;

namespace AbstractFactory.ConcretProducts;

public class LinuxTooltip : ITooltip
{
    public void Show() => Console.WriteLine("[Linux] Exibindo tooltip com estilo Linux");
}