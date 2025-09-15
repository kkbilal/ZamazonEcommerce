using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Zamazon.DtoLayer.IdentityDtos.RegisterDtos;

namespace Zamazon.WebUI.Controllers
{
    public class RegisterController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public RegisterController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		[HttpGet]
		public IActionResult Index()
		{
			
			return View();
		}
		[HttpPost]
        public async Task<IActionResult> Index(CreateRegisterDto createRegisterDto)
        {
			if (createRegisterDto.Password == createRegisterDto.ConfirmPassword)
			{
				var client = _httpClientFactory.CreateClient();
				var jsoncategory = JsonConvert.SerializeObject(createRegisterDto);
				StringContent stringContent = new StringContent(jsoncategory, System.Text.Encoding.UTF8, "application/json");
				var response = await client.PostAsync("http://localhost:5001/api/registers", stringContent);
				if (response.IsSuccessStatusCode)
				{
					return RedirectToAction("Index", "Login");
				}
			}
			
			return View();
		}
    }
}
