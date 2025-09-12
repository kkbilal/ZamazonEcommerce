using Microsoft.AspNetCore.Mvc;

namespace Zamazon.WebUI.ViewComponents.DefaultViewComponents
{
    public class _MostProductsDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
