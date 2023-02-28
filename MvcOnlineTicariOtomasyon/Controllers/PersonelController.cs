using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var listele = c.Personels.ToList();
            return View(listele);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> departmanlistele = (from x in c.Departmans.ToList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.DepartmanAD,
                                                         Value = x.DepartmanID.ToString(),
                                                     }).ToList();
            ViewBag.deger = departmanlistele;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> departmanlistele = (from x in c.Departmans.ToList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.DepartmanAD,
                                                         Value = x.DepartmanID.ToString(),
                                                     }).ToList();
            ViewBag.deger = departmanlistele;
            var bul = c.Personels.Find(id);
            return View("PersonelGetir", bul);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            var per = c.Personels.Find(p.PersonelID);
            per.PersonelAd = p.PersonelAd;
            per.PersonelSoyad = p.PersonelSoyad;
            per.PersonelGorsel = p.PersonelGorsel;
            per.DepartmanID = p.DepartmanID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}