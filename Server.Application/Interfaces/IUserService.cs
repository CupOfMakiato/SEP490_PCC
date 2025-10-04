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

        Task<Result<GetUserDTO>> ViewUserById(Guid id);
        //Task<UserDTO> GetUserById(Guid id);
        Task<Result<UserDTO>> GetCurrentUserById();
        // Delete
        Task<User> HardDeleteUser(Guid userId);
        //upload avatar
        Task<Result<object>> UploadAvatar(Guid userId, IFormFile file);
        //edit profile
        Task<Result<object>> EditUserProfile(EditUserDTO EditUserDTO);
        Task<Result<UserDiseasesAndUserAllergiesDTO>> GetAllergyAndDiseaseByUserId(Guid userId);
        Task<Result<object>> AddDiseaseToUser(Guid userId, UserDiseasesDTO diseasesDTO);
        Task<Result<object>> AddAlleryToUser(Guid userId, UserAllergiesDTO allergiesDTO);
        Task<Result<bool>> RemoveDiseaseFromUser(Guid userId, Guid diseaseId);
        Task<Result<bool>> RemoveAllergyFromUser(Guid userId, Guid allergyId);
        Task<Result<object>> UpdateDiseaseToUser(Guid userId, UserDiseasesDTO diseasesDTO);
        Task<Result<object>> UpdateAlleryToUser(Guid userId, UserAllergiesDTO allergiesDTO);
    }
}
