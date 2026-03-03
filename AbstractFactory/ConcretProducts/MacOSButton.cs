using AbstractFactory.ProductsInterfaces;

namespace AbstractFactory.ConcretProducts;

public class MacOSButton : IButton
{
    public void Render() => Console.WriteLine("[macOS] Renderizando botão com estilo macOS");
}