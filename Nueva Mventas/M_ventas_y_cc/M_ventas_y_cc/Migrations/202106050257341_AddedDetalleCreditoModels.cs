namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDetalleCreditoModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DETALLE_CREDITO",
                c => new
                    {
                        DETALLE_CREDITOId = c.Int(nullable: false, identity: true),
                        MONTO_CUOTA = c.Int(nullable: false),
                        NRO_CUOTA = c.Int(nullable: false),
                        PAGADO = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DETALLE_CREDITOId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DETALLE_CREDITO");
        }
    }
}
