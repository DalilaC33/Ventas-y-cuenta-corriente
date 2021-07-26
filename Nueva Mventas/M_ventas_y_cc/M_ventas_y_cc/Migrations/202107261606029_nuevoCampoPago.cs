namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevoCampoPago : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PAGOS", "numPago", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PAGOS", "numPago");
        }
    }
}
