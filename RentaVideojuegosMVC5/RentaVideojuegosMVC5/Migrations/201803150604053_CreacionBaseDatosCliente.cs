namespace RentaVideojuegosMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreacionBaseDatosCliente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 255),
                        Apellido = c.String(nullable: false, maxLength: 255),
                        Edad = c.Int(nullable: false),
                        EstaSuscrito = c.Boolean(nullable: false),
                        GeneroClienteId = c.Int(nullable: false),
                        MembresiaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GeneroClientes", t => t.GeneroClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Membresias", t => t.MembresiaId, cascadeDelete: true)
                .Index(t => t.GeneroClienteId)
                .Index(t => t.MembresiaId);
            
            CreateTable(
                "dbo.GeneroClientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Membresias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "MembresiaId", "dbo.Membresias");
            DropForeignKey("dbo.Clientes", "GeneroClienteId", "dbo.GeneroClientes");
            DropIndex("dbo.Clientes", new[] { "MembresiaId" });
            DropIndex("dbo.Clientes", new[] { "GeneroClienteId" });
            DropTable("dbo.Membresias");
            DropTable("dbo.GeneroClientes");
            DropTable("dbo.Clientes");
        }
    }
}
