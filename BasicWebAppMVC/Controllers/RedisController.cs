using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
namespace BasicWebAppMVC.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RedisController : ControllerBase
{
    private readonly IRedisService _redisService;
    public RedisController(IRedisService redisService)
    {
        _redisService = redisService;
    }
    [HttpGet("{key}")]
    // Redis Tutorial - Connecting an ASP.NET Web API with Redis 4
    public async Task<IActionResult> GetValue(string key)
    {
        var value = await _redisService.GetValueAsync(key);
        if (value == null)
        {
            return NotFound();
        }
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> SetValue([FromBody] KeyValuePair<string, string> pair)
    {
        await _redisService.SetValueAsync(pair.Key, pair.Value);
        return Ok();
    }
    
    [HttpGet("GetHash/{key}")]
    public async Task<IActionResult> GetHash(string key)
    {
        Console.WriteLine($"key: {key}");
        var value = await _redisService.GetHashAsync(key);
        if (value == null)
        {
            return NotFound();
        }
        string[] HashStringified = value.Select(entry => entry.Name.ToString() + ": " + entry.Value.ToString()).ToArray();
        // Console.WriteLine($"values: {JsonSerializer.Serialize(value)}");
        // Console.WriteLine($"stringArray: {JsonSerializer.Serialize(stringArray)}");
        return Ok(HashStringified);
    }
        
    
    [HttpPost("SetHash")]
    public async Task<IActionResult> SetValue([FromBody] KeyValuePair<string, Dictionary<string, string>> pair)
    {
        await _redisService.SetHashAsync(pair.Key, pair.Value);
        //Console.WriteLine("values: ", pair);
        return Ok();
    }
    
    
}