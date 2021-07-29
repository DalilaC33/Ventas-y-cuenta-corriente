namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFactPagos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PAGOS", "FACTURAId_FACTURAId", c => c.Int());
            CreateIndex("dbo.PAGOS", "FACTURAId_FACTURAId");
            AddForeignKey("dbo.PAGOS", "FACTURAId_FACTURAId", "dbo.FACTURAs", "FACTURAId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PAGOS", "FACTURAId_FACTURAId", "dbo.FACTURAs");
            DropIndex("dbo.PAGOS", new[] { "FACTURAId_FACTURAId" });
            DropColumn("dbo.PAGOS", "FACTURAId_FACTURAId");
        }
    }
}
