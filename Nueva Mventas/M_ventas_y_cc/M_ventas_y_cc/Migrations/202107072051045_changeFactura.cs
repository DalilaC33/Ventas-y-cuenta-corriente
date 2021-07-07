namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeFactura : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FACTURAs", "DETALLES_FACCTURAId_DETALLES_FACTURAId", "dbo.DETALLES_FACTURA");
            DropIndex("dbo.FACTURAs", new[] { "DETALLES_FACCTURAId_DETALLES_FACTURAId" });
            AddColumn("dbo.DETALLES_FACTURA", "FACTURAId_FACTURAId", c => c.Int());
            AddColumn("dbo.FACTURAs", "condicion", c => c.String());
            CreateIndex("dbo.DETALLES_FACTURA", "FACTURAId_FACTURAId");
            AddForeignKey("dbo.DETALLES_FACTURA", "FACTURAId_FACTURAId", "dbo.FACTURAs", "FACTURAId");
            DropColumn("dbo.FACTURAs", "DETALLES_FACCTURAId_DETALLES_FACTURAId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FACTURAs", "DETALLES_FACCTURAId_DETALLES_FACTURAId", c => c.Int());
            DropForeignKey("dbo.DETALLES_FACTURA", "FACTURAId_FACTURAId", "dbo.FACTURAs");
            DropIndex("dbo.DETALLES_FACTURA", new[] { "FACTURAId_FACTURAId" });
            DropColumn("dbo.FACTURAs", "condicion");
            DropColumn("dbo.DETALLES_FACTURA", "FACTURAId_FACTURAId");
            CreateIndex("dbo.FACTURAs", "DETALLES_FACCTURAId_DETALLES_FACTURAId");
            AddForeignKey("dbo.FACTURAs", "DETALLES_FACCTURAId_DETALLES_FACTURAId", "dbo.DETALLES_FACTURA", "DETALLES_FACTURAId");
        }
    }
}
