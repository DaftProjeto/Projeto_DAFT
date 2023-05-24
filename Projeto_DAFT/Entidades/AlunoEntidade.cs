namespace Projeto_DAFT.Entidades
{
    public class AlunoEntidade 
    {
        public int Id { get; set; }
        public string RA { get; set; }
        public int ID_Usuario { get; set; }
        public UsuarioEntidade usuario { get; set; }

    }
}
