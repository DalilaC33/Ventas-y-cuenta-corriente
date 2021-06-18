namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFORMAS_DE_PAGOModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FORMAS_DE_PAGO",
                c => new
                    {
                        FORMAS_DE_PAGOId = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.FORMAS_DE_PAGOId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FORMAS_DE_PAGO");
        }
    }
}
