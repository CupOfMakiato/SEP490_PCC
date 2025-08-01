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
            modelBuilder.Entity<RecommendedCheckup>().HasData(
                new RecommendedCheckup
                {
                    Id = Guid.NewGuid(),
                    Title = "Initial Prenatal Visit",
                    Description = "Confirm pregnancy, estimate due date, and run baseline tests (blood, urine, STIs, etc).",
                    RecommendedStartWeek = 6,
                    RecommendedEndWeek = 8,
                    Note = "Usually the first and longest appointment to establish prenatal care.",
                    Type = CheckupType.RoutinePrenatal,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new RecommendedCheckup
                {
                Id = Guid.NewGuid(),
                Title = "Nuchal Translucency Screening",
                Description = "Ultrasound and blood test to screen for Down syndrome and other chromosomal abnormalities.",
                RecommendedStartWeek = 11,
                RecommendedEndWeek = 14,
                Note = "Optional, but part of early genetic screening.",
                Type = CheckupType.Screening,
                IsDeleted = false,
                IsActive = true,
                CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                CreationDate = DateTime.UtcNow
                },
                new RecommendedCheckup
                {
                Id = Guid.NewGuid(),
                Title = "Anatomy Ultrasound",
                Description = "Detailed scan of fetal development and organ structure.",
                RecommendedStartWeek = 18,
                RecommendedEndWeek = 22,
                Note = "Checks baby’s growth and detects major abnormalities.",
                Type = CheckupType.Ultrasound,
                IsDeleted = false,
                IsActive = true,
                CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                CreationDate = DateTime.UtcNow
                },
                new RecommendedCheckup
                {
                Id = Guid.NewGuid(),
                Title = "Gestational Diabetes Screening",
                Description = "Blood sugar screening (glucose challenge test) to detect gestational diabetes.",
                RecommendedStartWeek = 24,
                RecommendedEndWeek = 28,
                Note = "Follow-up 3-hour test if results are abnormal.",
                Type = CheckupType.SpecialtyTest,
                IsDeleted = false,
                IsActive = true,
                CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                CreationDate = DateTime.UtcNow
                },
                new RecommendedCheckup
                {
                Id = Guid.NewGuid(),
                Title = "Group B Streptococcus (GBS) Screening",
                Description = "Swab test to check for GBS bacteria, which can affect newborn during delivery.",
                RecommendedStartWeek = 36,
                RecommendedEndWeek = 37,
                Note = "If positive, IV antibiotics will be given during labor.",
                Type = CheckupType.Screening,
                IsDeleted = false,
                IsActive = true,
                CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                CreationDate = DateTime.UtcNow
                },
                new RecommendedCheckup
                {
                Id = Guid.NewGuid(),
                Title = "Weekly Cervical Exams",
                Description = "Pelvic exam to assess cervix dilation and effacement before labor.",
                RecommendedStartWeek = 37,
                RecommendedEndWeek = 40,
                Note = "Helps track readiness for delivery and plan for labor.",
                Type = CheckupType.RoutinePrenatal,
                IsDeleted = false,
                IsActive = true,
                CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                CreationDate = DateTime.UtcNow
                }
            );
        }
    }
}
