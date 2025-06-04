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

        public Task<int> SaveChangeAsync();
    }
}
