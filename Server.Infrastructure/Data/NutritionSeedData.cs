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
    public static class NutritionSeedData
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            // ---------------------------------------------------
            // AGE GROUP
            // ---------------------------------------------------
            var age20To29 = Guid.NewGuid();

            modelBuilder.Entity<AgeGroup>().HasData(
                new AgeGroup
                {
                    Id = age20To29,
                    FromAge = 20,
                    ToAge = 29,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // ---------------------------------------------------
            // ENERGY SUGGESTIONS
            // ---------------------------------------------------
            //var ES1 = Guid.NewGuid();
            //var ES2 = Guid.NewGuid();
            //var ES3 = Guid.NewGuid();
            //var ES4 = Guid.NewGuid();
            //var ES5 = Guid.NewGuid();
            //var ES6 = Guid.NewGuid();
            modelBuilder.Entity<EnergySuggestion>().HasData(
                new EnergySuggestion
                {
                    Id = Guid.NewGuid(),
                    AgeGroupId = age20To29,
                    ActivityLevel = ActivityLevel.Light,
                    BaseCalories = 1760,
                    AdditionalCalories = 50,
                    Trimester = 1,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new EnergySuggestion
                {
                    Id = Guid.NewGuid(),
                    AgeGroupId = age20To29,
                    ActivityLevel = ActivityLevel.Light,
                    BaseCalories = 1760,
                    AdditionalCalories = 250,
                    Trimester = 2,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new EnergySuggestion
                {
                    Id = Guid.NewGuid(),
                    AgeGroupId = age20To29,
                    ActivityLevel = ActivityLevel.Light,
                    BaseCalories = 1760,
                    AdditionalCalories = 450,
                    Trimester = 3,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new EnergySuggestion
                {
                    Id = Guid.NewGuid(),
                    AgeGroupId = age20To29,
                    ActivityLevel = ActivityLevel.Moderate,
                    BaseCalories = 1960,
                    AdditionalCalories = 50,
                    Trimester = 1,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new EnergySuggestion
                {
                    Id = Guid.NewGuid(),
                    AgeGroupId = age20To29,
                    ActivityLevel = ActivityLevel.Moderate,
                    BaseCalories = 1960,
                    AdditionalCalories = 250,
                    Trimester = 2,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new EnergySuggestion
                {
                    Id = Guid.NewGuid(),
                    AgeGroupId = age20To29,
                    ActivityLevel = ActivityLevel.Moderate,
                    BaseCalories = 1960,
                    AdditionalCalories = 450,
                    Trimester = 3,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // ---------------------------------------------------
            // NUTRIENT CATEGORIES
            // ---------------------------------------------------
            var catPLG = Guid.NewGuid();
            var catMineral = Guid.NewGuid();
            var catVitamin = Guid.NewGuid();
            var catOther = Guid.NewGuid();

            modelBuilder.Entity<NutrientCategory>().HasData(
                new NutrientCategory
                {
                    Id = catPLG,
                    Name = "PLG Substances",
                    Description = "Protein, Lipid, Glucid",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new NutrientCategory
                {
                    Id = catMineral,
                    Name = "Minerals",
                    Description = "Essential minerals",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new NutrientCategory
                {
                    Id = catVitamin,
                    Name = "Vitamins",
                    Description = "Essential vitamins",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new NutrientCategory
                {
                    Id = catOther,
                    Name = "Other Information",
                    Description = "Other Information",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // ---------------------------------------------------
            // NUTRIENTS
            // ---------------------------------------------------
            var proteinId = Guid.NewGuid();
            var lipidId = Guid.NewGuid();
            var glucidId = Guid.NewGuid();

            var calciumId = Guid.NewGuid();
            var ironId = Guid.NewGuid();
            var zincId = Guid.NewGuid();
            var iodineId = Guid.NewGuid();

            var vitaminAId = Guid.NewGuid();
            var vitaminDId = Guid.NewGuid();
            var vitaminEId = Guid.NewGuid();
            var vitaminKId = Guid.NewGuid();
            var vitaminB1Id = Guid.NewGuid();
            var vitaminB2Id = Guid.NewGuid();
            var vitaminB6Id = Guid.NewGuid();
            var folateId = Guid.NewGuid();
            var vitaminB12Id = Guid.NewGuid();
            var vitaminCId = Guid.NewGuid();
            var cholineId = Guid.NewGuid();

            var fiberId = Guid.NewGuid();
            var saltId = Guid.NewGuid();

            modelBuilder.Entity<Nutrient>().HasData(
                // PLG
                new Nutrient { Id = proteinId, Name = "Protein", Description = "Protein Nutrient", NutrientCategoryId = catPLG, IsDeleted = false, CreationDate = new DateTime(2025, 09, 05) },
                new Nutrient { Id = lipidId, Name = "Lipid", Description = "Fat Nutrient", NutrientCategoryId = catPLG, IsDeleted = false, CreationDate = new DateTime(2025, 09, 05) },
                new Nutrient { Id = glucidId, Name = "Glucid", Description = "Carbohydrate", NutrientCategoryId = catPLG, IsDeleted = false, CreationDate = new DateTime(2025, 09, 05) },

                // Minerals
                new Nutrient { Id = calciumId, Name = "Calcium", Description = "Mineral for Bones", NutrientCategoryId = catMineral, IsDeleted = false, CreationDate = new DateTime(2025, 09, 05) },
                new Nutrient { Id = ironId, Name = "Iron", Description = "Mineral for Blood", NutrientCategoryId = catMineral, IsDeleted = false, CreationDate = new DateTime(2025, 09, 05) },
                new Nutrient { Id = zincId, Name = "Zinc", Description = "Mineral for Enzyme & Metabolism", NutrientCategoryId = catMineral, IsDeleted = false, CreationDate = new DateTime(2025, 09, 05) },
                new Nutrient { Id = iodineId, Name = "Iodine", Description = "Iodine for Thyroid", NutrientCategoryId = catMineral, IsDeleted = false, CreationDate = new DateTime(2025, 09, 05) },

                // Vitamins
                new Nutrient { Id = vitaminAId, Name = "Vitamin A", Description = "Vision & Immunity", NutrientCategoryId = catVitamin, IsDeleted = false, CreationDate = new DateTime(2025, 09, 05) },
                new Nutrient { Id = vitaminDId, Name = "Vitamin D", Description = "Bone & Immunity", NutrientCategoryId = catVitamin, IsDeleted = false, CreationDate = new DateTime(2025, 09, 05) },
                new Nutrient { Id = vitaminEId, Name = "Vitamin E", Description = "Antioxidant", NutrientCategoryId = catVitamin, IsDeleted = false, CreationDate = new DateTime(2025, 09, 05) },
                new Nutrient { Id = vitaminKId, Name = "Vitamin K", Description = "Blood Clot & Bone", NutrientCategoryId = catVitamin, IsDeleted = false, CreationDate = new DateTime(2025, 09, 05) },
                new Nutrient { Id = vitaminB1Id, Name = "Vitamin B1", Description = "Energy Metabolism", NutrientCategoryId = catVitamin, IsDeleted = false, CreationDate = new DateTime(2025, 09, 05) },
                new Nutrient { Id = vitaminB2Id, Name = "Vitamin B2", Description = "Energy Metabolism", NutrientCategoryId = catVitamin, IsDeleted = false, CreationDate = new DateTime(2025, 09, 05) },
                new Nutrient { Id = vitaminB6Id, Name = "Vitamin B6", Description = "Protein Metabolism", NutrientCategoryId = catVitamin, IsDeleted = false, CreationDate = new DateTime(2025, 09, 05) },
                new Nutrient { Id = folateId, Name = "Vitamin B9 (Folate)", Description = "DNA Synthesis", NutrientCategoryId = catVitamin, IsDeleted = false, CreationDate = new DateTime(2025, 09, 05) },
                new Nutrient { Id = vitaminB12Id, Name = "Vitamin B12", Description = "Red Blood Cells", NutrientCategoryId = catVitamin, IsDeleted = false, CreationDate = new DateTime(2025, 09, 05) },
                new Nutrient { Id = vitaminCId, Name = "Vitamin C", Description = "Immune & Collagen", NutrientCategoryId = catVitamin, IsDeleted = false, CreationDate = new DateTime(2025, 09, 05) },
                new Nutrient { Id = cholineId, Name = "Choline", Description = "Liver & Brain", NutrientCategoryId = catVitamin, IsDeleted = false, CreationDate = new DateTime(2025, 09, 05) },

                // Other
                new Nutrient { Id = fiberId, Name = "Fiber", Description = "Digestive Health", NutrientCategoryId = catOther, IsDeleted = false, CreationDate = new DateTime(2025, 09, 05) },
                new Nutrient { Id = saltId, Name = "Salt", Description = "Sodium", NutrientCategoryId = catOther, IsDeleted = false, CreationDate = new DateTime(2025, 09, 05) }
            );


            // ---------------------------------------------------
            // ATTRIBUTES with daily min/max values
            // ---------------------------------------------------
            var attrProtein = Guid.NewGuid();
            var attrLipid = Guid.NewGuid();
            var attrGlucid = Guid.NewGuid();
            var attrCalcium = Guid.NewGuid();
            var attrIron = Guid.NewGuid();
            var attrZinc = Guid.NewGuid();
            var attrIodine = Guid.NewGuid();
            var attrVitaminA = Guid.NewGuid();
            var attrVitaminD = Guid.NewGuid();
            var attrVitaminE = Guid.NewGuid();
            var attrVitaminK = Guid.NewGuid();
            var attrVitaminB1 = Guid.NewGuid();
            var attrVitaminB2 = Guid.NewGuid();
            var attrVitaminB6 = Guid.NewGuid();
            var attrFolate = Guid.NewGuid();
            var attrVitaminB12 = Guid.NewGuid();
            var attrVitaminC = Guid.NewGuid();
            var attrCholine = Guid.NewGuid();
            var attrFiber = Guid.NewGuid();
            var attrSalt = Guid.NewGuid();

            modelBuilder.Entity<NSAttribute>().HasData(
                // Macronutrients
                new NSAttribute
                {
                    Id = attrProtein,
                    NutrientId = proteinId,
                    MinEnergyPercentage = 10,
                    MaxEnergyPercentage = 15,
                    Unit = "%",
                    Amount = 0,
                    Type = 1,
                    MinValuePerDay = 50,
                    MaxValuePerDay = 70,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new NSAttribute
                {
                    Id = attrLipid,
                    NutrientId = lipidId,
                    MinEnergyPercentage = 20,
                    MaxEnergyPercentage = 30,
                    Unit = "%",
                    Amount = 0,
                    Type = 1,
                    MinValuePerDay = 60,
                    MaxValuePerDay = 80,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new NSAttribute
                {
                    Id = attrGlucid,
                    NutrientId = glucidId,
                    MinEnergyPercentage = 50,
                    MaxEnergyPercentage = 65,
                    Unit = "%",
                    Amount = 0,
                    Type = 1,
                    MinValuePerDay = 300,
                    MaxValuePerDay = 400,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },

                // Minerals
                new NSAttribute
                {
                    Id = attrCalcium,
                    NutrientId = calciumId,
                    MinEnergyPercentage = 0,
                    MaxEnergyPercentage = 0,
                    Unit = "mg",
                    Amount = 1200,
                    Type = 2,
                    MinValuePerDay = 1200,
                    MaxValuePerDay = 2000,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new NSAttribute
                {
                    Id = attrIron,
                    NutrientId = ironId,
                    MinEnergyPercentage = 0,
                    MaxEnergyPercentage = 0,
                    Unit = "mg",
                    Amount = 27,
                    Type = 2,
                    MinValuePerDay = 27,
                    MaxValuePerDay = 45,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new NSAttribute
                {
                    Id = attrZinc,
                    NutrientId = zincId,
                    MinEnergyPercentage = 0,
                    MaxEnergyPercentage = 0,
                    Unit = "mg",
                    Amount = 11,
                    Type = 2,
                    MinValuePerDay = 11,
                    MaxValuePerDay = 40,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new NSAttribute
                {
                    Id = attrIodine,
                    NutrientId = iodineId,
                    MinEnergyPercentage = 0,
                    MaxEnergyPercentage = 0,
                    Unit = "µg",
                    Amount = 150,
                    Type = 2,
                    MinValuePerDay = 150,
                    MaxValuePerDay = 300,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },

                // Vitamins
                new NSAttribute
                {
                    Id = attrVitaminA,
                    NutrientId = vitaminAId,
                    MinEnergyPercentage = 0,
                    MaxEnergyPercentage = 0,
                    Unit = "µg",
                    Amount = 770,
                    Type = 2,
                    MinValuePerDay = 770,
                    MaxValuePerDay = 3000,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new NSAttribute
                {
                    Id = attrVitaminD,
                    NutrientId = vitaminDId,
                    MinEnergyPercentage = 0,
                    MaxEnergyPercentage = 0,
                    Unit = "µg",
                    Amount = 15,
                    Type = 2,
                    MinValuePerDay = 15,
                    MaxValuePerDay = 100,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new NSAttribute
                {
                    Id = attrVitaminE,
                    NutrientId = vitaminEId,
                    MinEnergyPercentage = 0,
                    MaxEnergyPercentage = 0,
                    Unit = "mg",
                    Amount = 15,
                    Type = 2,
                    MinValuePerDay = 15,
                    MaxValuePerDay = 1000,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new NSAttribute
                {
                    Id = attrVitaminK,
                    NutrientId = vitaminKId,
                    MinEnergyPercentage = 0,
                    MaxEnergyPercentage = 0,
                    Unit = "µg",
                    Amount = 90,
                    Type = 2,
                    MinValuePerDay = 90,
                    MaxValuePerDay = 1200,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new NSAttribute
                {
                    Id = attrVitaminB1,
                    NutrientId = vitaminB1Id,
                    MinEnergyPercentage = 0,
                    MaxEnergyPercentage = 0,
                    Unit = "mg",
                    Amount = 1.1,
                    Type = 2,
                    MinValuePerDay = (float?)1.1,
                    MaxValuePerDay = 2,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new NSAttribute
                {
                    Id = attrVitaminB2,
                    NutrientId = vitaminB2Id,
                    MinEnergyPercentage = 0,
                    MaxEnergyPercentage = 0,
                    Unit = "mg",
                    Amount = 1.1,
                    Type = 2,
                    MinValuePerDay = (float?)1.1,
                    MaxValuePerDay = 2,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new NSAttribute
                {
                    Id = attrVitaminB6,
                    NutrientId = vitaminB6Id,
                    MinEnergyPercentage = 0,
                    MaxEnergyPercentage = 0,
                    Unit = "mg",
                    Amount = 1.3,
                    Type = 2,
                    MinValuePerDay = (float?)1.3,
                    MaxValuePerDay = 2,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new NSAttribute
                {
                    Id = attrFolate,
                    NutrientId = folateId,
                    MinEnergyPercentage = 0,
                    MaxEnergyPercentage = 0,
                    Unit = "µg",
                    Amount = 400,
                    Type = 2,
                    MinValuePerDay = 400,
                    MaxValuePerDay = 1000,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new NSAttribute
                {
                    Id = attrVitaminB12,
                    NutrientId = vitaminB12Id,
                    MinEnergyPercentage = 0,
                    MaxEnergyPercentage = 0,
                    Unit = "µg",
                    Amount = 2.4,
                    Type = 2,
                    MinValuePerDay = (float?)2.4,
                    MaxValuePerDay = 10,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new NSAttribute
                {
                    Id = attrVitaminC,
                    NutrientId = vitaminCId,
                    MinEnergyPercentage = 0,
                    MaxEnergyPercentage = 0,
                    Unit = "mg",
                    Amount = 85,
                    Type = 2,
                    MinValuePerDay = 85,
                    MaxValuePerDay = 2000,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },

                // Others
                new NSAttribute
                {
                    Id = attrCholine,
                    NutrientId = cholineId,
                    MinEnergyPercentage = 0,
                    MaxEnergyPercentage = 0,
                    Unit = "mg",
                    Amount = 550,
                    Type = 2,
                    MinValuePerDay = 550,
                    MaxValuePerDay = 3500,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new NSAttribute
                {
                    Id = attrFiber,
                    NutrientId = fiberId,
                    MinEnergyPercentage = 0,
                    MaxEnergyPercentage = 0,
                    Unit = "g",
                    Amount = 25,
                    Type = 2,
                    MinValuePerDay = 25,
                    MaxValuePerDay = 50,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new NSAttribute
                {
                    Id = attrSalt,
                    NutrientId = saltId,
                    MinEnergyPercentage = 0,
                    MaxEnergyPercentage = 0,
                    Unit = "g",
                    Amount = 6,
                    Type = 2,
                    MinValuePerDay = 6,
                    MaxValuePerDay = 10,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );


            // ---------------------------------------------------
            // NUTRIENT SUGGESTIONS
            // ---------------------------------------------------
            var sugProtein = Guid.NewGuid();
            var sugLipid = Guid.NewGuid();
            var sugGlucid = Guid.NewGuid();

            var sugMinerals = Guid.NewGuid();
            var sugVitamins = Guid.NewGuid();
            var sugOther = Guid.NewGuid();

            modelBuilder.Entity<NutrientSuggetion>().HasData(
                new NutrientSuggetion
                {
                    Id = sugProtein,
                    NutrientSuggetionName = "Protein",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new NutrientSuggetion
                {
                    Id = sugLipid,
                    NutrientSuggetionName = "Lipid",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new NutrientSuggetion
                {
                    Id = sugGlucid,
                    NutrientSuggetionName = "Glucid",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new NutrientSuggetion
                {
                    Id = sugMinerals,
                    NutrientSuggetionName = "Minerals",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new NutrientSuggetion
                {
                    Id = sugVitamins,
                    NutrientSuggetionName = "Vitamins",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new NutrientSuggetion
                {
                    Id = sugOther,
                    NutrientSuggetionName = "Other Information",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }

            );

            // ---------------------------------------------------
            // 8. LINK NutrientSuggestions ↔ Attributes
            // ---------------------------------------------------
            modelBuilder.Entity<NutrientSuggestionAttribute>().HasData(
                new NutrientSuggestionAttribute
                {
                    NutrientSuggestionAttributeId = Guid.NewGuid(),
                    NutrientSuggetionId = sugProtein,
                    AttributeId = attrProtein,
                    AgeGroudId = age20To29,
                    Trimester = 1,
                },
                new NutrientSuggestionAttribute
                {
                    NutrientSuggestionAttributeId = Guid.NewGuid(),
                    NutrientSuggetionId = sugLipid,
                    AttributeId = attrLipid,
                    AgeGroudId = age20To29,
                    Trimester = 1,
                },
                new NutrientSuggestionAttribute
                {
                    NutrientSuggestionAttributeId = Guid.NewGuid(),
                    NutrientSuggetionId = sugGlucid,
                    AttributeId = attrGlucid,
                    AgeGroudId = age20To29,
                    Trimester = 1,
                },

                // Minerals
                new NutrientSuggestionAttribute
                {
                    NutrientSuggestionAttributeId = Guid.NewGuid(),
                    NutrientSuggetionId = sugMinerals,
                    AttributeId = attrCalcium,
                    AgeGroudId = age20To29,
                    Trimester = 1,
                },
                new NutrientSuggestionAttribute
                {
                    NutrientSuggestionAttributeId = Guid.NewGuid(),
                    NutrientSuggetionId = sugMinerals,
                    AttributeId = attrIron,
                    AgeGroudId = age20To29,
                    Trimester = 1,
                },
                new NutrientSuggestionAttribute
                {
                    NutrientSuggestionAttributeId = Guid.NewGuid(),
                    NutrientSuggetionId = sugMinerals,
                    AttributeId = attrZinc,
                    AgeGroudId = age20To29,
                    Trimester = 1,
                },
                new NutrientSuggestionAttribute
                {
                    NutrientSuggestionAttributeId = Guid.NewGuid(),
                    NutrientSuggetionId = sugMinerals,
                    AttributeId = attrIodine,
                    AgeGroudId = age20To29,
                    Trimester = 1,
                },

                // Vitamins
                new NutrientSuggestionAttribute {NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugVitamins, AttributeId = attrVitaminA, AgeGroudId = age20To29, Trimester = 1 },
                new NutrientSuggestionAttribute {NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugVitamins, AttributeId = attrVitaminD, AgeGroudId = age20To29, Trimester = 1 },
                new NutrientSuggestionAttribute {NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugVitamins, AttributeId = attrVitaminE, AgeGroudId = age20To29, Trimester = 1 },
                new NutrientSuggestionAttribute {NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugVitamins, AttributeId = attrVitaminK, AgeGroudId = age20To29, Trimester = 1 },
                new NutrientSuggestionAttribute {NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugVitamins, AttributeId = attrVitaminB1, AgeGroudId = age20To29, Trimester = 1 },
                new NutrientSuggestionAttribute {NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugVitamins, AttributeId = attrVitaminB2, AgeGroudId = age20To29, Trimester = 1 },
                new NutrientSuggestionAttribute {NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugVitamins, AttributeId = attrVitaminB6, AgeGroudId = age20To29, Trimester = 1 },
                new NutrientSuggestionAttribute {NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugVitamins, AttributeId = attrFolate, AgeGroudId = age20To29, Trimester = 1 },
                new NutrientSuggestionAttribute {NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugVitamins, AttributeId = attrVitaminB12, AgeGroudId = age20To29, Trimester = 1 },
                new NutrientSuggestionAttribute {NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugVitamins, AttributeId = attrVitaminC, AgeGroudId = age20To29, Trimester = 1 },
                new NutrientSuggestionAttribute {NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugVitamins, AttributeId = attrCholine, AgeGroudId = age20To29, Trimester = 1 },

                // Other
                new NutrientSuggestionAttribute {NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugOther, AttributeId = attrFiber, AgeGroudId = age20To29, Trimester = 1 },
                new NutrientSuggestionAttribute {NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugOther, AttributeId = attrSalt, AgeGroudId = age20To29, Trimester = 1 }
            );

        }
    }
}
