namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSESIONESModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SESIONs", "ENCARGADOId_ENCARGADOId", "dbo.ENCARGADOes");
            DropIndex("dbo.SESIONs", new[] { "ENCARGADOId_ENCARGADOId" });
            CreateTable(
                "dbo.SESIONES",
                c => new
                    {
                        SESIONESId = c.Int(nullable: false, identity: true),
                        ENCARGADOSId = c.Int(nullable: false),
                        usuario = c.String(),
                        contraseña = c.String(),
                        ENCARGADOId_ENCARGADOId = c.Int(),
                    })
                .PrimaryKey(t => t.SESIONESId)
                .ForeignKey("dbo.ENCARGADOes", t => t.ENCARGADOId_ENCARGADOId)
                .Index(t => t.ENCARGADOId_ENCARGADOId);
            
            DropTable("dbo.SESIONs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SESIONs",
                c => new
                    {
                        SESIONId = c.Int(nullable: false, identity: true),
                        ENCARGADOSId = c.Int(nullable: false),
                        usuario = c.String(),
                        contraseña = c.String(),
                        ENCARGADOId_ENCARGADOId = c.Int(),
                    })
                .PrimaryKey(t => t.SESIONId);
            
            DropForeignKey("dbo.SESIONES", "ENCARGADOId_ENCARGADOId", "dbo.ENCARGADOes");
            DropIndex("dbo.SESIONES", new[] { "ENCARGADOId_ENCARGADOId" });
            DropTable("dbo.SESIONES");
            CreateIndex("dbo.SESIONs", "ENCARGADOId_ENCARGADOId");
            AddForeignKey("dbo.SESIONs", "ENCARGADOId_ENCARGADOId", "dbo.ENCARGADOes", "ENCARGADOId");
        }
    }
}
