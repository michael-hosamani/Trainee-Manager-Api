// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using Microsoft.IdentityModel.Tokens;
// using Microsoft.AspNetCore.Identity;
// using TraineeManagementApi.Dto;

// namespace TraineeManagementApi.Services;

// public class AuthService: IAuthService
// {
//     private readonly AppDbContext _db;

//     public AuthService(AppDbContext db)
//     {   
//         _db = db;
//     }

//     public async Task<LoginResponse?> Login(LoginRequest loginRequest)
//     {
//         var checkUser = _db.Users.SingleOrDefaultAsync(u => u.Username == loginRequest.Username);
//         if (checkUser == null)
//         {
//             return null;
//         }

//         var hasher = new PasswordHasher<User>();
//         var isCorrectPassword = hasher.VerifyHashedPassword(checkUser, checkUser.PasswordHash, loginRequest.Password);
//         if(isCorrectPassword == PasswordVerificationResult.Failed)
//         {
//             return null;
//         }

//         var claims = new[]
//         {
//             new Claim(JwtRegisteredClaimNames.Sub, checkUser.Id),
//             new Claim(JwtRegisteredClaimNames.Sub, checkUser.Username),
//             new Claim(ClaimTypes.Role, checkUser.Role)
//         };

//         var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
//         var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//         var token = new JwtSecurityToken(
//             issuer: "MyApp",
//             audience: "MyAppUsers",
//             claims: claims,
//             expires: DateTime.UtcNow.AddHours(1),
//             signingCredentials: creds
//         );

//         var jwt = new JwtSecurityTokenHandler().WriteToken(token);
//         return jwt;
//     }
// }