using Microsoft.AspNetCore.Mvc;

namespace Zamazon.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselDeafultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
