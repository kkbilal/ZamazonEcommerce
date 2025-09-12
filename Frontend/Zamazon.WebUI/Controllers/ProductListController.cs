using Microsoft.AspNetCore.Mvc;

namespace Zamazon.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            
            return View();
        }
    }
}
