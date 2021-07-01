namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addVDModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VENTAS_DETALLES",
                c => new
                    {
                        VENTAS_DETALLESId = c.Int(nullable: false, identity: true),
                        cantidad = c.Int(nullable: false),
                        precio_unitario = c.Single(nullable: false),
                        subtotal = c.Single(nullable: false),
                        PRODUCTOId_PRODUCTOId = c.Int(),
                        VENTAId_VENTAId = c.Int(),
                    })
                .PrimaryKey(t => t.VENTAS_DETALLESId)
                .ForeignKey("dbo.PRODUCTOes", t => t.PRODUCTOId_PRODUCTOId)
                .ForeignKey("dbo.VENTAs", t => t.VENTAId_VENTAId)
                .Index(t => t.PRODUCTOId_PRODUCTOId)
                .Index(t => t.VENTAId_VENTAId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VENTAS_DETALLES", "VENTAId_VENTAId", "dbo.VENTAs");
            DropForeignKey("dbo.VENTAS_DETALLES", "PRODUCTOId_PRODUCTOId", "dbo.PRODUCTOes");
            DropIndex("dbo.VENTAS_DETALLES", new[] { "VENTAId_VENTAId" });
            DropIndex("dbo.VENTAS_DETALLES", new[] { "PRODUCTOId_PRODUCTOId" });
            DropTable("dbo.VENTAS_DETALLES");
        }
    }
}
