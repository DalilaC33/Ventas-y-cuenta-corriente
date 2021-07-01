namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedASIENTOSDModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ASIENTOS_DETALLES",
                c => new
                    {
                        ASIENTOS_DETALLESId = c.Int(nullable: false, identity: true),
                        DEBE = c.Single(nullable: false),
                        HABER = c.Single(nullable: false),
                        estado = c.String(),
                        ASIENTOId_ASIENTOId = c.Int(),
                        CUENTASId_CUENTASId = c.Int(),
                    })
                .PrimaryKey(t => t.ASIENTOS_DETALLESId)
                .ForeignKey("dbo.ASIENTOes", t => t.ASIENTOId_ASIENTOId)
                .ForeignKey("dbo.CUENTAS", t => t.CUENTASId_CUENTASId)
                .Index(t => t.ASIENTOId_ASIENTOId)
                .Index(t => t.CUENTASId_CUENTASId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ASIENTOS_DETALLES", "CUENTASId_CUENTASId", "dbo.CUENTAS");
            DropForeignKey("dbo.ASIENTOS_DETALLES", "ASIENTOId_ASIENTOId", "dbo.ASIENTOes");
            DropIndex("dbo.ASIENTOS_DETALLES", new[] { "CUENTASId_CUENTASId" });
            DropIndex("dbo.ASIENTOS_DETALLES", new[] { "ASIENTOId_ASIENTOId" });
            DropTable("dbo.ASIENTOS_DETALLES");
        }
    }
}
