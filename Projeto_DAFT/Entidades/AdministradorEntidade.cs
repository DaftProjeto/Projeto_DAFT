namespace Projeto_DAFT.Entidades
{
    public class AdministradorEntidade 
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioEntidade Usuario { get; set; }
    }
}
