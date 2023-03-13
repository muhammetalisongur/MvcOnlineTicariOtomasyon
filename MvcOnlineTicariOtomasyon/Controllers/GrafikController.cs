using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle("Kategori - Urun Stok Sayisi").AddLegend("Stok").AddSeries("Degerler", xValue: new[] { "Mobilya", "Ofis Esyalari", "Bilgisayar" },
                yValues: new[] { 85, 65, 30 }).Write();

            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");

        }
        public ActionResult Index3()
        {

        }
    }
}