# Exercício: Abstract Factory em C#

## 🎯 Objetivo

Implementar o padrão de projeto **Abstract Factory** para criar uma interface de usuário multiplataforma, onde diferentes famílias de componentes (Windows e macOS) são criadas sem que o código cliente dependa de implementações concretas.

---

## 📖 Contexto

Você foi contratado para desenvolver um framework de UI que suporte múltiplos sistemas operacionais. O sistema deve ser capaz de criar botões e checkboxes com visuais e comportamentos nativos de cada plataforma — sem que o código principal precise saber qual plataforma está sendo usada.

---

## 🧩 Diagrama de Classes

```
IUIFactory (Abstract Factory)
├── CreateButton() → IButton
└── CreateCheckbox() → ICheckbox

WindowsFactory : IUIFactory          MacOSFactory : IUIFactory
├── CreateButton() → WindowsButton   ├── CreateButton() → MacOSButton
└── CreateCheckbox() → WinCheckbox   └── CreateCheckbox() → MacCheckbox

IButton                              ICheckbox
└── Render()                         └── Toggle()

WindowsButton : IButton              MacOSButton : IButton
WinCheckbox : ICheckbox              MacCheckbox : ICheckbox
```

---

## 📝 Tarefas

### 1. Interfaces dos Produtos

Crie as interfaces `IButton` e `ICheckbox`:

- `IButton` deve ter o método `void Render()`
- `ICheckbox` deve ter o método `void Toggle()`

---

### 2. Produtos Concretos — Windows

Implemente as classes concretas para Windows:

- `WindowsButton` que implementa `IButton`
    - `Render()` deve exibir: `"[Windows] Renderizando botão com estilo Windows"`
- `WindowsCheckbox` que implementa `ICheckbox`
    - `Toggle()` deve exibir: `"[Windows] Alternando checkbox estilo Windows"`

---

### 3. Produtos Concretos — macOS

Implemente as classes concretas para macOS:

- `MacOSButton` que implementa `IButton`
    - `Render()` deve exibir: `"[macOS] Renderizando botão com estilo macOS"`
- `MacOSCheckbox` que implementa `ICheckbox`
    - `Toggle()` deve exibir: `"[macOS] Alternando checkbox estilo macOS"`

---

### 4. Abstract Factory

Crie a interface `IUIFactory` com os métodos:
- `IButton CreateButton()`
- `ICheckbox CreateCheckbox()`

---

### 5. Factories Concretas

Implemente `WindowsFactory` e `MacOSFactory`, ambas implementando `IUIFactory`.

---

### 6. Código Cliente

Crie uma classe `Application` que:
- Receba um `IUIFactory` no construtor
- Tenha um método `BuildUI()` que crie um botão e um checkbox usando a factory
- Tenha um método `RenderUI()` que chame `Render()` no botão e `Toggle()` no checkbox

---

### 7. Program.cs

No `Main`, simule a seleção de plataforma:

```csharp
static void Main(string[] args)
{
    IUIFactory factory;

    string os = "windows"; // tente também "macos"

    if (os == "windows")
        factory = new WindowsFactory();
    else
        factory = new MacOSFactory();

    var app = new Application(factory);
    app.BuildUI();
    app.RenderUI();
}
```

**Saída esperada para Windows:**
```
[Windows] Renderizando botão com estilo Windows
[Windows] Alternando checkbox estilo Windows
```

**Saída esperada para macOS:**
```
[macOS] Renderizando botão com estilo macOS
[macOS] Alternando checkbox estilo macOS
```

---

## 🚀 Desafios Extras

1. **Nova plataforma:** Adicione suporte a uma terceira plataforma, `LinuxFactory`, com seus próprios componentes — sem modificar nenhum código existente.

2. **Novo produto:** Adicione um terceiro produto, `ITooltip`, com o método `Show()`, e implemente-o para todas as plataformas.

3. **Configuração dinâmica:** Leia o nome da plataforma de um argumento de linha de comando (`args[0]`) e instancie a factory correta.

---

## 💡 Dicas

- O cliente (`Application`) **nunca** deve referenciar classes concretas como `WindowsButton` diretamente — apenas interfaces.
- O padrão Abstract Factory é ideal quando seu sistema precisa ser **independente** de como seus produtos são criados.
- Cada factory concreta representa uma **família de produtos** compatíveis entre si.

---

## ✅ Checklist de Revisão

- [ ] Interfaces `IButton` e `ICheckbox` criadas
- [ ] Implementações concretas para Windows e macOS
- [ ] Interface `IUIFactory` definida
- [ ] `WindowsFactory` e `MacOSFactory` implementadas
- [ ] Classe `Application` depende apenas de interfaces
- [ ] `Main` seleciona a factory sem expor tipos concretos ao cliente
- [ ] Saída no console está correta para ambas as plataformas