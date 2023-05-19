using Microsoft.EntityFrameworkCore;
using Projeto_DAFT.Entidades;

namespace Projeto_DAFT
{
    public class Contexto : DbContext 
    {
        public Contexto(DbContextOptions<Contexto> opt) : base(opt)
        { }

    }
}
