using FactoryMethod.Interfaces;

namespace FactoryMethod.Products;

public class BoletoPayment : IPaymentMethod
{
    public void ProcessPayment(decimal amount) => Console.WriteLine($"Boleto paid! Amount: {amount:C}");
}