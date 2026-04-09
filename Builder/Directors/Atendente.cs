using Builder.Interfaces;
using Builder.Produtos;

namespace Builder.Directors;

public class Atendente
{
    private const int INDIVIDUAL = 1;
    private const int DUPLO = 2;
    
    public void MontarComboIndividualClassico(IPedidoBuilder builder) // lanche + bebida + acompanhamento
    {
        builder.AdicionarLanche("X-Burguer", INDIVIDUAL);
        builder.AdicionarBebida("Coca-Cola", INDIVIDUAL);
        builder.AdicionarAcompanhamento("Batata Frita", INDIVIDUAL);
    }

    public void MontarComboIndividualSobremesa(IPedidoBuilder builder) // lanche + acompanhamento + bebida + sobremesa
    {
        builder.AdicionarLanche("X-Burguer", INDIVIDUAL);
        builder.AdicionarBebida("Coca-Cola", INDIVIDUAL);
        builder.AdicionarAcompanhamento("Batata Frita", INDIVIDUAL);
        builder.AdicionarSobremesa("Sorvete", INDIVIDUAL);
    }
    
    public void MontarComboDuploClassico(IPedidoBuilder builder) // lanche + bebida + acompanhamento
    {
        builder.AdicionarLanche("X-Burguer", DUPLO);
        builder.AdicionarBebida("Coca-Cola", DUPLO);
        builder.AdicionarAcompanhamento("Batata Frita", DUPLO);
    }

    public void MontarComboDuploSobremesa(IPedidoBuilder builder) // lanche + acompanhamento + bebida + sobremesa
    {
        builder.AdicionarLanche("X-Burguer", DUPLO);
        builder.AdicionarBebida("Coca-Cola", DUPLO);
        builder.AdicionarAcompanhamento("Batata Frita", DUPLO);
        builder.AdicionarSobremesa("Sorvete", DUPLO);
    }
}