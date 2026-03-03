using AbstractFactory.ProductsInterfaces;

namespace AbstractFactory.AbstractsFactories;

public interface IUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
    ITooltip CreateTooltip();
}