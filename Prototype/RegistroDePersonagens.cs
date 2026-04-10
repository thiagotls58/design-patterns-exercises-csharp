namespace Prototype;

public class RegistroDePersonagens
{
    private Dictionary<string, IPersonagem> _personagens = new ();

    public void RegistrarPersonagem(string chave, IPersonagem personagem) => _personagens.Add(chave, personagem);

    public IPersonagem? ClonarPersonagem(string chave)
    {
        if (_personagens.TryGetValue(chave, out IPersonagem? personagem))
        {
            var clone = personagem.Clonar();
            return clone;
        }
        return null;
    }
}