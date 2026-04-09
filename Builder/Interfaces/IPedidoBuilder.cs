using Builder.Produtos;

namespace Builder.Interfaces;

public interface IPedidoBuilder
{
    IPedidoBuilder AdicionarLanche(string lanche, int quantidade);
    IPedidoBuilder AdicionarBebida(string bebida, int quantidade);
    IPedidoBuilder AdicionarAcompanhamento(string acompanhamento, int quantidade);
    IPedidoBuilder AdicionarSobremesa(string sobremesa, int quantidade);
    Pedido Build();
}