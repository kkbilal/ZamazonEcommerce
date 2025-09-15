using Microsoft.AspNetCore.Mvc;

namespace Zamazon.WebUI.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
