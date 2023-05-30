using Projeto_DAFT.Entidades;

namespace Projeto_DAFT.Models
{
    public class ProjetoViewModel : ProjetoEntidade
    { 
        public string Curso { get; set; }
        public string Nome_Aluno { get; set; }
        public string RA_Aluno { get; set; }
        public string Titulo { get; set; }
        public DateOnly Data_Envio { get; set; }



        public ProjetoViewModel() 
        {
            ListaAluno = new List<AlunoEntidade>();
            ListaProfessor = new List<ProfessorEntidade>();
        }

        public List<AlunoEntidade>ListaAluno { get; set; }
        public List<ProfessorEntidade> ListaProfessor { get; set; }
        
    }
}
