using Microsoft.AspNetCore.Mvc;

namespace MvcCookies.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}


	}
}
