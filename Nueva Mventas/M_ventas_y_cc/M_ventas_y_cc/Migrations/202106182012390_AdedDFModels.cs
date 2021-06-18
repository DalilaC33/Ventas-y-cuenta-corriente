namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdedDFModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DETALLES_FACTURA",
                c => new
                    {
                        DETALLES_FACTURAId = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        iva = c.Single(nullable: false),
                        total = c.Single(nullable: false),
                        estado = c.String(),
                        DETALLE_CREDITOId_DETALLE_CREDITOId = c.Int(),
                        ENCARGADOId_ENCARGADOId = c.Int(),
                    })
                .PrimaryKey(t => t.DETALLES_FACTURAId)
                .ForeignKey("dbo.DETALLE_CREDITO", t => t.DETALLE_CREDITOId_DETALLE_CREDITOId)
                .ForeignKey("dbo.ENCARGADOes", t => t.ENCARGADOId_ENCARGADOId)
                .Index(t => t.DETALLE_CREDITOId_DETALLE_CREDITOId)
                .Index(t => t.ENCARGADOId_ENCARGADOId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DETALLES_FACTURA", "ENCARGADOId_ENCARGADOId", "dbo.ENCARGADOes");
            DropForeignKey("dbo.DETALLES_FACTURA", "DETALLE_CREDITOId_DETALLE_CREDITOId", "dbo.DETALLE_CREDITO");
            DropIndex("dbo.DETALLES_FACTURA", new[] { "ENCARGADOId_ENCARGADOId" });
            DropIndex("dbo.DETALLES_FACTURA", new[] { "DETALLE_CREDITOId_DETALLE_CREDITOId" });
            DropTable("dbo.DETALLES_FACTURA");
        }
    }
}
