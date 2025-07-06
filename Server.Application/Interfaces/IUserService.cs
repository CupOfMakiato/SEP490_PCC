using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.User;
using Server.Application.Repositories;
using Server.Domain.Entities;

namespace Server.Application.Interfaces
{
    public interface IUserService 
    {
        Task<IList<User>> GetALl();
        Task<User> GetByEmail(string email);
        Task UpdateUserAsync(User user);


        Task<UserDTO> GetUserById(Guid id);
        Task<Result<UserDTO>> GetCurrentUserById();
        // Delete
        Task<User> HardDeleteUser(Guid userId);
        //upload avatar
        Task<Result<object>> UploadAvatar(Guid userId, IFormFile file);
    }
}
