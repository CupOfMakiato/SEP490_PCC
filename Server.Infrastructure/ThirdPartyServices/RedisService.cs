﻿using System.Text.Json;
using System.Text.Json.Serialization;
using Server.Application.Interfaces;
using StackExchange.Redis;

public class RedisService : IRedisService
{
    //private readonly IDatabase _database;
    //private readonly JsonSerializerOptions _jsonOptions;

    //public RedisService(IConnectionMultiplexer redis)
    //{
    //    _database = redis.GetDatabase();

    //    // Configure JSON serialization to handle circular references
    //    _jsonOptions = new JsonSerializerOptions
    //    {
    //        ReferenceHandler = ReferenceHandler.Preserve,
    //        WriteIndented = false
    //    };
    //}

    //public async Task<T?> GetAsync<T>(string key)
    //{
    //    var value = await _database.StringGetAsync(key);
    //    return value.HasValue ? JsonSerializer.Deserialize<T>(value!, _jsonOptions) : default;
    //}

    //public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
    //{
    //    var json = JsonSerializer.Serialize(value, _jsonOptions);
    //    await _database.StringSetAsync(key, json, expiration);
    //}

    //public async Task RemoveAsync(string key)
    //{
    //    await _database.KeyDeleteAsync(key);
    //}
}
