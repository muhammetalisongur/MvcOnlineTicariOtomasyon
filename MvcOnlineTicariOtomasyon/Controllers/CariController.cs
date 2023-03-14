using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{

    public class CariController : Controller
    {
        // GET: Cariler
        Context c = new Context();
        public ActionResult Index()
        {
            var deger = c.Carilers.Where(x => x.Durum == true).ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cariler ca)
        {
            c.Carilers.Add(ca);
            ca.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var bul = c.Carilers.Find(id);
            bul.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var bul = c.Carilers.Find(id);
            return View("CariGetir", bul);
        }

        public ActionResult CariGuncelle(Cariler p)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var bul = c.Carilers.Find(p.CariID);
            bul.CariAd = p.CariAd;
            bul.CariSoyad = p.CariSoyad;
            bul.CariSehir = p.CariSehir;
            bul.CariMail = p.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSatis(int id)
        {
            var deger = c.SatisHarekets.Where(x => x.CariID == id).ToList();
            var cari = c.Carilers.Where(x => x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.deger = cari;
            return View(deger);
        }

    }
}