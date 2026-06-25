using System.Net.Http.Json;
using Shared.Models;

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
}