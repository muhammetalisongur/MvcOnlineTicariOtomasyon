namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonelDepartmanID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Personels", "Departman_DepartmanID", "dbo.Departmen");
            DropIndex("dbo.Personels", new[] { "Departman_DepartmanID" });
            RenameColumn(table: "dbo.Personels", name: "Departman_DepartmanID", newName: "DepartmanID");
            AlterColumn("dbo.Personels", "DepartmanID", c => c.Int(nullable: false));
            CreateIndex("dbo.Personels", "DepartmanID");
            AddForeignKey("dbo.Personels", "DepartmanID", "dbo.Departmen", "DepartmanID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personels", "DepartmanID", "dbo.Departmen");
            DropIndex("dbo.Personels", new[] { "DepartmanID" });
            AlterColumn("dbo.Personels", "DepartmanID", c => c.Int());
            RenameColumn(table: "dbo.Personels", name: "DepartmanID", newName: "Departman_DepartmanID");
            CreateIndex("dbo.Personels", "Departman_DepartmanID");
            AddForeignKey("dbo.Personels", "Departman_DepartmanID", "dbo.Departmen", "DepartmanID");
        }
    }
}
