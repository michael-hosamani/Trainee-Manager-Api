using TraineeManagement.Api.Dto;
using Shared.Models;

namespace TraineeManagement.Api.Services;

public interface ITokenService {
    public GenerateTokenResult GenerateToken(User user, AuthTokenType tokenType);
}