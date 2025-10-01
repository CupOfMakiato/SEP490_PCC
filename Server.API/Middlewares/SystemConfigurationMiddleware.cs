using Server.Application.DTOs.NutrientCategory;
using Server.Application.Interfaces;
using System.Text;

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
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(
                        "{\"error\":\"Can't call system configuration\"}");
                    return;
                }
                
                if (path.StartsWith("/api/nutrientcategory"))
                {
                    switch (path)
                    {
                        case "/api/nutrientcategory/getbyid":
                            var id = context.Request.Query["categoryId"].FirstOrDefault();
                            if (id is null)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json"; // or "text/plain"

                                await context.Response.WriteAsync(
                                    "{\"error\":\"NutrientCategory's Id is null or empty\"}");
                                return;
                            }                                
                            break;
                        case "/api/nutrientcategory/create":
                            var body = await GetBody(context);
                            var createDto = System.Text.Json.JsonSerializer.Deserialize<CreateNutrientCategoryRequest>(body, jsonOptions);
                            
                            if (createDto.Name is null)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Name is null\"}");
                                return;
                            }

                            if (createDto.Description is null)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Description is null\"}");
                                return;
                            }

                            if (createDto.Name.Length > systemConfiguration.NameMaxLength ||
                                createDto.Name.Length < systemConfiguration.NameMinLength)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync($"{{\"error\":\"Name length must be from {systemConfiguration.NameMinLength} to {systemConfiguration.NameMaxLength}\"}}");
                                return;
                            }

                            if (createDto.Description.Length > systemConfiguration.DescriptionMaxLength ||
                                createDto.Description.Length < systemConfiguration.DescriptionMinLength && createDto.Description != null)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync($"{{\"error\":\"Description length must be from {systemConfiguration.DescriptionMinLength} to {systemConfiguration.DescriptionMaxLength}\"}}");
                                return;
                            }
                            break;
                        case "/api/nutrientcategory/update":
                            context.Request.EnableBuffering();
                             body = await GetBody(context);
                            var updateDto = System.Text.Json.JsonSerializer.Deserialize<UpdateNutrientCategoryRequest>(body, jsonOptions);

                            if (updateDto.Name is null)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Name is null\"}");
                                return;
                            }

                            if (updateDto.Description is null)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Description is null\"}");
                                return;
                            }

                            if (updateDto.Name.Length > systemConfiguration.NameMaxLength ||
                                updateDto.Name.Length < systemConfiguration.NameMinLength)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync($"{{\"error\":\"Name length must be from {systemConfiguration.NameMinLength} to {systemConfiguration.NameMaxLength}\"}}");
                                return;
                            }

                            if (updateDto.Description.Length > systemConfiguration.DescriptionMaxLength ||
                                updateDto.Description.Length < systemConfiguration.DescriptionMinLength)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync($"{{\"error\":\"Description length must be from {systemConfiguration.DescriptionMinLength} to {systemConfiguration.DescriptionMaxLength}\"}}");
                                return;
                            }
                            break;
                    }
                }            
            }

            await next(context);
        }
    }
}
