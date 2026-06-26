using System.Net.Http.Json;
using Shared.Models;
using Shared.Dto;

namespace SubmissionProcessor.Worker.Services;
public class TraineeDirectoryClient
{
    private readonly HttpClient _httpClient;

    public TraineeDirectoryClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<DummyTrainee?> GetTraineeAsync(CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<DummyTrainee>("api/trainees", cancellationToken);
    } 

    public async Task<TestResponseDto?> GetTraineeByIdASync(Guid correlationId, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<TestResponseDto>($"api/trainees/{correlationId}", cancellationToken);
    } 
}