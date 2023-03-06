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
       

        [HttpPost]
        public ActionResult tiklama()
        {
            return View();
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
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}