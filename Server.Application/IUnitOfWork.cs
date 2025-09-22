using Server.Application.Repositories;

namespace Server.Application
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public IAuthRepository AuthRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public ISubCategoryRepository SubCategoryRepository { get; }
        public IBlogRepository BlogRepository { get; }
        public ITagRepository TagRepository { get; }
        public IBookmarkRepository BookmarkRepository { get; }
        public ILikeRepository LikeRepository { get; }
        public ISubscriptionPlanRepository SubscriptionPlanRepository { get; }
        public IFoodCategoryRepository FoodCategoryRepository { get; }
        public IFoodRepository FoodRepository { get; }
        public INutrientRepository NutrientRepository { get; }
        public INutrientCategoryRepository NutrientCategoryRepository { get; }
        public IUserSubscriptionRepository UserSubscriptionRepository { get; }
        public IDiseaseRepository DiseaseRepository { get; }
        public IGrowthDataRepository GrowthDataRepository { get; }
        public IJournalRepository JournalRepository { get; }
        public IFoodRecommendationHistoryRepository FoodRecommendationHistoryRepository { get; }
        public IMediaRepository MediaRepository { get; }
        public IBasicBioMetricRepository BasicBioMetricRepository { get; }
        public IAgeGroupRepository AgeGroupRepository { get; }
        public IEnergySuggestionRepository EnergySuggestionRepository { get; }
        public IRecordedSymptomRepository SymptomRepository{ get; }
        public ICustomChecklistRepository CustomChecklistRepository { get; }
        public ITemplateChecklistRepository TemplateChecklistRepository { get; }
        public IClinicRepository ClinicRepository { get; }
        public IDoctorRepository DoctorRepository { get; }
        public IConsultantRepository ConsultantRepository { get; }
        public IScheduleRepository ScheduleRepository { get; }
        public ISlotRepository SlotRepository { get; }
        public IOnlineConsultationRepository OnlineConsultationRepository { get; }
        public IMessageRepository MessageRepository { get; }
        public IChatThreadRepository ChatThreadRepository { get; }
        public IOfflineConsultationRepository OfflineConsultationRepository { get; }
        public ITailoredCheckupReminderRepository TailoredCheckupReminderRepository { get; }
        public IRecommendedCheckupReminderRepository RecommendedCheckupReminderRepository { get; }
        public INutrientSuggetionRepository NutrientSuggetionRepository { get; }
        public IFeedbackRepository FeedbackRepository { get; }
        public INSAttributeRepository NSAttributeRepository { get; }
        public IDishRepository DishRepository { get; }
        public IAllergyCategoryRepository AllergyCategoryRepository { get; }
        public IMealRepository MealRepository { get; }
        public IAllergyRepository AllergyRepository { get; }
        public IPaymentRepository PaymentRepository { get; }
        public INotificationRepository NotificationRepository { get; }
        public Task<int> SaveChangeAsync();
    }
}
