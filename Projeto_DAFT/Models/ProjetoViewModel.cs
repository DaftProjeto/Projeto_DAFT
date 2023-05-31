using Projeto_DAFT.Entidades;

namespace Projeto_DAFT.Models
{
    public class ProjetoViewModel
    { 
        public string Curso { get; set; }
        public string Nome_Aluno { get; set; }
        public string RA_Aluno { get; set; }
        public string Titulo { get; set; }
        public DateOnly Data_Envio { get; set; }



        /*public ProjetoViewModel() 
        {
            ListaAluno = new List<AlunoEntidade>();
            //ListaOrientador = new List<Prof_OrientadorEntidade>();
            //ListaUsuario = new List<UsuarioEntidade>();
            //ListaSemestre = new List<SemestreEntidade>();   
        }

        //public List<UsuarioEntidade>ListaUsuario { get; set; }
        public List<AlunoEntidade>ListaAluno { get; set; }
        //public List<Prof_OrientadorEntidade>ListaOrientador { get; set; }
        //public List<SemestreEntidade> ListaSemestre { get; set; }
        */
    }
}
