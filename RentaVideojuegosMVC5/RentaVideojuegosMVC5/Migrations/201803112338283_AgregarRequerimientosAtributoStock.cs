namespace RentaVideojuegosMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarRequerimientosAtributoStock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videojuegoes", "NumeroDisponiblre", c => c.Int(nullable: false));
            AlterColumn("dbo.Videojuegoes", "Nombre", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Videojuegoes", "FechaDePublicacion", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Videojuegoes", "FechaDePublicacion", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Videojuegoes", "Nombre", c => c.String());
            DropColumn("dbo.Videojuegoes", "NumeroDisponiblre");
        }
    }
}
