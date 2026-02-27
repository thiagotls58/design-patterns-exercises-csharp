// See https://aka.ms/new-console-template for more information

using FactoryMethod.Enums;
using FactoryMethod.Processors;

string choice = Menu();

while (choice.ToUpper() != "0")
{
    if (Enum.TryParse(choice, out EPaymentType paymentType) && Enum.IsDefined(typeof(EPaymentType), paymentType))
    {
        Console.Write("Digite o valor do pagamento: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            Console.WriteLine("\nIniciando processamento...");

            var paymentProcessor = new ConcretPaymentProcessor();
            var paymentMethod = paymentProcessor.CreatePaymentMethod(paymentType);
            paymentMethod.ProcessPayment(amount);
        }
    }
    else
    {
        Console.WriteLine("Opção inválida.");
    }

    Console.ReadLine();

    choice = Menu();
}

Console.WriteLine("Finalizando o sistema...");

Console.ReadLine();

string Menu()
{
    Console.Clear();
    Console.WriteLine("=== Sistema de Pagamentos TechPay ===");
    Console.WriteLine($"[{(int)EPaymentType.CreditCard}] - Cartão de Crédito");
    Console.WriteLine($"[{(int)EPaymentType.DebitCard}] - Cartão de Débito");
    Console.WriteLine($"[{(int)EPaymentType.Boleto}] - Boleto");
    Console.WriteLine($"[0] - Sair");
    Console.WriteLine("Selecione o método desejado: ");
    
    return Console.ReadLine() ?? "";
}