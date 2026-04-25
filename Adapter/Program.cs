using Adapter.Adapters;
using Adapter.Enums;
using Adapter.Interfaces;
using Adapter.Services;

// ─── Lógica cliente — depende apenas de IPaymentGateway ──────────────────────
Console.WriteLine("=== Loja Express — Sistema de Pagamentos ===\n");

Console.WriteLine("Escolha a forma de pagamento:");
Console.WriteLine($"{(int)EPaymentType.Card} - Cartão (serviço legado)");
Console.WriteLine($"{(int)EPaymentType.Pix} - Pix    (serviço legado)");
Console.WriteLine($"{(int)EPaymentType.Boleto} - Boleto (serviço legado)");
Console.WriteLine("Opção: ");

string? choice = Console.ReadLine();
bool success = Enum.TryParse(choice, out EPaymentType paymentType);

if (!success)
{
    Console.WriteLine("Opção de pagamento inválida!");
    return;
}

// ─── Configuração dos adapters ────────────────────────────────────────────────
IPaymentGateway? gateway = null;

switch (paymentType)
{
    case EPaymentType.Card:
        gateway = new PaymentAdapter(new LegacyPaymentService()); ;
        break;
    case EPaymentType.Pix:
        Console.WriteLine("Informe a chave PIX: ");
        string? key = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(key))
        {
            Console.WriteLine("Chave PIX inválida!");
            return;
        }
        gateway = new PixAdapter(new LegacyPixService(), key);
        break;
    case EPaymentType.Boleto:
        Console.WriteLine("Informe a data de vencimento (dias): ");
        success = int.TryParse(Console.ReadLine(), out int dueDays);
        if (!success)
        {
            Console.WriteLine("Data de vencimento inválida!");
            return;
        }
        gateway = new BoletoAdapter(new LegacyBoletoService(), dueDays);
        break;
    default:
        throw new ArgumentException("Opção de pagamento inválida!");
}

Console.WriteLine("Informe o valor: ");
success = decimal.TryParse(Console.ReadLine(), out decimal amount);

if (!success)
{
    Console.WriteLine("Valor inválido!");
    return;
}

Console.WriteLine();
ProcessarPagamento(gateway, amount);

// ─── Função cliente pura ─────────────────────────────────────────────────────
static void ProcessarPagamento(IPaymentGateway gateway, decimal valor)
{
    Console.WriteLine($"Processando pagamento de R$ {valor:F2}...");
    gateway.Pay(valor);
    Console.WriteLine("Pagamento concluído!");
}