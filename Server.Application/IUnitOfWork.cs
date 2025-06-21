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
        public IVitaminRepository VitaminRepository { get; }
        public IVitaminCategoryRepository VitaminCategoryRepository { get; }
        public IDiseaseRepository DiseaseRepository { get; }
        public IGrowthDataRepository GrowthDataRepository { get; }
        public IJournalRepository JournalRepository { get; }
        public ISuggestionRuleRepository SuggestionRuleRepository { get; }
        public IFoodRecommendationHistoryRepository FoodRecommendationHistoryRepository { get; }

        public Task<int> SaveChangeAsync();
    }
}
