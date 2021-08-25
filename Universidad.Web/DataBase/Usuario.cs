using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Universidad.Web.DataBase
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        
        public int Tipo { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(200)]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string DNI { get; set; }
        
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string Password { get; set; }

        public virtual List<UsuarioMateria> Materias { get; set; }

        public Usuario()
        {
            Materias = new List<UsuarioMateria>();
        }
    }
}