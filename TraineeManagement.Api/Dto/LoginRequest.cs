using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace TraineeManagement.Api.Dto;

[Index(nameof(Username), IsUnique = true)]
public class LoginRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}