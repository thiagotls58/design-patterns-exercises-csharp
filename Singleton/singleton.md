# Exercício: Design Pattern Singleton em C#

## Contexto

Você foi contratado para desenvolver um sistema de **gerenciamento de configurações** para uma aplicação empresarial. O sistema precisa garantir que exista **apenas uma instância** do gerenciador de configurações durante toda a execução da aplicação, evitando inconsistências causadas por múltiplas instâncias com estados diferentes.

---

## Objetivo

Implementar a classe `ConfigurationManager` utilizando o design pattern **Singleton**, garantindo:

- Uma única instância da classe em toda a aplicação
- Acesso global a essa instância
- Segurança em ambientes **multi-thread** (thread-safe)

---

## Requisitos Funcionais

A classe `ConfigurationManager` deve:

1. Armazenar configurações como pares **chave-valor** (`string` → `string`)
2. Expor os seguintes métodos públicos:
   - `void Set(string key, string value)` — adiciona ou atualiza uma configuração
   - `string Get(string key)` — retorna o valor de uma configuração (ou `null` se não existir)
   - `bool Has(string key)` — verifica se uma chave existe
   - `void PrintAll()` — exibe todas as configurações no console
3. Expor uma propriedade estática `Instance` que retorna a única instância da classe

---

## Estrutura Esperada

```csharp
// Uso esperado no Program.cs
var config1 = ConfigurationManager.Instance;
var config2 = ConfigurationManager.Instance;

config1.Set("AppName", "MeuSistema");
config1.Set("Version", "1.0.0");
config1.Set("Theme", "Dark");

Console.WriteLine(config2.Get("AppName")); // MeuSistema
Console.WriteLine(config1 == config2);     // True

config2.PrintAll();
```

---

## Saída Esperada

```
MeuSistema
True

=== Configurações ===
AppName     → MeuSistema
Version     → 1.0.0
Theme       → Dark
```

---

## Desafios

Implemente o Singleton nas três abordagens abaixo, do mais simples ao mais robusto:

### 🥉 Nível 1 — Básico (Single-thread)

Implemente o Singleton clássico, **sem se preocupar** com concorrência.

> **Dica:** Use um campo estático privado e verifique se ele é `null` antes de criar a instância.

---

### 🥈 Nível 2 — Thread-Safe com Lock

Torne a implementação segura para uso em múltiplas threads utilizando `lock`.

> **Dica:** Use o padrão **double-checked locking** para evitar o overhead do `lock` após a instância já ter sido criada.

```csharp
private static readonly object _lockObj = new object();
```

---

### 🥇 Nível 3 — Thread-Safe com Lazy\<T\>

Refatore a solução utilizando `Lazy<T>` do .NET, a forma mais moderna e idiomática de implementar Singleton em C#.

```csharp
private static readonly Lazy<ConfigurationManager> _lazy = ...
```

---

## Critérios de Avaliação

| Critério                                      | Peso |
|-----------------------------------------------|------|
| Construtor privado implementado               | ✅    |
| Propriedade `Instance` estática e pública     | ✅    |
| Métodos funcionando corretamente              | ✅    |
| Instâncias comparadas retornam `true`         | ✅    |
| Thread-safety (Nível 2 e 3)                   | ✅    |
| Código limpo e legível                        | ✅    |

---

## Teste de Validação

Use o código abaixo para validar sua implementação:

```csharp
using System.Threading.Tasks;

// Teste básico
var a = ConfigurationManager.Instance;
var b = ConfigurationManager.Instance;
a.Set("Env", "Production");

System.Console.WriteLine(b.Get("Env"));   // Production
System.Console.WriteLine(a == b);         // True

// Teste multi-thread (para Níveis 2 e 3)
ConfigurationManager[] instances = new ConfigurationManager[10];

Parallel.For(0, 10, i =>
{
    instances[i] = ConfigurationManager.Instance;
});

bool allSame = System.Array.TrueForAll(instances, inst => inst == instances[0]);
System.Console.WriteLine($"Todas as instâncias são iguais: {allSame}"); // True
```

---

## Referências

- [Microsoft Docs — Lazy\<T\>](https://learn.microsoft.com/pt-br/dotnet/api/system.lazy-1)
- [Refactoring Guru — Singleton Pattern](https://refactoring.guru/pt-br/design-patterns/singleton)
- [Microsoft Docs — lock statement](https://learn.microsoft.com/pt-br/dotnet/csharp/language-reference/statements/lock)
