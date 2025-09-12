using Microsoft.AspNetCore.Mvc;

namespace Zamazon.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailProductInfoComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
