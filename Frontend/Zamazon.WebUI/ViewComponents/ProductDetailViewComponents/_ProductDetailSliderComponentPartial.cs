using Microsoft.AspNetCore.Mvc;

namespace Zamazon.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailSliderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
