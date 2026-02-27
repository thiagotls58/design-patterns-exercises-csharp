using FactoryMethod.Enums;
using FactoryMethod.Interfaces;

namespace FactoryMethod.Processors;

public abstract class AbstractPaymentProcessor
{
    public abstract IPaymentMethod CreatePaymentMethod(EPaymentType  paymentType);
}