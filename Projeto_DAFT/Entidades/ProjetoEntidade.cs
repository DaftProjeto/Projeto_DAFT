namespace Projeto_DAFT.Entidades
{
    public class ProjetoEntidade
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        public string Caminho { get; set; }

        public int AlunoId{ get; set; }
        public AlunoEntidade Aluno { get; set; }

        public int OrientadorId { get; set; }
        public ProfessorEntidade Orientador { get; set; }
       

        public int SemestreId { get; set; }
        public SemestreEntidade Semestre { get; set; }
       
        public string Curso { get; set; }
        public DateTime Data_Entrega { get; set; }

    }
}
