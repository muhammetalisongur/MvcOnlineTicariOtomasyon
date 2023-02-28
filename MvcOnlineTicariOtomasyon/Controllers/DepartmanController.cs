using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var listele = c.Departmans.Where(x => x.Durum == true).ToList();
            return View(listele);
        }
        [HttpGet]
        public ActionResult YeniDepartman()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDepartman(Departman d)
        {
            c.Departmans.Add(d);
            d.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var departman = c.Departmans.Find(id);
            departman.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var getir = c.Departmans.Find(id);
            return View("DepartmanGetir", getir);

        }
        public ActionResult DepartmanGuncelle(Departman d)
        {
            var departman = c.Departmans.Find(d.DepartmanID);
            departman.DepartmanAD = d.DepartmanAD;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}