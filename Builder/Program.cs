// See https://aka.ms/new-console-template for more information

// Uso direto do builder (fluent)

using Builder.Builders;
using Builder.Directors;

var builder = new PedidoBuilder();

Console.WriteLine("=== Pedido Personalizado ===");
var pedidoPersonalizado = builder
    .AdicionarLanche("X-Burguer", 1)
    .AdicionarBebida("Suco de Laranja", 1)
    .AdicionarSobremesa("Petit Gateau", 1)
    .Build();

Console.WriteLine(pedidoPersonalizado.Descricao);

// Uso via Director
var atendente = new Atendente();

Console.WriteLine("\n=== Combo Individual Clássico ===");
var builderComboIndividualClassico = new PedidoBuilder();
atendente.MontarComboIndividualClassico(builderComboIndividualClassico);
var comboIndividualClassico = builderComboIndividualClassico.Build();
Console.WriteLine(comboIndividualClassico.Descricao);

Console.WriteLine("\n=== Combo Individual Sobremesa ===");
var builderComboIndividualSobremesa = new PedidoBuilder();
atendente.MontarComboIndividualSobremesa(builderComboIndividualSobremesa);
var comboIndividualSobremesa = builderComboIndividualSobremesa.Build();
Console.WriteLine(comboIndividualSobremesa.Descricao);

Console.WriteLine("\n=== Combo Duplo Clássico ===");
var builderComboDuploClassico = new PedidoBuilder();
atendente.MontarComboDuploClassico(builderComboDuploClassico);
var comboDuploClassico = builderComboDuploClassico.Build();
Console.WriteLine(comboDuploClassico.Descricao);

Console.WriteLine("\n=== Combo Duplo Sobremesa ===");
var builderComboDuploSobremesa = new PedidoBuilder();
atendente.MontarComboDuploSobremesa(builderComboDuploSobremesa);
var comboDuploSobremesa = builderComboDuploSobremesa.Build();
Console.WriteLine(comboDuploSobremesa.Descricao);

Console.ReadLine();