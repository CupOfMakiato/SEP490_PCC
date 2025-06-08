using Server.Application;
using Server.Application.Repositories;
using Server.Infrastructure.Data;
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

        public UnitOfWork(AppDbContext dbContext, 
            IUserRepository userRepository,
            ICategoryRepository categoryRepository,
            ISubCategoryRepository subCategoryRepository,
            IAuthRepository authRepository,
            IBlogRepository blogRepository,
            ITagRepository tagRepository,
            IBookmarkRepository bookmarkRepository,
            ILikeRepository likeRepository)
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
        }

        public IUserRepository userRepository => _userRepository;
        public IAuthRepository authRepository => _authRepository;
        public ICategoryRepository categoryRepository => _categoryRepository;
        public ISubCategoryRepository subCategoryRepository => _subCategoryRepository;
        public IBlogRepository blogRepository => _blogRepository;
        public ITagRepository tagRepository => _tagRepository;
        public IBookmarkRepository bookmarkRepository => _bookmarkRepository;

        public ILikeRepository likeRepository => _likeRepository;


        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
