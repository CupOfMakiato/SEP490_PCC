using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Admin;
using Server.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Interfaces
{
    public interface IAdminService
    {
        // view all users, staff, clinics
        Task<Result<List<GetUserDTO>>> ViewAllUsers();
        Task<Result<List<GetUserDTO>>> ViewAllStaff();
        Task<Result<List<GetUserDTO>>> ViewAllClinics();
        // create staff and clinic accounts
        Task<Result<object>> CreateHealthExpertAccount(CreateAccountDTO CreateAccountDTO);
        Task<Result<object>> CreateNutrientSpecialistAccount(CreateAccountDTO CreateAccountDTO);
        Task<Result<object>> CreateClinicAccount(CreateAccountDTO CreateAccountDTO);
        // edit 
        Task<Result<object>> ChangeAccountAuthorize(EditAccountDTO EditAccountDTO);
        // delete or ban account
        Task HardDeleteAccount(string email);
        Task<Result<object>> BanAccount(string email);
        Task<Result<object>> UnBanAccount(string email);


    }
}
