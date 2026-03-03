using AbstractFactory.AbstractsFactories;
using AbstractFactory.ConcretFactories;
using AbstractFactory.Enums;
using AbstractFactory.ProductsInterfaces;

namespace AbstractFactory;

public class Application
{
    private IUIFactory _uiFactory;
    private IButton? _button;
    private ICheckbox? _checkbox;
    private ITooltip? _tooltip;

    public Application(EOperatingSystem operatingSystem)
    {
        _uiFactory = OperatingSystems[operatingSystem]();
        
        BuildUI();
    }

    public static readonly Dictionary<EOperatingSystem, Func<IUIFactory>> OperatingSystems = new Dictionary<EOperatingSystem, Func<IUIFactory>>
    {
        { EOperatingSystem.Windows, () => new WindowsFactory() },
        { EOperatingSystem.MacOS, () => new MacOSFactory() },
        { EOperatingSystem.Linux, () => new LinuxFactory() },
    };

    private void BuildUI()
    {
        _button = _uiFactory.CreateButton();
        _checkbox = _uiFactory.CreateCheckbox();
        _tooltip = _uiFactory.CreateTooltip();
    }

    public void RenderUI()
    {
        _button?.Render();
        _checkbox?.Toggle();
        _tooltip?.Show();
    }
}