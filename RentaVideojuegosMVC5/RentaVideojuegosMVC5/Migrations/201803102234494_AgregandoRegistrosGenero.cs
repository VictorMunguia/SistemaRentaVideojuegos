namespace RentaVideojuegosMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregandoRegistrosGenero : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Generoes (Nombre) VALUES ('Supervivencia') ");
            Sql("INSERT INTO Generoes (Nombre) VALUES ('Accion') ");
            Sql("INSERT INTO Generoes (Nombre) VALUES ('Terror') ");
            Sql("INSERT INTO Generoes (Nombre) VALUES ('Drama') ");
            Sql("INSERT INTO Generoes (Nombre) VALUES ('Estrategia') ");
            Sql("INSERT INTO Generoes (Nombre) VALUES ('RPG') ");
            Sql("INSERT INTO Edads (Nombre) VALUES ('Todos') ");
            Sql("INSERT INTO Edads (Nombre) VALUES ('Niños') ");
            Sql("INSERT INTO Edads (Nombre) VALUES ('Adolecentes') ");
            Sql("INSERT INTO Edads (Nombre) VALUES ('Adultos') ");
        }
        
        public override void Down()
        {
        }
    }
}
