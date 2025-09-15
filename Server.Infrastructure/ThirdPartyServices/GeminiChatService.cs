using Microsoft.Extensions.Configuration;
using Server.Application.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace Server.Infrastructure.ThirdPartyServices
{
    public class GeminiChatService : IGeminiChatService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public GeminiChatService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _apiKey = config["AI:ApiKey"] ?? throw new ArgumentNullException("AI:ApiKey is missing");
        }

        public async Task<string> SendMessageAsync(string message)
        {
            var request = new
            {
                contents = new[]
                {
                new {
                    parts = new[]
                    {
                        new { text = message }
                    }
                }
            }
            };

            // Gọi API Gemini
            var response = await _httpClient.PostAsJsonAsync(
                $"v1beta/models/gemini-1.5-flash:generateContent?key={_apiKey}",
                request
            );

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Gemini API error: {response.StatusCode} - {error}");
            }

            var json = await response.Content.ReadFromJsonAsync<JsonElement>();

            // Trích xuất text trả về
            return json
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString()!;
        }
    }
}
