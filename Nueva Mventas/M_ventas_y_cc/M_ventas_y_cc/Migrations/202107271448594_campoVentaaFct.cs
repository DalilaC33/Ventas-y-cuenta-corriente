namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class campoVentaaFct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FACTURAs", "VENTAId_VENTAId", c => c.Int());
            CreateIndex("dbo.FACTURAs", "VENTAId_VENTAId");
            AddForeignKey("dbo.FACTURAs", "VENTAId_VENTAId", "dbo.VENTAs", "VENTAId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FACTURAs", "VENTAId_VENTAId", "dbo.VENTAs");
            DropIndex("dbo.FACTURAs", new[] { "VENTAId_VENTAId" });
            DropColumn("dbo.FACTURAs", "VENTAId_VENTAId");
        }
    }
}
