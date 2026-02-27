using FactoryMethod.Interfaces;

namespace FactoryMethod.Products;

public class CreditCardPayment : IPaymentMethod
{
    public void ProcessPayment(decimal amount) => Console.WriteLine($"Credit Card paid! Amount: {amount:C}");
}