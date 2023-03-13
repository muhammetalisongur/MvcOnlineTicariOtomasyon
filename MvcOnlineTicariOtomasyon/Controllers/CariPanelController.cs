using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = c.Carilers.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.m = mail;
            return View(degerler);
        }
        public ActionResult Guncelle(Cariler k)
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariID).FirstOrDefault();
            var cari = c.Carilers.Find(id);
            cari.CariAd = k.CariAd;
            cari.CariSoyad = k.CariSoyad;
            cari.CariSehir = k.CariSehir;
            cari.Sifre = k.Sifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariID).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.CariID == id).ToList();
            return View(degerler);
        }
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Alici == mail).ToList();
            if (mesajlar != null)
            {
                var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
                ViewBag.d1 = gelensayisi;
            }
            else
                ViewBag.d1 = 0;
            if (mesajlar != null)
            {
                var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
                ViewBag.d2 = gidensayisi;
            }
            else
                ViewBag.d2 = 0;

            return View(mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Gonderici == mail).ToList();
            if (mesajlar != null)
            {
                var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
                ViewBag.d1 = gelensayisi;
            }
            else
                ViewBag.d1 = 0;
            if (mesajlar != null)
            {
                var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
                ViewBag.d2 = gidensayisi;
            }
            else
                ViewBag.d2 = 0;

            return View(mesajlar);
        }

        public ActionResult MesajDetay(int id)
        {
            var degerler = c.Mesajlars.Where(x => x.MesajID == id).ToList();
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Gonderici == mail).ToList();
            if (mesajlar != null)
            {
                var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
                ViewBag.d1 = gelensayisi;
            }
            else
                ViewBag.d1 = 0;
            if (mesajlar != null)
            {
                var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
                ViewBag.d2 = gidensayisi;
            }
            else
                ViewBag.d2 = 0;
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Gonderici == mail).ToList();
            if (mesajlar != null)
            {
                var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
                ViewBag.d1 = gelensayisi;
            }
            else
                ViewBag.d1 = 0;
            if (mesajlar != null)
            {
                var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
                ViewBag.d2 = gidensayisi;
            }
            else
                ViewBag.d2 = 0;
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            c.Mesajlars.Add(m);
            c.SaveChanges();
            return View();
        }

    }
}