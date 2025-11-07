using App.Data;
using App.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Iniciando estudo com Entity Framework!");

// Usar 'using' garante que a conexão com o banco seja fechada
using var context = new EscolaContext();

// ------------------------------------------------
// CREATE: Adicionando novos dados
// ------------------------------------------------
Console.WriteLine("Inserindo dados...");

var turmaA = new Turma { NomeTurma = "3A", Turno = "Manhã" };
var turmaB = new Turma { NomeTurma = "3B", Turno = "Tarde" };

context.Turmas.Add(turmaA);
context.Turmas.Add(turmaB);

context.SaveChanges();

var ana = new Aluno { Nome = "Ana", Idade = 17, TurmaId = turmaA.Id };
var bruno = new Aluno { Nome = "Bruno", Idade = 18, TurmaId = turmaA.Id };
var carla = new Aluno { Nome = "Carla", Idade = 17, TurmaId = turmaB.Id };

context.Alunos.AddRange(ana, bruno, carla);

context.SaveChanges();

context.Notas.AddRange(
    new Nota { Disciplina = "Matemática", Valor = 9.5, AlunoId = ana.Id },
    new Nota { Disciplina = "Português", Valor = 8.0, AlunoId = ana.Id },
    new Nota { Disciplina = "Matemática", Valor = 7.0, AlunoId = bruno.Id }
);

context.SaveChanges();

Console.WriteLine("Dados inseridos!");

// ------------------------------------------------
// READ: Lendo dados com LINQ
// ------------------------------------------------
Console.WriteLine("\n--- Alunos da Turma 3A ---");

var alunosDaTurmaA = context.Alunos
    .Where(a => a.Turma.NomeTurma == "3A")
    .ToList();

foreach (var aluno in alunosDaTurmaA)
{
    Console.WriteLine($"Nome: {aluno.Nome}, Idade: {aluno.Idade}");
}

// ------------------------------------------------
// UPDATE: Atualizando um dado
// ------------------------------------------------
Console.WriteLine("\nAtualizando nota do Bruno...");

var alunoBruno = context.Alunos.FirstOrDefault(a => a.Nome == "Bruno");

var notaBruno = context.Notas
    .FirstOrDefault(n => n.AlunoId == alunoBruno.Id && n.Disciplina == "Matemática");

if (notaBruno != null)
{
    notaBruno.Valor = 7.5;
    context.SaveChanges();
    Console.WriteLine("Nota atualizada!");
}

// ------------------------------------------------
// DELETE: Deletando um dado
// ------------------------------------------------
Console.WriteLine("\nRemovendo a Carla...");

var alunaCarla = context.Alunos.FirstOrDefault(a => a.Nome == "Carla");

if (alunaCarla != null)
{
    context.Alunos.Remove(alunaCarla);
    context.SaveChanges();
    Console.WriteLine("Aluno removido!");
}
else
{
    Console.WriteLine("Aluno não encontrado.");
}

    // ------------------------------------------------
    // READ Avançado (com JOINs usando .Include())
    // ------------------------------------------------
    Console.WriteLine("\n--- Relatório Aluno e Suas Notas ---");

// .Include() diz ao EF para trazer os dados relacionados (faz um JOIN)
var alunosComNotas = context.Alunos
    .Include(a => a.Notas)
    .Include(a => a.Turma) 
    .ToList();

foreach (var aluno in alunosComNotas)
{
    Console.WriteLine($"Aluno: {aluno.Nome} (Turma: {aluno.Turma.NomeTurma})");

    foreach (var nota in aluno.Notas)
    {
        Console.WriteLine($"  - {nota.Disciplina}: {nota.Valor}");
    }
}