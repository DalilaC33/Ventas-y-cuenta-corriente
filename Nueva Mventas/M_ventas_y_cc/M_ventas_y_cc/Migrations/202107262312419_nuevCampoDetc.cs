namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevCampoDetc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DETALLE_CREDITO", "numDetCredito", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DETALLE_CREDITO", "numDetCredito");
        }
    }
}
