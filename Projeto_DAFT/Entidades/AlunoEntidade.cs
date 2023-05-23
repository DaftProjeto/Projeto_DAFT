namespace Projeto_DAFT.Entidades
{
    public class AlunoEntidade : UsuarioEntidade
    {
        public int Id { get; set; }
        public string RA { get; set; }
        public UsuarioEntidade Id_Usuario { get; set; }

    }
}
