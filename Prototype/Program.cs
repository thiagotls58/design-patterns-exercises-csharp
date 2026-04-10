// See https://aka.ms/new-console-template for more information

using Prototype;

var registroPersonagens = new RegistroDePersonagens();

var aragorn = new Personagem("Aragorn", "Guerreiro", 1, 100);
aragorn.Habilidades.Add(new Habilidade("Golpe Pesado", 80));
aragorn.Habilidades.Add(new Habilidade("Escudo de Ferro", 0));
aragorn.Exibir();

registroPersonagens.RegistrarPersonagem("aragorn", aragorn);

var cloneAragorn = registroPersonagens.ClonarPersonagem("aragorn");
if (cloneAragorn != null)
    cloneAragorn.Exibir();
else
    Console.WriteLine("Registro não encontrado");