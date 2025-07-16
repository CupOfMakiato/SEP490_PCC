using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Interfaces
{
    public interface IGoogleService
    {
        Task<string> GoogleCallback(string code);
        Task<string> GetUrlLoginWithGoogle();
        Task<LoginGoogle> AuthenticateGoogleUser(GoogleUserRequest request);
        Task<Result<object>> RegisterWithGoogle(GoogleUserRequest request);
        Task<Result<object>> GetOrCreateExternalLoginUser(string provider, string key, string email);
    }
}
