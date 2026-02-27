# Exercício Prático: Factory Method com .NET 8

## Objetivo
Implementar o padrão de projeto **Factory Method** para criar um sistema de processamento de pagamentos extensível em uma aplicação Console.

---

## O Cenário: "TechPay Pro"
Você está desenvolvendo o núcleo de um gateway de pagamentos. O sistema precisa suportar diferentes métodos (Cartão de Crédito e Boleto) e deve ser fácil adicionar novos métodos (como Pix ou Cripto) sem alterar a lógica de processamento principal.



---

## Requisitos Técnicos

### 1. O Produto (`IPaymentMethod`)
Crie uma interface que defina o contrato para todos os métodos de pagamento.
* **Método:** `void ProcessPayment(double amount);`

### 2. Produtos Concretos
Implemente as classes reais que executam o pagamento:
* `CreditCardPayment`: Deve exibir "Pagando R$ [valor] via Cartão de Crédito - Simulando Transação...".
* `BoletoPayment`: Deve exibir "Gerando Boleto no valor de R$ [valor] - Linha digitável: 12345.6789...".

### 3. O Criador (`PaymentProcessor` - Classe Abstrata)
Esta é a peça central do padrão.
* **Factory Method:** `public abstract IPaymentMethod CreatePaymentMethod();`
* **Lógica de Operação:** Crie um método `void Execute(double amount)` que chama o `CreatePaymentMethod()`, recebe o objeto e invoca o processamento.

### 4. Criadores Concretos
Crie as fábricas específicas:
* `CreditCardProcessor`: Retorna uma instância de `CreditCardPayment`.
* `BoletoProcessor`: Retorna uma instância de `BoletoPayment`.

---

## Estrutura de Pastas Sugerida
```text
/TechPayConsole
├── Program.cs
├── Interfaces/
│   └── IPaymentMethod.cs
├── Products/
│   ├── CreditCardPayment.cs
│   └── BoletoPayment.cs
└── Processors/
    ├── PaymentProcessor.cs
    ├── CreditCardProcessor.cs
    └── BoletoProcessor.cs