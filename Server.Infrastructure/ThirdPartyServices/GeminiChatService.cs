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
        private const string BaseUrl = "https://generativelanguage.googleapis.com/v1beta";
        private const string Model = "models/gemini-flash-latest";

        // system prompt tách riêng
        private const string SystemPrompt =
            "You are a healthcare consultant working in a major hospital. " +
            "Specialize in maternal health and pregnancy nutrition. " +
            "Provide evidence-based, professional guidance to pregnant mothers. " +
            "Answer concisely by default; expand only if the user explicitly asks for more detail. " +
            "Do not provide diagnosis or prescriptions.";

        public GeminiChatService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _apiKey = config["AI:ApiKey"] ?? throw new ArgumentNullException("AI:ApiKey is missing");
        }

        public async Task<string> SendMessageAsync(string message)
        {
            var request = new
            {
                systemInstruction = new
                {
                    parts = new[] { new { text = SystemPrompt } }
                },
                contents = new[]
                {
                    new {
                        role = "user",
                        parts = new[] { new { text = message } }
                    }
                },
                generationConfig = new
                {
                    maxOutputTokens = 1024,
                    temperature = 0.7
                }
            };

            var url = $"{BaseUrl}/{Model}:generateContent?key={_apiKey}";
            var response = await _httpClient.PostAsJsonAsync(url, request);

            var raw = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Gemini API error: {response.StatusCode} - {raw}");
            }

            var json = JsonDocument.Parse(raw).RootElement;

            if (json.TryGetProperty("candidates", out var candidates) &&
                candidates.GetArrayLength() > 0 &&
                candidates[0].TryGetProperty("content", out var content) &&
                content.TryGetProperty("parts", out var parts) &&
                parts.GetArrayLength() > 0 &&
                parts[0].TryGetProperty("text", out var textProp))
            {
                return textProp.GetString() ?? string.Empty;
            }

            // fallback khi không có text
            return $"[No valid text in Gemini response] Raw: {raw}";
        }
    }
}
