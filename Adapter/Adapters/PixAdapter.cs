using Adapter.Interfaces;
using Adapter.Services;

namespace Adapter.Adapters;

public class PixAdapter : IPaymentGateway
{
    private readonly LegacyPixService _legacyPixService;
    private readonly string _pixKey;

    public PixAdapter(LegacyPixService legacyPixService, string pixKey)
    {
        _legacyPixService = legacyPixService;
        _pixKey = pixKey;
    }

    public void Pay(decimal amount) =>
        _legacyPixService.SendPix(_pixKey, (float)amount);
}
