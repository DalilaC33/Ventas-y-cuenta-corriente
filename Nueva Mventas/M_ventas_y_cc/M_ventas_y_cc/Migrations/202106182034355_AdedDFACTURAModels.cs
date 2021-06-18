namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdedDFACTURAModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FACTURAs",
                c => new
                    {
                        FACTURAId = c.Int(nullable: false, identity: true),
                        estado = c.String(),
                        total = c.Single(nullable: false),
                        iva = c.Single(nullable: false),
                        saldo = c.String(),
                        CLIENTEId_CLIENTEId = c.Int(),
                        DETALLES_FACCTURAId_DETALLES_FACTURAId = c.Int(),
                        ENCARGADOId_ENCARGADOId = c.Int(),
                    })
                .PrimaryKey(t => t.FACTURAId)
                .ForeignKey("dbo.CLIENTEs", t => t.CLIENTEId_CLIENTEId)
                .ForeignKey("dbo.DETALLES_FACTURA", t => t.DETALLES_FACCTURAId_DETALLES_FACTURAId)
                .ForeignKey("dbo.ENCARGADOes", t => t.ENCARGADOId_ENCARGADOId)
                .Index(t => t.CLIENTEId_CLIENTEId)
                .Index(t => t.DETALLES_FACCTURAId_DETALLES_FACTURAId)
                .Index(t => t.ENCARGADOId_ENCARGADOId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FACTURAs", "ENCARGADOId_ENCARGADOId", "dbo.ENCARGADOes");
            DropForeignKey("dbo.FACTURAs", "DETALLES_FACCTURAId_DETALLES_FACTURAId", "dbo.DETALLES_FACTURA");
            DropForeignKey("dbo.FACTURAs", "CLIENTEId_CLIENTEId", "dbo.CLIENTEs");
            DropIndex("dbo.FACTURAs", new[] { "ENCARGADOId_ENCARGADOId" });
            DropIndex("dbo.FACTURAs", new[] { "DETALLES_FACCTURAId_DETALLES_FACTURAId" });
            DropIndex("dbo.FACTURAs", new[] { "CLIENTEId_CLIENTEId" });
            DropTable("dbo.FACTURAs");
        }
    }
}
