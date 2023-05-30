namespace Projeto_DAFT.Entidades
{
    public class ProjetoEntidade
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        public string Caminho { get; set; }
        public string Turno { get; set; }

        public int AlunoId{ get; set; }
        public AlunoEntidade Aluno { get; set; }

        public int ProfessorId { get; set; }
        public ProfessorEntidade Professor { get; set; }

        public string Curso { get; set; }
        public DateTime Data_Entrega { get; set; } 

    }
}
