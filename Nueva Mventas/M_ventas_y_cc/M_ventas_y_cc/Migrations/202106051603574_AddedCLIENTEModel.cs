namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCLIENTEModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CLIENTEs",
                c => new
                    {
                        CLIENTEId = c.Int(nullable: false, identity: true),
                        ruc = c.Int(nullable: false),
                        nombre = c.String(),
                        apellido = c.String(),
                        telefono = c.String(),
                        correo = c.String(),
                        credito = c.String(),
                    })
                .PrimaryKey(t => t.CLIENTEId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CLIENTEs");
        }
    }
}
