using TraineeManagementApi.Dto;

namespace TraineeManagementApi.Services;

public interface IAuthService
{
    Task<LoginResponse?> UserLogin(LoginRequest loginRequest);
    Task<LoginResponse?> Refresh(RefreshTokenDto refreshToken);
}