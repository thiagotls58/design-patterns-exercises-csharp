# Exercício Prático: Adapter com C#

## Objetivo
Implementar o padrão de projeto **Adapter** para integrar uma API legada de pagamentos em um fluxo moderno da aplicação sem alterar o código cliente.

---

## O Cenário: "Loja Express"
Seu sistema novo trabalha com um contrato padrão para cobranças, mas você precisa aproveitar um serviço legado de terceiros que possui nomes de métodos e parâmetros diferentes.

O desafio é adaptar esse serviço legado para que ele funcione com a interface esperada pelo sistema atual.

---

## Requisitos Técnicos

### 1. Target (interface esperada pelo sistema)
Crie a interface `IPaymentGateway` com o método:

* `void Pay(decimal amount);`

### 2. Adaptee (serviço legado)
Crie a classe `LegacyPaymentService` simulando uma API antiga:

* Método: `void MakePayment(double value);`
* Esse método deve imprimir algo como:
  * `"Pagamento legado aprovado: R$ {valor}"`

### 3. Adapter
Crie a classe `PaymentAdapter` que:

* Implementa `IPaymentGateway`
* Recebe `LegacyPaymentService` por construtor
* No método `Pay(decimal amount)`, converte o valor para `double` e delega para `MakePayment`

### 4. Cliente
No `Program.cs`, o código cliente deve depender apenas de `IPaymentGateway`, sem conhecer `LegacyPaymentService` diretamente.

---

## Estrutura de Pastas Sugerida
```text
/Adapter
├── Program.cs
├── Interfaces/
│   └── IPaymentGateway.cs
├── Legacy/
│   └── LegacyPaymentService.cs
└── Adapters/
    └── PaymentAdapter.cs
```

---

## Critérios de Aceite

* O cliente utiliza apenas `IPaymentGateway`
* O `PaymentAdapter` encapsula a integração com o legado
* O programa executa sem erros
* A saída no console confirma o pagamento via serviço legado

---

## Desafio Extra (Opcional)

1. Adicione uma segunda API legada, por exemplo `LegacyPixService`, com assinatura diferente.
2. Crie outro adapter para ela.
3. Permita alternar entre adapters no `Program.cs` sem mudar a lógica cliente.

---

## Desafio 2: Boleto Bancário

### Cenário
A "Loja Express" precisa agora aceitar pagamentos via **boleto bancário**. Existe um serviço legado de boleto (`LegacyBoletoService`) fornecido por um banco parceiro, mas sua interface é completamente diferente do contrato esperado pelo sistema.

### Requisitos Técnicos

#### 1. Adaptee (serviço legado do banco)
Crie a classe `LegacyBoletoService` dentro de `Services/` simulando a API do banco:

* Método: `string GenerateBoleto(double value, int dueDays);`
  * Deve retornar uma string simulando um código de barras, ex:
    `"23790.12345 67890.112345 67890.112345 1 98760000014990"`
* Método: `void PrintBoleto(string boletoCode);`
  * Deve imprimir algo como:
    `"[BOLETO] Código: {código} | Vencimento: {X} dias | Aguardando pagamento..."`

#### 2. Adapter
Crie a classe `BoletoAdapter` dentro de `Adapters/` que:

* Implementa `IPaymentGateway`
* Recebe `LegacyBoletoService` por construtor
* Recebe também o número de dias para vencimento (`dueDays`) por construtor
* No método `Pay(decimal amount)`:
  1. Converte `amount` para `double`
  2. Chama `GenerateBoleto` para obter o código do boleto
  3. Chama `PrintBoleto` para exibir o boleto ao usuário

#### 3. Cliente
Integre o novo adapter no `Program.cs`:

* Adicione a opção **3 — Boleto** no menu de escolha
* Instancie o `BoletoAdapter` com vencimento de **3 dias**
* A lógica de `ProcessarPagamento` **não deve ser alterada** — ela já depende apenas de `IPaymentGateway`

### Estrutura de Pastas Sugerida
```text
/Adapter
├── Program.cs                  ← adicione a opção 3 aqui
├── Interfaces/
│   └── IPaymentGateway.cs      ← sem alterações
├── Services/
│   ├── LegacyPaymentService.cs ← sem alterações
│   ├── LegacyPixService.cs     ← sem alterações
│   └── LegacyBoletoService.cs  ← [NOVO]
└── Adapters/
    ├── PaymentAdapter.cs       ← sem alterações
    ├── PixAdapter.cs           ← sem alterações
    └── BoletoAdapter.cs        ← [NOVO]
```

### Critérios de Aceite

* `LegacyBoletoService` possui os dois métodos com as assinaturas descritas
* `BoletoAdapter` orquestra `GenerateBoleto` + `PrintBoleto` dentro de `Pay`
* A opção **3** no menu direciona para o `BoletoAdapter`
* `ProcessarPagamento` permanece **inalterada**
* O programa executa sem erros e imprime o código do boleto no console

