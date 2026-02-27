using FactoryMethod.Enums;
using FactoryMethod.Interfaces;
using FactoryMethod.Products;

namespace FactoryMethod.Processors;

public class ConcretPaymentProcessor : AbstractPaymentProcessor
{
    public override IPaymentMethod CreatePaymentMethod(EPaymentType  paymentType)
    {
        var paymentMethod = PaymentMethods[paymentType];
        return paymentMethod();
    }

    private static readonly Dictionary<EPaymentType, Func<IPaymentMethod>> PaymentMethods = new Dictionary<EPaymentType, Func<IPaymentMethod>>()
    {
        { EPaymentType.CreditCard, () => new CreditCardPayment() },
        { EPaymentType.DebitCard, () => new DebitCardPayment() },
        { EPaymentType.Boleto, () => new BoletoPayment() }
    };
}