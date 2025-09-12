using Microsoft.AspNetCore.Mvc;

namespace Zamazon.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
