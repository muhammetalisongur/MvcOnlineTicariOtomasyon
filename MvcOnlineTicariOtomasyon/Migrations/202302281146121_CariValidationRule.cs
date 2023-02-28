namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CariValidationRule : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Carilers", "CariAd", c => c.String(nullable: false, maxLength: 30, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Carilers", "CariAd", c => c.String(maxLength: 30, unicode: false));
        }
    }
}
