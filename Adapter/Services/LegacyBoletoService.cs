namespace Adapter.Services;

public class LegacyBoletoService
{
    public string GenerateBoleto(double value, int dueDays) =>
        $"23790.12345 67890.112345 67890.112345 1 9876{value.ToString("F2").Replace(".", "").Replace(",", "").PadLeft(10, '0')}";

    public void PrintBoleto(string boleto) =>
        Console.WriteLine(boleto);
}