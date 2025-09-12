using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Zamazon.DtoLayer.CatalogDtos.CategoryDtos;

namespace Zamazon.WebUI.Areas.Admin.Controllers
{
	[AllowAnonymous]
	[Area("Admin")]
	[Route("Admin/[controller]/[action]")]
	public class CategoryController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CategoryController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}


		public async Task<IActionResult> Index()
		{

			ViewBag.list = "Category List";
			ViewBag.navigation1 = "Category";
			ViewBag.navigation2 = "Index";

			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7002/api/Categories");
			if (response.IsSuccessStatusCode)
			{
				var jsoncategories = await response.Content.ReadAsStringAsync();
				var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsoncategories);
				return View(categories);
			}


			return View();
		}

		[HttpGet]
		public IActionResult AddCategory()
		{
			ViewBag.list = "Category";
			ViewBag.navigation1 = "Add Category";
			ViewBag.navigation2 = "Index";
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddCategory(CreateCategoryDto createCategoryDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsoncategory = JsonConvert.SerializeObject(createCategoryDto);
			StringContent stringContent = new StringContent(jsoncategory, System.Text.Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7002/api/Categories", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Category", new { area = "Admin" });
			}
			return View();
		}
		[Route("{id}")]
		public async Task<IActionResult> DeleteCategory(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.DeleteAsync($"https://localhost:7002/api/Categories/{id}");
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Category", new { area = "Admin" });
			}
			return View();
		}
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> UpdateCategory(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync($"https://localhost:7002/api/Categories/{id}");
			if (response.IsSuccessStatusCode)
			{
				var jsoncategory = await response.Content.ReadAsStringAsync();
				var category = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsoncategory);
				ViewBag.list = "Category";
				ViewBag.navigation1 = "Update Category";
				ViewBag.navigation2 = "Index";
				return View(category);
			}
			return View();
		}
		[HttpPost]
		[Route("{id}")]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsoncategory = JsonConvert.SerializeObject(updateCategoryDto);
			StringContent stringContent = new StringContent(jsoncategory, System.Text.Encoding.UTF8, "application/json");
			var response = await client.PutAsync("https://localhost:7002/api/Categories/{updateCategoryDto.CategoryId}", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Category", new { area = "Admin" });
			}
			return View();
		}


	}
}
