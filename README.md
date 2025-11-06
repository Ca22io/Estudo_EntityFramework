🎯 Objetivo do Projeto
Criar uma aplicação de console (.NET 8) que realiza operações de CRUD (Create, Read, Update, Delete) em um banco de dados SQLite, usando o fluxo "Code-First" do Entity Framework Core.

📂 Estrutura do Projeto
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
