using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]

    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
        Class1 c1 = new Class1();
        public ActionResult Index()
        {
            c1.IUruns = c.Uruns.Where(x => x.UrunID == 1).ToList();
            c1.IDetay = c.Detays.Where(x => x.DetayID == 1).ToList();
            return View(c1);
        }
    }
}