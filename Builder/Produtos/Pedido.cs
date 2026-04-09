using System.Text;

namespace Builder.Produtos;

public class Pedido
{
    public Dictionary<string, int> Lanches { get; internal set; } = new ();
    public Dictionary<string, int> Bebidas { get; internal set; } = new ();
    public Dictionary<string, int> Acompanhamentos { get; internal set; } = new ();
    public Dictionary<string, int> Sobremesas { get; internal set; } = new ();

    public string Descricao
    {
        get
        {
            var sb = new StringBuilder();
            if (Lanches.Any())
            {
                sb.AppendLine("Lanches: ");
                foreach (var item in Lanches)
                    sb.AppendLine($"{item.Value} - {item.Key}");
                sb.AppendLine("----------------------------------------");
            }
            
            if (Acompanhamentos.Any())
            {
                sb.AppendLine("Acompanhamentos: ");
                foreach (var item in Acompanhamentos)
                    sb.AppendLine($"{item.Value} - {item.Key}");
                sb.AppendLine("----------------------------------------");
            }
            
            if (Bebidas.Any())
            {
                sb.AppendLine("Bebidas: ");
                foreach (var item in Bebidas)
                    sb.AppendLine($"{item.Value} - {item.Key}");
                sb.AppendLine("----------------------------------------");
            }
            
            if (Sobremesas.Any())
            {
                sb.AppendLine("Sobremesas: ");
                foreach (var item in Sobremesas)
                    sb.AppendLine($"{item.Value} - {item.Key}");
                sb.AppendLine("----------------------------------------");
            }
                
            return sb.ToString();
        }
    }
}