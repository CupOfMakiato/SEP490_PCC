
using FluentValidation.AspNetCore;
using Server.API.Middlewares;
using Server.Application.Interfaces;
using Server.Infrastructure.Hubs;
using Server.WebAPI.Middlewares;
using Server.WebAPI.Services;
using System.Diagnostics;

namespace Server.WebAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIService(this IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler =
                        System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.DefaultIgnoreCondition =
                        System.Text.Json.Serialization.JsonIgnoreCondition.Never;
                    options.JsonSerializerOptions.Converters.Add(
                        new System.Text.Json.Serialization.JsonStringEnumConverter()); // Add this line to handle enums as strings in JSON
                });
            services.AddSignalR();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Pregnancy Care Companion", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Please enter into field the word 'Bearer' followed by space and JWT",
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
            {
                {
                    new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        Reference = new Microsoft.OpenApi.Models.OpenApiReference
                        {
                            Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });

            });
            services.AddEndpointsApiExplorer();

            services.AddHealthChecks();
            services.AddSingleton<GlobalExceptionMiddleware>();
            services.AddSingleton<PerformanceMiddleware>();
            services.AddSingleton<RateLimitMiddleware>();

            services.AddSingleton<Stopwatch>();
            services.AddScoped<IClaimsService, ClaimsService>();

            services.AddSingleton<NotificationHub>();

            services.AddHttpContextAccessor();
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("User", policy =>
                    policy.RequireClaim(System.Security.Claims.ClaimTypes.Role, "User"));
                options.AddPolicy("Admin", policy =>
                    policy.RequireClaim(System.Security.Claims.ClaimTypes.Role, "Admin"));
                options.AddPolicy("HealthExpert", policy =>
                    policy.RequireClaim(System.Security.Claims.ClaimTypes.Role, "HealthExpert"));
                options.AddPolicy("NutrientSpecialist", policy =>
                    policy.RequireClaim(System.Security.Claims.ClaimTypes.Role, "NutrientSpecialist"));
                options.AddPolicy("Clinic", policy =>
                    policy.RequireClaim(System.Security.Claims.ClaimTypes.Role, "Clinic"));
                options.AddPolicy("Consultant", policy =>
                    policy.RequireClaim(System.Security.Claims.ClaimTypes.Role, "Consultant"));
            });
            return services;
        }
    }
}
