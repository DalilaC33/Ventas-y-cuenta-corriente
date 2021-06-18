namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBANCOModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BANCOes",
                c => new
                    {
                        BANCOId = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.BANCOId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BANCOes");
        }
    }
}
