using Server.Application.Repositories;

namespace Server.Application
{
    public interface IUnitOfWork
    {
        public IUserRepository userRepository { get; }
        public IAuthRepository authRepository { get; }
        public ICategoryRepository categoryRepository { get; }
        public ISubCategoryRepository subCategoryRepository { get; }
        public IBlogRepository blogRepository { get; }
        public ITagRepository tagRepository { get; }
        public IBookmarkRepository bookmarkRepository { get; }
        public ILikeRepository likeRepository { get; }
        public IFoodCategoryRepository FoodCategoryRepository { get; }
        public IFoodRepository FoodRepository { get; }
        public INutrientRepository NutrientRepository { get; }
        public INutrientCategoryRepository NutrientCategoryRepository { get; }
        public IDiseaseRepository DiseaseRepository { get; }
        public ISuggestionRuleRepository SuggestionRuleRepository { get; }
        public IFoodRecommendationHistoryRepository FoodRecommendationHistoryRepository { get; }

        public Task<int> SaveChangeAsync();
    }
}
