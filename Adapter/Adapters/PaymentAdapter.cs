using Adapter.Interfaces;
using Adapter.Services;

namespace Adapter.Adapters;

public class PaymentAdapter : IPaymentGateway
{
    private readonly LegacyPaymentService _legacyPaymentService;

    public PaymentAdapter(LegacyPaymentService legacyPaymentService)
    {
        _legacyPaymentService = legacyPaymentService;
    }

    public void Pay(decimal amount) => _legacyPaymentService.MakePayment((double)amount);
}
