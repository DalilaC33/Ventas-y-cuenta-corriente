namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSTYDEPModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DEPOSITOes",
                c => new
                    {
                        DEPOSITOId = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        direccion = c.String(),
                    })
                .PrimaryKey(t => t.DEPOSITOId);
            
            CreateTable(
                "dbo.STOCKs",
                c => new
                    {
                        STOCKId = c.Int(nullable: false, identity: true),
                        cantidad = c.Int(nullable: false),
                        DEPOSITOId_DEPOSITOId = c.Int(),
                        PRODUCTOId_PRODUCTOId = c.Int(),
                    })
                .PrimaryKey(t => t.STOCKId)
                .ForeignKey("dbo.DEPOSITOes", t => t.DEPOSITOId_DEPOSITOId)
                .ForeignKey("dbo.PRODUCTOes", t => t.PRODUCTOId_PRODUCTOId)
                .Index(t => t.DEPOSITOId_DEPOSITOId)
                .Index(t => t.PRODUCTOId_PRODUCTOId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.STOCKs", "PRODUCTOId_PRODUCTOId", "dbo.PRODUCTOes");
            DropForeignKey("dbo.STOCKs", "DEPOSITOId_DEPOSITOId", "dbo.DEPOSITOes");
            DropIndex("dbo.STOCKs", new[] { "PRODUCTOId_PRODUCTOId" });
            DropIndex("dbo.STOCKs", new[] { "DEPOSITOId_DEPOSITOId" });
            DropTable("dbo.STOCKs");
            DropTable("dbo.DEPOSITOes");
        }
    }
}
