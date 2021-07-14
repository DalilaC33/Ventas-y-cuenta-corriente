namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changePagos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PAGOS", "DETALLES_DE_PAGO_DETALLES_DE_PAGOId", "dbo.DETALLES_DE_PAGO");
            DropIndex("dbo.PAGOS", new[] { "DETALLES_DE_PAGO_DETALLES_DE_PAGOId" });
            AddColumn("dbo.DETALLE_CREDITO", "PAGOSId_PAGOSId", c => c.Int());
            AddColumn("dbo.DETALLES_DE_PAGO", "PAGOSId_PAGOSId", c => c.Int());
            CreateIndex("dbo.DETALLE_CREDITO", "PAGOSId_PAGOSId");
            CreateIndex("dbo.DETALLES_DE_PAGO", "PAGOSId_PAGOSId");
            AddForeignKey("dbo.DETALLE_CREDITO", "PAGOSId_PAGOSId", "dbo.PAGOS", "PAGOSId");
            AddForeignKey("dbo.DETALLES_DE_PAGO", "PAGOSId_PAGOSId", "dbo.PAGOS", "PAGOSId");
            DropColumn("dbo.PAGOS", "DETALLES_DE_PAGO_DETALLES_DE_PAGOId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PAGOS", "DETALLES_DE_PAGO_DETALLES_DE_PAGOId", c => c.Int());
            DropForeignKey("dbo.DETALLES_DE_PAGO", "PAGOSId_PAGOSId", "dbo.PAGOS");
            DropForeignKey("dbo.DETALLE_CREDITO", "PAGOSId_PAGOSId", "dbo.PAGOS");
            DropIndex("dbo.DETALLES_DE_PAGO", new[] { "PAGOSId_PAGOSId" });
            DropIndex("dbo.DETALLE_CREDITO", new[] { "PAGOSId_PAGOSId" });
            DropColumn("dbo.DETALLES_DE_PAGO", "PAGOSId_PAGOSId");
            DropColumn("dbo.DETALLE_CREDITO", "PAGOSId_PAGOSId");
            CreateIndex("dbo.PAGOS", "DETALLES_DE_PAGO_DETALLES_DE_PAGOId");
            AddForeignKey("dbo.PAGOS", "DETALLES_DE_PAGO_DETALLES_DE_PAGOId", "dbo.DETALLES_DE_PAGO", "DETALLES_DE_PAGOId");
        }
    }
}
