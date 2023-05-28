namespace Projeto_DAFT.Entidades
{
    public class Prof_OrientadorEntidade
    {
        public int Id { get; set; }
        public int ProfessorId { get; set; }
        public ProfessorEntidade Professor { get; set; }
    }
}
