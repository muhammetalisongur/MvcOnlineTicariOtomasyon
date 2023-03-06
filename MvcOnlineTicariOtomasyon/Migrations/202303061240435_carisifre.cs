namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carisifre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carilers", "Sifre", c => c.String(maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carilers", "Sifre");
        }
    }
}
