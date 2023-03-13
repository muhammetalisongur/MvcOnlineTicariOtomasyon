using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]

    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
      
        public ActionResult Index(string p)
        {
            var UrunListele = from x in c.Uruns select x;
            if (!string.IsNullOrEmpty(p))
            {
                UrunListele = UrunListele.Where(y => y.UrunAd.Contains(p));
            }
            return View(UrunListele.ToList());
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger = (from x in c.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.KategoriAd,
                                              Value = x.KategoriID.ToString()
                                          }).ToList();
            ViewBag.dgr = deger;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun u)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                u.UrunGorsel = "/Images/" + dosyaadi + uzanti;
            }
            u.Durum = true;
            c.Uruns.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger = c.Uruns.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger = (from x in c.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.KategoriAd,
                                              Value = x.KategoriID.ToString()
                                          }).ToList();
            ViewBag.dgr = deger;
            var urundeger = c.Uruns.Find(id);
            return View("UrunGetir", urundeger);
        }
        public ActionResult UrunGuncelle(Urun u, HttpPostedFileBase UrunGorsel)
        {

            var urn = c.Uruns.Find(u.UrunID);
            urn.AlisFiyat = u.AlisFiyat;
            urn.Durum = u.Durum;
            urn.KategoriID = u.KategoriID;
            urn.Marka = u.Marka;
            urn.SatisFiyat = u.SatisFiyat;
            urn.Stok = u.Stok;
            urn.UrunAd = u.UrunAd;

            if (ModelState.IsValid)
            {

                if (UrunGorsel != null)
                {

                    string dosyaadi = Path.GetFileName(UrunGorsel.FileName);
                    string yol = "/Images/" + dosyaadi;
                    UrunGorsel.SaveAs(Server.MapPath(yol));
                    urn.UrunGorsel = yol;
                }

            }
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UrunListesi()
        {
            var deger = c.Uruns.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            var deger1 = c.Uruns.Find(id);
            ViewBag.dgr1 = deger1.UrunID;
            ViewBag.dg2 = deger1.SatisFiyat;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket s)
        {

            var urunFiyat = c.Uruns.Where(x => x.UrunID == s.UrunID).Select(z => z.SatisFiyat).FirstOrDefault();
            var urunStok = c.Uruns.Where(x => x.UrunID == s.UrunID).Select(z => z.Stok).FirstOrDefault();


            if (urunStok >= s.Adet)
            {
                urunStok = (short)(urunStok - s.Adet);

                var kalanStok = c.Uruns.Find(s.UrunID);
                kalanStok.Stok = urunStok;

                s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                c.SatisHarekets.Add(s);
                c.SaveChanges();
                return RedirectToAction("Index", "Satis");
            }
            else
                return RedirectPermanent("~/Urun/UrunGetir/" + s.UrunID);


        }
    }
}