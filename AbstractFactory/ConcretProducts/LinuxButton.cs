using AbstractFactory.ProductsInterfaces;

namespace AbstractFactory.ConcretProducts;

public class LinuxButton : IButton
{
    public void Render() => Console.WriteLine("[Linux] Renderizando botão com estilo Linux");
}