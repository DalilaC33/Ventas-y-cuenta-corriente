namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPRODUCTOModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PRODUCTOes",
                c => new
                    {
                        PRODUCTOId = c.Int(nullable: false, identity: true),
                        codigo = c.String(),
                        nombre = c.String(),
                        descripcion = c.String(),
                        precio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PRODUCTOId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PRODUCTOes");
        }
    }
}
