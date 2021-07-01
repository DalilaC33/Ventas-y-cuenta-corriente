namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDPModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DETALLES_DE_PAGO",
                c => new
                    {
                        DETALLES_DE_PAGOId = c.Int(nullable: false, identity: true),
                        monto = c.Single(nullable: false),
                        vuelto = c.Single(nullable: false),
                        numero = c.Int(nullable: false),
                        BANCOId_BANCOId = c.Int(),
                        FORMAS_DE_PAGOId_FORMAS_DE_PAGOId = c.Int(),
                        TARJETAId_TARJETAId = c.Int(),
                    })
                .PrimaryKey(t => t.DETALLES_DE_PAGOId)
                .ForeignKey("dbo.BANCOes", t => t.BANCOId_BANCOId)
                .ForeignKey("dbo.FORMAS_DE_PAGO", t => t.FORMAS_DE_PAGOId_FORMAS_DE_PAGOId)
                .ForeignKey("dbo.TARJETAs", t => t.TARJETAId_TARJETAId)
                .Index(t => t.BANCOId_BANCOId)
                .Index(t => t.FORMAS_DE_PAGOId_FORMAS_DE_PAGOId)
                .Index(t => t.TARJETAId_TARJETAId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DETALLES_DE_PAGO", "TARJETAId_TARJETAId", "dbo.TARJETAs");
            DropForeignKey("dbo.DETALLES_DE_PAGO", "FORMAS_DE_PAGOId_FORMAS_DE_PAGOId", "dbo.FORMAS_DE_PAGO");
            DropForeignKey("dbo.DETALLES_DE_PAGO", "BANCOId_BANCOId", "dbo.BANCOes");
            DropIndex("dbo.DETALLES_DE_PAGO", new[] { "TARJETAId_TARJETAId" });
            DropIndex("dbo.DETALLES_DE_PAGO", new[] { "FORMAS_DE_PAGOId_FORMAS_DE_PAGOId" });
            DropIndex("dbo.DETALLES_DE_PAGO", new[] { "BANCOId_BANCOId" });
            DropTable("dbo.DETALLES_DE_PAGO");
        }
    }
}
