﻿using Microsoft.EntityFrameworkCore;
using Server.Application;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Repositories
{
    public class AuthRepository : GenericRepository<User>, IAuthRepository
    {
        private readonly AppDbContext _dbContext;

        public AuthRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext,
                  timeService,
                  claimsService)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteRefreshToken(Guid userId)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(u => u.Id == userId);
            user.RefreshToken = null;
            return await SaveChange();
        }

        public async Task<User> GetRefreshToken(string refreshToken)
        {
            return await _dbContext.User.Include(r => r.Role).FirstOrDefaultAsync(r => r.RefreshToken == refreshToken);
        }
        public async Task<bool> UpdateRefreshToken(Guid userId, string refreshToken)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(u => u.Id == userId);
            user.RefreshToken = refreshToken;
            return await SaveChange();
        }

        public async Task<bool> SaveChange()
        {
            var save = await _dbContext.SaveChangesAsync();
            return save > 0 && true;
        }
    }
}
