using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using Zamazon.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Zamazon.WebUI.Areas.Admin.Controllers;

namespace Zamazon.WebUI.ViewComponents.DefaultViewComponents
{	
	public class _SpecialOfferComponentPartial : ViewComponent
    {
		private readonly IHttpClientFactory _httpClientFactory;
		public _SpecialOfferComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async  Task<IViewComponentResult> InvokeAsync()
        {
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7002/api/SpecialOffers");
			if (response.IsSuccessStatusCode)
			{
				var jsoncategories = await response.Content.ReadAsStringAsync();
				var categories = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsoncategories);
				return View(categories);
			}


			return View();
		}
	}
}