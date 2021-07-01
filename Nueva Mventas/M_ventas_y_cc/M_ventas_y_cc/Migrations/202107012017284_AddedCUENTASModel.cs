namespace M_ventas_y_cc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCUENTASModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CUENTAS",
                c => new
                    {
                        CUENTASId = c.Int(nullable: false, identity: true),
                        denominacion = c.String(),
                        codigo = c.Int(nullable: false),
                        estado = c.String(),
                    })
                .PrimaryKey(t => t.CUENTASId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CUENTAS");
        }
    }
}
