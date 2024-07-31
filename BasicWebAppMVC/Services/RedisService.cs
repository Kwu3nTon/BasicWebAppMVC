using StackExchange.Redis;

public interface IRedisService
{
    Task<string> GetValueAsync(string key);
    Task SetValueAsync(string key, string value);
    Task<HashEntry[]> GetHashAsync(string key);
    Task SetHashAsync(string key, Dictionary<string, string> hash);
    
}

public class RedisService : IRedisService
{
    private readonly ConnectionMultiplexer _redis;

    public RedisService(IConfiguration configuration)
    {
        string connectionString = configuration["Redis:ConnectionString"];
        _redis = ConnectionMultiplexer.Connect(connectionString);
        
    }
    public async Task<string> GetValueAsync(string key)
    {
        var db = _redis.GetDatabase();
        return await db.StringGetAsync(key);
    }
    public async Task SetValueAsync(string key, string value)
    {
        var db = _redis.GetDatabase();
        await db.StringSetAsync(key, value);
    }
    
    public async Task<HashEntry[]> GetHashAsync(string key)
    {
        var db = _redis.GetDatabase();
        return await db.HashGetAllAsync(key);
    }
    
    public async Task SetHashAsync(string key, Dictionary<string, string> hash)
    {
        var db = _redis.GetDatabase();
        HashEntry[] hashEntries = new HashEntry[hash.Count];
        int i = 0;
        foreach (KeyValuePair<string, string> item in hash)
        {
            hashEntries[i++] = new HashEntry(item.Key, item.Value);
        }
        await db.HashSetAsync(key, hashEntries);
    }
}