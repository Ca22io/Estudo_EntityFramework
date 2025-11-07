# Estudo de Entity Framework Core 8 com SQLite (Code-First)

Esta é uma aplicação de console em .NET 8 que demonstra o uso do Entity Framework Core no fluxo "Code-First". O projeto foca em realizar operações de **CRUD (Create, Read, Update, Delete)** em um banco de dados **SQLite**, mostrando como mapear classes C# para tabelas de banco de dados.

O cenário utilizado é o de uma mini-secretaria acadêmica, com `Alunos`, `Turmas` e `Notas`.

## 🚀 Evolução do Aprendizado: Do LINQ ao EF Core

Este projeto é a evolução direta do meu [Repositório de Estudo de LINQ](https://github.com/SEU_USUARIO/Estudo_Linq) (Substitua este link pelo seu).

Enquanto o projeto anterior focava em consultas LINQ em *memória* (com dados mockados em `List<T>`), este projeto aplica os **mesmos conceitos de consulta LINQ** contra um **banco de dados real**.

Aqui, o LINQ é usado para que o Entity Framework o traduza em comandos SQL, demonstrando a persistência de dados real, o mapeamento de relacionamentos e o gerenciamento de estado.

## 📖 Conceitos de EF Core Demonstrados

Este projeto serve como um guia prático para os seguintes conceitos:

* **Configuração do `DbContext`**: Mapeamento das entidades (`DbSet`) e configuração do provedor (`OnConfiguring`).
* **Fluxo Code-First**: Criação de `Models` C# que geram a estrutura do banco.
* **Migrations**: Geração (`dotnet ef migrations add`) e aplicação (`dotnet ef database update`) de alterações no schema do banco.
* **CREATE**: Uso de `.Add()` e `.AddRange()` com `SaveChanges()` para inserir dados.
* **READ (LINQ to SQL)**: Uso de `.Where()`, `.FirstOrDefault()` e outros operadores LINQ que são traduzidos para SQL.
* **UPDATE**: Busca de uma entidade, modificação de suas propriedades e `SaveChanges()`.
* **DELETE**: Uso de `.Remove()` com `SaveChanges()` para deletar registros.
* **Relacionamentos e JOINs**: Uso de Chaves Estrangeiras (`TurmaId`) e Propriedades de Navegação (`ICollection<Aluno>`).
* **Carregamento Relacionado (Eager Loading)**: Uso do `.Include()` para trazer dados de tabelas relacionadas (o "JOIN" do EF Core).

## 🚀 Tecnologias Utilizadas

* **.NET 8**
* **Entity Framework Core 8** (EF Core)
* **Provedor SQLite** (`Microsoft.EntityFrameworkCore.Sqlite`)
* **Fluxo Code-First** (com `EF Core Migrations`)
* **LINQ** (para consultas no banco)

## ⚙️ Como Clonar e Executar

### Pré-requisitos

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* [Git](https://git-scm.com/downloads)
* **Ferramenta Global do EF Core:** (Se ainda não tiver)
    ```sh
    dotnet tool install --global dotnet-ef
    ```

### Passos para Execução

1.  Abra seu terminal ou prompt de comando.
2.  Clone este repositório:
    ```sh
    git clone https://github.com/Ca22io/Estudo_EntityFramework
    ```
    (Substitua pelo link do seu repositório)

3.  Navegue até o diretório do projeto:
    ```sh
    cd Estudo_EntityFramework
    ```

4.  Restaure os pacotes NuGet:
    ```sh
    dotnet restore
    ```

5.  **CRIE O BANCO DE DADOS (Importante!)**
    Este projeto usa Migrations. O arquivo `escola.db` não está no repositório. Para criá-lo com todas as tabelas, execute:
    ```sh
    dotnet ef database update
    ```
    *(Este comando lê a pasta `Migrations` e aplica o "plano" dela, criando o arquivo `escola.db` na raiz do projeto).*

6.  Execute a aplicação:
    ```sh
    dotnet run
    ```
## 🖥️ Saída Esperada no Console

Ao executar o comando `dotnet run`, a aplicação irá inserir, ler, atualizar e deletar dados. A saída esperada é:

O console exibirá as operações de CRUD sendo executadas: inserindo dados, lendo, atualizando e deletando.

```
Iniciando estudo com Entity Framework!
Inserindo dados...
Dados inseridos!

--- Todos os alunos cadastrados ---
Nome: Ana
Nome: Bruno
Nome: Carla

--- Alunos da Turma 3A ---
Nome: Ana, Idade: 17
Nome: Bruno, Idade: 18

Atualizando nota do Bruno...
Nota atualizada!

Removendo a Carla...
Aluno removido!

--- Relatório Aluno e Suas Notas ---
Aluno: Ana (Turma: 3A)
  - Matemática: 9,5
  - Português: 8
Aluno: Bruno (Turma: 3A)
  - Matemática: 7,5
```
*(Nota: O relatório final mostra a nota do Bruno já atualizada para 7.5 e não lista mais a aluna Carla, pois ela foi removida na etapa de Delete).*

## 📂 Estrutura do Projeto

Esta será a estrutura de pastas que você vai criar:
```
  Estudo_EntityFramework/
  │
  ├── Data/
  │   └── EscolaContext.cs      # O "coração" do EF, representa sua conexão com o BD.
  │
  ├── Migrations/
  │   └── (Pasta gerada pelo EF) # Armazena o histórico de alterações do BD.
  │
  ├── Models/
  │   ├── Aluno.cs            # Entidade Aluno (igual ao projeto LINQ).
  │   ├── Turma.cs            # Entidade Turma.
  │   └── Nota.cs             # Entidade Nota.
  │
  ├── escola.db                 # (Arquivo gerado pelo EF) O seu banco de dados SQLite.
  │
  ├── Program.cs                # Onde vamos executar as operações de CRUD.
  └── Estudo_EntityFramework.csproj
```
