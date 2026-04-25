namespace Adapter.Services;

public class LegacyPixService
{
    public void SendPix(string pixKey, float amount) =>
        Console.WriteLine($"Pix enviado para a chave '{pixKey}': R$ {amount:F2}");
}
