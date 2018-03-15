namespace RentaVideojuegosMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregandoCampoDescuentoMembresia2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GeneroClientes (Nombre) VALUES ('Hombre') ");
            Sql("INSERT INTO GeneroClientes (Nombre) VALUES ('Mujer') ");
            Sql("INSERT INTO Membresias (Nombre,Descuento) VALUES ('Sin membresia','0') ");
            Sql("INSERT INTO Membresias (Nombre,Descuento) VALUES ('Bronce','15') ");
            Sql("INSERT INTO Membresias (Nombre,Descuento) VALUES ('Plata','30') ");
            Sql("INSERT INTO Membresias (Nombre,Descuento) VALUES ('Oro','45') ");
        }
        
        public override void Down()
        {
        }
    }
}
