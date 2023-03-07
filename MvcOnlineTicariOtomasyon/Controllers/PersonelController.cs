using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.IO;
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
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Images/" + dosyaadi + uzanti;
            }

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
        public ActionResult PersonelGuncelle(Personel x, HttpPostedFileBase PersonelGorsel)

        {

            var gnc = c.Personels.Find(x.PersonelID);
            gnc.PersonelAd = x.PersonelAd;
            gnc.PersonelSoyad = x.PersonelSoyad;
            gnc.DepartmanID = x.DepartmanID;

            if (ModelState.IsValid)
            {

                if (PersonelGorsel != null)
                {

                    string dosyaadi = Path.GetFileName(PersonelGorsel.FileName);
                    string yol = "/Images/" + dosyaadi;
                    PersonelGorsel.SaveAs(Server.MapPath(yol));
                    gnc.PersonelGorsel = yol;
                }

            }
            c.SaveChanges();

            return RedirectToAction("Index");

        }



        public ActionResult PersonelListe()
        {
            var listele = c.Personels.ToList();
            return View(listele);
        }
    }
}