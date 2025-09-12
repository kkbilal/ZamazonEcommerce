using Microsoft.AspNetCore.Mvc;

namespace Zamazon.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartSummaryComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
