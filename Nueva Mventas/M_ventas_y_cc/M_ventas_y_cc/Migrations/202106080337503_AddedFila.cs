namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFila : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.STOCKs", "Nombre_producto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.STOCKs", "Nombre_producto");
        }
    }
}
