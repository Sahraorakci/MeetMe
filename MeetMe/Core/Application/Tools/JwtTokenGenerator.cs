using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Constants;
using Application.Dto;
using Microsoft.IdentityModel.Tokens;

namespace Application.Tools;

public class JwtTokenGenerator
{
    public static TokenResponseDto GenerateToken(CheckUserResponseDto checkUserResponseDto)
    {
        var claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.NameIdentifier, checkUserResponseDto.Id.ToString()));
        if (!string.IsNullOrWhiteSpace((checkUserResponseDto.Mail)))
            claims.Add(new Claim(ClaimTypes.Email, checkUserResponseDto.Mail));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenConstant.Key));
        var signinCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expireDate = DateTime.UtcNow.AddDays(JwtTokenConstant.Expire);
        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: JwtTokenConstant.ValidIssuer,
            audience: JwtTokenConstant.ValidAudience,
            claims: claims, notBefore: DateTime.UtcNow, expires: expireDate, signingCredentials: signinCredential);

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
  
        return new TokenResponseDto(tokenHandler.WriteToken(jwtSecurityToken), expireDate);
    }
}