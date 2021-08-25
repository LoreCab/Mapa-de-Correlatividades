using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Universidad.Web.DataBase
{
    public class MateriaPadres
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Materia")]
        public int IdMateria { get; set; }

        public int IdPadre { get; set; }

        public virtual Materia Materia { get; set; }

    }
}