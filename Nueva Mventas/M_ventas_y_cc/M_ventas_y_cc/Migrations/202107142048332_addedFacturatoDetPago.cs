namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedFacturatoDetPago : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DETALLES_DE_PAGO", "FACTURAId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DETALLES_DE_PAGO", "FACTURAId");
        }
    }
}
