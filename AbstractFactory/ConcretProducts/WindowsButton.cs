using AbstractFactory.ProductsInterfaces;

namespace AbstractFactory.ConcretProducts;

public class WindowsButton : IButton
{
    public void Render() => Console.WriteLine("[Windows] Renderizando botão com estilo Windows");
}