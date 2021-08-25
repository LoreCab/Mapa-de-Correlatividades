using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Universidad.Web.DataBase
{
    public class Materia
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        [Column(TypeName = "varchar")]
        public string Nombre { get; set; }

        public int Level { get; set; }

        public virtual List<MateriaPadres> Padres { get; set; }

        public Materia()
        {
            Padres = new List<MateriaPadres>();
        }
    }
}