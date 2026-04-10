# Exercício: Design Pattern Prototype em C#

## 📖 Contexto

O padrão **Prototype** permite criar novos objetos copiando (clonando) instâncias existentes,
sem depender de suas classes concretas. É útil quando a criação de um objeto do zero é cara ou
complexa, e uma cópia levemente modificada é suficiente.

---

## 🎯 Objetivo

Você é desenvolvedor em uma empresa de RPG e precisa implementar um sistema de criação de
personagens. O jogo possui personagens base (templates) que devem ser clonados e customizados
para cada partida, sem recriar tudo do zero a cada vez.

---

## 📋 Requisitos

### 1. Interface `IPersonagem`

Crie uma interface com o método de clonagem:

```csharp
public interface IPersonagem
{
    IPersonagem Clonar();
    void Exibir();
}
```

---

### 2. Classe `Habilidade`

Crie uma classe simples que representa uma habilidade do personagem:

| Propriedade | Tipo     | Descrição              |
|-------------|----------|------------------------|
| `Nome`      | `string` | Nome da habilidade     |
| `Dano`      | `int`    | Dano causado           |

---

### 3. Classe concreta `Personagem`

Implemente a classe `Personagem` que implementa `IPersonagem`:

| Propriedade   | Tipo               | Descrição                        |
|---------------|--------------------|----------------------------------|
| `Nome`        | `string`           | Nome do personagem               |
| `Classe`      | `string`           | Ex: Guerreiro, Mago, Arqueiro    |
| `Nivel`       | `int`              | Nível atual                      |
| `Vida`        | `int`              | Pontos de vida                   |
| `Habilidades` | `List<Habilidade>` | Lista de habilidades             |

**Requisitos da implementação:**
- O método `Clonar()` deve realizar uma **cópia profunda** (*deep copy*), ou seja, a lista de
  `Habilidades` do clone não deve compartilhar a mesma referência com o original.
- O método `Exibir()` deve imprimir no console todas as propriedades e habilidades do personagem.

---

### 4. Classe `RegistroDePersonagens` (Prototype Registry)

Implemente um registro que armazena personagens template e fornece clones sob demanda:

```csharp
public class RegistroDePersonagens
{
    // Armazena os templates por chave (nome da classe)
    private Dictionary<string, IPersonagem> _templates = new();

    public void Registrar(string chave, IPersonagem personagem) { ... }

    public IPersonagem ObterClone(string chave) { ... }
}
```

---

### 5. Programa principal (`Program.cs`)

No `Main`, faça o seguinte:

1. Crie **3 personagens template** (Guerreiro, Mago, Arqueiro) com habilidades distintas.
2. Registre-os no `RegistroDePersonagens`.
3. Clone o **Guerreiro** duas vezes, dando nomes diferentes a cada clone (`"Aragorn"` e `"Boromir"`).
4. Clone o **Mago** uma vez com o nome `"Gandalf"` e adicione uma habilidade extra a ele.
5. Exiba todos os personagens criados e verifique que **alterar o clone não afeta o template**.

---

## ✅ Critérios de Aceite

- [ ] A interface `IPersonagem` com o método `Clonar()` existe e é implementada corretamente.
- [ ] `Clonar()` realiza **deep copy** (lista de habilidades é independente).
- [ ] O `RegistroDePersonagens` armazena e fornece clones sem expor o template original.
- [ ] Adicionar uma habilidade ao clone **não** modifica o template.
- [ ] O método `Exibir()` mostra todas as informações do personagem no console.
- [ ] O código compila e roda sem erros.

---

## 💡 Dicas

- Para fazer a deep copy da lista, você pode usar `.Select(h => new Habilidade { ... }).ToList()`.
- Lembre-se: `MemberwiseClone()` faz apenas **shallow copy** — listas ainda compartilhariam referência.
- O registro deve retornar **sempre um clone**, nunca o template diretamente.

---

## 🧪 Saída Esperada (exemplo)

```
=== Personagem: Aragorn ===
Classe : Guerreiro
Nível  : 1
Vida   : 200
Habilidades:
  - Golpe Pesado  (Dano: 80)
  - Escudo de Ferro (Dano: 0)

=== Personagem: Boromir ===
Classe : Guerreiro
Nível  : 1
Vida   : 200
Habilidades:
  - Golpe Pesado  (Dano: 80)
  - Escudo de Ferro (Dano: 0)

=== Personagem: Gandalf ===
Classe : Mago
Nível  : 1
Vida   : 120
Habilidades:
  - Bola de Fogo  (Dano: 150)
  - Congelamento  (Dano: 90)
  - Relâmpago     (Dano: 200)   <-- habilidade adicionada apenas no clone

=== Template Mago (não deve ter Relâmpago) ===
Classe : Mago
Nível  : 1
Vida   : 120
Habilidades:
  - Bola de Fogo  (Dano: 150)
  - Congelamento  (Dano: 90)
```

---

## 🚀 Desafio Extra

Após concluir o exercício principal, tente:

1. Implementar a interface `ICloneable` do .NET no lugar da sua `IPersonagem`, adaptando o design.
2. Adicionar suporte a **clonagem em cadeia**: um personagem pode ter um `Mentor` (outro `Personagem`),
   e o clone também deve clonar o mentor recursivamente.
3. Tornar o `RegistroDePersonagens` **thread-safe** usando `ConcurrentDictionary`.
