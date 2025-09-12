using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Zamazon.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace Zamazon.WebUI.Areas.Admin.Controllers
{
	[AllowAnonymous]
	[Area("Admin")]
	[Route("Admin/[controller]/[action]")]
	public class SpecialOfferController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public SpecialOfferController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}


		public async Task<IActionResult> Index()
		{

			ViewBag.list = "Offer List";
			ViewBag.navigation1 = "Offer";
			ViewBag.navigation2 = "Index";

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

		[HttpGet]
		public IActionResult CreateSpecialOffer()
		{
			ViewBag.list = "SpecialOffer";
			ViewBag.navigation1 = "Add SpecialOffer";
			ViewBag.navigation2 = "Index";
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonoffer = JsonConvert.SerializeObject(createSpecialOfferDto);
			StringContent stringContent = new StringContent(jsonoffer, System.Text.Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7002/api/SpecialOffers", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
			}
			return View();
		}
		[Route("{id}")]
		public async Task<IActionResult> DeleteSpecialOffer(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.DeleteAsync($"https://localhost:7002/api/SpecialOffers/{id}");
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
			}
			return View();
		}
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> UpdateSpecialOffer(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync($"https://localhost:7002/api/SpecialOffers/{id}");
			if (response.IsSuccessStatusCode)
			{
				var jsonoffer = await response.Content.ReadAsStringAsync();
				var category = JsonConvert.DeserializeObject<UpdateSpecialOfferDto>(jsonoffer);
				ViewBag.list = "SpecialOffer";
				ViewBag.navigation1 = "Update SpecialOffer";
				ViewBag.navigation2 = "Index";
				return View(category);
			}
			return View();
		}
		[HttpPost]
		[Route("{id}")]
		public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonoffer = JsonConvert.SerializeObject(updateSpecialOfferDto);
			StringContent stringContent = new StringContent(jsonoffer, System.Text.Encoding.UTF8, "application/json");
			var response = await client.PutAsync("https://localhost:7002/api/SpecialOffers/{updateSpecialOfferDto.SpecialOfferId}", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
			}
			return View();
		}
	}
}
