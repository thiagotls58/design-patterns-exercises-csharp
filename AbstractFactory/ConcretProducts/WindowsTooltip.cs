using AbstractFactory.ProductsInterfaces;

namespace AbstractFactory.ConcretProducts;

public class WindowsTooltip : ITooltip
{
    public void Show() => Console.WriteLine("[Windows] Exibindo tooltip com estilo Windows");
}