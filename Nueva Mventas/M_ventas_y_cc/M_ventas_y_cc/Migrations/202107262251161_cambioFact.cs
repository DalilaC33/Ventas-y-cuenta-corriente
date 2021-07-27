namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambioFact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FACTURAs", "factNum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FACTURAs", "factNum");
        }
    }
}
