namespace TraineeManagementApi.Services;

public interface IRedisCacheService
{
    Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken);
    void SetAsync<T>(string key, T value, TimeSpan ttl, CancellationToken cancellationToken);

    void RemoveAsync(string key, CancellationToken cancellationToken);
}