using Adapter.Interfaces;
using Adapter.Services;

namespace Adapter.Adapters;

public class BoletoAdapter : IPaymentGateway
{
    private readonly LegacyBoletoService _legacyBoletoService;
    private readonly int _dueDays;

    public BoletoAdapter(LegacyBoletoService legacyBoletoService, int dueDays)
    {
        _legacyBoletoService = legacyBoletoService;
        _dueDays = dueDays;
    }

    public void Pay(decimal amount)
    {
        var barCode = _legacyBoletoService.GenerateBoleto((double)amount, _dueDays);
        _legacyBoletoService.PrintBoleto(barCode);
    }
}