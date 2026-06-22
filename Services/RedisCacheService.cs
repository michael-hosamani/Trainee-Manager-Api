using System.Runtime.InteropServices;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace TraineeManagementApi.Services;

public class RedisCacheService: IRedisCacheService
{
    private readonly IDistributedCache _cache;
    private readonly ILogger<RedisCacheService> _logger;

    public RedisCacheService(IDistributedCache cache, ILogger<RedisCacheService> logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        try
        {
            string? cachedData = await _cache.GetStringAsync(key);
            if(cachedData == null)
            {
                _logger.LogWarning("Value not found for key: {key} in redis", key);
                return default;
            }

            return JsonSerializer.Deserialize<T>(cachedData);
        }
        catch (Exception ex)
        {
            _logger.LogWarning("Error occured while fetching value for key: {key} with Excpetion: {ex}", key, ex);
            return default;
        }
    }
    public async void SetAsync<T>(string key, T value, TimeSpan ttl)
    {
        try
        { 
            var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(ttl);
            string jsonValue = JsonSerializer.Serialize(value);
            await _cache.SetStringAsync(key, jsonValue, options);
        }
        catch(Exception ex)
        {
            _logger.LogWarning("Error occured while setting value for key: {key} with Excpetion: {ex}", key, ex);
        }
    }

    public async void RemoveAsync(string key)
    {
        try
        {   
            await _cache.RemoveAsync(key);
        }
        catch(Exception ex)
        {
            _logger.LogWarning("Error occured while removing value for key: {key} with Excpetion: {ex}", key, ex);
        }
    }
}