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
using Server.Application.HangfireInterface;
using Server.Application.HangfireService;
using Hangfire;
using Server.Infrastructure.Services;

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
            services.AddScoped<IFoodRecommendationHistoryService, FoodRecommendationHistoryService>();
            services.AddScoped<INutrientSuggestionService, NutrientSuggestionService>();

            services.AddScoped<IGrowthDataService, GrowthDataService>();       

            services.AddScoped<ICustomChecklistService, CustomChecklistService>();
            services.AddScoped<ITemplateChecklistService, TemplateChecklistService>();
            services.AddScoped<ITailoredCheckupReminderService, TailoredCheckupReminderService>();
            services.AddScoped<IJournalService, JournalService>();
            services.AddScoped<IBasicBioMetricService, BasicBioMetricService>();
            services.AddScoped<ISymptomService, SymptomService>();

            services.AddScoped<IClinicService, ClinicService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IConsultantService, ConsultantService>();
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<IOnlineConsultationService, OnlineConsultationService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IOfflineConsultationService, OfflineConsultationService>();
            services.AddScoped<IFeedbackService, FeedbackService>();

            services.AddScoped<IAdminService, AdminService>();

            services.AddScoped<PasswordService>();
            services.AddScoped<OtpService>();
            services.AddScoped<EmailService>();
            services.AddScoped<IRedisService, RedisService>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();
            services.AddScoped<IGoogleService, GoogleService>();

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
            services.AddScoped<IFoodRecommendationHistoryRepository, FoodRecommendationHistoryRepository>();

            services.AddScoped<IGrowthDataRepository, GrowthDataRepository>();
            services.AddScoped<ICustomChecklistRepository, CustomChecklistRepository>();
            services.AddScoped<ITemplateChecklistRepository, TemplateChecklistRepository>();
            services.AddScoped<IJournalRepository, JournalRepository>();
            services.AddScoped<IBasicBioMetricRepository, BasicBioMetricRepository>();
            services.AddScoped<ISymptomRepository, SymptomRepository>();
            services.AddScoped<ITailoredCheckupReminderRepository, TailoredCheckupReminderRepository>();

            services.AddScoped<IAgeGroupRepository, AgeGroupRepository>();
            services.AddScoped<IEnergySuggestionRepository, EnergySuggestionRepository>();
          
            services.AddScoped<INutrientSuggetionRepository, NutrientSuggetionRepository>();


            services.AddScoped<IClinicRepository, ClinicRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IConsultantRepository, ConsultantRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<ISlotRepository, SlotRepository>();
            services.AddScoped<IOnlineConsultationRepository, OnlineConsultationRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IChatThreadRepository, ChatThreadRepository>();
            services.AddScoped<IOfflineConsultationRepository, OfflineConsultationRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();

            // Background Services
            services.AddHostedService<ConsultationReminderBackgroundService>();

            services.AddScoped<IMessageNotifier, MessageNotifier>();


            // Hangfire
            services.AddScoped<IAccountCleanupService, AccountCleanupService>();
            services.AddScoped<IGrowthDataBGService, GrowthDataBGService>();
            services.AddScoped<ITailoredReminderEmailService, TailoredReminderEmailService>();

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

            // Hangfire DB
            services.AddHangfire(options =>
            {
                options.UseSqlServerStorage(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
