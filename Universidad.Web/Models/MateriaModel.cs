using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Universidad.Web.Models
{
    public class MateriaModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int Level { get; set; }

        public int Estado { get; set; }

        public List<int> Padres { get; set; }
    }
}