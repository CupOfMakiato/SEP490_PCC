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
        public IFoodCategoryRepository FoodCategoryRepository { get; }
        public IFoodRepository FoodRepository { get; }
        public INutrientRepository NutrientRepository { get; }
        public INutrientCategoryRepository NutrientCategoryRepository { get; }
        public IDiseaseRepository DiseaseRepository { get; }
        public IGrowthDataRepository GrowthDataRepository { get; }
        public IJournalRepository JournalRepository { get; }
        public IFoodRecommendationHistoryRepository FoodRecommendationHistoryRepository { get; }
        public IMediaRepository MediaRepository { get; }
        public IBasicBioMetricRepository BasicBioMetricRepository { get; }
        public IAgeGroupRepository AgeGroupRepository { get; }
        public IEnergySuggestionRepository EnergySuggestionRepository { get; }
        public ISymptomRepository SymptomRepository{ get; }
        public ICustomChecklistRepository CustomChecklistRepository { get; }
        public IClinicRepository ClinicRepository { get; }
        public IDoctorRepository DoctorRepository { get; }
        public IConsultantRepository ConsultantRepository { get; }

        public Task<int> SaveChangeAsync();
    }
}
