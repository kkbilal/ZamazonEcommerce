using Zamazon.DtoLayer.IdentityDtos.LoginDtos;

namespace Zamazon.WebUI.Services.Interfaces
{
	public interface IIdentityService
	{
		Task<bool> SignIn(SignInDto signInDto);
	}
}
