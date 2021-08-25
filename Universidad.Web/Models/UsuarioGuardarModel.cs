using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Universidad.Web.Models
{
    public class UsuarioGuardarModel
    {
        public int Id { get; set; }
        
        public string Nombre { get; set; }

        public string DNI { get; set; }
        
        public string Password { get; set; }

    }
}