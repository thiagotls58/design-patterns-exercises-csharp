using AbstractFactory.ProductsInterfaces;

namespace AbstractFactory.ConcretProducts;

public class MacOSTooltip : ITooltip
{
    public void Show() => Console.WriteLine("[macOS] Exibindo tooltip com estilo macOS");
}