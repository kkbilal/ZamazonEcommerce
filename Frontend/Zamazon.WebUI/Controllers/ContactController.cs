using Microsoft.AspNetCore.Mvc;

namespace Zamazon.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
