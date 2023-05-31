namespace Projeto_DAFT.Entidades
{
    public class UsuarioEntidade
    {

        public int Id { get; set; }
        public string Nome { get; set; }    
        public string Email { get; set; }   
        public string Senha { get; set; }
        public int Permissao { get; set; }
        public string Telefone { get; set; }
        public bool Autoriza_Email { get; set; }
        public bool Autoriza_Dados { get; set; }

 

    }
}
