namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yapilacak : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Yapilacaks",
                c => new
                    {
                        YapilacakID = c.Int(nullable: false, identity: true),
                        Baslik = c.String(maxLength: 100, unicode: false),
                        Durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.YapilacakID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Yapilacaks");
        }
    }
}
