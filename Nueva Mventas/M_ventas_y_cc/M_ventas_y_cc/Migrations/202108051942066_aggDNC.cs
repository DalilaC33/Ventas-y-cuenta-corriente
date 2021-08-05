namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aggDNC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DETALLES_NOTAS_DE_CREDITO",
                c => new
                    {
                        DETALLES_NOTAS_DE_CREDITOId = c.Int(nullable: false, identity: true),
                        numDetalleNC = c.Int(nullable: false),
                        cantidad = c.Int(nullable: false),
                        subtotal = c.Single(nullable: false),
                        NOTAS_DE_CREDITOId_NOTAS_DE_CREDITOId = c.Int(),
                        PRODUCTOId_PRODUCTOId = c.Int(),
                    })
                .PrimaryKey(t => t.DETALLES_NOTAS_DE_CREDITOId)
                .ForeignKey("dbo.NOTAS_DE_CREDITO", t => t.NOTAS_DE_CREDITOId_NOTAS_DE_CREDITOId)
                .ForeignKey("dbo.PRODUCTOes", t => t.PRODUCTOId_PRODUCTOId)
                .Index(t => t.NOTAS_DE_CREDITOId_NOTAS_DE_CREDITOId)
                .Index(t => t.PRODUCTOId_PRODUCTOId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DETALLES_NOTAS_DE_CREDITO", "PRODUCTOId_PRODUCTOId", "dbo.PRODUCTOes");
            DropForeignKey("dbo.DETALLES_NOTAS_DE_CREDITO", "NOTAS_DE_CREDITOId_NOTAS_DE_CREDITOId", "dbo.NOTAS_DE_CREDITO");
            DropIndex("dbo.DETALLES_NOTAS_DE_CREDITO", new[] { "PRODUCTOId_PRODUCTOId" });
            DropIndex("dbo.DETALLES_NOTAS_DE_CREDITO", new[] { "NOTAS_DE_CREDITOId_NOTAS_DE_CREDITOId" });
            DropTable("dbo.DETALLES_NOTAS_DE_CREDITO");
        }
    }
}
