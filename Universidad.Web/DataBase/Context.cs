using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Universidad.Web.DataBase
{
    public class Context : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<UsuarioMateria> UsuarioMaterias { get; set; }
        public DbSet<MateriaPadres> MateriaPadres { get; set; }

        public Context() : base("context")
        {

        }
    }
}