namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedENM : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ENCARGADOes", "encargadoNum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ENCARGADOes", "encargadoNum");
        }
    }
}
