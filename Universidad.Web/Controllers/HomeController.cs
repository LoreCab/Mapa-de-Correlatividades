using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Universidad.Web.DataBase;
using Universidad.Web.Models;

namespace Universidad.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context = new Context();

        [HttpGet]
        public ActionResult Index()
        {
            Session.Remove("user");
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            var user = _context.Usuario.FirstOrDefault(x => x.DNI.Equals(model.DNI) && x.Password.Equals(model.Password));
            if (user == null)
            {
                return View();
            }

            Session.Add("user", user);

            if (user.Tipo == 1)
            {
                return RedirectToAction("Usuarios");
            }
            else
            {
                return RedirectToAction("Materias");
            }
        }

        public ActionResult Usuarios()
        {
            var user = GetUser();
            if (user == null)
            {
                return RedirectToAction("Index");
            }

            var list = _context.Usuario.Where(x => x.Tipo == 2).Select(x => new UsuarioItemModel
            {
                Id = x.Id,
                Nombre = x.Nombre
            }).ToList();
            
            ViewBag.user = user;
            return View(list);
        }

        public ActionResult ObtenerUsuario(UsuarioGuardarModel model)
        {
            var user = GetUser();
            if (user == null)
            {
                return RedirectToAction("Index");
            }

            var usuario = _context.Usuario.FirstOrDefault(x => x.Id == model.Id) ?? new Usuario();

            if (usuario.Id > 0)
            {
                model.Nombre = usuario.Nombre;
                model.DNI = usuario.DNI;
                model.Password = usuario.Password;
            }

            ViewBag.user = user;
            return View("UsuarioGuardar", model);
        }

        public ActionResult GuardarUsuario(UsuarioGuardarModel model)
        {
            var user = GetUser();
            if (user == null)
            {
                return RedirectToAction("Index");
            }

            var alumno = _context.Usuario.FirstOrDefault(x => x.Id == model.Id) ?? new Usuario();

            var esNuevo = false;
            if (alumno.Id == 0)
            {
                esNuevo = true;
                alumno.Tipo = 2;
                _context.Usuario.Add(alumno);
            }

            alumno.Nombre = model.Nombre;
            alumno.DNI = model.DNI;
            alumno.Password = model.Password;

            _context.SaveChanges();

            if (esNuevo)
            {
                var materias = _context.Materia.ToList();
                var relacion = new List<UsuarioMateria>();
                materias.ToList().ForEach(materia =>
                   {
                       relacion.Add(new UsuarioMateria { IdUsuario = alumno.Id, IdMateria = materia.Id, Estado = 2 });
                   });

                _context.UsuarioMaterias.AddRange(relacion);
                _context.SaveChanges();
            }
            
            return Redirect("Usuarios");
        }

        public ActionResult UsuarioEliminar(UsuarioGetModel model)
        {
            var usuario = _context.Usuario.FirstOrDefault(x => x.Id == model.Id);
            if (usuario != null)
            {
                var materias = _context.UsuarioMaterias.Where(x => x.IdUsuario == usuario.Id).ToList();
                _context.UsuarioMaterias.RemoveRange(materias);
                _context.SaveChanges();

                _context.Usuario.Remove(usuario);
                _context.SaveChanges();
            }
            return Json(new { Success = true });
        }
        
        public ActionResult Materias()
        {
            var user = GetUser();
            if (user == null)
            {
                return RedirectToAction("Index");
            }

            var relaciones = _context.UsuarioMaterias.Where(x => x.IdUsuario == user.Id).ToList();
            var list = _context.Materia.Include("Padres").ToList();
            var materias = list.Select(x => new MateriaModel { 
                Id = x.Id,
                Nombre = x.Nombre,
                Level = x.Level,
                Padres = x.Padres.Select(y => y.IdPadre).ToList()
            }).ToList();

            materias.ForEach(materia =>
            {
                materia.Estado = relaciones.FirstOrDefault(x => x.IdMateria == materia.Id).Estado;
            });

            var group = materias.OrderBy(x => x.Level).GroupBy(x => x.Level).ToList();
            
            ViewBag.user = user;
            return View(group);
        }

        public ActionResult ConfigurarMaterias()
        {
            var user = GetUser();
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            
            var relaciones = _context.UsuarioMaterias.Where(x => x.IdUsuario == user.Id).ToList();
            var materias = _context.Materia.Select(x => new MateriaItemModel { 
                Id = x.Id,
                Nombre = x.Nombre,
            }).ToList();

            materias.ForEach(materia =>
            {
                var rel  = relaciones.FirstOrDefault(x => x.IdMateria == materia.Id);
                materia.IdMateria = rel.IdMateria;
                materia.IdUsuario = rel.IdUsuario;
                materia.Estado = rel.Estado.ToString();
            });
           
            ViewBag.user = user;
            return View(materias);
        } 

        public ActionResult GuardarMaterias(List<MateriaItemModel> model)
        {
            foreach (var item in model)
            {
                var materiaRel = _context.UsuarioMaterias.FirstOrDefault(x => x.Id == item.Id) ?? new UsuarioMateria();

                if (materiaRel.Id == 0)
                {
                    _context.UsuarioMaterias.Add(materiaRel);
                }

                materiaRel.IdUsuario = item.IdUsuario;
                materiaRel.IdMateria = item.IdMateria;
                materiaRel.Estado = Convert.ToInt32(item.Estado);

                _context.SaveChanges();
            }
            return Redirect("Materias");
        }

        private Usuario GetUser()
        {
            return Session["user"] as Usuario;
        }
    }
}