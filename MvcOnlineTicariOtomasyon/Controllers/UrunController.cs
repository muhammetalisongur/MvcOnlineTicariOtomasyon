using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index()
        {
            var UrunListele = c.Uruns.Where(x => x.Durum == true).ToList();

            return View(UrunListele);
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
        public ActionResult UrunGuncelle(Urun u)
        {
            var urn = c.Uruns.Find(u.UrunID);
            urn.AlisFiyat = u.AlisFiyat;
            urn.Durum = u.Durum;
            urn.KategoriID= u.KategoriID;
            urn.Marka= u.Marka;
            urn.SatisFiyat= u.SatisFiyat;
            urn.Stok= u.Stok;
            urn.UrunAd= u.UrunAd;
            urn.UrunGorsel= u.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
          
        }
        public ActionResult UrunListesi()
        {
            var deger = c.Uruns.ToList();
            return View(deger);
        }
    }
}