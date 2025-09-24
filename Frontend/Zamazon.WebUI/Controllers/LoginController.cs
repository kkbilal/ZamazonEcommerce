using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using Zamazon.DtoLayer.IdentityDtos.LoginDtos;
using Zamazon.WebUI.Models;
using Zamazon.WebUI.Services;
using Zamazon.WebUI.Services.Interfaces;

namespace Zamazon.WebUI.Controllers
{
	public class LoginController : Controller
	{
		private IHttpClientFactory _httpClientFactory;
		private readonly ILoginService _loginService;
		private readonly IIdentityService _identityService;
		public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService, IIdentityService identityService)
		{
			_httpClientFactory = httpClientFactory;
			_loginService = loginService;
			_identityService = identityService;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
		{
			var client = _httpClientFactory.CreateClient();
			var content = new StringContent(JsonSerializer.Serialize(createLoginDto), System.Text.Encoding.UTF8, "application/json");
			var response = await client.PostAsync("http://localhost:5001/api/Logins", content);
			if (response.IsSuccessStatusCode)
			{
				var jsondata = await response.Content.ReadAsStringAsync();
				var tokenModel = JsonSerializer.Deserialize<JwtResponse>(jsondata,new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});
				if (tokenModel != null)
				{
					JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
					var token = handler.ReadJwtToken(tokenModel.Token);
					var claims = token.Claims.ToList();
					if (tokenModel.Token != null)
					{
						claims.Add(new Claim("zamazontoken", tokenModel.Token));
						var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
						var authProperties = new AuthenticationProperties
						{
							ExpiresUtc = tokenModel.Expiration,
							IsPersistent = true
						};
						await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
						var id = _loginService.GetUserId;
						return RedirectToAction("Index", "Default");
					}
				}
			}
			return View();
		}
		[HttpGet]
		public IActionResult SignIn()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignIn(SignInDto signInDto)
		{
			signInDto.UserName = "test";
			signInDto.Password = "123456aA*";
			await _identityService.SignIn(signInDto);
			return RedirectToAction("Index", "Default");
		}
	}
}
