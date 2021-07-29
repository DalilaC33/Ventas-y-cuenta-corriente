namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambioDetFact : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DETALLES_FACTURA", "DETALLE_CREDITOId_DETALLE_CREDITOId", "dbo.DETALLE_CREDITO");
            DropIndex("dbo.DETALLES_FACTURA", new[] { "DETALLE_CREDITOId_DETALLE_CREDITOId" });
            AlterColumn("dbo.FACTURAs", "factNum", c => c.String());
            DropColumn("dbo.DETALLES_FACTURA", "DETALLE_CREDITOId_DETALLE_CREDITOId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DETALLES_FACTURA", "DETALLE_CREDITOId_DETALLE_CREDITOId", c => c.Int());
            AlterColumn("dbo.FACTURAs", "factNum", c => c.Int(nullable: false));
            CreateIndex("dbo.DETALLES_FACTURA", "DETALLE_CREDITOId_DETALLE_CREDITOId");
            AddForeignKey("dbo.DETALLES_FACTURA", "DETALLE_CREDITOId_DETALLE_CREDITOId", "dbo.DETALLE_CREDITO", "DETALLE_CREDITOId");
        }
    }
}
