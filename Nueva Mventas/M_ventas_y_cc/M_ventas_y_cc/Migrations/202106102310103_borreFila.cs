namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class borreFila : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SESIONs", "ENCARGADOSId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SESIONs", "ENCARGADOSId", c => c.Int(nullable: false));
        }
    }
}
