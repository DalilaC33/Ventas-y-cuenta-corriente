namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNCModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NOTAS_DE_CREDITO",
                c => new
                    {
                        NOTAS_DE_CREDITOId = c.Int(nullable: false, identity: true),
                        fecha_emision = c.DateTime(nullable: false),
                        concepto = c.String(),
                        razon = c.String(),
                        monto = c.Single(nullable: false),
                        iva = c.Single(nullable: false),
                        ENCARGADOId_ENCARGADOId = c.Int(),
                        FACTURAId_FACTURAId = c.Int(),
                    })
                .PrimaryKey(t => t.NOTAS_DE_CREDITOId)
                .ForeignKey("dbo.ENCARGADOes", t => t.ENCARGADOId_ENCARGADOId)
                .ForeignKey("dbo.FACTURAs", t => t.FACTURAId_FACTURAId)
                .Index(t => t.ENCARGADOId_ENCARGADOId)
                .Index(t => t.FACTURAId_FACTURAId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NOTAS_DE_CREDITO", "FACTURAId_FACTURAId", "dbo.FACTURAs");
            DropForeignKey("dbo.NOTAS_DE_CREDITO", "ENCARGADOId_ENCARGADOId", "dbo.ENCARGADOes");
            DropIndex("dbo.NOTAS_DE_CREDITO", new[] { "FACTURAId_FACTURAId" });
            DropIndex("dbo.NOTAS_DE_CREDITO", new[] { "ENCARGADOId_ENCARGADOId" });
            DropTable("dbo.NOTAS_DE_CREDITO");
        }
    }
}
