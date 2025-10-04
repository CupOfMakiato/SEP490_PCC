using Server.Application.DTOs.NutrientCategory;
using Server.Application.DTOs.NutrientSuggestion;
using Server.Application.Interfaces;
using System.Text;
using System.Text.Json;

namespace Server.API.Middlewares
{
    public class SystemConfigurationMiddleware : IMiddleware
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public SystemConfigurationMiddleware(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task IsNullOrWhiteSpaceBody(string body, HttpContext context)
        {
            if (!string.IsNullOrWhiteSpace(body)) return;
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync("{\"error\":\"Request body is empty\"}");
            return;
        }

        public async Task<string> GetBody(HttpContext context)
        {
            context.Request.EnableBuffering();

            // Move to beginning in case someone has read before
            context.Request.Body.Position = 0;

            using var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true);
            var body = await reader.ReadToEndAsync();

            // Reset position so others can read again
            context.Request.Body.Position = 0;

            await IsNullOrWhiteSpaceBody(body, context);

            return body;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var path = context.Request.Path.Value?.ToLower();
            var jsonOptions = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            if (path is null)
                await context.Response.WriteAsync("Path is null");
            Console.WriteLine(path);
            Console.WriteLine(context.Request.Method);
            using (var scope = _serviceScopeFactory.CreateScope())
            {                
                var scopeService = scope.ServiceProvider.GetRequiredService<ISystemConfigurationService>();
                var systemConfiguration = await scopeService.GetSystemConfigurationAsync();
                if (systemConfiguration == null)
                {
                    await next(context);
                }
                
                if (path.StartsWith("/api/nutrientcategory"))
                {
                    switch (path)
                    {
                        case "/api/nutrientsuggestionattribute/create":
                            {
                                var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
                                context.Request.Body = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(body));

                                var request = JsonSerializer.Deserialize<AddNutrientSuggestionAttributeRequest>(body);

                                if (request == null)
                                {
                                    await BadRequest(context, "Request body is invalid");
                                    return;
                                }

                                if (request.NutrientSuggetionId == Guid.Empty)
                                {
                                    await BadRequest(context, "NutrientSuggetionId is required");
                                    return;
                                }

                                if (string.IsNullOrWhiteSpace(request.Unit))
                                {
                                    await BadRequest(context, "Unit is required");
                                    return;
                                }

                                if (request.Amount < 0)
                                {
                                    await BadRequest(context, "Amount must be non-negative");
                                    return;
                                }

                                if (request.NutrientId == Guid.Empty)
                                {
                                    await BadRequest(context, "NutrientId is required");
                                    return;
                                }

                                if (request.Type < 0)
                                {
                                    await BadRequest(context, "Type must be non-negative");
                                    return;
                                }

                                if (request.Trimester < 0 || request.Trimester > 3)
                                {
                                    await BadRequest(context, "Trimester must be between 0 and 3");
                                    return;
                                }

                                if (request.MinEnergyPercentage.HasValue &&
                                    (request.MinEnergyPercentage < 0 || request.MinEnergyPercentage > 100))
                                {
                                    await BadRequest(context, "MinEnergyPercentage must be between 0 and 100");
                                    return;
                                }

                                if (request.MaxEnergyPercentage.HasValue &&
                                    (request.MaxEnergyPercentage < 0 || request.MaxEnergyPercentage > 100))
                                {
                                    await BadRequest(context, "MaxEnergyPercentage must be between 0 and 100");
                                    return;
                                }

                                if (request.MinEnergyPercentage.HasValue && request.MaxEnergyPercentage.HasValue &&
                                    request.MinEnergyPercentage > request.MaxEnergyPercentage)
                                {
                                    await BadRequest(context, "MinEnergyPercentage cannot be greater than MaxEnergyPercentage");
                                    return;
                                }

                                if (request.MinValuePerDay.HasValue && request.MaxValuePerDay.HasValue &&
                                    request.MinValuePerDay > request.MaxValuePerDay)
                                {
                                    await BadRequest(context, $"MinValuePerDay cannot be greater than MaxValuePerDay");
                                    return;
                                }

                                if (request.MinAnimalProteinPercentageRequire.HasValue &&
                                    (request.MinAnimalProteinPercentageRequire < 0 || request.MinAnimalProteinPercentageRequire > 100))
                                {
                                    await BadRequest(context, "MinAnimalProteinPercentageRequire must be between 0 and 100");
                                    return;
                                }
                            }
                            break;
                    }
                }            
            }

            await next(context);
        }

        private static async Task BadRequest(HttpContext context, string errorMessage)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(new { error = errorMessage }));
        }
    }
}
