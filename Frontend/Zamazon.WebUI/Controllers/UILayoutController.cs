using Microsoft.AspNetCore.Mvc;

namespace Zamazon.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult _UILayout()
        {
            return View();
        }
    }
}
