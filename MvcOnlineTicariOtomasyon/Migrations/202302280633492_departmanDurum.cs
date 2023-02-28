namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class departmanDurum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departmen", "Durum", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departmen", "Durum");
        }
    }
}
