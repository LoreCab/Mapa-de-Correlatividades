using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Universidad.Web.DataBase
{
    public class UsuarioMateria
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }

        [ForeignKey("Materia")]
        public int IdMateria { get; set; }

        public int Estado { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Materia Materia { get; set; }

    }
}