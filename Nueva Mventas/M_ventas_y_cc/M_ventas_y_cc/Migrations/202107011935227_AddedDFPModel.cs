namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDFPModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DETALLES_FACT_PAGO",
                c => new
                    {
                        DETALLES_FACT_PAGOId = c.Int(nullable: false, identity: true),
                        DETALLE_CREDITOId_DETALLE_CREDITOId = c.Int(),
                        PAGOSId_PAGOSId = c.Int(),
                    })
                .PrimaryKey(t => t.DETALLES_FACT_PAGOId)
                .ForeignKey("dbo.DETALLE_CREDITO", t => t.DETALLE_CREDITOId_DETALLE_CREDITOId)
                .ForeignKey("dbo.PAGOS", t => t.PAGOSId_PAGOSId)
                .Index(t => t.DETALLE_CREDITOId_DETALLE_CREDITOId)
                .Index(t => t.PAGOSId_PAGOSId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DETALLES_FACT_PAGO", "PAGOSId_PAGOSId", "dbo.PAGOS");
            DropForeignKey("dbo.DETALLES_FACT_PAGO", "DETALLE_CREDITOId_DETALLE_CREDITOId", "dbo.DETALLE_CREDITO");
            DropIndex("dbo.DETALLES_FACT_PAGO", new[] { "PAGOSId_PAGOSId" });
            DropIndex("dbo.DETALLES_FACT_PAGO", new[] { "DETALLE_CREDITOId_DETALLE_CREDITOId" });
            DropTable("dbo.DETALLES_FACT_PAGO");
        }
    }
}
