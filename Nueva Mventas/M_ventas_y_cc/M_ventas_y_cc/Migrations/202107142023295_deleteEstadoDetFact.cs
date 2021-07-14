namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteEstadoDetFact : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DETALLES_FACTURA", "estado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DETALLES_FACTURA", "estado", c => c.String());
        }
    }
}
