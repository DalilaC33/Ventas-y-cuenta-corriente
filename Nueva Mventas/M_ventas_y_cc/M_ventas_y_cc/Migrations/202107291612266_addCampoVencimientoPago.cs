namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCampoVencimientoPago : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PAGOS", "fechaVenc", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PAGOS", "fechaVenc");
        }
    }
}
