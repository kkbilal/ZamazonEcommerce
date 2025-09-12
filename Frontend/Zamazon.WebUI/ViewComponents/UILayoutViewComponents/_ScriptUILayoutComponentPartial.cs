using Microsoft.AspNetCore.Mvc;

namespace Zamazon.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _ScriptUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
