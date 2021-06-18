namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdedDVENTAModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VENTAs",
                c => new
                    {
                        VENTAId = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        estado = c.String(),
                        total = c.Single(nullable: false),
                        iva = c.Single(nullable: false),
                        CLIENTEId_CLIENTEId = c.Int(),
                        ENCARGADOId_ENCARGADOId = c.Int(),
                    })
                .PrimaryKey(t => t.VENTAId)
                .ForeignKey("dbo.CLIENTEs", t => t.CLIENTEId_CLIENTEId)
                .ForeignKey("dbo.ENCARGADOes", t => t.ENCARGADOId_ENCARGADOId)
                .Index(t => t.CLIENTEId_CLIENTEId)
                .Index(t => t.ENCARGADOId_ENCARGADOId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VENTAs", "ENCARGADOId_ENCARGADOId", "dbo.ENCARGADOes");
            DropForeignKey("dbo.VENTAs", "CLIENTEId_CLIENTEId", "dbo.CLIENTEs");
            DropIndex("dbo.VENTAs", new[] { "ENCARGADOId_ENCARGADOId" });
            DropIndex("dbo.VENTAs", new[] { "CLIENTEId_CLIENTEId" });
            DropTable("dbo.VENTAs");
        }
    }
}
