namespace App.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public int Idade { get; set; }

        public int TurmaId { get; set; }

        public Turma? Turma { get; set; }
        public ICollection<Nota>? Notas { get; set; }
    }
}