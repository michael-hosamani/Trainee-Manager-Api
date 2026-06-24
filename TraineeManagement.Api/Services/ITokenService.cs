using TraineeManagement.Api.Dto;
using TraineeManagement.Api.Models;

namespace TraineeManagement.Api.Services;

public interface ITokenService {
    public GenerateTokenResult GenerateToken(User user, AuthTokenType tokenType);
}