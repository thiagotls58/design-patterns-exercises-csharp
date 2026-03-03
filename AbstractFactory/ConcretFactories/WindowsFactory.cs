using AbstractFactory.AbstractsFactories;
using AbstractFactory.ConcretProducts;
using AbstractFactory.ProductsInterfaces;

namespace AbstractFactory.ConcretFactories;

public class WindowsFactory : IUIFactory
{
    public IButton CreateButton() => new WindowsButton();

    public ICheckbox CreateCheckbox() => new WindowsCheckbox();
    
    public ITooltip CreateTooltip() => new  WindowsTooltip();
}