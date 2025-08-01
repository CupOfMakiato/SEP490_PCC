using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Server.Application;
using Server.Application.Commons;
using Server.Application.HangfireInterface;
using Server.Domain.Entities;
using Server.Infrastructure;
using Server.Infrastructure.Hubs;
using Server.WebAPI;
using Server.WebAPI.Middlewares;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// parse the configuration in appsettings
{
    builder.Services
            .AddWebAPIService()
            .AddApplication()
            .AddInfrastructuresService(builder.Configuration);
}

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Configure JWT authentication
var key = System.Text.Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:SecretKey"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            ClockSkew = System.TimeSpan.Zero
        };
    })
    .AddCookie()
    .AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
    {
        options.ClientId = builder.Configuration["GoogleAPI:ClientId"];
        options.ClientSecret = builder.Configuration["GoogleAPI:SecretCode"];
    });

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
    });
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.WithOrigins(
                "http://localhost:5173",
                "https://localhost:5173",
                "https://nestlycare.live",
                "https://www.nestlycare.live",
                "http://nestlycare.live"
                )
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

builder.Services.AddHangfireServer();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var recurringJobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();

    recurringJobManager.AddOrUpdate<IAccountCleanupService>(
        "delete-unverified-accounts",
        job => job.DeleteUnverifiedAccountsOlderThanOneMonthAsync(),
        Cron.Daily(hour: 17) // fire at 00:00 Vietnam Time which is... 17:00 UTC idk lol
        //Cron.MinuteInterval(1) // Run every minute for testing
    );
    recurringJobManager.AddOrUpdate<IGrowthDataBGService>(
        "send-daily-summary-emails",
        job => job.InactivateExpiredGrowthDataProfiles(),
        Cron.Daily(hour: 17) // fire at 00:00 Vietnam Time
    );
    recurringJobManager.AddOrUpdate<ITailoredReminderEmailService>(
    "send-checkup-reminder",
        job => job.SendTailoredReminderCheckupEmail(),
        //Cron.Daily(hour: 17) // fire at 00:00 Vietnam Time
        Cron.MinuteInterval(1) // Run every minute for testing
    );
}


app.UseSwagger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwaggerUI();
}
else
{
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.InjectJavascript("/custom-swagger.js");
        c.RoutePrefix = string.Empty;
    });
}

app.UseExceptionHandler("/Error");

app.UseCors("AllowAllOrigins");




// Middleware for performance tracking
app.UseMiddleware<PerformanceMiddleware>();

// use authen
app.UseAuthentication();
app.UseAuthorization();

// Use Global Exception Middleware 
app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseHangfireDashboard("/hangfire");

app.MapHealthChecks("/healthchecks"); 

app.MapControllers();

app.MapHub<NotificationHub>("hub/notificationHub");

app.Run();
