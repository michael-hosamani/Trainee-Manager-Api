using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TraineeManagementApi.Models;

namespace TraineeManagementApi.Dto;

public class LoginResponse
{
    public required string Token { get; set; }
    public required DateTime ExpiresIn { get; set; }
    public required UserWithoutPassword User { get; set; }
}

public class UserWithoutPassword
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required Role Role { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}