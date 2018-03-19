namespace AISLTP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courts",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Txt = c.String(nullable: false),
                        Prim = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Licoes",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Fam = c.String(nullable: false),
                        Ima = c.String(nullable: false),
                        Otc = c.String(nullable: false),
                        Dr = c.String(nullable: false),
                        Pasport = c.String(),
                        Nac = c.String(nullable: false),
                        Obl = c.String(nullable: false),
                        Rn = c.String(nullable: false),
                        Np = c.String(nullable: false),
                        Prim = c.String(nullable: false),
                        Vneshnost = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sotrs",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Cod_sotr = c.String(nullable: false),
                        Dvi = c.DateTime(nullable: false),
                        Ima = c.String(nullable: false),
                        Fio = c.String(nullable: false),
                        Otc = c.String(nullable: false),
                        Dr = c.DateTime(nullable: false),
                        Sex = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sotrs");
            DropTable("dbo.Licoes");
            DropTable("dbo.Courts");
        }
    }
}
