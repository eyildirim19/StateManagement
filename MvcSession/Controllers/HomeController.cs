using Microsoft.AspNetCore.Mvc;

namespace MvcSession.Controllers
{
    public class HomeController : Controller
    {
        int sayac;
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("syc") != null)
            {
                sayac = (int)HttpContext.Session.GetInt32("syc");
            }

            return View(sayac);
        }

        [HttpPost]
        public IActionResult Arttir()
        {
            // Önce session var mı bakıyoruz...
            // syc session'i var mi?
            if (HttpContext.Session.GetInt32("syc") != null)
            {
                // sessiondaki değeri çıkaralım ve sayac değişkenimize atalım...
                sayac = (int)HttpContext.Session.GetInt32("syc"); // getInt32 metodu nullable int olduğu için notnull inte atanamaz..
            }
            sayac++; // sayacı arttır....
            // değeri sessiona ekle
            HttpContext.Session.SetInt32("syc", sayac);

            return View("Index", sayac);
        }

    }
}
