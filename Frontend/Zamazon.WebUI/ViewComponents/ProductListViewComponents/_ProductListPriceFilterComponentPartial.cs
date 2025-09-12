using Microsoft.AspNetCore.Mvc;

namespace Zamazon.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListPriceFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
