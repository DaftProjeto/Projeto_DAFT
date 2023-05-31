namespace Projeto_DAFT.Entidades
{
    public class AlunoEntidade 
    {
        public int Id { get; set; }
        public string RA { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioEntidade Usuario { get; set; }

    }
}
