using Projeto_DAFT.Entidades;

namespace Projeto_DAFT.Models
{
    public class EnviarViewModel
    {

        public EnviarViewModel()
        {  
            ListaProfessor = new List<ProfessorEntidade>();
        }


        public AlunoEntidade Aluno { get; set; }

        public UsuarioEntidade Usuario { get; set; }

        public List<ProfessorEntidade> ListaProfessor{ get; set; } 

    }
}
