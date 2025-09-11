using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Data
{
    public static class CheckupSeedData
    {
            public static void SeedData(ModelBuilder modelBuilder)
            {
                var systemUser = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f");

                modelBuilder.Entity<RecommendedCheckup>().HasData(
                    new RecommendedCheckup
                    {
                        Id = Guid.NewGuid(),
                        Title = "Initial Prenatal Visit",
                        Description = "Confirm pregnancy, estimate due date, and run baseline tests (blood, urine, STIs, etc).",
                        RecommendedStartWeek = 6,
                        RecommendedEndWeek = 10,
                        Note = "First in-depth appointment—establish prenatal care baseline.",
                        Type = CheckupType.recommneded,
                        IsDeleted = false,
                        IsActive = true,
                        CreatedBy = systemUser,
                        CreationDate = DateTime.UtcNow
                    },
                    new RecommendedCheckup
                    {
                        Id = Guid.NewGuid(),
                        Title = "Second Trimester Checkpoint",
                        Description = "Follow-up to monitor maternal and fetal health—typical physical exam.",
                        RecommendedStartWeek = 10,
                        RecommendedEndWeek = 12,
                        Note = "Short visit to revisit labs and check progress.",
                        Type = CheckupType.recommneded,
                        IsDeleted = false,
                        IsActive = true,
                        CreatedBy = systemUser,
                        CreationDate = DateTime.UtcNow
                    },
                    new RecommendedCheckup
                    {
                        Id = Guid.NewGuid(),
                        Title = "Mid-Pregnancy Screening",
                        Description = "Detailed scan and fetal development assessment.",
                        RecommendedStartWeek = 16,
                        RecommendedEndWeek = 18,
                        Note = "Includes anatomy ultrasound and growth tracking.",
                        Type = CheckupType.recommneded,
                        IsDeleted = false,
                        IsActive = true,
                        CreatedBy = systemUser,
                        CreationDate = DateTime.UtcNow
                    },
                    new RecommendedCheckup
                    {
                        Id = Guid.NewGuid(),
                        Title = "Gestational Diabetes Screening",
                        Description = "Glucose challenge test to check for gestational diabetes.",
                        RecommendedStartWeek = 20,
                        RecommendedEndWeek = 22,
                        Note = "Standard screening in mid-pregnancy.",
                        Type = CheckupType.recommneded,
                        IsDeleted = false,
                        IsActive = true,
                        CreatedBy = systemUser,
                        CreationDate = DateTime.UtcNow
                    },
                    new RecommendedCheckup
                    {
                        Id = Guid.NewGuid(),
                        Title = "Routine Follow-up",
                        Description = "Regular wellness check to assess maternal and fetal status.",
                        RecommendedStartWeek = 24,
                        RecommendedEndWeek = 28,
                        Note = "Standard check-up during late second trimester.",
                        Type = CheckupType.recommneded,
                        IsDeleted = false,
                        IsActive = true,
                        CreatedBy = systemUser,
                        CreationDate = DateTime.UtcNow
                    },
                    new RecommendedCheckup
                    {
                        Id = Guid.NewGuid(),
                        Title = "Early Third Trimester Visit",
                        Description = "Assessment around the beginning of the third trimester.",
                        RecommendedStartWeek = 32,
                        RecommendedEndWeek = 32,
                        Note = "Transition to more frequent visits begins soon.",
                        Type = CheckupType.recommneded,
                        IsDeleted = false,
                        IsActive = true,
                        CreatedBy = systemUser,
                        CreationDate = DateTime.UtcNow
                    },
                    new RecommendedCheckup
                    {
                        Id = Guid.NewGuid(),
                        Title = "Late Third Trimester Check (36 weeks)",
                        Description = "Checkup for dilation, fetal position, and Group B strep culture.",
                        RecommendedStartWeek = 36,
                        RecommendedEndWeek = 36,
                        Note = "Key milestone before entering weekly visits.",
                        Type = CheckupType.recommneded,
                        IsDeleted = false,
                        IsActive = true,
                        CreatedBy = systemUser,
                        CreationDate = DateTime.UtcNow
                    },
                    new RecommendedCheckup
                    {
                        Id = Guid.NewGuid(),
                        Title = "Weekly Monitoring (3 Weeks)",
                        Description = "Frequent monitoring leading up to labor and delivery.",
                        RecommendedStartWeek = 38,
                        RecommendedEndWeek = 40,
                        Note = "Weekly prenatal visits until birth.",
                        Type = CheckupType.recommneded,
                        IsDeleted = false,
                        IsActive = true,
                        CreatedBy = systemUser,
                        CreationDate = DateTime.UtcNow
                    }
                );
            }
    }
}
