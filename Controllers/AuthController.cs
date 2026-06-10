using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraineeManagementApi.Dto;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("api/[controller]")]
public class AuthController: ControllerBase
{
    private readonly AppDbContext _db;
    private readonly IConfiguration _configuration;
    public AuthController(AppDbContext db, IConfiguration configuration)
    {
        _db = db;
        _configuration = configuration;
    }

    [HttpPost("/login")]
    public async Task<ActionResult> Login(LoginRequest loginRequest)
    {
        var user = _db.Users.Where(u => u.Username == loginRequest.Username).FirstOrDefault();

        if (user == null)
        {
            return BadRequest("Invalid Username");
        }
  
        var hasher = new PasswordHasher<User>();
        var isCorrectPassword = hasher.VerifyHashedPassword(user, user.PasswordHash, loginRequest.Password);
        if(isCorrectPassword == PasswordVerificationResult.Failed)
        {
            return Unauthorized("Incorrect password");
        }
        
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),  
            new Claim(ClaimTypes.Name, user.Username), 
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var key = _configuration["Jwt:Key"];
        if(key == null)
        {
            return BadRequest();
        }

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "TraineeManagementApi",
            audience: "TraineeManagementClient",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials
        );
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        // var token = _jwtService.GenerateToken(checkUser.Username);
        // return Ok(new {Token = token });
        return Ok(new
        {
            user,
            Token = jwt
        });
    }
}