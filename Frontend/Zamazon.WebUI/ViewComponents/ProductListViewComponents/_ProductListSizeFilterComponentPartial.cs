using Microsoft.AspNetCore.Mvc;

namespace Zamazon.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListSizeFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
