namespace Projeto_DAFT.Entidades
{
    public class ProjetoEntidade
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        public string Caminho { get; set; }
        

        //public AlunoEntidade Aluno { get; set; }
        //public AlunoEntidade Nome { get; set; }
        public int ID_Aluno { get; set; }
        //public ProfessorEntidade Nome { get; set; }
        //public SemestreEntidade Ano { get; set; }

        public int ID_Semestre { get; set; }
        public int ID_Orientador { get; set; }
        public string Curso { get; set; }
        public DateTime Data_Envio { get; set; }

    }
}
