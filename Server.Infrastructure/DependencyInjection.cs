using Microsoft.Extensions.DependencyInjection;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Application.Services;
using Server.Application;
using Server.Infrastructure.Data;
using Server.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Infrastructure.Mappers;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Server.Application.Settings.CloudinaryService;
using Server.Infrastructure.ThirdPartyServices;
using StackExchange.Redis;
using Server.Application.Utils;

namespace Server.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructuresService(this IServiceCollection services, IConfiguration configuration)
        {
            //UOW
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Service
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ISubCategoryService, SubCategoryService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IOtpService, OtpService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IBookmarkService, BookmarkService>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<IFoodCategoryService, FoodCategoryService>();
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<INutrientCategoryService, NutrientCategoryService>();
            services.AddScoped<INutrientService, NutrientService>();
            services.AddScoped<IDiseaseService, DiseaseService>();
            services.AddScoped<ISuggestionRuleService, SuggestionRuleService>();
            services.AddScoped<IFoodRecommendationHistoryService, FoodRecommendationHistoryService>();

            services.AddScoped<IGrowthDataService, GrowthDataService>();            
            services.AddScoped<IJournalService, JournalService>();
            services.AddScoped<IBasicBioMetricService, BasicBioMetricService>();

            services.AddScoped<PasswordService>();
            services.AddScoped<OtpService>();
            services.AddScoped<EmailService>();
            services.AddScoped<IRedisService, RedisService>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();

            services.AddMemoryCache();

            // Repo
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();

            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IBookmarkRepository, BookmarkRepository>();
            services.AddScoped<ILikeRepository, LikeRepository>();

            services.AddScoped<IFoodCategoryRepository, FoodCategoryRepository>();
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<INutrientCategoryRepository, NutrientCategoryRepository>();
            services.AddScoped<INutrientRepository, NutrientRepository>();
            services.AddScoped<IMediaRepository, MediaRepository>();
            services.AddScoped<IDiseaseRepository, DiseaseRepository>();
            services.AddScoped<ISuggestionRuleRepository, SuggestionRuleRepository>();
            services.AddScoped<IFoodRecommendationHistoryRepository, FoodRecommendationHistoryRepository>();

            services.AddScoped<IGrowthDataRepository, GrowthDataRepository>();
            services.AddScoped<IJournalRepository, JournalRepository>();
            services.AddScoped<IBasicBioMetricRepository, BasicBioMetricRepository>();
            services.AddScoped<IAgeGroupRepository, AgeGroupRepository>();
            services.AddScoped<IEnergySuggestionRepository, EnergySuggestionRepository>();

            // Cloudinary
            services.Configure<CloudinarySetting>(configuration.GetSection("CloudinarySetting"));

            // Database Sql
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            // Redis
            //services.AddSingleton<IConnectionMultiplexer>(sp =>
            //    ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")!)
            //);

            return services;
        }
    }
}
