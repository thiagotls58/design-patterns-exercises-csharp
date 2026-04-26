# Exercício Prático: Bridge com C#

## Objetivo
Implementar o padrão de projeto **Bridge** para separar a abstração de um sistema de notificações da sua implementação concreta, permitindo que ambos evoluam de forma independente.

---

## O Cenário: "NotifyHub"

Você está construindo um sistema de notificações para uma plataforma de e-commerce. O sistema precisa enviar diferentes **tipos de notificação** (simples, urgente, resumo diário) por diferentes **canais** (e-mail, SMS, push notification).

Sem o Bridge, cada combinação exigiria uma classe separada: `EmailUrgente`, `SmsSimples`, `PushResumo`... a quantidade de classes explodiria rapidamente.

O desafio é aplicar o Bridge para desacoplar o **tipo de notificação** (abstração) do **canal de envio** (implementação), permitindo combiná-los livremente.

---

## Requisitos Técnicos

### 1. Implementor (interface de envio)
Crie a interface `INotificationSender` com o método:

* `void Send(string recipient, string message);`

### 2. Concrete Implementors (canais de envio)
Crie as classes que implementam `INotificationSender`:

* `EmailSender`
  * `Send` deve imprimir: `"[EMAIL] Para: {destinatário} | Mensagem: {mensagem}"`
* `SmsSender`
  * `Send` deve imprimir: `"[SMS] Para: {destinatário} | Mensagem: {mensagem}"`

### 3. Abstraction (tipo de notificação)
Crie a classe abstrata `Notification` que:

* Recebe `INotificationSender` por construtor e a armazena em um campo protegido
* Declara o método abstrato: `void Notify(string recipient, string message);`

### 4. Refined Abstractions (tipos concretos de notificação)
Crie as classes que herdam de `Notification`:

* `SimpleNotification`
  * Implementa `Notify` repassando a mensagem diretamente ao sender
* `UrgentNotification`
  * Implementa `Notify` prefixando a mensagem com `"[URGENTE] "` antes de repassar ao sender

### 5. Cliente
No `Program.cs`, demonstre as combinações possíveis:

* `SimpleNotification` com `EmailSender`
* `SimpleNotification` com `SmsSender`
* `UrgentNotification` com `EmailSender`
* `UrgentNotification` com `SmsSender`

---

## Estrutura de Pastas Sugerida
```text
/Bridge
├── Program.cs
├── Senders/
│   ├── INotificationSender.cs
│   ├── EmailSender.cs
│   └── SmsSender.cs
└── Notifications/
    ├── Notification.cs
    ├── SimpleNotification.cs
    └── UrgentNotification.cs
```

---

## Critérios de Aceite

* `Notification` não conhece os detalhes de `EmailSender` ou `SmsSender` — depende apenas de `INotificationSender`
* Novos canais ou novos tipos de notificação podem ser adicionados sem alterar o código existente
* O programa executa sem erros e exibe as 4 combinações no console
* Nenhuma classe de notificação instancia diretamente um sender — o sender é injetado via construtor

---

## Desafio Extra (Opcional)

1. Adicione um terceiro canal: `PushSender`, que imprime `"[PUSH] Para: {destinatário} | Mensagem: {mensagem}"`.
2. Adicione um terceiro tipo de notificação: `DigestNotification`, que acumula múltiplas mensagens internamente e, ao chamar `Notify`, envia um resumo concatenado no formato `"Resumo ({N} itens): msg1 | msg2 | ..."`.
3. Combine as novas classes com os senders existentes no `Program.cs` — sem alterar nenhuma classe já criada.

---

## Desafio 2: Formatação de Conteúdo

### Cenário
O "NotifyHub" agora precisa suportar diferentes **formatos de conteúdo** para as mensagens enviadas. Alguns canais (como e-mail) aceitam HTML, enquanto outros (como SMS) exigem texto puro.

A ideia é estender o Bridge existente adicionando um segundo nível de implementação: o **formatador de conteúdo**.

### Requisitos Técnicos

#### 1. Implementor (interface de formatação)
Crie a interface `IMessageFormatter` com o método:

* `string Format(string title, string body);`

#### 2. Concrete Formatters
Crie as classes que implementam `IMessageFormatter`:

* `PlainTextFormatter`
  * Retorna: `"{título}: {corpo}"`
* `HtmlFormatter`
  * Retorna: `"<b>{título}</b><br>{corpo}"`

#### 3. Atualização dos Senders
Atualize `EmailSender` e `SmsSender` (ou crie versões novas) para receberem um `IMessageFormatter` por construtor e usarem-no ao montar a mensagem antes de exibir no console.

#### 4. Cliente
No `Program.cs`, demonstre combinações como:

* `UrgentNotification` + `EmailSender` com `HtmlFormatter`
* `SimpleNotification` + `SmsSender` com `PlainTextFormatter`

### Estrutura de Pastas Sugerida
```text
/Bridge
├── Program.cs
├── Formatters/                      ← [NOVO]
│   ├── IMessageFormatter.cs
│   ├── PlainTextFormatter.cs
│   └── HtmlFormatter.cs
├── Senders/
│   ├── INotificationSender.cs       ← sem alterações
│   ├── EmailSender.cs               ← atualizado para usar IMessageFormatter
│   └── SmsSender.cs                 ← atualizado para usar IMessageFormatter
└── Notifications/
    ├── Notification.cs              ← sem alterações
    ├── SimpleNotification.cs        ← sem alterações
    └── UrgentNotification.cs        ← sem alterações
```

### Critérios de Aceite

* `IMessageFormatter` é injetado nos senders via construtor
* As classes de `Notifications/` **não precisam de alteração** — a mudança de formatação é transparente para elas
* `PlainTextFormatter` e `HtmlFormatter` produzem saídas distintas e visíveis no console
* O programa executa sem erros com as novas combinações demonstradas
