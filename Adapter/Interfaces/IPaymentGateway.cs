namespace Adapter.Interfaces;

public interface IPaymentGateway
{
    void Pay(decimal amount);
}