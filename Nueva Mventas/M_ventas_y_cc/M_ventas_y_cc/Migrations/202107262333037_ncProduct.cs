namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ncProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PRODUCTOes", "numPRODUCTO", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PRODUCTOes", "numPRODUCTO");
        }
    }
}
