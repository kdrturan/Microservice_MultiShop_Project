using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MultiShop.IdentityServer.Tools
{
    public class JwtTokenJenerator
    {
        public static TokenResponseViewModel GenerateToen(GetCheckAppUserViewModel model)
        {
            var claims = new List<Claim>();
            if (!string.IsNullOrEmpty(model.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, model.Role));
            }
            claims.Add(new Claim(ClaimTypes.NameIdentifier, model.UserId));

            if (!string.IsNullOrEmpty(model.UserName))
            {
                claims.Add(new Claim("UserName", model.UserName));
            }

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(JwtTokenDefault.Key));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefault.Expire);
            JwtSecurityToken token = new JwtSecurityToken(issuer:JwtTokenDefault.ValidIssuer,audience:JwtTokenDefault.ValidAudience, claims:claims,
                notBefore:DateTime.UtcNow, expires:expireDate, signingCredentials:signingCredentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return new TokenResponseViewModel(handler.WriteToken(token), expireDate);
        }
    }
}
