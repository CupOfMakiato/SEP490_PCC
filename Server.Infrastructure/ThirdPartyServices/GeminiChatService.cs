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
                    role = "user",
                    parts = new[]
                    {
                        new { text = "You are a healthcare consultant working in a major hospital. " +
                           "Your specialty is maternal health and pregnancy nutrition. " +
                           "Provide evidence-based, professional guidance to pregnant mothers. " +
                           "You can suggest safe foods, nutrients, lifestyle practices, and " +
                           "general actions to support health during pregnancy. " +
                           "If asked about illnesses or symptoms, explain what they can do " +
                           "to relieve discomfort safely and when to seek medical attention. " +
                           "Do not provide diagnosis or prescriptions." }
                    }
                },
                new {
                    role = "user",
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
