using Microsoft.Ajax.Utilities;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Context = MvcOnlineTicariOtomasyon.Models.Siniflar.Context;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Cariler cari)
        {
            c.Carilers.Add(cari);
            c.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult Partial2()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial2(Cariler p)
        {
            var bilgiler = c.Carilers.FirstOrDefault(x => x.CariMail == p.CariMail && x.Sifre == p.Sifre);
            if (bilgiler !=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return PartialView("Index", "CariPanel");
            }
           

            return PartialView();
        }
        [HttpGet]
        public PartialViewResult Partial3()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial3(Cariler cari)
        {
            return PartialView();
        }
    }
}