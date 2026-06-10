
namespace TraineeManagementApi.Dto;

public class LoginResponse
{
    public required string Token { get; set; }
    public required string ExpiresIn { get; set; }
    public required User User { get; set; }
}