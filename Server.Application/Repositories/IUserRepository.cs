using System.Linq.Expressions;
using Google.Apis.Auth;
using Server.Domain.Entities;

namespace Server.Application.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        //view 
        Task<IList<User>> GetALl();
        Task<List<User>> GetAllStaff();
        Task<List<User>> GetAllClinic();
        Task<User?> FindByEmail(string email);
        Task<User> GetUserByName(string userName);
        Task UpdateAsync(User user);
        Task AddAsync(User user);
        Task<User> AddUser(User user);
        Task<User> GetUserByEmail(string email);
        Task<bool> ExistsAsync(Expression<Func<User, bool>> predicate);
        Task<User> GetUserById(Guid userId);
        Task<User> GetAllUserById(Guid id);
        Task<List<User>> GetUsersByRole(int role);
        Task<User> GetUserWithRole(Guid userId);
        //Task<User> GetUserByIdWithServiceUsed(Guid userId);

        Task<User> GetUserByVerificationToken(string token);

        //Forget Password
        Task<User> GetUserByResetToken(string resetToken);

        //Allergy and Disease
        Task<User> GetUserWithAllergyAndDisease(Guid userId);
    }
}
