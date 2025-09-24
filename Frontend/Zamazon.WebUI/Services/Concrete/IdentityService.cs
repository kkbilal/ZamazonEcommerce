using Duende.IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Security.Claims;
using Zamazon.DtoLayer.IdentityDtos.LoginDtos;
using Zamazon.WebUI.Services.Interfaces;
using Zamazon.WebUI.Settings;

namespace Zamazon.WebUI.Services.Concrete
{
	public class IdentityService : IIdentityService
	{
		private readonly HttpClient _httpClient;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ClientSettings _clientSettings;
		public IdentityService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IOptions<ClientSettings> clientSettings)
		{
			_httpClient = httpClient;
			_httpContextAccessor = httpContextAccessor;
			_clientSettings = clientSettings.Value;
		}

		public async Task<bool> SignIn(SignInDto signInDto)
		{
			var discoveryEndpoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
			{
				Address = "http://localhost:5001/",
				Policy = new DiscoveryPolicy { RequireHttps = false }
			});
			var passwordTokenRequest = new PasswordTokenRequest
			{
				ClientId = _clientSettings.ZamazonManagerClient.ClientId,
				ClientSecret = _clientSettings.ZamazonManagerClient.ClientSecret,
				UserName = signInDto.UserName,
				Password = signInDto.Password,
				Address = discoveryEndpoint.TokenEndpoint,
			};

			var token = await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);

			var userInfoRequest = new UserInfoRequest
			{
				Token = token.AccessToken,
				Address = discoveryEndpoint.UserInfoEndpoint
			};
			var userInfo = await _httpClient.GetUserInfoAsync(userInfoRequest);
			
			ClaimsIdentity claimsIdentity = new ClaimsIdentity(userInfo.Claims, CookieAuthenticationDefaults.AuthenticationScheme,"name" ,"role");
			ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
			var authanticationProperties = new AuthenticationProperties();
			authanticationProperties.StoreTokens(new List<AuthenticationToken>
			{
				new AuthenticationToken{ Name = OpenIdConnectParameterNames.AccessToken,Value= token.AccessToken},
				new AuthenticationToken{ Name = OpenIdConnectParameterNames.RefreshToken,Value= token.RefreshToken},
				new AuthenticationToken{ Name = OpenIdConnectParameterNames.ExpiresIn,Value= DateTime.UtcNow.AddSeconds(token.ExpiresIn).ToString("o",System.Globalization.CultureInfo.InvariantCulture)}
			});
			authanticationProperties.IsPersistent = false;

			await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authanticationProperties);
			return token.IsError ? false : true;
		}
	}
}
