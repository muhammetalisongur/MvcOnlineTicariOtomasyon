using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Xml.Linq;

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
                s.Fiyat = urunFiyat;
                s.ToplamTutar = urunFiyat * s.Adet;
                s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                c.SatisHarekets.Add(s);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return RedirectPermanent("~/Urun/UrunGetir/" + s.UrunID);
        }
        public ActionResult SatisGetir(int id)
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
            var bul = c.SatisHarekets.Find(id);
            return View("SatisGetir", bul);
        }
        public ActionResult SatisGuncelle(SatisHareket s)
        {
            var urunFiyat = c.Uruns.Where(x => x.UrunID == s.UrunID).Select(z => z.SatisFiyat).FirstOrDefault();
            var urunStok = c.Uruns.Where(x => x.UrunID == s.UrunID).Select(z => z.Stok).FirstOrDefault();
            int adet = s.Adet;
            decimal fiyat = urunFiyat;
            decimal toplam;
            int stok = urunStok;
            var satisID = c.SatisHarekets.Find(s.SatisID);
            int eskiAdet = satisID.Adet;
            short res = 0;
            if (urunStok >= adet)
            {
                if (eskiAdet > adet)
                {
                    res = Convert.ToInt16(eskiAdet - adet);
                    stok = stok + res;
                }
                if (eskiAdet < adet)
                {
                    res = Convert.ToInt16(adet - eskiAdet);
                    stok = stok - res;
                }
                var urun = c.Uruns.Find(s.UrunID);
                urun.Stok = Convert.ToInt16(stok);
                toplam = fiyat * adet;
                satisID.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                satisID.Fiyat = fiyat;
                satisID.Adet = adet;
                satisID.ToplamTutar = toplam;
                satisID.UrunID = s.UrunID;
                satisID.CariID = s.CariID;
                satisID.PersonelID = s.PersonelID;
                c.SaveChanges();
                return RedirectToAction("Index");

            }

            else
            {
                return RedirectPermanent("~/Product/ChangeProduct/" + s.UrunID);
            }




        }

    }
}
