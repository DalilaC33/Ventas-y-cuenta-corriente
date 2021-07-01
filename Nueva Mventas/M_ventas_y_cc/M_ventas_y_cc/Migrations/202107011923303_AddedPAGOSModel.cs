namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPAGOSModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PAGOS",
                c => new
                    {
                        PAGOSId = c.Int(nullable: false, identity: true),
                        total = c.Single(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        CLIENTEId_CLIENTEId = c.Int(),
                        DETALLES_DE_PAGO_DETALLES_DE_PAGOId = c.Int(),
                        VENTAId_VENTAId = c.Int(),
                    })
                .PrimaryKey(t => t.PAGOSId)
                .ForeignKey("dbo.CLIENTEs", t => t.CLIENTEId_CLIENTEId)
                .ForeignKey("dbo.DETALLES_DE_PAGO", t => t.DETALLES_DE_PAGO_DETALLES_DE_PAGOId)
                .ForeignKey("dbo.VENTAs", t => t.VENTAId_VENTAId)
                .Index(t => t.CLIENTEId_CLIENTEId)
                .Index(t => t.DETALLES_DE_PAGO_DETALLES_DE_PAGOId)
                .Index(t => t.VENTAId_VENTAId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PAGOS", "VENTAId_VENTAId", "dbo.VENTAs");
            DropForeignKey("dbo.PAGOS", "DETALLES_DE_PAGO_DETALLES_DE_PAGOId", "dbo.DETALLES_DE_PAGO");
            DropForeignKey("dbo.PAGOS", "CLIENTEId_CLIENTEId", "dbo.CLIENTEs");
            DropIndex("dbo.PAGOS", new[] { "VENTAId_VENTAId" });
            DropIndex("dbo.PAGOS", new[] { "DETALLES_DE_PAGO_DETALLES_DE_PAGOId" });
            DropIndex("dbo.PAGOS", new[] { "CLIENTEId_CLIENTEId" });
            DropTable("dbo.PAGOS");
        }
    }
}
