namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeCreditos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CLIENTEs", "credito", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CLIENTEs", "credito", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
