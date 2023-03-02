using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var listele = c.SatisHarekets.ToList();
            return View(listele);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            var urunFiyat = c.Uruns.Where(x => x.UrunID == s.UrunID).Select(z => z.SatisFiyat).FirstOrDefault();
            var urunStok = c.Uruns.Where(x => x.UrunID == s.UrunID).Select(z => z.Stok).FirstOrDefault();
            if (urunStok >= s.Adet)
            {
                urunStok = (short)(urunStok - s.Adet);

                var kalanStok = c.Uruns.Find(s.UrunID);
                kalanStok.Stok = urunStok;
                s.ToplamTutar = urunFiyat * s.Adet;
                s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                c.SatisHarekets.Add(s);
                c.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return RedirectPermanent("~/Urun/UrunGetir/" + s.UrunID);
            }
        }


        //public ActionResult UpdateSell(SalesAction s)
        //{
        //    var prodPrice = db.Products.Where(x => x.ProdId == s.ProdId).Select(z => z.SellPrice).FirstOrDefault();
        //    var prodStock = db.Products.Where(x => x.ProdId == s.ProdId).Select(z => z.Stock).FirstOrDefault();
        //    int quality = s.Quality;
        //    decimal price = prodPrice;
        //    decimal total;
        //    int stock = prodStock;
        //    var sellId = db.SalesActions.Find(s.SalesId);
        //    int oldQuality = sellId.Quality;
        //    short res = 0;
        //    if (prodStock >= quality)
        //    {
        //        if (oldQuality > quality) { res = Convert.ToInt16(oldQuality - quality); stock = stock + res; }
        //        if (oldQuality < quality) { res = Convert.ToInt16(quality - oldQuality); stock = stock - res; }
        //        var prod = db.Products.Find(s.ProdId);
        //        prod.Stock = Convert.ToInt16(stock);
        //        total = price * quality;
        //        sellId.DateSales = DateTime.Parse(DateTime.Now.ToShortDateString());
        //        sellId.Price = price;
        //        sellId.Quality = quality;
        //        sellId.Total = total;
        //        sellId.ProdId = s.ProdId;
        //        sellId.Clientid = s.Clientid;
        //        sellId.PersonId = s.PersonId;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");

        //    }

        //    else
        //    {
        //        return RedirectPermanent("~/Product/ChangeProduct/" + s.ProdId);
        //    }
    }
}
