using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Data
{
    public static class SystemConfigurationSeedData
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            var systemUser = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f");

            // RecommendedCheckup seeding (giữ nguyên như code của bạn)
            modelBuilder.Entity<RecommendedCheckup>().HasData(
            // ... danh sách checkup bạn đã seed
            );

            // SystemConfiguration seeding
            modelBuilder.Entity<SystemConfiguration>().HasData(
                new SystemConfiguration
                {
                    Id = Guid.NewGuid(),
                    NameMinLength = 3,
                    NameMaxLength = 100,
                    DescriptionMinLength = 10,
                    DescriptionMaxLength = 500,
                    TrimesterMinValue = 1,
                    TrimesterMaxValue = 3,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedBy = systemUser,
                    CreationDate = DateTime.UtcNow
                }
            );
        }

    }
}
