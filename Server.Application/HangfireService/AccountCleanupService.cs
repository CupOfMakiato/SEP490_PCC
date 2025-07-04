using Server.Application.HangfireInterface;
using Server.Application.Repositories;
using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.HangfireService
{
    public class AccountCleanupService : IAccountCleanupService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountCleanupService(IUserRepository userRepository, 
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task DeleteUnverifiedAccountsOlderThanOneMonthAsync()
        {
            var expiredUsers = await _userRepository.FindAsync(u =>
                !u.IsVerified &&
                u.Status == StatusEnums.Pending
                && u.CreationDate <= DateTime.UtcNow.Date.AddMonths(-1)

                //&& u.CreationDate <= DateTime.UtcNow.AddMonths(-1)
                //&& u.CreationDate <= DateTime.UtcNow.AddMinutes(-1) //test
            );

            foreach (var user in expiredUsers)
            {
                _userRepository.HardRemove(user);
                Console.WriteLine($"Deleted unverified user: {user.Email}");

            }
            if (expiredUsers.Any())
                await _unitOfWork.SaveChangeAsync();
        }
    }
}
