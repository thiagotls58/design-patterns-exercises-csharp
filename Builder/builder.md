# Exercício: Design Pattern Builder em C#

## Contexto

Você foi contratado para desenvolver o sistema de pedidos de uma **lanchonete**. Cada pedido pode ter uma composição variada: lanche, bebida, sobremesa e acompanhamento — mas nenhum desses itens é obrigatório.

O problema é que o construtor da classe `Pedido` está ficando cada vez mais complexo à medida que novos itens são adicionados ao cardápio. Seu objetivo é aplicar o **padrão Builder** para tornar a criação de pedidos flexível, legível e fácil de manter.

---

## Estrutura esperada

### Classe `Pedido`

Representa um pedido finalizado. Deve conter:

| Propriedade     | Tipo      | Descrição                        |
|-----------------|-----------|----------------------------------|
| `Lanche`        | `string?` | Nome do lanche escolhido         |
| `Bebida`        | `string?` | Nome da bebida escolhida         |
| `Sobremesa`     | `string?` | Nome da sobremesa escolhida      |
| `Acompanhamento`| `string?` | Nome do acompanhamento escolhido |
| `Descricao`     | `string`  | Resumo legível do pedido         |

> A propriedade `Descricao` deve listar apenas os itens que foram adicionados.

---

### Interface `IPedidoBuilder`

Define o contrato do builder. Deve expor métodos para:

- Adicionar lanche
- Adicionar bebida
- Adicionar sobremesa
- Adicionar acompanhamento
- Construir e retornar o `Pedido`

> Cada método (exceto `Build`) deve retornar o próprio builder para permitir **encadeamento de chamadas** (fluent interface).

---

### Classe `PedidoBuilder`

Implementa `IPedidoBuilder` e é responsável por montar o pedido passo a passo.

---

### Classe `Atendente` *(Director)*

Conhece as combinações de pedido mais comuns da lanchonete e usa o builder para montá-las. Deve conter pelo menos dois métodos:

- `MontarComboClassico(IPedidoBuilder builder)` — lanche + bebida + acompanhamento
- `MontarComboSobremesa(IPedidoBuilder builder)` — lanche + sobremesa + bebida

---

## Tarefa

Implemente as classes acima e valide com o seguinte código cliente em `Program.cs`:

```csharp
// Uso direto do builder (fluent)
var builder = new PedidoBuilder();

var pedidoPersonalizado = builder
    .AdicionarLanche("X-Burguer")
    .AdicionarBebida("Suco de Laranja")
    .AdicionarSobremesa("Petit Gateau")
    .Build();

Console.WriteLine("=== Pedido Personalizado ===");
Console.WriteLine(pedidoPersonalizado.Descricao);

// Uso via Director
Console.WriteLine("\n=== Combo Clássico ===");
var builderCombo = new PedidoBuilder();
var atendente = new Atendente();
atendente.MontarComboClassico(builderCombo);
var comboClassico = builderCombo.Build();
Console.WriteLine(comboClassico.Descricao);

Console.WriteLine("\n=== Combo Sobremesa ===");
var builderSobremesa = new PedidoBuilder();
atendente.MontarComboSobremesa(builderSobremesa);
var comboSobremesa = builderSobremesa.Build();
Console.WriteLine(comboSobremesa.Descricao);
```

### Saída esperada

```
=== Pedido Personalizado ===
Pedido: Lanche=X-Burguer | Bebida=Suco de Laranja | Sobremesa=Petit Gateau

=== Combo Clássico ===
Pedido: Lanche=X-Salada | Bebida=Refrigerante | Acompanhamento=Batata Frita

=== Combo Sobremesa ===
Pedido: Lanche=X-Burguer | Bebida=Milk Shake | Sobremesa=Brownie
```

---

## Dicas

- A classe `Pedido` **não deve ter** um construtor público com parâmetros — ela deve ser montada exclusivamente pelo builder.
- Lembre-se de **resetar o estado interno** do builder após o `Build()`, para que ele possa ser reutilizado.
- A propriedade `Descricao` pode ser gerada com `string.Join` filtrando os itens nulos.

---

## Critérios de avaliação

- [ ] A interface `IPedidoBuilder` está definida corretamente com fluent interface
- [ ] O `PedidoBuilder` implementa todos os métodos da interface
- [ ] A classe `Atendente` utiliza o builder sem conhecer detalhes da construção
- [ ] O builder é resetado após `Build()`
- [ ] A saída no console corresponde ao esperado
- [ ] O código compila sem erros e sem warnings

---

## Solução de referência

<details>
<summary>⚠️ Tente resolver antes de abrir!</summary>

```csharp
// Pedido.cs
public class Pedido
{
    public string? Lanche { get; internal set; }
    public string? Bebida { get; internal set; }
    public string? Sobremesa { get; internal set; }
    public string? Acompanhamento { get; internal set; }

    public string Descricao
    {
        get
        {
            var itens = new List<string>();
            if (Lanche != null)         itens.Add($"Lanche={Lanche}");
            if (Bebida != null)         itens.Add($"Bebida={Bebida}");
            if (Sobremesa != null)      itens.Add($"Sobremesa={Sobremesa}");
            if (Acompanhamento != null) itens.Add($"Acompanhamento={Acompanhamento}");
            return "Pedido: " + string.Join(" | ", itens);
        }
    }
}

// IPedidoBuilder.cs
public interface IPedidoBuilder
{
    IPedidoBuilder AdicionarLanche(string lanche);
    IPedidoBuilder AdicionarBebida(string bebida);
    IPedidoBuilder AdicionarSobremesa(string sobremesa);
    IPedidoBuilder AdicionarAcompanhamento(string acompanhamento);
    Pedido Build();
}

// PedidoBuilder.cs
public class PedidoBuilder : IPedidoBuilder
{
    private Pedido _pedido = new Pedido();

    public IPedidoBuilder AdicionarLanche(string lanche)
    {
        _pedido.Lanche = lanche;
        return this;
    }

    public IPedidoBuilder AdicionarBebida(string bebida)
    {
        _pedido.Bebida = bebida;
        return this;
    }

    public IPedidoBuilder AdicionarSobremesa(string sobremesa)
    {
        _pedido.Sobremesa = sobremesa;
        return this;
    }

    public IPedidoBuilder AdicionarAcompanhamento(string acompanhamento)
    {
        _pedido.Acompanhamento = acompanhamento;
        return this;
    }

    public Pedido Build()
    {
        var pedidoPronto = _pedido;
        _pedido = new Pedido(); // reset
        return pedidoPronto;
    }
}

// Atendente.cs
public class Atendente
{
    public void MontarComboClassico(IPedidoBuilder builder)
    {
        builder
            .AdicionarLanche("X-Salada")
            .AdicionarBebida("Refrigerante")
            .AdicionarAcompanhamento("Batata Frita");
    }

    public void MontarComboSobremesa(IPedidoBuilder builder)
    {
        builder
            .AdicionarLanche("X-Burguer")
            .AdicionarBebida("Milk Shake")
            .AdicionarSobremesa("Brownie");
    }
}
```

</details>
