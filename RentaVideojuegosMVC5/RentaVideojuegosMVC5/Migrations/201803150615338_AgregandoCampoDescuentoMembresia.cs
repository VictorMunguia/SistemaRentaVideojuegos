namespace RentaVideojuegosMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregandoCampoDescuentoMembresia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Membresias", "Descuento", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Membresias", "Descuento");
        }
    }
}
