namespace FactoryMethod.Interfaces;

public interface IPaymentMethod
{
    void ProcessPayment(decimal amount);
}