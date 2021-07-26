namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ventaCampos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VENTAs", "numVenta", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VENTAs", "numVenta");
        }
    }
}
