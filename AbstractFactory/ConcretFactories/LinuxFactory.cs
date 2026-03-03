using AbstractFactory.AbstractsFactories;
using AbstractFactory.ConcretProducts;
using AbstractFactory.ProductsInterfaces;

namespace AbstractFactory.ConcretFactories;

public class LinuxFactory : IUIFactory
{
    public IButton CreateButton() => new LinuxButton();

    public ICheckbox CreateCheckbox() => new LinuxCheckbox();

    public ITooltip CreateTooltip() => new LinuxTooltip();
}