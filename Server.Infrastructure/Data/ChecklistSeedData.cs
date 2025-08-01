using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrastructure.Data
{
    public static class ChecklistSeedData
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TemplateChecklist>().HasData(
                // First Trimester (14 events/symptoms)
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Experience morning sickness",
                    Trimester = 1,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Feel fatigue or exhaustion",
                    Trimester = 1,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Notice breast tenderness",
                    Trimester = 1,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Experience frequent urination",
                    Trimester = 1,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Feel mood swings",
                    Trimester = 1,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Notice food aversions or cravings",
                    Trimester = 1,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Confirm pregnancy with a test",
                    Trimester = 1,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Experience spotting or light bleeding",
                    Trimester = 1,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Feel bloating or gas",
                    Trimester = 1,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Experience headaches",
                    Trimester = 1,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Notice heightened sense of smell",
                    Trimester = 1,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Experience constipation",
                    Trimester = 1,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Hear baby’s heartbeat at first ultrasound",
                    Trimester = 1,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Feel dizziness or lightheadedness",
                    Trimester = 1,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                // Second Trimester (14 events/symptoms)
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Feel increased energy",
                    Trimester = 2,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Notice a baby bump",
                    Trimester = 2,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Feel fetal movements (quickening)",
                    Trimester = 2,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Experience heartburn or indigestion",
                    Trimester = 2,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Notice skin changes (e.g., pregnancy glow)",
                    Trimester = 2,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Experience nasal congestion",
                    Trimester = 2,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Feel leg cramps",
                    Trimester = 2,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Notice stretch marks",
                    Trimester = 2,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Experience back pain",
                    Trimester = 2,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Undergo anatomy scan ultrasound",
                    Trimester = 2,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Experience round ligament pain",
                    Trimester = 2,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Notice increased appetite",
                    Trimester = 2,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Experience vivid dreams",
                    Trimester = 2,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Learn baby’s gender (if desired)",
                    Trimester = 2,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                // Third Trimester (14 events/symptoms)
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Experience Braxton Hicks contractions",
                    Trimester = 3,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Feel increased fetal movements",
                    Trimester = 3,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Experience swelling in feet or ankles",
                    Trimester = 3,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Feel shortness of breath",
                    Trimester = 3,
                    //IsTemplate = true,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Experience more frequent urination",
                    Trimester = 3,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Feel pelvic pressure",
                    Trimester = 3,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Experience insomnia",
                    Trimester = 3,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Notice increased vaginal discharge",
                    Trimester = 3,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Experience varicose veins",
                    Trimester = 3,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Feel baby engage in pelvis",
                    Trimester = 3,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Experience hemorrhoids",
                    Trimester = 3,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Feel increased fatigue",
                    Trimester = 3,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Experience nesting instincts",
                    Trimester = 3,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                },
                new TemplateChecklist
                {
                    Id = Guid.NewGuid(),
                    TaskName = "Notice signs of labor",
                    Trimester = 3,
                    IsDeleted = false,
                    IsActive = true,
                    CreatedBy = Guid.Parse("44046f02-055d-4259-b3b9-234cc96f4a0f"),
                    CreationDate = DateTime.UtcNow
                }
            );

        }
    }
}
