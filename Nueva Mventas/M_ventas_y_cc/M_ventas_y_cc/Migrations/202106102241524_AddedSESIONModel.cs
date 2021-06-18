namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSESIONModel : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.SESIONId)
                .ForeignKey("dbo.ENCARGADOes", t => t.ENCARGADOId_ENCARGADOId)
                .Index(t => t.ENCARGADOId_ENCARGADOId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SESIONs", "ENCARGADOId_ENCARGADOId", "dbo.ENCARGADOes");
            DropIndex("dbo.SESIONs", new[] { "ENCARGADOId_ENCARGADOId" });
            DropTable("dbo.SESIONs");
        }
    }
}
