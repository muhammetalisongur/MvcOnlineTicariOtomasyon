using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count().ToString();
            ViewBag.cari = deger1;
            var deger2 = c.Uruns.Sum(x => x.Stok).ToString();
            ViewBag.urun = deger2;
            var deger3 = c.SatisHarekets.Sum(x => x.Adet).ToString();
            ViewBag.satis = deger3;
            var deger4 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.toplam = deger4;

            var yapilacaklar = c.Yapilacaks.ToList();

            return View(yapilacaklar);
        }
        [HttpGet]
        public ActionResult YeniYapilacak()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYapilacak(Yapilacak y)
        {
            c.Yapilacaks.Add(y);
            y.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YapilacakSil(int id)
        {
            var d = c.Yapilacaks.Find(id);
            c.Yapilacaks.Remove(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YapilacakGetir(int id)
        {
            var d = c.Yapilacaks.Find(id);
            return View("YapilacakGetir", d);
        }
        public ActionResult YapilacakGuncelle(Yapilacak y)
        {
            var d = c.Yapilacaks.Find(y.YapilacakID);
            y.Durum = true;
            d.Baslik = y.Baslik;
            d.KalanSure = y.KalanSure;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}