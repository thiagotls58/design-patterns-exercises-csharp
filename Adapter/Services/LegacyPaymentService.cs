namespace Adapter.Services;

public class LegacyPaymentService
{
    public void MakePayment(double value) =>
        Console.WriteLine($"Pagamento legado aprovado: R$ {value:F2}");
}