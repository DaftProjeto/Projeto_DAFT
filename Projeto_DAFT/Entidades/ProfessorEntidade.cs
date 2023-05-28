namespace Projeto_DAFT.Entidades
{
    public class ProfessorEntidade
    {
        public int Id { get; set; }
        public string Matricula { get; set; }


        public int UsuarioId { get; set; }
        public UsuarioEntidade Usuario { get; set; }
    }
}
