using TraineeManagement.Api.Dto;

namespace TraineeManagement.Api.Services;

public interface IAuthService
{
    Task<LoginResponse?> UserLogin(LoginRequest loginRequest);
    Task<LoginResponse?> Refresh(RefreshTokenDto refreshToken);
}