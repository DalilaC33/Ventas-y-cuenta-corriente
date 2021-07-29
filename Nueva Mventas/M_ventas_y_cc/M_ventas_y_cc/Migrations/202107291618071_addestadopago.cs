namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addestadopago : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PAGOS", "estado", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PAGOS", "estado");
        }
    }
}
