using AbstractFactory.AbstractsFactories;
using AbstractFactory.ConcretProducts;
using AbstractFactory.ProductsInterfaces;

namespace AbstractFactory.ConcretFactories;

public class MacOSFactory : IUIFactory
{
    public IButton CreateButton() => new MacOSButton();

    public ICheckbox CreateCheckbox() => new MacOSCheckbox();
    
    public ITooltip CreateTooltip() =>  new MacOSTooltip();
}