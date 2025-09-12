using Microsoft.AspNetCore.Mvc;

namespace Zamazon.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartProductsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
