namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ventaDetalleCampo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VENTAS_DETALLES", "numVentDet", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VENTAS_DETALLES", "numVentDet");
        }
    }
}
