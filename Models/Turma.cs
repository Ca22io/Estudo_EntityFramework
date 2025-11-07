namespace App.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public required string NomeTurma { get; set; }
        public required string Turno { get; set; }

        public ICollection<Aluno>? Alunos { get; set; }
    }
}