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
            var deger = c.Carilers.ToList();
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
       

    }
}