namespace App.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public required string Disciplina { get; set; }
        public double Valor { get; set; }

        public int AlunoId { get; set; }

        public Aluno? Aluno { get; set; }
    }
}