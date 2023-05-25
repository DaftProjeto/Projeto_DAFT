using Projeto_DAFT.Entidades;

namespace Projeto_DAFT.Models
{
    public class UsuarioViewModel : UsuarioEntidade
    {
        public string? RA { get; set; }
        public string? Lattes { get; set; }
        public int? tipo { get; set; } 
    }
}
