using System.Text;

namespace Prototype;

public class Personagem : IPersonagem
{
    public Personagem(string nome, 
        string classe, 
        int nivel,
        int vida)
    {
        Nome = nome;
        Classe = classe;
        Nivel = nivel;
        Vida = vida;
    }

    public string Nome { get; private set; }
    public string Classe { get; private set; }
    public int Nivel { get; private set; }
    public int Vida { get; private set; }
    public List<Habilidade> Habilidades { get; private set; } = new();
    
    public IPersonagem Clonar()
    {
        var clone = new  Personagem(Nome, Classe, Nivel, Vida);
        clone.Habilidades = Habilidades.Select(h => new Habilidade(h.Nome, h.Dano)).ToList();
        return clone;
    }

    public void Exibir()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"=== Personagem: {Nome} ===");
        sb.AppendLine($"Classe: {Classe}");
        sb.AppendLine($"Nível: {Nivel}");
        sb.AppendLine($"Vida: {Vida}");
        sb.AppendLine($"Habilidades: ");
        foreach (var habilidade in Habilidades)
            sb.AppendLine($"    - {habilidade.ToString()}");
        
        Console.WriteLine(sb.ToString());
    }
}