namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class detaycreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Detays",
                c => new
                    {
                        DetayID = c.Int(nullable: false, identity: true),
                        urunad = c.String(maxLength: 30, unicode: false),
                        urunbilgi = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.DetayID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Detays");
        }
    }
}
