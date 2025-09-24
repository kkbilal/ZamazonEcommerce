using System;

namespace Zamazon.IdentityServer.Tools
{
	public class TokenResponseViewModel
	{
		public TokenResponseViewModel(string token, DateTime expiration)
		{
			Token = token;
			Expiration = expiration;
		}

		public string Token { get; set; }
		public DateTime Expiration { get; set; }
    }
}
