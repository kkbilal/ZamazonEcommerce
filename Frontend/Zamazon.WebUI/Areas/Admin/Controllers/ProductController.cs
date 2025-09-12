using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Zamazon.DtoLayer.CatalogDtos.CategoryDtos;
using Zamazon.DtoLayer.CatalogDtos.ProductDtos;

namespace Zamazon.WebUI.Areas.Admin.Controllers
{
	[AllowAnonymous]
	[Area("Admin")]
	[Route("Admin/[controller]/[action]")]
	public class ProductController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}


		public async Task<IActionResult> Index()
		{

			ViewBag.list = "Product List";
			ViewBag.navigation1 = "Product";
			ViewBag.navigation2 = "Index";

			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7002/api/Products");
			if (response.IsSuccessStatusCode)
			{
				var jsonProducts = await response.Content.ReadAsStringAsync();
				var Products = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonProducts);
				return View(Products);
			}


			return View();
		}
		[HttpGet]
		public async Task<IActionResult> CreateProduct()
		{
			ViewBag.list = "Product";
			ViewBag.navigation1 = "Create Product";
			ViewBag.navigation2 = "Index";

			var client = _httpClientFactory.CreateClient();
			var response =await  client.GetAsync("https://localhost:7002/api/Categories");
			var jsoncategories = await response.Content.ReadAsStringAsync();
			var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsoncategories);
			List<SelectListItem> categoryItems = (from category in categories
												  select new SelectListItem
												  {
													  Text = category.CategoryName,
													  Value = category.CategoryId
												  }).ToList();
			ViewBag.catValues = categoryItems;

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonproduct = JsonConvert.SerializeObject(createProductDto);
			StringContent stringContent = new StringContent(jsonproduct, System.Text.Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7002/api/Products", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
			}
			return View();
		}
		[Route("{id}")]
		public async Task<IActionResult> DeleteProduct(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.DeleteAsync($"https://localhost:7002/api/Products/{id}");
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
			}
			return View();
		}
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> UpdateProduct(string id)
		{
			var client1 = _httpClientFactory.CreateClient();
			var response1 = await client1.GetAsync("https://localhost:7002/api/Categories");
			var jsoncategories1 = await response1.Content.ReadAsStringAsync();
			var categories1 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsoncategories1);
			List<SelectListItem> categoryItems1 = (from category in categories1
												  select new SelectListItem
												  {
													  Text = category.CategoryName,
													  Value = category.CategoryId
												  }).ToList();
			ViewBag.catValues = categoryItems1;


			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync($"https://localhost:7002/api/Products/{id}");
			if (response.IsSuccessStatusCode)
			{

				var jsonproduct = await response.Content.ReadAsStringAsync();
				var product = JsonConvert.DeserializeObject<UpdateProductDto>(jsonproduct);
				ViewBag.list = "Product";
				ViewBag.navigation1 = "Update Product";
				ViewBag.navigation2 = "Index";
				return View(product);
			}
			return View();
		}
		[HttpPost]
		[Route("{id}")]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonProduct = JsonConvert.SerializeObject(updateProductDto);
			StringContent stringContent = new StringContent(jsonProduct, System.Text.Encoding.UTF8, "application/json");
			var response = await client.PutAsync("https://localhost:7002/api/Products/{updateProductDto.ProductId}", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
			}
			return View();
		}
		public async Task<IActionResult> ProductListWithCategory()
		{

			ViewBag.list = "Product List";
			ViewBag.navigation1 = "Product";
			ViewBag.navigation2 = "Index";

			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7002/api/Products/GetProductsWithCategory");
			if (response.IsSuccessStatusCode)
			{
				var jsonProducts = await response.Content.ReadAsStringAsync();
				var Products = JsonConvert.DeserializeObject<List<ResultWithCategoryDto>>(jsonProducts);
				return View(Products);
			}


			return View();
		}
	}
}
