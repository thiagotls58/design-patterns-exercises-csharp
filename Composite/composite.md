# Exercício Prático: Composite com C#

## Objetivo
Implementar o padrão de projeto **Composite** para representar hierarquias parte-todo, permitindo que clientes tratem objetos individuais e composições de objetos de maneira uniforme.

---

## O Cenário: "FileExplorer"

Você está construindo um módulo de exploração de sistema de arquivos para uma ferramenta de análise de disco. O sistema precisa calcular o **tamanho total** e **listar o conteúdo** tanto de arquivos simples quanto de pastas que contêm outros arquivos e subpastas.

Sem o Composite, o código cliente precisaria distinguir constantemente entre arquivos e pastas com `if/else`. Com o Composite, tanto `Arquivo` quanto `Pasta` respondem à mesma interface, e o cliente não precisa saber a diferença.

O desafio é modelar essa hierarquia usando o padrão Composite para que pastas e arquivos sejam tratados de forma uniforme.

---

## Requisitos Técnicos

### 1. Component (interface base)
Crie a interface `IFileSystemItem` com os métodos:

* `string GetName();`
* `long GetSize();`
* `void Display(int indent = 0);`

### 2. Leaf (folha — arquivo simples)
Crie a classe `FileItem` que implementa `IFileSystemItem`:

* Recebe `name` (string) e `size` (long) por construtor
* `GetName()` retorna o nome do arquivo
* `GetSize()` retorna o tamanho em bytes
* `Display(indent)` imprime: `"{espaços}{name} ({size} bytes)"`, onde `{espaços}` é uma string de `indent` espaços

### 3. Composite (pasta — contém outros itens)
Crie a classe `DirectoryItem` que implementa `IFileSystemItem`:

* Recebe `name` (string) por construtor
* Mantém internamente uma lista de `IFileSystemItem`
* `Add(IFileSystemItem item)` adiciona um item à lista
* `GetName()` retorna o nome da pasta
* `GetSize()` retorna a **soma recursiva** dos tamanhos de todos os itens contidos
* `Display(indent)` imprime o nome da pasta e, recursivamente, exibe cada filho com `indent + 2` espaços

### 4. Cliente
No `Program.cs`, construa a seguinte hierarquia e chame `Display()` na raiz:

```
/root
├── boot.cfg         (512 bytes)
├── readme.txt       (1024 bytes)
└── /documents
    ├── report.pdf   (204800 bytes)
    ├── notes.txt    (2048 bytes)
    └── /images
        ├── photo.jpg  (1048576 bytes)
        └── logo.png   (32768 bytes)
```

Ao final, imprima também o tamanho total de `/root`.

---

## Saída Esperada

```
/root (1289728 bytes)
  boot.cfg (512 bytes)
  readme.txt (1024 bytes)
  /documents (1288192 bytes)
    report.pdf (204800 bytes)
    notes.txt (2048 bytes)
    /images (1081344 bytes)
      photo.jpg (1048576 bytes)
      logo.png (32768 bytes)

Tamanho total de /root: 1289728 bytes
```

---

## Estrutura de Pastas Sugerida
```text
/Composite
├── Program.cs
└── FileSystem/
    ├── IFileSystemItem.cs
    ├── FileItem.cs
    └── DirectoryItem.cs
```

---

## Critérios de Aceite

* `IFileSystemItem` é a única interface que o código cliente (`Program.cs`) conhece — ele nunca checa o tipo concreto com `is` ou casts
* `DirectoryItem.GetSize()` é calculado recursivamente, sem conhecer a diferença entre `FileItem` e outro `DirectoryItem`
* A indentação aumenta corretamente a cada nível de profundidade
* A adição de um novo tipo de item (ex: `SymLinkItem`) não exige alterações em `DirectoryItem` nem no cliente
* O programa executa sem erros e exibe a saída no formato especificado

---

## Desafio Extra (Opcional)

1. Adicione o método `Remove(IFileSystemItem item)` em `DirectoryItem` e demonstre a remoção de um arquivo no `Program.cs`.
2. Adicione um método `Search(string name)` à interface que, em `FileItem`, retorna o próprio item se o nome bater, e em `DirectoryItem`, percorre recursivamente os filhos retornando todos os itens cujo nome contenha a string buscada.
3. Implemente `SymLinkItem` (um "atalho") que wrapa qualquer `IFileSystemItem` e delega todas as chamadas a ele — demonstrando que o Composite aceita novos tipos sem modificação.

---

## Desafio 2: Permissões e Visitante

### Cenário
O "FileExplorer" agora precisa **auditar permissões** da árvore de arquivos sem poluir as classes de `FileSystem/` com lógica de negócio. A ideia é introduzir o padrão **Visitor** em cima da hierarquia Composite já criada.

### Requisitos Técnicos

#### 1. Aceitar visitantes
Adicione o método `void Accept(IFileSystemVisitor visitor);` à interface `IFileSystemItem`.

#### 2. Interface do visitante
Crie a interface `IFileSystemVisitor` com os métodos:

* `void VisitFile(FileItem file);`
* `void VisitDirectory(DirectoryItem directory);`

#### 3. Visitante concreto
Crie a classe `PermissionAuditVisitor` que implementa `IFileSystemVisitor`:

* `VisitFile` imprime: `"[AUDIT] Arquivo: {nome} — leitura: OK, escrita: OK"`
* `VisitDirectory` imprime: `"[AUDIT] Pasta: {nome} — listagem: OK"`

#### 4. Implementação do Accept
* Em `FileItem`: chama `visitor.VisitFile(this)`
* Em `DirectoryItem`: chama `visitor.VisitDirectory(this)` e, em seguida, chama `Accept(visitor)` em cada filho

#### 5. Cliente
No `Program.cs`, reutilize a hierarquia já criada e dispare o `PermissionAuditVisitor` na raiz.

### Estrutura de Pastas Sugerida
```text
/Composite
├── Program.cs
├── FileSystem/
│   ├── IFileSystemItem.cs      ← adicionar Accept
│   ├── FileItem.cs             ← implementar Accept
│   └── DirectoryItem.cs        ← implementar Accept
└── Visitors/                   ← [NOVO]
    ├── IFileSystemVisitor.cs
    └── PermissionAuditVisitor.cs
```

### Critérios de Aceite

* O visitante percorre **toda** a árvore sem que o cliente precise iterar manualmente
* As classes de `FileSystem/` **não contêm** lógica de auditoria — apenas delegam ao visitante
* Adicionar um segundo visitante (ex: `SizeReportVisitor`) não exige alteração em nenhuma classe de `FileSystem/`
* O programa executa sem erros e exibe o relatório de auditoria completo no console
