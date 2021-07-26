namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCamposTFB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BANCOes", "numBanco", c => c.Int(nullable: false));
            AddColumn("dbo.FORMAS_DE_PAGO", "numFDP", c => c.Int(nullable: false));
            AddColumn("dbo.TARJETAs", "numTarjeta", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TARJETAs", "numTarjeta");
            DropColumn("dbo.FORMAS_DE_PAGO", "numFDP");
            DropColumn("dbo.BANCOes", "numBanco");
        }
    }
}
