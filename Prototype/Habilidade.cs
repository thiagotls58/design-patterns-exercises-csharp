namespace Prototype;

public class Habilidade
{
    public Habilidade(string nome, int dano)
    {
        Nome = nome;
        Dano = dano;
    }

    public string Nome { get; private set; }
    public int Dano { get; private set; }
    
    public override string ToString()
    {
        return $"{Nome} (Dano: {Dano})";
    }
}