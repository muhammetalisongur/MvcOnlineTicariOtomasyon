using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Faturalars.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var bul = c.Faturalars.Find(id);
            return View("FaturaGetir", bul);
        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var fatura = c.Faturalars.Find(f.FaturaID);
            fatura.FaturaSeriNo = f.FaturaSeriNo;
            fatura.FaturaSiraNo = f.FaturaSiraNo;
            fatura.Tarih = f.Tarih;
            fatura.Saat = f.Saat;
            fatura.VergiDairesi = f.VergiDairesi;
            fatura.TeslimEden = f.TeslimEden;
            fatura.TeslimAlan = f.TeslimAlan;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var deger = c.FaturaKalems.Where(x => x.FaturaID == id).ToList();

            return View(deger);
        }

        [HttpGet]
        public ActionResult YeniKalem()
        {
            //List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
            //                               select new SelectListItem
            //                               {
            //                                   Text = x.UrunAd,
            //                                   Value = x.UrunID.ToString(),
            //                               }).ToList();
            //ViewBag.deger1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem f)
        {
           
            c.FaturaKalems.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}