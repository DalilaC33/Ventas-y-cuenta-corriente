namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedENCARGADOModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ENCARGADOes",
                c => new
                    {
                        ENCARGADOId = c.Int(nullable: false, identity: true),
                        usuario = c.String(),
                        contraseña = c.String(),
                        nombre = c.String(),
                        apellido = c.String(),
                        ci = c.String(),
                        telefono = c.String(),
                        correo = c.String(),
                        direccion = c.String(),
                    })
                .PrimaryKey(t => t.ENCARGADOId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ENCARGADOes");
        }
    }
}
