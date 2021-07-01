namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCLIENTEyENCARGADOModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CLIENTEs", "ruc", c => c.String());
            DropColumn("dbo.CLIENTEs", "apellido");
            DropColumn("dbo.ENCARGADOes", "apellido");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ENCARGADOes", "apellido", c => c.String());
            AddColumn("dbo.CLIENTEs", "apellido", c => c.String());
            AlterColumn("dbo.CLIENTEs", "ruc", c => c.Int(nullable: false));
        }
    }
}
