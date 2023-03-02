namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fatura : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Faturalars", "Toplam", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Faturalars", "Saat", c => c.String(maxLength: 5, fixedLength: true, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Faturalars", "Saat", c => c.DateTime(nullable: false));
            DropColumn("dbo.Faturalars", "Toplam");
        }
    }
}
