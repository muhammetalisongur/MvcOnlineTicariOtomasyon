namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        KullaniciAd = c.String(maxLength: 10, unicode: false),
                        Sifre = c.String(maxLength: 30, unicode: false),
                        Yetki = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Carilers",
                c => new
                    {
                        CariID = c.Int(nullable: false, identity: true),
                        CariAd = c.String(maxLength: 30, unicode: false),
                        CariSoyad = c.String(maxLength: 30, unicode: false),
                        CariSehir = c.String(maxLength: 13, unicode: false),
                        CariMail = c.String(maxLength: 50, unicode: false),
                        SatisHareket_SatisID = c.Int(),
                    })
                .PrimaryKey(t => t.CariID)
                .ForeignKey("dbo.SatisHarekets", t => t.SatisHareket_SatisID)
                .Index(t => t.SatisHareket_SatisID);
            
            CreateTable(
                "dbo.SatisHarekets",
                c => new
                    {
                        SatisID = c.Int(nullable: false, identity: true),
                        Tarih = c.DateTime(nullable: false),
                        Adet = c.Int(nullable: false),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ToplamTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SatisID);
            
            CreateTable(
                "dbo.Personels",
                c => new
                    {
                        PersonelID = c.Int(nullable: false, identity: true),
                        PersonelAd = c.String(maxLength: 30, unicode: false),
                        PersonelSoyad = c.String(maxLength: 30, unicode: false),
                        PersonelGorsel = c.String(maxLength: 250, unicode: false),
                        Departman_DepartmanID = c.Int(),
                        SatisHareket_SatisID = c.Int(),
                    })
                .PrimaryKey(t => t.PersonelID)
                .ForeignKey("dbo.Departmen", t => t.Departman_DepartmanID)
                .ForeignKey("dbo.SatisHarekets", t => t.SatisHareket_SatisID)
                .Index(t => t.Departman_DepartmanID)
                .Index(t => t.SatisHareket_SatisID);
            
            CreateTable(
                "dbo.Departmen",
                c => new
                    {
                        DepartmanID = c.Int(nullable: false, identity: true),
                        DepartmanAD = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.DepartmanID);
            
            CreateTable(
                "dbo.Uruns",
                c => new
                    {
                        UrunID = c.Int(nullable: false, identity: true),
                        UrunAd = c.String(maxLength: 30, unicode: false),
                        Marka = c.String(maxLength: 30, unicode: false),
                        Stok = c.Short(nullable: false),
                        AlisFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SatisFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Durum = c.Boolean(nullable: false),
                        UrunGorsel = c.String(maxLength: 250, unicode: false),
                        Kategori_KategoriID = c.Int(),
                        SatisHareket_SatisID = c.Int(),
                    })
                .PrimaryKey(t => t.UrunID)
                .ForeignKey("dbo.Kategoris", t => t.Kategori_KategoriID)
                .ForeignKey("dbo.SatisHarekets", t => t.SatisHareket_SatisID)
                .Index(t => t.Kategori_KategoriID)
                .Index(t => t.SatisHareket_SatisID);
            
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        KategoriID = c.Int(nullable: false, identity: true),
                        KategoriAd = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.KategoriID);
            
            CreateTable(
                "dbo.FaturaKalems",
                c => new
                    {
                        FaturaKalemID = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 100, unicode: false),
                        Miktar = c.Int(nullable: false),
                        BirimFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Faturalar_FaturaID = c.Int(),
                    })
                .PrimaryKey(t => t.FaturaKalemID)
                .ForeignKey("dbo.Faturalars", t => t.Faturalar_FaturaID)
                .Index(t => t.Faturalar_FaturaID);
            
            CreateTable(
                "dbo.Faturalars",
                c => new
                    {
                        FaturaID = c.Int(nullable: false, identity: true),
                        FaturaSeriNo = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        FaturaSiraNo = c.String(maxLength: 6, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                        VergiDairesi = c.String(maxLength: 60, unicode: false),
                        Saat = c.DateTime(nullable: false),
                        TeslimEden = c.String(maxLength: 30, unicode: false),
                        TeslimAlan = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.FaturaID);
            
            CreateTable(
                "dbo.Giders",
                c => new
                    {
                        GiderID = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 100, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.GiderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FaturaKalems", "Faturalar_FaturaID", "dbo.Faturalars");
            DropForeignKey("dbo.Uruns", "SatisHareket_SatisID", "dbo.SatisHarekets");
            DropForeignKey("dbo.Uruns", "Kategori_KategoriID", "dbo.Kategoris");
            DropForeignKey("dbo.Personels", "SatisHareket_SatisID", "dbo.SatisHarekets");
            DropForeignKey("dbo.Personels", "Departman_DepartmanID", "dbo.Departmen");
            DropForeignKey("dbo.Carilers", "SatisHareket_SatisID", "dbo.SatisHarekets");
            DropIndex("dbo.FaturaKalems", new[] { "Faturalar_FaturaID" });
            DropIndex("dbo.Uruns", new[] { "SatisHareket_SatisID" });
            DropIndex("dbo.Uruns", new[] { "Kategori_KategoriID" });
            DropIndex("dbo.Personels", new[] { "SatisHareket_SatisID" });
            DropIndex("dbo.Personels", new[] { "Departman_DepartmanID" });
            DropIndex("dbo.Carilers", new[] { "SatisHareket_SatisID" });
            DropTable("dbo.Giders");
            DropTable("dbo.Faturalars");
            DropTable("dbo.FaturaKalems");
            DropTable("dbo.Kategoris");
            DropTable("dbo.Uruns");
            DropTable("dbo.Departmen");
            DropTable("dbo.Personels");
            DropTable("dbo.SatisHarekets");
            DropTable("dbo.Carilers");
            DropTable("dbo.Admins");
        }
    }
}
