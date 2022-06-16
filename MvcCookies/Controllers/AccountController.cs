using Microsoft.AspNetCore.Mvc;
using MvcCookies.Models;
using System.Text.Json;

namespace MvcCookies.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            UserVM model;
            if (HttpContext.Request.Cookies["User"] != null)
                model = JsonSerializer.Deserialize<UserVM>(HttpContext.Request.Cookies["User"]);
            else
                model = new UserVM();

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(UserVM model)
        {
            if (model.UserName == "admin" && model.Password == "123")
            {
                HttpContext.Session.SetString("user", "admin"); // user keyli bir session oluşturup admin değerini set ediyoruz....

                if (model.RememberMe)// beni hatirla....
                {
                    string str = JsonSerializer.Serialize(model); // nesneiyi json'a çevirir

                    HttpContext.Response.Cookies.Append("User", str, new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1),  // Expier => cookinin ne kadar saklanacağı belirtilir....
                        HttpOnly = true
                    });
                }
                else
                    HttpContext.Response.Cookies.Delete("User"); // cookie siliniyor....

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("user"); // user sessionı sil...
            return RedirectToAction("Index", "Home");
        }
    }
}