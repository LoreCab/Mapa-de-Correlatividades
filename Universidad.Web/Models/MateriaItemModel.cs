using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Universidad.Web.Models
{
    public class MateriaItemModel
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdMateria { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
    }
}