using FactoryMethod.Interfaces;

namespace FactoryMethod.Products;

public class DebitCardPayment : IPaymentMethod
{
    public void ProcessPayment(decimal amount) => Console.WriteLine($"Debit Card paid! Amount: {amount:C}");
}