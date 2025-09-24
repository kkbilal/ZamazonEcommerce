using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Zamazon.IdentityServer.Tools
{
	public class JwtTokenGenerator
	{
		public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel model)
		{
			var claims = new List<Claim>
	{
        // JWT standard claims
        new Claim(JwtRegisteredClaimNames.Sub, model.UserName ?? string.Empty), // subject
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),      // unique token id
        new Claim(ClaimTypes.NameIdentifier, model.Id.ToString())               // user id
    };

			// Role optional
			if (!string.IsNullOrWhiteSpace(model.Role))
				claims.Add(new Claim(ClaimTypes.Role, model.Role));

			// Username optional (custom claim)
			if (!string.IsNullOrWhiteSpace(model.UserName))
				claims.Add(new Claim("UserName", model.UserName));

			// Buraya istediğin özel claimleri kolayca ekleyebilirsin
			// Örn: claims.Add(new Claim("Department", model.Department));

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.key));

			var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			// Dakika bazlı expire (daha güvenli)
			var expireDate = DateTime.UtcNow.AddMinutes(JwtTokenDefaults.Expire);

			var token = new JwtSecurityToken(
				issuer: JwtTokenDefaults.Issuer,
				audience: JwtTokenDefaults.Audience,
				claims: claims,
				notBefore: DateTime.UtcNow,
				expires: expireDate,
				signingCredentials: signingCredentials
			);

			var tokenHandler = new JwtSecurityTokenHandler();

			return new TokenResponseViewModel(tokenHandler.WriteToken(token), expireDate);
		}

	}
}
