using System.Text;
using Shared.Models;
using TraineeManagement.Api.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace TraineeManagement.Api.Services;

public class TokenService: ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration){
        _configuration = configuration;
    }

    public GenerateTokenResult GenerateToken(User user, AuthTokenType tokenType){
        Claim[] claims;
        if(tokenType == AuthTokenType.AccessToken){
            claims = 
            [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),  
                new Claim(ClaimTypes.Name, user.Username), 
                new Claim(ClaimTypes.Role, user.Role.ToString())
            
            ];
        }
        else{
            claims = 
            [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),  
            ];
        }
        

        var key = _configuration["Jwt:Key"];

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: tokenType == AuthTokenType.AccessToken ? DateTime.UtcNow.AddMinutes(10) : DateTime.UtcNow.AddDays(7),
            signingCredentials: credentials
        );

        var handler = new JwtSecurityTokenHandler();

        var jwt = handler.WriteToken(token);

        var expiryDate = handler.ReadJwtToken(jwt).ValidTo;

        return new GenerateTokenResult{
            jwt = jwt,
            expiryDate = expiryDate
        };
    }
}