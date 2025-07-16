using Server.Application;
using Server.Application.Repositories;
using Server.Infrastructure.Data;
using Server.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IAuthRepository _authRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IBookmarkRepository _bookmarkRepository;
        private readonly ILikeRepository _likeRepository;
        private readonly IFoodCategoryRepository _foodCategoryRepository;
        private readonly IFoodRepository _foodRepository;
        private readonly INutrientRepository _nutrientRepository;
        private readonly INutrientCategoryRepository _nutrientCategoryRepository;
        private readonly IDiseaseRepository _diseaseRepository;
        private readonly IGrowthDataRepository _growthDataRepository;
        private readonly IJournalRepository _journalRepository;
        private readonly IBasicBioMetricRepository _basicBioMetricRepository;
        private readonly IAgeGroupRepository _ageGroupRepository;
        private readonly IEnergySuggestionRepository _energySuggestionRepository;
        private readonly IFoodRecommendationHistoryRepository _foodRecommendationHistoryRepository;
        private readonly ISymptomRepository _symptomRepository;

        public UnitOfWork(AppDbContext dbContext, 
            IUserRepository userRepository,
            ICategoryRepository categoryRepository,
            ISubCategoryRepository subCategoryRepository,
            IAuthRepository authRepository,
            IBlogRepository blogRepository,
            ITagRepository tagRepository,
            IBookmarkRepository bookmarkRepository,
            ILikeRepository likeRepository,
            IFoodCategoryRepository foodCategoryRepository,
            IFoodRepository foodRepository,
            INutrientRepository nutrientRepository,
            IDiseaseRepository diseaseRepository,
            IGrowthDataRepository growthDataRepository,
            IJournalRepository journalRepository,
            IFoodRecommendationHistoryRepository foodRecommendationHistoryRepository,
            INutrientCategoryRepository nutrientCategoryRepository,
            IBasicBioMetricRepository basicBioMetricRepository,
            IMediaRepository mediaRepository,
            ISymptomRepository symptomRepository,
            IAgeGroupRepository ageGroupRepository,
            IEnergySuggestionRepository energySuggestionRepository)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _subCategoryRepository = subCategoryRepository;
            _authRepository = authRepository;
            _blogRepository = blogRepository;
            _tagRepository = tagRepository;
            _bookmarkRepository = bookmarkRepository;
            _likeRepository = likeRepository;
            _foodCategoryRepository = foodCategoryRepository;
            _foodRepository = foodRepository;
            _nutrientRepository = nutrientRepository;
            _nutrientCategoryRepository = nutrientCategoryRepository;
            _diseaseRepository = diseaseRepository;
            _growthDataRepository = growthDataRepository;
            _journalRepository = journalRepository;
            _foodRecommendationHistoryRepository = foodRecommendationHistoryRepository;
            _basicBioMetricRepository = basicBioMetricRepository;
            _mediaRepository = mediaRepository;
            _symptomRepository = symptomRepository;
            _ageGroupRepository = ageGroupRepository;
            _energySuggestionRepository = energySuggestionRepository;
        }

        public IUserRepository UserRepository => _userRepository;
        public IAuthRepository AuthRepository => _authRepository;
        public ICategoryRepository CategoryRepository => _categoryRepository;
        public ISubCategoryRepository SubCategoryRepository => _subCategoryRepository;
        public IBlogRepository BlogRepository => _blogRepository;
        public ITagRepository TagRepository => _tagRepository;
        public IBookmarkRepository BookmarkRepository => _bookmarkRepository;

        public ILikeRepository LikeRepository => _likeRepository;

        public IGrowthDataRepository GrowthDataRepository => _growthDataRepository;
        public IJournalRepository JournalRepository => _journalRepository;
        public IBasicBioMetricRepository BasicBioMetricRepository => _basicBioMetricRepository;

        public IFoodCategoryRepository FoodCategoryRepository => _foodCategoryRepository;

        public IFoodRepository FoodRepository => _foodRepository;
        public INutrientRepository NutrientRepository => _nutrientRepository;
        public INutrientCategoryRepository NutrientCategoryRepository => _nutrientCategoryRepository;
        public IDiseaseRepository DiseaseRepository => _diseaseRepository;
        public IMediaRepository MediaRepository => _mediaRepository;
        public IAgeGroupRepository AgeGroupRepository => _ageGroupRepository;
        public IFoodRecommendationHistoryRepository FoodRecommendationHistoryRepository => _foodRecommendationHistoryRepository;
        public ISymptomRepository SymptomRepository => _symptomRepository;
        public IEnergySuggestionRepository EnergySuggestionRepository => _energySuggestionRepository;

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
