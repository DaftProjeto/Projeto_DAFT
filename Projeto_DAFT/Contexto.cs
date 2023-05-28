﻿using Microsoft.EntityFrameworkCore;
using Projeto_DAFT.Entidades;
using System.Collections.Generic;

namespace Projeto_DAFT
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> opt) : base(opt)
        { }

        public DbSet<UsuarioEntidade> Usuario { get; set; }
        public DbSet<RegraEntidade> Regra { get; set; }
        public DbSet<AdministradorEntidade> Administrador { get; set; }
        public DbSet<AlunoEntidade> Aluno { get; set; }
        public DbSet<Prof_OrientadorEntidade> Orientador { get; set; }
        public DbSet<Prof_BancaEntidade> Banca { get; set; }
        public DbSet<ProfessorEntidade> Professor { get; set; }
        public DbSet<SemestreEntidade> Semestre { get; set; }
        public DbSet<ProjetoEntidade> Projeto { get; set; }
    }
}
