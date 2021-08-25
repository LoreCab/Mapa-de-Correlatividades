namespace Universidad.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Materias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 200, unicode: false),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MateriaPadres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdMateria = c.Int(nullable: false),
                        IdPadre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materias", t => t.IdMateria, cascadeDelete: true)
                .Index(t => t.IdMateria);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 200, unicode: false),
                        DNI = c.String(maxLength: 20, unicode: false),
                        Password = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsuarioMaterias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUsuario = c.Int(nullable: false),
                        IdMateria = c.Int(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materias", t => t.IdMateria, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.IdUsuario, cascadeDelete: true)
                .Index(t => t.IdUsuario)
                .Index(t => t.IdMateria);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioMaterias", "IdUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioMaterias", "IdMateria", "dbo.Materias");
            DropForeignKey("dbo.MateriaPadres", "IdMateria", "dbo.Materias");
            DropIndex("dbo.UsuarioMaterias", new[] { "IdMateria" });
            DropIndex("dbo.UsuarioMaterias", new[] { "IdUsuario" });
            DropIndex("dbo.MateriaPadres", new[] { "IdMateria" });
            DropTable("dbo.UsuarioMaterias");
            DropTable("dbo.Usuarios");
            DropTable("dbo.MateriaPadres");
            DropTable("dbo.Materias");
        }
    }
}
