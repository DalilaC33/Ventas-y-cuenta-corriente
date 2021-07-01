namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedASIENTOModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ASIENTOes",
                c => new
                    {
                        ASIENTOId = c.Int(nullable: false, identity: true),
                        numero = c.Single(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        descripcion = c.String(),
                        totalDEBE = c.Single(nullable: false),
                        totalHABER = c.Single(nullable: false),
                        fecha_creacion = c.DateTime(nullable: false),
                        estado = c.String(),
                    })
                .PrimaryKey(t => t.ASIENTOId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ASIENTOes");
        }
    }
}
