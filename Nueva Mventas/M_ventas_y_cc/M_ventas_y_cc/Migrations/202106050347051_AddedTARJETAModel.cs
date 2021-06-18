namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTARJETAModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TARJETAs",
                c => new
                    {
                        TARJETAId = c.Int(nullable: false, identity: true),
                        marca = c.String(),
                        tipo = c.String(),
                    })
                .PrimaryKey(t => t.TARJETAId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TARJETAs");
        }
    }
}
