namespace Projeto_DAFT.Entidades
{
    public class AdministradorEntidade : UsuarioEntidade
    {
        public int ID { get; set; }
        public UsuarioEntidade ID_Usuario { get; set; }
    }
}
