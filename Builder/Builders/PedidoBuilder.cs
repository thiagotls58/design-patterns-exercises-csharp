using Builder.Interfaces;
using Builder.Produtos;

namespace Builder.Builders;

public class PedidoBuilder : IPedidoBuilder
{
    private Pedido _pedido = new();


    public IPedidoBuilder AdicionarLanche(string lanche, int quantidade)
    {
        _pedido.Lanches.Add(lanche, quantidade);
        return this;
    }

    public IPedidoBuilder AdicionarBebida(string bebida, int quantidade)
    {
        _pedido.Bebidas.Add(bebida,  quantidade);
        return this;
    }

    public IPedidoBuilder AdicionarAcompanhamento(string acompanhamento, int quantidade)
    {
        _pedido.Acompanhamentos.Add(acompanhamento,  quantidade);
        return this;
    }

    public IPedidoBuilder AdicionarSobremesa(string sobremesa, int quantidade)
    {
        _pedido.Sobremesas.Add(sobremesa,  quantidade);
        return this;
    }

    public Pedido Build()
    {
        var pedidoPronto = _pedido;
        _pedido = new Pedido();

        return pedidoPronto;
    }
}