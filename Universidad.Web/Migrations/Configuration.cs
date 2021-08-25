namespace Universidad.Web.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Universidad.Web.DataBase;

    internal sealed class Configuration : DbMigrationsConfiguration<Universidad.Web.DataBase.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Universidad.Web.DataBase.Context context)
        {
            if (!context.Materia.Any())
            {
                var materias = context.Materia.AddRange(new List<Materia>
                { //Materias 1er año

                    new Materia  { Id = 1, Nombre = "Filosofía", Level = 0 },
                    new Materia  { Id = 2, Nombre = "Fundamentos de la Informática", Level = 0 },

                    new Materia  { Id = 3, Nombre = "Algebra y Geometría Analítica", Level = 1 },
                    new Materia  { Id = 4, Nombre = "Cálculo I", Level = 1 },
                    new Materia  { Id = 5, Nombre = "Química", Level = 1 },
                    new Materia  { Id = 6, Nombre = "Expresión Oral y Escrita", Level = 1 },

                    new Materia  { Id = 7, Nombre = "Álgebra Lineal", Level = 2,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 3 } } },
                    new Materia  { Id =8 , Nombre = "Calculo II", Level = 2,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 4 } } },
                    new Materia  { Id = 9, Nombre = "Fisica I", Level = 2,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 4 } } },
                    new Materia  { Id = 10, Nombre = "Arquitectura de Computadoras", Level = 2 },

                    // Materias 2do año

                    new Materia  { Id = 11, Nombre = "Teología", Level = 3 },
                    new Materia  { Id = 12, Nombre = "Programación I", Level = 3,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 2 } } },

                    new Materia  { Id = 13, Nombre = "Cálculo III", Level = 4,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 3 }, new MateriaPadres { IdPadre = 4 }, new MateriaPadres { IdPadre = 8 } } },
                    new Materia  { Id = 14, Nombre = "Fisica II", Level = 4,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 8 }, new MateriaPadres { IdPadre = 9 } } },
                    new Materia  { Id = 15, Nombre = "Estructura de Datos", Level = 4,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 2 } } },
                    new Materia  { Id = 16, Nombre = "Sistema de Representación", Level = 4,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 2 } } },

                    new Materia  { Id = 17, Nombre = "Sistemas Operativos I", Level = 5,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 15 }, new MateriaPadres { IdPadre = 10} } },
                    new Materia  { Id = 18, Nombre = "Fisica III", Level = 5,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 13 }, new MateriaPadres { IdPadre = 14 }, new MateriaPadres { IdPadre = 5 }, new MateriaPadres { IdPadre = 9 } } },
                    new Materia  { Id = 19, Nombre = "Matemática Discreta", Level = 5,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 7 }, new MateriaPadres { IdPadre = 8 }, new MateriaPadres { IdPadre = 4 } } },
                    new Materia  { Id = 20, Nombre = "Inglés Técnico", Level = 5,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 2 }, new MateriaPadres { IdPadre = 10 } } },

                    // Materias 3er año

                    new Materia  { Id = 21, Nombre = "Doctrina Social de la Iglesia", Level = 6,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 11 } } },

                    new Materia  { Id = 22, Nombre = "Programación II", Level = 7,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 12 }, new MateriaPadres { IdPadre = 15 }, new MateriaPadres { IdPadre = 2 } } },
                    new Materia  { Id = 23, Nombre = "Sistemas Operativos II", Level = 7,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 10 }, new MateriaPadres { IdPadre = 17 } } },
                    new Materia  { Id = 24, Nombre = "Organización Empresarial", Level = 7,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 2 }, new MateriaPadres { IdPadre = 12 } } },
                    new Materia  { Id = 25, Nombre = "Probabilidad y Estadística", Level = 7,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 13 }, new MateriaPadres { IdPadre = 19 }, new MateriaPadres { IdPadre = 7 }, new MateriaPadres { IdPadre = 8 } } },
                    new Materia  { Id = 26, Nombre = "Información y Comunicación", Level = 7,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 10 }, new MateriaPadres { IdPadre = 17 } } },

                    new Materia  { Id = 27, Nombre = "Sistemas de Información I", Level = 8,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 12 }, new MateriaPadres { IdPadre = 24 } } },
                    new Materia  { Id = 28, Nombre = "Base de Datos I", Level = 8,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 15 }, new MateriaPadres { IdPadre = 22 } } },
                    new Materia  { Id = 29, Nombre = "Análisis Numérico", Level = 8,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 19 }, new MateriaPadres { IdPadre = 15 }, new MateriaPadres { IdPadre = 8 } } },
                    new Materia  { Id = 30, Nombre = "Redes de Computadoras", Level = 8,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 26 }, new MateriaPadres { IdPadre = 16 } } },

                    // Materias de 4to año

                    new Materia  { Id = 31, Nombre = "Modelos y Simulación", Level = 9,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 29 }, new MateriaPadres { IdPadre = 27 }, new MateriaPadres { IdPadre = 13 }, new MateriaPadres { IdPadre = 12 }, new MateriaPadres { IdPadre = 25 } } },
                    new Materia  { Id = 32, Nombre = "Sistemas de Información II", Level = 9,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 27 }, new MateriaPadres { IdPadre = 30 }, new MateriaPadres { IdPadre = 22 }, new MateriaPadres { IdPadre = 17 } } },

                    new Materia  { Id = 33, Nombre = "Lenguajes Formales y Autómatas", Level = 10,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 22 }, new MateriaPadres { IdPadre = 19 } } },
                    new Materia  { Id = 34, Nombre = "Base de Datos II", Level = 10,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 28 }, new MateriaPadres { IdPadre = 23 }, new MateriaPadres { IdPadre = 17 } } },
                    new Materia  { Id = 35, Nombre = "Economía para Ingenieros", Level = 10,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 24 }, new MateriaPadres { IdPadre = 25 } } },

                    new Materia  { Id = 36, Nombre = "Inteligencia Artificial", Level = 11,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 22 }, new MateriaPadres { IdPadre = 27 } } },
                    new Materia  { Id = 37, Nombre = "Metodología de la Investigación", Level = 11,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 27 }, new MateriaPadres { IdPadre = 28 }, new MateriaPadres { IdPadre = 25 }, new MateriaPadres { IdPadre = 6 } } },
                    new Materia  { Id = 38, Nombre = "Ingeniería de Software", Level = 11,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 23 }, new MateriaPadres { IdPadre = 30 }, new MateriaPadres { IdPadre = 24 }, new MateriaPadres { IdPadre = 22 }, new MateriaPadres { IdPadre = 27 }, new MateriaPadres { IdPadre = 17 } } },
                    new Materia  { Id = 39, Nombre = "Sistemas de Tiempo Real", Level = 11,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 27 }, new MateriaPadres { IdPadre = 23 }, new MateriaPadres { IdPadre = 17 } } },

                    // Materias de 5to año

                    new Materia  { Id = 40, Nombre = "Trabajo Final", Level = 12,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 37 }, new MateriaPadres { IdPadre = 38 }, new MateriaPadres { IdPadre = 36 }, new MateriaPadres { IdPadre = 32 }, new MateriaPadres { IdPadre = 30 }, new MateriaPadres { IdPadre = 27 }, new MateriaPadres { IdPadre = 34 }, new MateriaPadres { IdPadre = 23 } } },

                    new Materia  { Id = 41, Nombre = "Administración de Proyectos", Level = 13,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 34 }, new MateriaPadres { IdPadre = 32 }, new MateriaPadres { IdPadre = 38 }, new MateriaPadres { IdPadre = 31 }, new MateriaPadres { IdPadre = 35 }, new MateriaPadres { IdPadre = 30 }, new MateriaPadres { IdPadre = 24 }, new MateriaPadres { IdPadre = 28 }, new MateriaPadres { IdPadre = 29 } } },
                    new Materia  { Id = 42, Nombre = "Legislación y Gestión Ambiental", Level = 13,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 24 } } },
                    new Materia  { Id = 43, Nombre = "Ajuste en el Rendimiento de Bases de Datos", Level = 13,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 32 }, new MateriaPadres { IdPadre = 34 }, new MateriaPadres { IdPadre = 28 }, new MateriaPadres { IdPadre = 19 } } },

                     new Materia  { Id = 44, Nombre = "Ética y Profesión", Level = 14,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 32 }, new MateriaPadres { IdPadre = 38 }, new MateriaPadres { IdPadre = 21 } } },
                    new Materia  { Id = 45, Nombre = "Seguridad Informática", Level = 14,
                        Padres = new List<MateriaPadres> { new MateriaPadres { IdPadre = 32 }, new MateriaPadres { IdPadre = 34 }, new MateriaPadres { IdPadre = 30 }, new MateriaPadres { IdPadre = 28 }, new MateriaPadres { IdPadre = 27 } } },
                   


                });

                var usuarios = context.Usuario.AddRange(new List<Usuario> {
                    new Usuario { Id = 1, Nombre = "admin", DNI = "admin", Password = "admin", Tipo = 1 },
                    new Usuario { Id = 2, Nombre = "Lorena Caballero", DNI = "32159955", Password = "12006499", Tipo = 2 },
                    new Usuario { Id = 3, Nombre = "Maria Valdiviezo", DNI = "12006499", Password = "12345678", Tipo = 2 },
                    new Usuario { Id = 4, Nombre = "Raul Caballero", DNI= "13121812", Password = "12345678", Tipo = 2},
                });

                var relacion = new List<UsuarioMateria>();
                usuarios.Skip(1).ToList().ForEach(usuario =>
                {
                    Random rand = new Random();
                    materias.ToList().ForEach(materia =>
                    {
                        var r = new Random(usuario.Id * materia.Id);
                        int estado = Convert.ToInt32(rand.Next(0,3)); //0 SIN CURSAR, 1 APROBADAS, 2 REGULAR
                        relacion.Add(new UsuarioMateria { IdUsuario = usuario.Id, IdMateria = materia.Id, Estado = estado });
                    });
                });
                context.UsuarioMaterias.AddRange(relacion);

            }

        }
    }
}
