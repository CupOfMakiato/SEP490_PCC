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
            // FOOD CATEGORY
            // ---------------------------------------------------\
            var FCFruits = Guid.NewGuid();
            var FCVeg = Guid.NewGuid();
            var FCSeaFood = Guid.NewGuid();
            var FCDairy = Guid.NewGuid();
            var FCMushroom = Guid.NewGuid();
            var FCGrain = Guid.NewGuid();
            var FCMeat = Guid.NewGuid();
            var FCSpice = Guid.NewGuid();
            var FCNut = Guid.NewGuid();
            var FCGreen = Guid.NewGuid();
            var FCOil = Guid.NewGuid();
            var FCBeverages = Guid.NewGuid();
            var FCBakedPr = Guid.NewGuid();
            modelBuilder.Entity<FoodCategory>().HasData(
                new FoodCategory
                {
                    Id = FCFruits,
                    Name = "Fruits",
                    Description = "Naturally sweet foods such as apples, bananas, berries, and citrus fruits.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new FoodCategory
                {
                    Id = FCVeg,
                    Name = "Vegetables",
                    Description = "Edible plant parts including root vegetables, leafy greens, and legumes.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new FoodCategory
                {
                    Id = FCSeaFood,
                    Name = "Seafood",
                    Description = "Fish, shellfish, and other edible marine life.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new FoodCategory
                {
                    Id = FCDairy,
                    Name = "Dairy",
                    Description = "Milk-based products such as cheese, yogurt, butter, and cream.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new FoodCategory
                {
                    Id = FCMushroom,
                    Name = "Mushrooms",
                    Description = "Edible fungi including button mushrooms, shiitake, and portobello.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new FoodCategory
                {
                    Id = FCGrain,
                    Name = "Grains",
                    Description = "Cereal crops and grain-based foods such as rice, wheat, oats, and corn.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new FoodCategory
                {
                    Id = FCMeat,
                    Name = "Meat",
                    Description = "Animal flesh consumed as food, including beef, pork, and poultry.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new FoodCategory
                {
                    Id = FCSpice,
                    Name = "Spices",
                    Description = "Aromatic substances used to season and flavor food, such as pepper, cinnamon, and cumin.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new FoodCategory
                {
                    Id = FCNut,
                    Name = "Nuts",
                    Description = "Edible seeds enclosed in hard shells, including almonds, walnuts, and peanuts.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new FoodCategory
                {
                    Id = FCGreen,
                    Name = "Greens",
                    Description = "Leafy vegetables rich in vitamins, such as spinach, kale, and lettuce.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new FoodCategory
                {
                    Id = FCOil,
                    Name = "Oils and Sauces",
                    Description = "Cooking oils, condiments, dressings, and sauces used for flavoring.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new FoodCategory
                {
                    Id = FCBeverages,
                    Name = "Beverages",
                    Description = "Drinks including water, tea, coffee, juices, and soft drinks.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new FoodCategory
                {
                    Id = FCBakedPr,
                    Name = "Baked Products",
                    Description = "Foods prepared by baking, such as bread, cakes, and cookies.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );
            // ---------------------------------------------------
            // FOOD
            // ---------------------------------------------------
            var FChicken = Guid.NewGuid();
            var FBeef = Guid.NewGuid();
            var FPork = Guid.NewGuid();

            var FShrimp = Guid.NewGuid();
            var FTuna = Guid.NewGuid();
            var FCod = Guid.NewGuid();

            var FSpinach = Guid.NewGuid();
            var FKale = Guid.NewGuid();
            var FLettuce = Guid.NewGuid();


            var FCarrot = Guid.NewGuid();
            var FBroccoli = Guid.NewGuid();
            var FTomato = Guid.NewGuid();
            var FGarlic = Guid.NewGuid();
            var FEggplant = Guid.NewGuid();
            var FBeanSprouts = Guid.NewGuid();
            var FLemongrass = Guid.NewGuid();
            var FOnion = Guid.NewGuid();
            var FSpringOnion = Guid.NewGuid();
            var FCucumber = Guid.NewGuid();
            var FPumpkin = Guid.NewGuid();
            var FRadish = Guid.NewGuid();

            var FApple = Guid.NewGuid();
            var FWatermelon = Guid.NewGuid();
            var FGrapefruit = Guid.NewGuid();
            var FStrawberry = Guid.NewGuid();
            var FRaspberry = Guid.NewGuid();
            var FOrange = Guid.NewGuid();
            var FPineapple = Guid.NewGuid();

            var FOliveOil = Guid.NewGuid();
            var FSunflowerOil = Guid.NewGuid();
            var FVegetableOil = Guid.NewGuid();
            var FFishSauce = Guid.NewGuid();

            var FAlmond = Guid.NewGuid();
            var FWalnut = Guid.NewGuid();
            var FCashew = Guid.NewGuid();
            var FPeanuts = Guid.NewGuid();

            var FMilk = Guid.NewGuid();
            var FButter = Guid.NewGuid();
            var FEgg = Guid.NewGuid();

            var FSoyBean = Guid.NewGuid();
            var FRice = Guid.NewGuid();
            var FGlutinousRice = Guid.NewGuid();
            var FNoodles = Guid.NewGuid();
            var FChickpeas = Guid.NewGuid();
            var FTofu = Guid.NewGuid();
            var FLotusSeeds = Guid.NewGuid();

            var FWheatBread = Guid.NewGuid();
            var FRiceBread = Guid.NewGuid();
            var FGFMultigrainBread = Guid.NewGuid();
            var FBanhMi = Guid.NewGuid();

            var FWater = Guid.NewGuid();
            var FHerbalTea = Guid.NewGuid();
            var FAppleJuice = Guid.NewGuid();
            var FOrangeJuice = Guid.NewGuid();
            var FPineappleJuice = Guid.NewGuid();
            var FCarrotJuice = Guid.NewGuid();
            var FTomatoJuice = Guid.NewGuid();
            var FCranberryJuice = Guid.NewGuid();
            var FGrapeJuice = Guid.NewGuid();
            var FLemonade = Guid.NewGuid();
            var FSmoothie = Guid.NewGuid();
            var FAlmondMilk = Guid.NewGuid();
            var FRiceMilk = Guid.NewGuid();
            var FAloeVeraJuice = Guid.NewGuid();
            var FGreenTea = Guid.NewGuid();
            var FBlackTea = Guid.NewGuid();
            var FCarbonatedWater = Guid.NewGuid();
            var FBottledWater = Guid.NewGuid();

            var FCinnamon = Guid.NewGuid();
            var FTurmeric = Guid.NewGuid();
            var FChiliPowder = Guid.NewGuid();
            var FTableSalt = Guid.NewGuid();
            var FBlackPepper = Guid.NewGuid();
            var FStarAnise = Guid.NewGuid();
            var FSugar = Guid.NewGuid();
            var FVinegar = Guid.NewGuid();
            var FMSG = Guid.NewGuid();
            var FSoupPowder = Guid.NewGuid();
            var FRicePaper = Guid.NewGuid();
            var FCoriander = Guid.NewGuid();
            var FKetchup = Guid.NewGuid();
            var FSoysauce = Guid.NewGuid();
            var FChilliSauce = Guid.NewGuid();
            var FMayo = Guid.NewGuid();

            var FShiitake = Guid.NewGuid();

            modelBuilder.Entity<Food>().HasData(
                // --- Meat ---
                new Food
                {
                    Id = FChicken,
                    Name = "Chicken Breast",
                    Description = "Lean poultry meat, rich in protein and low in fat.",
                    FoodCategoryId = FCMeat,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe when fully cooked. Avoid raw or undercooked chicken due to risk of salmonella.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FBeef,
                    Name = "Beef",
                    Description = "Red meat rich in protein, iron, and vitamin B12.",
                    FoodCategoryId = FCMeat,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe when fully cooked. Avoid rare or raw beef to reduce risk of toxoplasmosis.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FPork,
                    Name = "Pork",
                    Description = "Meat from pigs, commonly consumed in many forms such as chops or bacon.",
                    FoodCategoryId = FCMeat,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe when thoroughly cooked. Avoid raw or undercooked pork due to parasite risk.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },

                // --- Seafood ---
                new Food
                {
                    Id = FShrimp,
                    Name = "Shrimp",
                    Description = "A low-calorie seafood rich in protein, iodine, and selenium.",
                    FoodCategoryId = FCSeaFood,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe when fully cooked. Avoid raw shrimp (sushi) due to bacterial risk.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FTuna,
                    Name = "Tuna",
                    Description = "Popular fish rich in protein and omega-3 fatty acids.",
                    FoodCategoryId = FCSeaFood,
                    ImageUrl = null,
                    PregnancySafe = false,
                    SafetyNote = "Limit intake (high in mercury). Avoid raw tuna in sushi during pregnancy.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FCod,
                    Name = "Cod",
                    Description = "Mild white fish, low in fat and a good source of vitamin B12.",
                    FoodCategoryId = FCSeaFood,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe when cooked. A good low-mercury seafood choice during pregnancy.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },

                // --- Greens ---
                new Food
                {
                    Id = FSpinach,
                    Name = "Spinach",
                    Description = "Leafy green vegetable high in folate, iron, and vitamin K.",
                    FoodCategoryId = FCGreen,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe and highly recommended during pregnancy. Wash thoroughly before eating.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FKale,
                    Name = "Kale",
                    Description = "Nutrient-dense leafy green vegetable high in vitamin C and antioxidants.",
                    FoodCategoryId = FCGreen,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe and beneficial. Best consumed cooked or washed well if eaten raw.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FLettuce,
                    Name = "Lettuce",
                    Description = "Common salad green, low in calories and hydrating.",
                    FoodCategoryId = FCGreen,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe if washed properly. Avoid pre-packaged lettuce if not fresh to reduce listeria risk.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },

                // --- Vegetables ---
                new Food
                {
                    Id = FCarrot,
                    Name = "Carrot",
                    Description = "Root vegetable high in beta-carotene, fiber, and vitamin A.",
                    FoodCategoryId = FCVeg,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe and beneficial. Helps with vitamin A intake in pregnancy.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FBroccoli,
                    Name = "Broccoli",
                    Description = "Cruciferous vegetable rich in vitamin C, folate, and fiber.",
                    FoodCategoryId = FCVeg,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe and recommended. Supports folate needs during pregnancy.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FTomato,
                    Name = "Tomato",
                    Description = "Juicy red fruit often used as a vegetable, high in lycopene and vitamin C.",
                    FoodCategoryId = FCVeg,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe and hydrating. Wash thoroughly to remove pesticides.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FBeanSprouts,
                    Name = "Bean Sprouts",
                    Description = "Crisp sprouts from mung beans, used raw or lightly cooked.",
                    FoodCategoryId = FCVeg,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Wash thoroughly. Avoid if not fresh due to bacterial risk.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FLemongrass,
                    Name = "Lemongrass",
                    Description = "Aromatic stalk used for flavoring soups and stir-fries.",
                    FoodCategoryId = FCVeg,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe in cooking amounts; remove woody ends before serving.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FEggplant,
                    Name = "Eggplant",
                    Description = "Versatile nightshade vegetable used in stir-fries and stews.",
                    FoodCategoryId = FCVeg,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Cook thoroughly; discard bitter seeds if present.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FGarlic,
                    Name = "Garlic",
                    Description = "Pungent bulb used as seasoning in virtually all Vietnamese dishes.",
                    FoodCategoryId = FCVeg,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe raw or cooked; avoid excessive raw intake if gastrointestinal issues.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FOnion,
                    Name = "Onion",
                    Description = "Bulb vegetable used for flavoring in many dishes.",
                    FoodCategoryId = FCVeg,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe raw or cooked; may cause mild heartburn for some.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FSpringOnion,
                    Name = "Spring Onion (Scallion)",
                    Description = "Mild green onion used as garnish and in salads.",
                    FoodCategoryId = FCVeg,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Wash thoroughly to remove soil and bacteria.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FCucumber,
                    Name = "Cucumber",
                    Description = "Refreshing vegetable high in water content.",
                    FoodCategoryId = FCVeg,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Wash well; remove seeds if sensitive.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FPumpkin,
                    Name = "Pumpkin",
                    Description = "Can be classified as a fruit and can be a great source of Vitamin A",
                    FoodCategoryId = FCVeg,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Remove the seeds before cooking.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FRadish,
                    Name = "Radish",
                    Description = "Crisp root vegetable with peppery flavor, commonly used in salads and pickles.",
                    FoodCategoryId = FCVeg, // Vegetables
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe and hydrating. Wash thoroughly before eating, especially if consumed raw.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },

                // --- Oils ---
                new Food
                {
                    Id = FOliveOil,
                    Name = "Olive Oil",
                    Description = "Healthy cooking oil rich in monounsaturated fats and antioxidants.",
                    FoodCategoryId = FCOil,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe and beneficial in moderation. Supports heart health.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FSunflowerOil,
                    Name = "Sunflower Oil",
                    Description = "Oil made from sunflower seeds, high in vitamin E.",
                    FoodCategoryId = FCOil,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe in small amounts. Use cold-pressed or refined types for cooking.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FFishSauce,
                    Name = "Fish Sauce",
                    Description = "Fermented seafood condiment essential in Vietnamese cuisine.",
                    FoodCategoryId = FCOil,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe in moderation. High sodium content; rinse well in recipes.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FKetchup,
                    Name = "Ketchup",
                    Description = "Tomato-based condiment sweetened and salted; commonly used as a dipping or topping sauce.",
                    FoodCategoryId = FCOil, // Oils and Sauces
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe in moderation; can be high in sodium and added sugar. Choose low-sodium, no-added-sugar options when possible.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FSoysauce,
                    Name = "Soy Sauce",
                    Description = "Fermented soy-based liquid seasoning with strong umami and high sodium content.",
                    FoodCategoryId = FCOil, // Oils and Sauces
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe in small amounts; high in sodium. Opt for low-sodium varieties to help manage blood pressure and fluid retention.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FChilliSauce,
                    Name = "Chili Sauce",
                    Description = "Spicy sauce made from chili peppers, vinegar, salt, and sometimes sugar.",
                    FoodCategoryId = FCOil, // Oils and Sauces
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe in moderation; may trigger heartburn or reflux during pregnancy in some individuals.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FMayo,
                    Name = "Mayonnaise",
                    Description = "Emulsion of oil, egg, and acid (vinegar or lemon), used as a spread or dressing base.",
                    FoodCategoryId = FCOil, // Oils and Sauces
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Use pasteurized/retail versions; homemade mayo with raw egg is not recommended. High in fat—use sparingly.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FVegetableOil,
                    Name = "Vegetable Oil",
                    Description = "A commonly used cooking oil blend derived from plant sources.",
                    FoodCategoryId = FCOil,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe in moderate amounts. Choose refined versions for cooking.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },

                // --- Fruits ---
                new Food
                {
                    Id = FOrange,
                    Name = "Orange",
                    Description = "A citrus fruit rich in vitamin C, folate, and fiber. Commonly eaten fresh or consumed as juice.",
                    FoodCategoryId = FCFruits,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe and beneficial during pregnancy. Prefer whole fruit over juice to maximize fiber and control sugar intake.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FApple,
                    Name = "Apple",
                    Description = "A crisp fruit rich in fiber and vitamin C.",
                    FoodCategoryId = FCFruits,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe and beneficial. Wash well before eating to remove pesticide residues.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FWatermelon,
                    Name = "Watermelon",
                    Description = "Hydrating fruit with high water content, rich in vitamins A and C.",
                    FoodCategoryId = FCFruits,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe and refreshing. Keeps hydration levels up—great during pregnancy heat or nausea.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FGrapefruit,
                    Name = "Grapefruit",
                    Description = "Citrus fruit high in vitamin A and vitamin C with a tangy flavor.",
                    FoodCategoryId = FCFruits,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe and nutritious, though very high in vitamin A—don’t overconsume especially if taking vitamin A supplements.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FStrawberry,
                    Name = "Strawberry",
                    Description = "Sweet berry rich in vitamin C, antioxidants, and fiber.",
                    FoodCategoryId = FCFruits,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Wash well. Excellent immune-support fruit during pregnancy.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FRaspberry,
                    Name = "Raspberry",
                    Description = "Tart berry high in fiber, vitamins K, E, and B5, and minerals like zinc.",
                    FoodCategoryId = FCFruits,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe and nutrient-dense. High fiber makes it excellent for digestion.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FPineapple,
                    Name = "Pineapple",
                    Description = "Tropical fruit with sweet-tart flavor, used in salads and soups.",
                    FoodCategoryId = FCFruits,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe and hydrating; peel and core before eating.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },

                // --- Nuts ---
                new Food
                {
                    Id = FAlmond,
                    Name = "Almonds",
                    Description = "Nutrient-dense nut high in vitamin E, magnesium, and protein.",
                    FoodCategoryId = FCNut,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe in moderation. Helps with healthy fats and protein needs.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FWalnut,
                    Name = "Walnuts",
                    Description = "Rich in omega-3 fatty acids and antioxidants.",
                    FoodCategoryId = FCNut,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe and beneficial. Good for brain health during pregnancy.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FCashew,
                    Name = "Cashews",
                    Description = "Creamy nut high in copper, magnesium, and healthy fats.",
                    FoodCategoryId = FCNut,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe if not allergic. Limit roasted and salted versions to reduce sodium intake.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)

                },
                new Food
                {
                    Id = FPeanuts,
                    Name = "Peanuts",
                    Description = "A legume often consumed as a nut, rich in protein, healthy fats, and B vitamins.",
                    FoodCategoryId = FCNut,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe if not allergic. No need to avoid during pregnancy. Limit salted or roasted peanuts to reduce sodium intake.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FLotusSeeds,
                    Name = "Lotus Seeds",
                    Description = "Seeds from lotus flowers, used in sweet and savory dishes.",
                    FoodCategoryId = FCGrain,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe when cooked. Soak before use to remove bitterness.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                // --- Dairy ---
                new Food
                {
                    Id = FButter,
                    Name = "Butter",
                    Description = "Dairy-based fat product commonly used for cooking and baking.",
                    FoodCategoryId = FCDairy,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe in moderation. High in saturated fat, so limit intake.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },

                new Food
                {
                    Id = FMilk,
                    Name = "Milk",
                    Description = "A dairy product rich in calcium, protein, and vitamin B12. Commonly consumed as a beverage or used in cooking.",
                    FoodCategoryId = FCDairy,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe in moderation. Choose pasteurized milk to avoid infections such as listeria.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FEgg,
                    Name = "Egg",
                    Description = "A nutrient-rich food source containing high-quality protein, vitamins, and minerals.",
                    FoodCategoryId = FCDairy,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe if fully cooked. Avoid raw or undercooked eggs during pregnancy to prevent salmonella risk.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                // --- Grains ---

                new Food
                {
                    Id = FSoyBean,
                    Name = "SoyBean",
                    Description = "A legume commonly consumed as soybeans, tofu, soy milk, and soy sauce. High in protein and isoflavones.",
                    FoodCategoryId = FCVeg,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Generally safe in moderate amounts. Limit highly processed soy products.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FRice,
                    Name = "Rice",
                    Description = "A staple cereal grain high in net carbohydrates and general carbohydrates.",
                    FoodCategoryId = FCGrain,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Generally safe when cooked properly; rinse to remove arsenic residues.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FGlutinousRice,
                    Name = "Glutinous Rice",
                    Description = "Also called sticky rice; a glutinous grain high in net carbs and carbohydrates.",
                    FoodCategoryId = FCGrain,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe when cooked; may be high in simple carbs, so eat in moderation.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FNoodles,
                    Name = "Noodles",
                    Description = "A refined grain product with folate (B9) content alongside net carbohydrates.",
                    FoodCategoryId = FCGrain,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Generally safe; opt for whole-grain versions for added fiber.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FChickpeas,
                    Name = "Chickpeas",
                    Description = "A legume high in fiber and folate (rich source of B9).",
                    FoodCategoryId = FCGrain,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Generally safe; may cause digestive gas in some—soaking may help.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FTofu,
                    Name = "Tofu",
                    Description = "A soy-based food made from soybeans, notable for calcium and polyunsaturated fat.",
                    FoodCategoryId = FCGrain,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Generally safe; choose low-sodium or calcium-coagulant types if concerned.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },


                // --- Baked Products ---

                new Food
                {
                    Id = FWheatBread,
                    Name = "Wheat Bread",
                    Description = "Bread made from wheat flour, a staple source of carbohydrates and dietary fiber.",
                    FoodCategoryId = FCBakedPr,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe for most, but should be avoided by people with gluten intolerance or celiac disease.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },


                new Food
                {
                    Id = FRiceBread,
                    Name = "Rice Bread",
                    Description = "Bread made primarily from rice flour, naturally gluten-free and easy to digest.",
                    FoodCategoryId = FCBakedPr,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe and light option for gluten-sensitive individuals. Choose fortified versions for better nutrition.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FGFMultigrainBread,
                    Name = "Gluten-Free Multigrain Bread",
                    Description = "Bread made from a mix of gluten-free grains such as sorghum, millet, quinoa, and brown rice flour.",
                    FoodCategoryId = FCBakedPr,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe and nutrient-dense. Ensure certified gluten-free to avoid cross-contamination with wheat.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FRicePaper,
                    Name = "Rice Paper",
                    Description = "Thin rice sheets for spring rolls and summer rolls.",
                    FoodCategoryId = FCBakedPr,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Hydrate briefly before use; safe when fresh.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FBanhMi,
                    Name = "Bánh Mì (Vietnamese Sandwich)",
                    Description = "Vietnamese baguette sandwich typically with bread, protein, pickled vegetables, herbs, and condiments.",
                    FoodCategoryId = FCBakedPr, // Baked Products
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe when ingredients are fresh and meats are fully cooked. Can be high in sodium/refined carbs depending on fillings and sauces.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                // --- Beverages ---
                new Food
                {
                    Id = FWater,
                    Name = "Water",
                    Description = "The most essential beverage for hydration, supporting digestion and nutrient transport.",
                    FoodCategoryId = FCBeverages,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe and vital. Pregnant women should aim for 8–10 glasses of water daily.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FHerbalTea,
                    Name = "Herbal Tea (Chamomile, Ginger, Rooibos)",
                    Description = "Caffeine-free teas made from herbs, often used to aid relaxation or digestion.",
                    FoodCategoryId = FCBeverages,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe in moderation. Avoid herbs not recommended in pregnancy (e.g., licorice root).",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FAppleJuice,
                    Name = "Apple Juice",
                    Description = "Sweet fruit juice made from pressed apples, rich in vitamin C and natural sugars.",
                    FoodCategoryId = FCBeverages,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe in moderation. Choose pasteurized juice to avoid bacterial risk. Prefer whole fruit over juice to control sugar intake.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FOrangeJuice,
                    Name = "Orange Juice",
                    Description = "Citrus juice high in vitamin C, folate, and antioxidants.",
                    FoodCategoryId = FCBeverages,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe and beneficial during pregnancy. Choose pasteurized, fortified varieties for added folate. Limit to 1 cup daily due to sugar content.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FPineappleJuice,
                    Name = "Pineapple Juice",
                    Description = "Tropical fruit juice rich in vitamin C, manganese, and bromelain enzyme.",
                    FoodCategoryId = FCBeverages,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe in moderation. High in natural sugars; dilute with water if desired. Choose pasteurized varieties.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FCarrotJuice,
                    Name = "Carrot Juice",
                    Description = "Vegetable juice extremely high in beta-carotene and vitamin A.",
                    FoodCategoryId = FCBeverages,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe but limit intake due to very high vitamin A content. Excess vitamin A can be harmful during pregnancy. Maximum 1/2 cup daily.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FTomatoJuice,
                    Name = "Tomato Juice",
                    Description = "Vegetable juice rich in lycopene, vitamin C, and potassium.",
                    FoodCategoryId = FCBeverages,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe and nutritious. Choose low-sodium varieties to avoid excess salt intake during pregnancy.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FCranberryJuice,
                    Name = "Cranberry Juice",
                    Description = "Tart berry juice known for urinary tract health benefits, high in vitamin C.",
                    FoodCategoryId = FCBeverages,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe and may help prevent UTIs during pregnancy. Choose unsweetened or lightly sweetened varieties to reduce sugar intake.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FGrapeJuice,
                    Name = "Grape Juice",
                    Description = "Sweet fruit juice rich in antioxidants and natural sugars.",
                    FoodCategoryId = FCBeverages,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe in moderation. High in natural sugars; limit to small portions. Choose 100% grape juice without added sugars.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FLemonade,
                    Name = "Lemonade",
                    Description = "Refreshing citrus drink made from lemon juice, water, and sweetener.",
                    FoodCategoryId = FCBeverages,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe and can help with morning sickness. Control sugar content by making homemade or choosing low-sugar versions.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FSmoothie,
                    Name = "Fruit Smoothie",
                    Description = "Blended drink combining fruits, vegetables, and liquid base, rich in vitamins and fiber.",
                    FoodCategoryId = FCBeverages,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe and nutritious when made with pasteurized ingredients. Excellent way to increase fruit and vegetable intake during pregnancy.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FAlmondMilk,
                    Name = "Almond Milk",
                    Description = "Plant-based milk alternative made from ground almonds, often fortified with calcium and vitamins.",
                    FoodCategoryId = FCBeverages,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe alternative to dairy milk. Choose fortified versions for calcium and vitamin D. Lower in protein than cow's milk.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FRiceMilk,
                    Name = "Rice Milk",
                    Description = "Plant-based milk alternative made from rice, naturally sweet and easy to digest.",
                    FoodCategoryId = FCBeverages,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe for those with multiple food allergies. Choose fortified versions. Lower in protein than dairy milk.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FAloeVeraJuice,
                    Name = "Aloe Vera Juice",
                    Description = "Juice from aloe vera plant, known for soothing digestive properties.",
                    FoodCategoryId = FCBeverages,
                    ImageUrl = null,
                    PregnancySafe = false,
                    SafetyNote = "Not recommended during pregnancy. May cause uterine contractions and digestive issues. Consult healthcare provider before use.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FGreenTea,
                    Name = "Green Tea",
                    Description = "Lightly caffeinated tea rich in antioxidants and catechins.",
                    FoodCategoryId = FCBeverages,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe in moderation (1-2 cups daily). Contains caffeine; limit total daily caffeine intake to 200mg during pregnancy.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FBlackTea,
                    Name = "Black Tea",
                    Description = "Traditional caffeinated tea with robust flavor and antioxidants.",
                    FoodCategoryId = FCBeverages,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe in moderation (1-2 cups daily). Monitor total daily caffeine intake; limit to 200mg during pregnancy.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FCarbonatedWater,
                    Name = "Carbonated Water",
                    Description = "Sparkling water with natural or added carbonation, refreshing and calorie-free.",
                    FoodCategoryId = FCBeverages,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe and can help with nausea and morning sickness. Choose varieties without added sodium or artificial sweeteners.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FBottledWater,
                    Name = "Bottled Water",
                    Description = "Purified or spring water sold in bottles, convenient source of hydration.",
                    FoodCategoryId = FCBeverages,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe and convenient. Ensure from reputable sources. Consider environmental impact; filtered tap water is often equally safe.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                // --- Spices ---
                new Food
                {
                    Id = FCinnamon,
                    Name = "Cinnamon",
                    Description = "A warming spice with antioxidant properties, often used in sweet and savory dishes.",
                    FoodCategoryId = FCSpice,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe in small amounts. Avoid high supplemental doses which may affect blood sugar.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },

                new Food
                {
                    Id = FTurmeric,
                    Name = "Turmeric",
                    Description = "A golden spice containing curcumin, known for anti-inflammatory benefits.",
                    FoodCategoryId = FCSpice,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe in food amounts. Avoid concentrated supplements unless prescribed.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FChiliPowder,
                    Name = "Chili Powder",
                    Description = "A spicy seasoning made from dried ground chili peppers, commonly used in savory dishes.",
                    FoodCategoryId = FCSpice,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe in moderation. Excess may cause heartburn or digestive discomfort during pregnancy.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FTableSalt,
                    Name = "Table Salt",
                    Description = "A common seasoning composed mainly of sodium chloride, often fortified with iodine.",
                    FoodCategoryId = FCSpice,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe in moderate amounts. Excess salt may contribute to water retention and high blood pressure.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FBlackPepper,
                    Name = "Black Pepper",
                    Description = "A popular spice made from ground peppercorns, adding a sharp and mildly spicy flavor.",
                    FoodCategoryId = FCSpice,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe in food amounts. Large amounts may irritate the stomach lining during pregnancy.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FStarAnise,
                    Name = "Star Anise",
                    Description = "Aromatic spice with licorice flavor, used in broths.",
                    FoodCategoryId = FCSpice,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Use sparingly. Remove whole pods before serving.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FSugar,
                    Name = "Sugar",
                    Description = "Sweetener used in desserts, sauces, and beverages.",
                    FoodCategoryId = FCSpice,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Use in moderation to control blood sugar levels.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FVinegar,
                    Name = "Vinegar",
                    Description = "Acidic condiment made from fermented ethanol.",
                    FoodCategoryId = FCSpice,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Safe in cooking amounts; avoid excessive consumption.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FMSG,
                    Name = "Monosodium Glutamate (MSG)",
                    Description = "Flavor enhancer commonly used in Asian cooking.",
                    FoodCategoryId = FCSpice,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Generally safe; avoid if sensitive to glutamates.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FSoupPowder,
                    Name = "Soup Powder",
                    Description = "Instant soup seasoning base for quick broth preparation.",
                    FoodCategoryId = FCSpice,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "High in sodium; rinse ingredients or use low-sodium version.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Food
                {
                    Id = FCoriander,
                    Name = "Coriander",
                    Description = "A type of traditional Vietnamese herb that is typically used for garnish",
                    FoodCategoryId = FCSpice,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "a type of greens that is safe for use",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                // --- Mushrooms ---
                new Food
                {
                    Id = FShiitake,
                    Name = "Shiitake Mushrooms",
                    Description = "Umami-rich mushrooms used fresh or dried in many dishes.",
                    FoodCategoryId = FCMushroom,
                    ImageUrl = null,
                    PregnancySafe = true,
                    SafetyNote = "Rehydrate dried mushrooms; cook thoroughly.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );
            // ---------------------------------------------------
            // DISEASE
            // ---------------------------------------------------
            var DDiabetes = Guid.NewGuid();
            var DHypertension = Guid.NewGuid();
            var DCeliac = Guid.NewGuid();
            var DAnemia = Guid.NewGuid();

            var DCough = Guid.NewGuid();
            var DCold = Guid.NewGuid();
            var DFlu = Guid.NewGuid();
            var DDiarrhea = Guid.NewGuid();
            var DFever = Guid.NewGuid();
            modelBuilder.Entity<Disease>().HasData(
                // ==== Chronic ====
                new Disease
                {
                    Id = DDiabetes,
                    Name = "Gestational Diabetes",
                    Description = "A form of diabetes that develops during pregnancy, leading to elevated blood sugar levels.",
                    Symptoms = "Increased thirst, frequent urination, fatigue, blurred vision.",
                    TreatmentOptions = "Dietary changes, exercise, blood sugar monitoring, insulin therapy if required.",
                    PregnancyRelated = true,
                    RiskLevel = "High",
                    TypeOfDesease = "Chronic",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Disease
                {
                    Id = DHypertension,
                    Name = "Chronic Hypertension",
                    Description = "High blood pressure present before pregnancy or diagnosed before 20 weeks of gestation.",
                    Symptoms = "Often asymptomatic, may include headaches, dizziness, or vision problems.",
                    TreatmentOptions = "Antihypertensive medication, reduced sodium intake, regular monitoring.",
                    PregnancyRelated = true,
                    RiskLevel = "High",
                    TypeOfDesease = "Chronic",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Disease
                {
                    Id = DCeliac,
                    Name = "Celiac Disease",
                    Description = "An autoimmune disorder where ingestion of gluten damages the small intestine.",
                    Symptoms = "Diarrhea, weight loss, bloating, fatigue, anemia.",
                    TreatmentOptions = "Strict lifelong gluten-free diet, nutritional supplements if deficient.",
                    PregnancyRelated = true,
                    RiskLevel = "Medium",
                    TypeOfDesease = "Chronic",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Disease
                {
                    Id = DAnemia,
                    Name = "Anemia (Iron-Deficiency)",
                    Description = "Low red blood cell count due to inadequate iron, reducing oxygen delivery to tissues.",
                    Symptoms = "Fatigue, weakness, pale skin, shortness of breath.",
                    TreatmentOptions = "Iron supplements, iron-rich diet, folic acid and vitamin B12 support.",
                    PregnancyRelated = true,
                    RiskLevel = "Medium",
                    TypeOfDesease = "Chronic",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },

                // ==== Acute / Temporary ====
                new Disease
                {
                    Id = DCough,
                    Name = "Cough and Respiratory Irritation",
                    Description = "A temporary condition caused by viral infections, allergies, or irritation affecting the airways.",
                    Symptoms = "Coughing, sore throat, chest discomfort.",
                    TreatmentOptions = "Hydration, warm fluids, honey (if not allergic), avoid irritants, safe cough remedies.",
                    PregnancyRelated = true,
                    RiskLevel = "Low",
                    TypeOfDesease = "Acute",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Disease
                {
                    Id = DCold,
                    Name = "Common Cold",
                    Description = "A mild viral infection affecting the upper respiratory tract.",
                    Symptoms = "Runny nose, sneezing, mild fever, sore throat, fatigue.",
                    TreatmentOptions = "Rest, hydration, vitamin C-rich foods, avoid excessive dairy if it worsens mucus.",
                    PregnancyRelated = true,
                    RiskLevel = "Low",
                    TypeOfDesease = "Acute",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Disease
                {
                    Id = DFlu,
                    Name = "Seasonal Flu",
                    Description = "An acute viral infection that can cause moderate to severe symptoms.",
                    Symptoms = "Fever, chills, muscle aches, cough, sore throat, fatigue.",
                    TreatmentOptions = "Rest, hydration, balanced diet, avoid high-fat and heavy meals, physician-approved antivirals if severe.",
                    PregnancyRelated = true,
                    RiskLevel = "Medium",
                    TypeOfDesease = "Acute",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Disease
                {
                    Id = DDiarrhea,
                    Name = "Diarrhea",
                    Description = "Temporary digestive upset that may result from infection, food intolerance, or stress.",
                    Symptoms = "Loose stools, abdominal cramping, dehydration risk.",
                    TreatmentOptions = "Oral rehydration, bland foods (bananas, rice, applesauce, toast), avoid dairy and fatty foods.",
                    PregnancyRelated = true,
                    RiskLevel = "Medium",
                    TypeOfDesease = "Acute",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Disease
                {
                    Id = DFever,
                    Name = "Fever",
                    Description = "Elevated body temperature usually caused by infection or inflammation.",
                    Symptoms = "High temperature, chills, sweating, muscle aches.",
                    TreatmentOptions = "Plenty of fluids, light meals, avoid spicy/oily foods, physician-approved fever reducers if needed.",
                    PregnancyRelated = true,
                    RiskLevel = "Medium",
                    TypeOfDesease = "Acute",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );
            // ---------------------------------------------------
            // FOOD-DISEASE RELATIONS
            // ---------------------------------------------------
            modelBuilder.Entity<FoodDisease>().HasData(
                // === Gestational Diabetes ===
                new FoodDisease
                {
                    DiseaseId = DDiabetes,
                    FoodId = FButter,
                    Status = FoodDiseaseStatus.Warning,
                    Description = "High in saturated fat, may worsen insulin resistance."
                },
                new FoodDisease
                {
                    DiseaseId = DDiabetes,
                    FoodId = FSpinach,
                    Status = FoodDiseaseStatus.Recommend,
                    Description = "Rich in folate, fiber, and low in calories. Supports blood sugar control."
                },
                new FoodDisease
                {
                    DiseaseId = DDiabetes,
                    FoodId = FAlmond,
                    Status = FoodDiseaseStatus.Recommend,
                    Description = "Provides healthy fats and protein to stabilize blood sugar."
                },

                // === Hypertension ===
                new FoodDisease
                {
                    DiseaseId = DHypertension,
                    FoodId = FPeanuts,
                    Status = FoodDiseaseStatus.Warning,
                    Description = "Limit salted peanuts due to high sodium content, which raises blood pressure."
                },
                new FoodDisease
                {
                    DiseaseId = DHypertension,
                    FoodId = FOliveOil,
                    Status = FoodDiseaseStatus.Recommend,
                    Description = "Rich in heart-healthy monounsaturated fats. Supports blood pressure regulation."
                },
                new FoodDisease
                {
                    DiseaseId = DHypertension,
                    FoodId = FBroccoli,
                    Status = FoodDiseaseStatus.Recommend,
                    Description = "High in potassium and fiber. Helps regulate blood pressure."
                },

                // === Celiac Disease ===
                new FoodDisease
                {
                    DiseaseId = DCeliac,
                    FoodId = FChicken,
                    Status = FoodDiseaseStatus.Recommend,
                    Description = "Naturally gluten-free, safe source of protein."
                },
                new FoodDisease
                {
                    DiseaseId = DCeliac,
                    FoodId = FTuna,
                    Status = FoodDiseaseStatus.Recommend,
                    Description = "Naturally gluten-free and rich in omega-3, but limit due to mercury."
                },
                new FoodDisease
                {
                    DiseaseId = DCeliac,
                    FoodId = FGFMultigrainBread,
                    Status = FoodDiseaseStatus.Recommend,
                    Description = "Gluten-free alternative that you can try."
                },
                new FoodDisease
                {
                    DiseaseId = DCeliac,
                    FoodId = FRiceBread,
                    Status = FoodDiseaseStatus.Recommend,
                    Description = "Gluten-free alternative that you can try."
                },
                new FoodDisease
                {
                    DiseaseId = DCeliac,
                    FoodId = FWheatBread,
                    Status = FoodDiseaseStatus.Warning,
                    Description = "Please choose bread that is gluten-free"
                },

                // === Anemia ===
                new FoodDisease
                {
                    DiseaseId = DAnemia,
                    FoodId = FBeef,
                    Status = FoodDiseaseStatus.Recommend,
                    Description = "Excellent source of heme iron and vitamin B12."
                },
                new FoodDisease
                {
                    DiseaseId = DAnemia,
                    FoodId = FSpinach,
                    Status = FoodDiseaseStatus.Recommend,
                    Description = "Good source of non-heme iron and folate, supports red blood cell production."
                },

                // === Acute Conditions ===

                // Cough
                new FoodDisease
                {
                    DiseaseId = DCough,
                    FoodId = FMilk,
                    Status = FoodDiseaseStatus.Warning,
                    Description = "May increase mucus production and worsen cough in some individuals."
                },
                new FoodDisease
                {
                    DiseaseId = DCough,
                    FoodId = FChicken,
                    Status = FoodDiseaseStatus.Warning,
                    Description = "Chicken can worsen the symptom"
                },

                // Cold
                new FoodDisease
                {
                    DiseaseId = DCold,
                    FoodId = FOrange,
                    Status = FoodDiseaseStatus.Recommend,
                    Description = "High in vitamin C, supports immune function."
                },
                new FoodDisease
                {
                    DiseaseId = DCold,
                    FoodId = FButter,
                    Status = FoodDiseaseStatus.Warning,
                    Description = "High-fat foods may worsen inflammation and slow recovery."
                },

                // Flu
                new FoodDisease
                {
                    DiseaseId = DFlu,
                    FoodId = FTomato,
                    Status = FoodDiseaseStatus.Recommend,
                    Description = "Rich in vitamin C and antioxidants, helps immune system."
                },
                new FoodDisease
                {
                    DiseaseId = DFlu,
                    FoodId = FSunflowerOil,
                    Status = FoodDiseaseStatus.Warning,
                    Description = "Fried foods cooked in excess oil may worsen nausea and fatigue."
                },

                // Diarrhea
                new FoodDisease
                {
                    DiseaseId = DDiarrhea,
                    FoodId = FButter,
                    Status = FoodDiseaseStatus.Warning,
                    Description = "High-fat foods worsen diarrhea symptoms."
                },
                new FoodDisease
                {
                    DiseaseId = DDiarrhea,
                    FoodId = FCarrot,
                    Status = FoodDiseaseStatus.Recommend,
                    Description = "Easy to digest and part of the BRAT diet (bananas, rice, applesauce, toast)."
                },

                // Fever
                new FoodDisease
                {
                    DiseaseId = DFever,
                    FoodId = FChicken,
                    Status = FoodDiseaseStatus.Recommend,
                    Description = "Light, protein-rich food that is easy to digest during fever."
                },
                new FoodDisease
                {
                    DiseaseId = DFever,
                    FoodId = FButter,
                    Status = FoodDiseaseStatus.Warning,
                    Description = "High-fat foods can be harder to digest during fever."
                }
            );

            // ---------------------------------------------------
            // ALLERGY CATEGORY
            // ---------------------------------------------------
            var AllergyFood = Guid.NewGuid();
            var AllergyPet = Guid.NewGuid();
            var AllergyMold = Guid.NewGuid();
            var AllergyLatex = Guid.NewGuid();
            var AllergyInsect = Guid.NewGuid();
            var AllergyPollen = Guid.NewGuid();
            modelBuilder.Entity<AllergyCategory>().HasData(
                new AllergyCategory
                {
                    Id = AllergyFood,
                    Name = "Food Allergy",
                    Description = "There are different types of allergic reactions to foods. There are differences between IgE-mediated allergies, non-IgE mediated allergies and food intolerances.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new AllergyCategory
                {
                    Id = AllergyPet,
                    Name = "Pet Allergy",
                    Description = "Allergies to pets with fur are common. It is important to know that an allergy-free (hypoallergenic) breed of dog or cat does not exist.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new AllergyCategory
                {
                    Id = AllergyMold,
                    Name = "Mold Allergy",
                    Description = "Mold and mildew are fungi. Since fungi grow in so many places, both indoors and outdoors, allergic reactions to mold can occur year round.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new AllergyCategory
                {
                    Id = AllergyLatex,
                    Name = "Latex Allergy",
                    Description = "A latex allergy is an allergic reaction to natural rubber latex. Natural rubber latex gloves, balloons, condoms and other natural rubber products contain latex. An allergy to latex can be a serious health risk.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new AllergyCategory
                {
                    Id = AllergyInsect,
                    Name = "Insect Allergy",
                    Description = "Bees, wasps, hornets, yellow jackets and fire ants are the most common stinging insects that cause an allergic reaction.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new AllergyCategory
                {
                    Id = AllergyPollen,
                    Name = "Pollen Allergy",
                    Description = "Pollen is one of the most common triggers of seasonal allergies. Many people know pollen allergy as “hay fever,” but experts usually refer to it as “seasonal allergic rhinitis.”",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );
            // ---------------------------------------------------
            // ALLERGY
            // ---------------------------------------------------
            var MilkA = Guid.NewGuid();
            var EggA = Guid.NewGuid();
            var PeanutA = Guid.NewGuid();
            var TreeNutA = Guid.NewGuid();
            var FishA = Guid.NewGuid();
            var ShellfishA = Guid.NewGuid();
            var SoyA = Guid.NewGuid();
            var WheatA = Guid.NewGuid();

            modelBuilder.Entity<Allergy>().HasData(
                new Allergy
                {
                    Id = MilkA,
                    AllergyCategoryId = AllergyFood,
                    Name = "Milk",
                    Description = "An immune system reaction to proteins found in cow’s milk and dairy products.",
                    CommonSymptoms = "Hives, wheezing, vomiting, digestive issues, anaphylaxis in severe cases.",
                    PregnancyRisk = "Generally not dangerous to the fetus directly, but maternal nutrition may be affected if dairy intake is restricted.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Allergy
                {
                    Id = EggA,
                    AllergyCategoryId = AllergyFood,
                    Name = "Egg",
                    Description = "Reaction to proteins in egg whites or yolks, common in children.",
                    CommonSymptoms = "Skin rashes, respiratory issues, stomach pain, anaphylaxis in severe cases.",
                    PregnancyRisk = "Minimal risk to fetus; ensure maternal protein intake from alternative sources.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Allergy
                {
                    Id = PeanutA,
                    AllergyCategoryId = AllergyFood,
                    Name = "Peanut",
                    Description = "One of the most common and severe food allergies caused by peanut proteins.",
                    CommonSymptoms = "Hives, swelling, difficulty breathing, anaphylaxis.",
                    PregnancyRisk = "High maternal stress or reactions may indirectly affect pregnancy. Careful avoidance required.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Allergy
                {
                    Id = TreeNutA,
                    AllergyCategoryId = AllergyFood,
                    Name = "Tree Nut",
                    Description = "Allergy to nuts such as almonds, walnuts, cashews, and pecans.",
                    CommonSymptoms = "Skin reactions, stomach pain, throat swelling, anaphylaxis.",
                    PregnancyRisk = "Similar to peanut allergy; requires strict avoidance during pregnancy.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Allergy
                {
                    Id = FishA,
                    AllergyCategoryId = AllergyFood,
                    Name = "Fish",
                    Description = "Reaction to proteins in finned fish such as salmon, tuna, or cod.",
                    CommonSymptoms = "Hives, nausea, headaches, breathing difficulties, anaphylaxis.",
                    PregnancyRisk = "Fish avoidance may reduce omega-3 intake; supplementation may be needed under medical advice.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Allergy
                {
                    Id = ShellfishA,
                    AllergyCategoryId = AllergyFood,
                    Name = "Shellfish",
                    Description = "Immune reaction to proteins in crustaceans and mollusks such as shrimp, crab, or lobster.",
                    CommonSymptoms = "Skin reactions, digestive distress, shortness of breath, severe anaphylaxis.",
                    PregnancyRisk = "Strict avoidance needed to prevent maternal reactions; nutritional substitutes may be required.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Allergy
                {
                    Id = SoyA,
                    AllergyCategoryId = AllergyFood,
                    Name = "Soy",
                    Description = "Allergy to proteins found in soybeans and soy products.",
                    CommonSymptoms = "Hives, itching, digestive issues, in rare cases anaphylaxis.",
                    PregnancyRisk = "Minimal direct impact; soy is a common protein source, so alternatives should be considered.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Allergy
                {
                    Id = WheatA,
                    AllergyCategoryId = AllergyFood,
                    Name = "Wheat",
                    Description = "Reaction to proteins found in wheat, distinct from celiac disease.",
                    CommonSymptoms = "Skin rash, hives, nasal congestion, digestive issues, anaphylaxis.",
                    PregnancyRisk = "Avoiding wheat may reduce carbohydrate intake; ensure alternative grains are included.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );
            // ---------------------------------------------------
            // FOOD-ALLERGY RELATIONS
            // ---------------------------------------------------
            modelBuilder.Entity<FoodAllergy>().HasData(
            // Dairy
            new FoodAllergy
            {
                FoodId = FMilk,
                AllergyId = MilkA,
                Description = "Milk is a common allergen that can cause hives, digestive issues, or respiratory problems in allergic individuals. Lactose intolerance is different and involves difficulty digesting milk sugar."
            },
            new FoodAllergy
            {
                FoodId = FButter,
                AllergyId = MilkA,
                Description = "Butter contains milk proteins that can trigger allergic reactions, though clarified butter (ghee) may sometimes be tolerated."
            },
            new FoodAllergy
            {
                FoodId = FEgg,
                AllergyId = EggA,
                Description = "Egg allergy is common in children and may cause skin rashes, respiratory issues, and digestive symptoms. Avoid both yolk and white unless tolerance is confirmed."
            },

            // Peanuts
            new FoodAllergy
            {
                FoodId = FPeanuts,
                AllergyId = PeanutA,
                Description = "Peanuts are one of the most severe allergens, often causing rapid reactions including anaphylaxis. Strict avoidance is essential."
            },

            // Tree Nuts
            new FoodAllergy
            {
                FoodId = FAlmond,
                AllergyId = TreeNutA,
                Description = "Almonds may cause allergic reactions ranging from mild itching to severe anaphylaxis in individuals sensitive to tree nuts."
            },
            new FoodAllergy
            {
                FoodId = FWalnut,
                AllergyId = TreeNutA,
                Description = "Walnuts are a common trigger of tree nut allergy, which can cause swelling, abdominal pain, and potentially life-threatening reactions."
            },
            new FoodAllergy
            {
                FoodId = FCashew,
                AllergyId = TreeNutA,
                Description = "Cashew allergy is often severe and can lead to anaphylaxis. Even trace amounts may provoke reactions."
            },

            // Fish
            new FoodAllergy
            {
                FoodId = FTuna,
                AllergyId = FishA,
                Description = "Tuna allergy is less common but can cause hives, nausea, or asthma-like symptoms. Cross-contamination with other fish is also a risk."
            },
            new FoodAllergy
            {
                FoodId = FCod,
                AllergyId = FishA,
                Description = "Cod is a frequent cause of fish allergy, especially in children. Cooking does not remove allergenic proteins."
            },

            // Shellfish
            new FoodAllergy
            {
                FoodId = FShrimp,
                AllergyId = ShellfishA,
                Description = "Shrimp is one of the most common shellfish allergens and can trigger severe reactions including anaphylaxis. Patients are usually allergic to multiple shellfish species."
            }
            );

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
                new NutrientSuggestionAttribute { NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugVitamins, AttributeId = attrVitaminA, AgeGroudId = age20To29, Trimester = 1 },
                new NutrientSuggestionAttribute { NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugVitamins, AttributeId = attrVitaminD, AgeGroudId = age20To29, Trimester = 1 },
                new NutrientSuggestionAttribute { NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugVitamins, AttributeId = attrVitaminE, AgeGroudId = age20To29, Trimester = 1 },
                new NutrientSuggestionAttribute { NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugVitamins, AttributeId = attrVitaminK, AgeGroudId = age20To29, Trimester = 1 },
                new NutrientSuggestionAttribute { NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugVitamins, AttributeId = attrVitaminB1, AgeGroudId = age20To29, Trimester = 1 },
                new NutrientSuggestionAttribute { NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugVitamins, AttributeId = attrVitaminB2, AgeGroudId = age20To29, Trimester = 1 },
                new NutrientSuggestionAttribute { NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugVitamins, AttributeId = attrVitaminB6, AgeGroudId = age20To29, Trimester = 1 },
                new NutrientSuggestionAttribute { NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugVitamins, AttributeId = attrFolate, AgeGroudId = age20To29, Trimester = 1 },
                new NutrientSuggestionAttribute { NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugVitamins, AttributeId = attrVitaminB12, AgeGroudId = age20To29, Trimester = 1 },
                new NutrientSuggestionAttribute { NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugVitamins, AttributeId = attrVitaminC, AgeGroudId = age20To29, Trimester = 1 },
                new NutrientSuggestionAttribute { NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugVitamins, AttributeId = attrCholine, AgeGroudId = age20To29, Trimester = 1 },

                // Other
                new NutrientSuggestionAttribute { NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugOther, AttributeId = attrFiber, AgeGroudId = age20To29, Trimester = 1 },
                new NutrientSuggestionAttribute { NutrientSuggestionAttributeId = Guid.NewGuid(), NutrientSuggetionId = sugOther, AttributeId = attrSalt, AgeGroudId = age20To29, Trimester = 1 }
            );

            // ---------------------------------------------------
            // FOODNUTRIENT DATA
            // ---------------------------------------------------
            modelBuilder.Entity<FoodNutrient>().HasData(
                new FoodNutrient
                {
                    FoodId = FChicken,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 27,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChicken,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChicken,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChicken,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChicken,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChicken,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChicken,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChicken,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 10,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChicken,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChicken,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.4,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChicken,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChicken,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChicken,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChicken,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChicken,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 10,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChicken,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChicken,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChicken,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChicken,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 90,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChicken,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeef,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 27,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeef,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeef,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeef,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeef,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeef,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeef,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeef,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 10,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeef,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeef,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.4,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeef,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeef,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeef,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeef,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeef,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 10,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeef,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeef,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeef,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeef,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 90,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeef,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPork,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 27,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPork,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPork,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPork,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPork,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPork,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPork,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPork,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 10,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPork,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPork,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.4,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPork,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPork,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPork,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPork,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPork,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 10,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPork,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPork,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPork,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPork,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 90,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPork,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShrimp,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 27,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShrimp,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShrimp,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShrimp,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShrimp,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShrimp,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShrimp,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShrimp,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 10,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShrimp,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShrimp,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.4,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShrimp,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShrimp,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShrimp,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShrimp,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShrimp,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 10,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShrimp,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShrimp,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShrimp,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShrimp,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 90,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShrimp,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTuna,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 27,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTuna,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTuna,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTuna,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTuna,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTuna,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTuna,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTuna,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 10,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTuna,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTuna,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.4,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTuna,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTuna,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTuna,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTuna,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTuna,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 10,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTuna,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTuna,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTuna,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTuna,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 90,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTuna,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCod,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 27,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCod,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCod,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCod,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCod,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCod,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCod,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCod,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 10,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCod,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCod,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.4,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCod,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCod,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCod,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCod,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCod,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 10,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCod,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCod,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCod,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCod,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 90,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCod,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpinach,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpinach,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpinach,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpinach,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 100,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpinach,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpinach,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpinach,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpinach,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpinach,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpinach,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpinach,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpinach,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpinach,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpinach,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpinach,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 80,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpinach,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpinach,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpinach,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpinach,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpinach,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FKale,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FKale,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FKale,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FKale,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 100,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FKale,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FKale,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FKale,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FKale,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FKale,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FKale,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FKale,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FKale,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FKale,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FKale,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FKale,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 80,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FKale,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FKale,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FKale,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FKale,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FKale,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLettuce,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLettuce,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLettuce,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLettuce,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 100,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLettuce,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLettuce,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLettuce,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLettuce,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLettuce,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLettuce,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLettuce,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLettuce,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLettuce,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLettuce,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLettuce,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 80,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLettuce,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLettuce,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLettuce,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLettuce,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLettuce,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrot,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrot,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrot,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrot,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 100,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrot,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrot,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrot,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrot,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrot,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrot,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrot,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrot,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrot,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrot,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrot,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 80,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrot,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrot,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrot,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrot,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrot,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBroccoli,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBroccoli,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBroccoli,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBroccoli,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 100,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBroccoli,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBroccoli,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBroccoli,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBroccoli,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBroccoli,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBroccoli,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBroccoli,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBroccoli,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBroccoli,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBroccoli,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBroccoli,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 80,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBroccoli,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBroccoli,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBroccoli,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBroccoli,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBroccoli,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomato,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomato,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomato,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomato,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 100,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomato,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomato,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomato,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomato,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomato,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomato,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomato,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomato,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomato,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomato,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomato,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 80,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomato,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomato,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomato,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomato,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomato,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGarlic,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGarlic,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGarlic,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGarlic,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 100,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGarlic,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGarlic,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGarlic,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGarlic,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGarlic,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGarlic,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGarlic,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGarlic,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGarlic,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGarlic,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGarlic,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 80,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGarlic,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGarlic,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGarlic,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGarlic,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGarlic,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEggplant,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 27,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEggplant,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEggplant,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEggplant,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEggplant,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEggplant,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEggplant,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEggplant,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 10,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEggplant,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEggplant,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.4,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEggplant,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEggplant,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEggplant,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEggplant,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEggplant,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 10,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEggplant,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEggplant,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEggplant,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEggplant,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 90,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEggplant,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeanSprouts,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeanSprouts,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeanSprouts,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeanSprouts,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 100,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeanSprouts,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeanSprouts,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeanSprouts,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeanSprouts,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeanSprouts,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeanSprouts,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeanSprouts,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeanSprouts,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeanSprouts,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeanSprouts,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeanSprouts,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 80,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeanSprouts,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeanSprouts,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeanSprouts,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeanSprouts,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBeanSprouts,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemongrass,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemongrass,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemongrass,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemongrass,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 100,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemongrass,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemongrass,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemongrass,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemongrass,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemongrass,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemongrass,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemongrass,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemongrass,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemongrass,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemongrass,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemongrass,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 80,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemongrass,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemongrass,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemongrass,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemongrass,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemongrass,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOnion,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOnion,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOnion,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOnion,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 100,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOnion,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOnion,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOnion,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOnion,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOnion,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOnion,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOnion,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOnion,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOnion,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOnion,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOnion,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 80,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOnion,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOnion,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOnion,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOnion,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOnion,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpringOnion,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpringOnion,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpringOnion,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpringOnion,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 100,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpringOnion,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpringOnion,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpringOnion,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpringOnion,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpringOnion,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpringOnion,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpringOnion,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpringOnion,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpringOnion,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpringOnion,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpringOnion,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 80,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpringOnion,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpringOnion,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpringOnion,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpringOnion,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSpringOnion,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCucumber,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCucumber,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCucumber,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCucumber,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 100,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCucumber,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCucumber,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCucumber,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCucumber,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCucumber,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCucumber,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCucumber,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCucumber,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCucumber,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCucumber,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCucumber,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 80,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCucumber,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCucumber,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCucumber,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCucumber,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCucumber,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPumpkin,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPumpkin,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPumpkin,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPumpkin,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 100,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPumpkin,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPumpkin,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPumpkin,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPumpkin,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPumpkin,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPumpkin,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPumpkin,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPumpkin,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPumpkin,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPumpkin,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPumpkin,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 80,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPumpkin,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPumpkin,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPumpkin,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPumpkin,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPumpkin,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FApple,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FApple,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FApple,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 11.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FApple,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FApple,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FApple,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FApple,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FApple,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FApple,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FApple,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FApple,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FApple,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FApple,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FApple,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FApple,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 25,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FApple,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FApple,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 35,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FApple,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 9,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FApple,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FApple,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWatermelon,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWatermelon,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWatermelon,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 11.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWatermelon,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWatermelon,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWatermelon,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWatermelon,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWatermelon,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWatermelon,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWatermelon,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWatermelon,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWatermelon,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWatermelon,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWatermelon,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWatermelon,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 25,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWatermelon,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWatermelon,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 35,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWatermelon,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 9,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWatermelon,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWatermelon,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapefruit,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapefruit,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapefruit,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 11.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapefruit,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapefruit,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapefruit,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapefruit,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapefruit,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapefruit,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapefruit,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapefruit,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapefruit,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapefruit,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapefruit,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapefruit,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 25,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapefruit,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapefruit,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 35,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapefruit,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 9,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapefruit,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapefruit,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStrawberry,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStrawberry,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStrawberry,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 11.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStrawberry,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStrawberry,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStrawberry,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStrawberry,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStrawberry,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStrawberry,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStrawberry,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStrawberry,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStrawberry,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStrawberry,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStrawberry,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStrawberry,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 25,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStrawberry,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStrawberry,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 35,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStrawberry,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 9,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStrawberry,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStrawberry,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRaspberry,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRaspberry,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRaspberry,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 11.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRaspberry,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRaspberry,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRaspberry,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRaspberry,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRaspberry,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRaspberry,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRaspberry,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRaspberry,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRaspberry,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRaspberry,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRaspberry,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRaspberry,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 25,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRaspberry,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRaspberry,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 35,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRaspberry,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 9,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRaspberry,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRaspberry,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrange,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrange,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrange,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 11.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrange,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrange,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrange,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrange,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrange,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrange,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrange,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrange,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrange,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrange,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrange,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrange,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 25,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrange,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrange,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 35,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrange,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 9,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrange,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrange,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineapple,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineapple,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineapple,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 11.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineapple,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineapple,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineapple,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineapple,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineapple,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineapple,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineapple,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineapple,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineapple,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineapple,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineapple,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineapple,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 25,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineapple,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineapple,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 35,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineapple,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 9,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineapple,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineapple,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOliveOil,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOliveOil,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 100.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOliveOil,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOliveOil,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOliveOil,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOliveOil,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOliveOil,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOliveOil,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOliveOil,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOliveOil,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 14,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOliveOil,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 60,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOliveOil,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOliveOil,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOliveOil,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOliveOil,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOliveOil,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOliveOil,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOliveOil,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOliveOil,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOliveOil,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSunflowerOil,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSunflowerOil,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 100.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSunflowerOil,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSunflowerOil,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSunflowerOil,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSunflowerOil,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSunflowerOil,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSunflowerOil,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSunflowerOil,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSunflowerOil,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 14,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSunflowerOil,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 60,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSunflowerOil,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSunflowerOil,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSunflowerOil,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSunflowerOil,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSunflowerOil,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSunflowerOil,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSunflowerOil,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSunflowerOil,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSunflowerOil,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVegetableOil,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVegetableOil,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 100.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVegetableOil,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVegetableOil,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVegetableOil,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVegetableOil,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVegetableOil,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVegetableOil,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVegetableOil,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVegetableOil,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 14,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVegetableOil,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 60,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVegetableOil,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVegetableOil,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVegetableOil,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVegetableOil,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVegetableOil,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVegetableOil,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVegetableOil,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVegetableOil,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVegetableOil,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FFishSauce,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FFishSauce,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 100.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FFishSauce,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FFishSauce,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FFishSauce,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FFishSauce,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FFishSauce,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FFishSauce,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FFishSauce,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FFishSauce,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 14,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FFishSauce,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 60,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FFishSauce,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FFishSauce,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FFishSauce,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FFishSauce,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FFishSauce,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FFishSauce,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FFishSauce,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FFishSauce,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FFishSauce,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmond,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmond,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 55,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmond,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 22,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmond,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 250,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmond,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 4.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmond,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmond,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmond,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmond,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmond,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 26,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmond,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmond,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmond,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmond,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmond,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 50,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmond,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmond,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmond,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmond,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 55,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmond,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWalnut,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWalnut,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 55,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWalnut,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 22,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWalnut,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 250,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWalnut,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 4.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWalnut,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWalnut,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWalnut,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWalnut,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWalnut,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 26,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWalnut,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWalnut,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWalnut,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWalnut,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWalnut,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 50,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWalnut,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWalnut,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWalnut,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWalnut,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 55,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWalnut,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCashew,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCashew,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 55,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCashew,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 22,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCashew,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 250,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCashew,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 4.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCashew,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCashew,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCashew,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCashew,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCashew,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 26,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCashew,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCashew,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCashew,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCashew,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCashew,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 50,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCashew,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCashew,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCashew,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCashew,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 55,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCashew,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPeanuts,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPeanuts,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 55,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPeanuts,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 22,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPeanuts,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 250,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPeanuts,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 4.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPeanuts,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPeanuts,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPeanuts,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPeanuts,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPeanuts,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 26,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPeanuts,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPeanuts,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPeanuts,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPeanuts,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPeanuts,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 50,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPeanuts,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPeanuts,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPeanuts,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPeanuts,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 55,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPeanuts,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMilk,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMilk,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMilk,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 5.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMilk,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMilk,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMilk,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMilk,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMilk,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMilk,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMilk,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMilk,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 5.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMilk,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMilk,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMilk,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMilk,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMilk,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMilk,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMilk,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMilk,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMilk,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FButter,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FButter,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FButter,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 5.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FButter,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FButter,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FButter,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FButter,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FButter,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FButter,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FButter,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FButter,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 5.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FButter,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FButter,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FButter,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FButter,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FButter,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FButter,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FButter,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FButter,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FButter,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEgg,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 27,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEgg,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEgg,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEgg,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEgg,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEgg,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEgg,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEgg,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 10,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEgg,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEgg,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.4,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEgg,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEgg,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEgg,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEgg,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEgg,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 10,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEgg,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEgg,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEgg,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEgg,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 90,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FEgg,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoyBean,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoyBean,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoyBean,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 5.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoyBean,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoyBean,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoyBean,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoyBean,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoyBean,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoyBean,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoyBean,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoyBean,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 5.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoyBean,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoyBean,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoyBean,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoyBean,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoyBean,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoyBean,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoyBean,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoyBean,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoyBean,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRice,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 5.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRice,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRice,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 55.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRice,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRice,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRice,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRice,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRice,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRice,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRice,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRice,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRice,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRice,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRice,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.06,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRice,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 30,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRice,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRice,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRice,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRice,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRice,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGlutinousRice,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 5.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGlutinousRice,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGlutinousRice,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 55.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGlutinousRice,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGlutinousRice,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGlutinousRice,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGlutinousRice,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGlutinousRice,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGlutinousRice,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGlutinousRice,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGlutinousRice,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGlutinousRice,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGlutinousRice,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGlutinousRice,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.06,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGlutinousRice,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 30,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGlutinousRice,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGlutinousRice,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGlutinousRice,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGlutinousRice,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGlutinousRice,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FNoodles,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 5.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FNoodles,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FNoodles,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 55.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FNoodles,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FNoodles,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FNoodles,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FNoodles,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FNoodles,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FNoodles,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FNoodles,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FNoodles,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FNoodles,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FNoodles,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FNoodles,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.06,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FNoodles,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 30,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FNoodles,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FNoodles,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FNoodles,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FNoodles,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FNoodles,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChickpeas,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChickpeas,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChickpeas,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 5.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChickpeas,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChickpeas,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChickpeas,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChickpeas,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChickpeas,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChickpeas,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChickpeas,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChickpeas,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 5.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChickpeas,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChickpeas,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChickpeas,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChickpeas,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChickpeas,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChickpeas,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChickpeas,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChickpeas,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChickpeas,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTofu,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTofu,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTofu,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 5.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTofu,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTofu,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTofu,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTofu,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTofu,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTofu,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTofu,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTofu,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 5.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTofu,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTofu,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTofu,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTofu,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTofu,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTofu,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTofu,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTofu,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTofu,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLotusSeeds,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLotusSeeds,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 55,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLotusSeeds,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 22,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLotusSeeds,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 250,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLotusSeeds,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 4.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLotusSeeds,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLotusSeeds,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLotusSeeds,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLotusSeeds,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLotusSeeds,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 26,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLotusSeeds,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLotusSeeds,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLotusSeeds,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLotusSeeds,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLotusSeeds,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 50,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLotusSeeds,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLotusSeeds,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLotusSeeds,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLotusSeeds,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 55,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLotusSeeds,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWheatBread,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 5.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWheatBread,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWheatBread,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 55.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWheatBread,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWheatBread,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWheatBread,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWheatBread,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWheatBread,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWheatBread,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWheatBread,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWheatBread,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWheatBread,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWheatBread,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWheatBread,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.06,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWheatBread,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 30,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWheatBread,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWheatBread,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWheatBread,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWheatBread,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWheatBread,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceBread,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 5.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceBread,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceBread,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 55.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceBread,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceBread,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceBread,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceBread,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceBread,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceBread,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceBread,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceBread,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceBread,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceBread,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceBread,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.06,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceBread,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 30,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceBread,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceBread,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceBread,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceBread,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceBread,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGFMultigrainBread,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 5.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGFMultigrainBread,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGFMultigrainBread,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 55.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGFMultigrainBread,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGFMultigrainBread,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGFMultigrainBread,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGFMultigrainBread,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGFMultigrainBread,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGFMultigrainBread,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGFMultigrainBread,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGFMultigrainBread,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGFMultigrainBread,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGFMultigrainBread,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGFMultigrainBread,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.06,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGFMultigrainBread,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 30,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGFMultigrainBread,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGFMultigrainBread,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGFMultigrainBread,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGFMultigrainBread,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGFMultigrainBread,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWater,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWater,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 100.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWater,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWater,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWater,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWater,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWater,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWater,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWater,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWater,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 14,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWater,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 60,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWater,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWater,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWater,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWater,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWater,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWater,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWater,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWater,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FWater,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FHerbalTea,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FHerbalTea,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 100.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FHerbalTea,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FHerbalTea,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FHerbalTea,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FHerbalTea,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FHerbalTea,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FHerbalTea,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FHerbalTea,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FHerbalTea,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 14,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FHerbalTea,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 60,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FHerbalTea,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FHerbalTea,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FHerbalTea,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FHerbalTea,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FHerbalTea,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FHerbalTea,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FHerbalTea,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FHerbalTea,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FHerbalTea,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAppleJuice,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAppleJuice,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAppleJuice,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 11.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAppleJuice,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAppleJuice,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAppleJuice,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAppleJuice,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAppleJuice,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAppleJuice,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAppleJuice,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAppleJuice,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAppleJuice,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAppleJuice,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAppleJuice,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAppleJuice,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 25,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAppleJuice,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAppleJuice,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 35,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAppleJuice,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 9,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAppleJuice,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAppleJuice,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrangeJuice,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrangeJuice,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrangeJuice,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 11.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrangeJuice,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrangeJuice,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrangeJuice,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrangeJuice,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrangeJuice,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrangeJuice,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrangeJuice,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrangeJuice,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrangeJuice,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrangeJuice,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrangeJuice,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrangeJuice,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 25,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrangeJuice,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrangeJuice,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 35,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrangeJuice,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 9,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrangeJuice,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FOrangeJuice,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineappleJuice,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineappleJuice,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineappleJuice,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 11.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineappleJuice,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineappleJuice,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineappleJuice,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineappleJuice,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineappleJuice,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineappleJuice,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineappleJuice,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineappleJuice,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineappleJuice,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineappleJuice,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineappleJuice,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineappleJuice,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 25,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineappleJuice,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineappleJuice,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 35,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineappleJuice,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 9,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineappleJuice,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FPineappleJuice,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrotJuice,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrotJuice,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrotJuice,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrotJuice,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 100,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrotJuice,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrotJuice,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrotJuice,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrotJuice,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrotJuice,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrotJuice,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrotJuice,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrotJuice,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrotJuice,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrotJuice,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrotJuice,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 80,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrotJuice,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrotJuice,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrotJuice,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrotJuice,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarrotJuice,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomatoJuice,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomatoJuice,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomatoJuice,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomatoJuice,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 100,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomatoJuice,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomatoJuice,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomatoJuice,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomatoJuice,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomatoJuice,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomatoJuice,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomatoJuice,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomatoJuice,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomatoJuice,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomatoJuice,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomatoJuice,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 80,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomatoJuice,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomatoJuice,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomatoJuice,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomatoJuice,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTomatoJuice,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCranberryJuice,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCranberryJuice,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCranberryJuice,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 11.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCranberryJuice,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCranberryJuice,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCranberryJuice,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCranberryJuice,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCranberryJuice,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCranberryJuice,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCranberryJuice,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCranberryJuice,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCranberryJuice,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCranberryJuice,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCranberryJuice,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCranberryJuice,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 25,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCranberryJuice,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCranberryJuice,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 35,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCranberryJuice,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 9,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCranberryJuice,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCranberryJuice,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapeJuice,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapeJuice,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapeJuice,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 11.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapeJuice,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapeJuice,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapeJuice,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapeJuice,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapeJuice,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapeJuice,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapeJuice,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapeJuice,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapeJuice,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapeJuice,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapeJuice,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapeJuice,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 25,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapeJuice,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapeJuice,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 35,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapeJuice,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 9,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapeJuice,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGrapeJuice,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemonade,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemonade,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemonade,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 11.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemonade,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemonade,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemonade,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemonade,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemonade,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemonade,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemonade,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemonade,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemonade,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemonade,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemonade,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemonade,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 25,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemonade,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemonade,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 35,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemonade,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 9,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemonade,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FLemonade,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSmoothie,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSmoothie,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSmoothie,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 11.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSmoothie,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSmoothie,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSmoothie,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSmoothie,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSmoothie,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSmoothie,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSmoothie,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSmoothie,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSmoothie,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSmoothie,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSmoothie,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSmoothie,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 25,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSmoothie,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSmoothie,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 35,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSmoothie,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 9,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSmoothie,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSmoothie,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmondMilk,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmondMilk,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmondMilk,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 11.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmondMilk,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmondMilk,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmondMilk,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmondMilk,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmondMilk,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmondMilk,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmondMilk,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmondMilk,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmondMilk,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmondMilk,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmondMilk,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmondMilk,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 25,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmondMilk,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmondMilk,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 35,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmondMilk,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 9,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmondMilk,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAlmondMilk,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceMilk,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceMilk,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceMilk,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 11.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceMilk,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceMilk,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceMilk,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceMilk,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceMilk,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceMilk,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceMilk,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceMilk,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceMilk,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceMilk,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceMilk,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceMilk,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 25,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceMilk,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceMilk,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 35,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceMilk,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 9,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceMilk,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRiceMilk,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAloeVeraJuice,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAloeVeraJuice,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAloeVeraJuice,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 11.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAloeVeraJuice,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAloeVeraJuice,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAloeVeraJuice,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAloeVeraJuice,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAloeVeraJuice,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAloeVeraJuice,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAloeVeraJuice,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAloeVeraJuice,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAloeVeraJuice,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAloeVeraJuice,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.04,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAloeVeraJuice,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAloeVeraJuice,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 25,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAloeVeraJuice,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAloeVeraJuice,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 35,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAloeVeraJuice,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 9,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAloeVeraJuice,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FAloeVeraJuice,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                //new FoodNutrient
                //{
                //    FoodId = FV8Juice,
                //    NutrientId = proteinId,
                //    NutrientEquivalent = 1.0,
                //    Unit = "g",
                //    AmountPerUnit = 0.8,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FV8Juice,
                //    NutrientId = lipidId,
                //    NutrientEquivalent = 1.0,
                //    Unit = "g",
                //    AmountPerUnit = 0.2,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FV8Juice,
                //    NutrientId = glucidId,
                //    NutrientEquivalent = 1.0,
                //    Unit = "g",
                //    AmountPerUnit = 11.0,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FV8Juice,
                //    NutrientId = calciumId,
                //    NutrientEquivalent = 0.001,
                //    Unit = "mg",
                //    AmountPerUnit = 20,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FV8Juice,
                //    NutrientId = ironId,
                //    NutrientEquivalent = 0.001,
                //    Unit = "mg",
                //    AmountPerUnit = 0.2,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FV8Juice,
                //    NutrientId = zincId,
                //    NutrientEquivalent = 0.001,
                //    Unit = "mg",
                //    AmountPerUnit = 0.1,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FV8Juice,
                //    NutrientId = iodineId,
                //    NutrientEquivalent = 1e-06,
                //    Unit = "μg",
                //    AmountPerUnit = 0.0,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FV8Juice,
                //    NutrientId = vitaminAId,
                //    NutrientEquivalent = 1e-06,
                //    Unit = "μg",
                //    AmountPerUnit = 20,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FV8Juice,
                //    NutrientId = vitaminDId,
                //    NutrientEquivalent = 1e-06,
                //    Unit = "μg",
                //    AmountPerUnit = 0.0,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FV8Juice,
                //    NutrientId = vitaminEId,
                //    NutrientEquivalent = 0.001,
                //    Unit = "mg",
                //    AmountPerUnit = 0.2,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FV8Juice,
                //    NutrientId = vitaminKId,
                //    NutrientEquivalent = 1e-06,
                //    Unit = "μg",
                //    AmountPerUnit = 3.0,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FV8Juice,
                //    NutrientId = vitaminB1Id,
                //    NutrientEquivalent = 0.001,
                //    Unit = "mg",
                //    AmountPerUnit = 0.04,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FV8Juice,
                //    NutrientId = vitaminB2Id,
                //    NutrientEquivalent = 0.001,
                //    Unit = "mg",
                //    AmountPerUnit = 0.04,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FV8Juice,
                //    NutrientId = vitaminB6Id,
                //    NutrientEquivalent = 0.001,
                //    Unit = "mg",
                //    AmountPerUnit = 0.05,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FV8Juice,
                //    NutrientId = folateId,
                //    NutrientEquivalent = 1e-06,
                //    Unit = "μg",
                //    AmountPerUnit = 25,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FV8Juice,
                //    NutrientId = vitaminB12Id,
                //    NutrientEquivalent = 1e-06,
                //    Unit = "μg",
                //    AmountPerUnit = 0.0,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FV8Juice,
                //    NutrientId = vitaminCId,
                //    NutrientEquivalent = 0.001,
                //    Unit = "mg",
                //    AmountPerUnit = 35,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FV8Juice,
                //    NutrientId = cholineId,
                //    NutrientEquivalent = 0.001,
                //    Unit = "mg",
                //    AmountPerUnit = 9,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FV8Juice,
                //    NutrientId = fiberId,
                //    NutrientEquivalent = 1.0,
                //    Unit = "g",
                //    AmountPerUnit = 6,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FV8Juice,
                //    NutrientId = saltId,
                //    NutrientEquivalent = 1.0,
                //    Unit = "g",
                //    AmountPerUnit = 1.8,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                new FoodNutrient
                {
                    FoodId = FGreenTea,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGreenTea,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 100.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGreenTea,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGreenTea,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGreenTea,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGreenTea,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGreenTea,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGreenTea,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGreenTea,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGreenTea,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 14,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGreenTea,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 60,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGreenTea,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGreenTea,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGreenTea,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGreenTea,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGreenTea,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGreenTea,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGreenTea,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGreenTea,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FGreenTea,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackTea,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackTea,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 100.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackTea,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackTea,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackTea,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackTea,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackTea,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackTea,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackTea,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackTea,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 14,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackTea,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 60,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackTea,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackTea,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackTea,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackTea,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackTea,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackTea,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackTea,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackTea,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackTea,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                //new FoodNutrient
                //{
                //    FoodId = FCoffee,
                //    NutrientId = proteinId,
                //    NutrientEquivalent = 1.0,
                //    Unit = "g",
                //    AmountPerUnit = 0.0,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FCoffee,
                //    NutrientId = lipidId,
                //    NutrientEquivalent = 1.0,
                //    Unit = "g",
                //    AmountPerUnit = 100.0,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FCoffee,
                //    NutrientId = glucidId,
                //    NutrientEquivalent = 1.0,
                //    Unit = "g",
                //    AmountPerUnit = 0.0,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FCoffee,
                //    NutrientId = calciumId,
                //    NutrientEquivalent = 0.001,
                //    Unit = "mg",
                //    AmountPerUnit = 5,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FCoffee,
                //    NutrientId = ironId,
                //    NutrientEquivalent = 0.001,
                //    Unit = "mg",
                //    AmountPerUnit = 0.2,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FCoffee,
                //    NutrientId = zincId,
                //    NutrientEquivalent = 0.001,
                //    Unit = "mg",
                //    AmountPerUnit = 0.1,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FCoffee,
                //    NutrientId = iodineId,
                //    NutrientEquivalent = 1e-06,
                //    Unit = "μg",
                //    AmountPerUnit = 0.0,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FCoffee,
                //    NutrientId = vitaminAId,
                //    NutrientEquivalent = 1e-06,
                //    Unit = "μg",
                //    AmountPerUnit = 0,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FCoffee,
                //    NutrientId = vitaminDId,
                //    NutrientEquivalent = 1e-06,
                //    Unit = "μg",
                //    AmountPerUnit = 0.0,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FCoffee,
                //    NutrientId = vitaminEId,
                //    NutrientEquivalent = 0.001,
                //    Unit = "mg",
                //    AmountPerUnit = 14,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FCoffee,
                //    NutrientId = vitaminKId,
                //    NutrientEquivalent = 1e-06,
                //    Unit = "μg",
                //    AmountPerUnit = 60,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FCoffee,
                //    NutrientId = vitaminB1Id,
                //    NutrientEquivalent = 0.001,
                //    Unit = "mg",
                //    AmountPerUnit = 0.0,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FCoffee,
                //    NutrientId = vitaminB2Id,
                //    NutrientEquivalent = 0.001,
                //    Unit = "mg",
                //    AmountPerUnit = 0.0,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FCoffee,
                //    NutrientId = vitaminB6Id,
                //    NutrientEquivalent = 0.001,
                //    Unit = "mg",
                //    AmountPerUnit = 0.0,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FCoffee,
                //    NutrientId = folateId,
                //    NutrientEquivalent = 1e-06,
                //    Unit = "μg",
                //    AmountPerUnit = 0,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FCoffee,
                //    NutrientId = vitaminB12Id,
                //    NutrientEquivalent = 1e-06,
                //    Unit = "μg",
                //    AmountPerUnit = 0.0,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FCoffee,
                //    NutrientId = vitaminCId,
                //    NutrientEquivalent = 0.001,
                //    Unit = "mg",
                //    AmountPerUnit = 0,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FCoffee,
                //    NutrientId = cholineId,
                //    NutrientEquivalent = 0.001,
                //    Unit = "mg",
                //    AmountPerUnit = 0,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FCoffee,
                //    NutrientId = fiberId,
                //    NutrientEquivalent = 1.0,
                //    Unit = "g",
                //    AmountPerUnit = 0.3,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                //new FoodNutrient
                //{
                //    FoodId = FCoffee,
                //    NutrientId = saltId,
                //    NutrientEquivalent = 1.0,
                //    Unit = "g",
                //    AmountPerUnit = 0.0,
                //    TotalWeight = 100.0,
                //    FoodEquivalent = "100g"
                //},
                new FoodNutrient
                {
                    FoodId = FCarbonatedWater,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarbonatedWater,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 100.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarbonatedWater,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarbonatedWater,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarbonatedWater,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarbonatedWater,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarbonatedWater,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarbonatedWater,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarbonatedWater,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarbonatedWater,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 14,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarbonatedWater,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 60,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarbonatedWater,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarbonatedWater,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarbonatedWater,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarbonatedWater,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarbonatedWater,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarbonatedWater,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarbonatedWater,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarbonatedWater,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCarbonatedWater,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBottledWater,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBottledWater,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 100.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBottledWater,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBottledWater,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBottledWater,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBottledWater,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBottledWater,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBottledWater,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBottledWater,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBottledWater,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 14,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBottledWater,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 60,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBottledWater,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBottledWater,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBottledWater,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBottledWater,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBottledWater,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBottledWater,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBottledWater,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBottledWater,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBottledWater,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCinnamon,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 8.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCinnamon,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 12.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCinnamon,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 60.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCinnamon,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 500,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCinnamon,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCinnamon,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 4.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCinnamon,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCinnamon,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 200,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCinnamon,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCinnamon,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCinnamon,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 100,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCinnamon,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCinnamon,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCinnamon,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCinnamon,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 50,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCinnamon,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCinnamon,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 25,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCinnamon,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCinnamon,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 12,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCinnamon,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 30,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTurmeric,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 8.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTurmeric,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 12.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTurmeric,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 60.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTurmeric,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 500,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTurmeric,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTurmeric,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 4.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTurmeric,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTurmeric,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 200,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTurmeric,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTurmeric,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTurmeric,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 100,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTurmeric,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTurmeric,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTurmeric,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTurmeric,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 50,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTurmeric,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTurmeric,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 25,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTurmeric,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTurmeric,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 12,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTurmeric,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 30,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChiliPowder,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 8.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChiliPowder,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 12.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChiliPowder,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 60.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChiliPowder,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 500,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChiliPowder,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChiliPowder,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 4.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChiliPowder,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChiliPowder,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 200,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChiliPowder,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChiliPowder,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChiliPowder,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 100,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChiliPowder,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChiliPowder,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChiliPowder,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChiliPowder,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 50,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChiliPowder,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChiliPowder,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 25,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChiliPowder,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChiliPowder,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 12,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FChiliPowder,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 30,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTableSalt,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTableSalt,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTableSalt,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 5.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTableSalt,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTableSalt,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTableSalt,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTableSalt,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTableSalt,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTableSalt,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTableSalt,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTableSalt,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 5.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTableSalt,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTableSalt,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTableSalt,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTableSalt,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTableSalt,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTableSalt,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTableSalt,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTableSalt,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FTableSalt,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackPepper,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 8.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackPepper,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 12.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackPepper,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 60.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackPepper,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 500,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackPepper,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackPepper,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 4.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackPepper,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackPepper,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 200,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackPepper,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackPepper,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackPepper,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 100,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackPepper,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackPepper,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackPepper,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackPepper,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 50,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackPepper,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackPepper,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 25,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackPepper,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackPepper,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 12,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FBlackPepper,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 30,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStarAnise,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 8.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStarAnise,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 12.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStarAnise,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 60.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStarAnise,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 500,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStarAnise,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStarAnise,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 4.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStarAnise,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStarAnise,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 200,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStarAnise,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStarAnise,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 2.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStarAnise,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 100,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStarAnise,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStarAnise,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStarAnise,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStarAnise,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 50,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStarAnise,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStarAnise,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 25,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStarAnise,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStarAnise,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 12,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FStarAnise,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 30,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSugar,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSugar,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 100.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSugar,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSugar,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSugar,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSugar,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSugar,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSugar,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSugar,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSugar,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 14,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSugar,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 60,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSugar,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSugar,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSugar,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSugar,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSugar,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSugar,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSugar,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSugar,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSugar,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVinegar,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVinegar,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 100.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVinegar,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVinegar,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVinegar,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVinegar,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVinegar,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVinegar,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVinegar,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVinegar,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 14,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVinegar,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 60,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVinegar,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVinegar,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVinegar,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVinegar,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVinegar,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVinegar,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVinegar,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVinegar,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FVinegar,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMSG,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMSG,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 100.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMSG,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMSG,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMSG,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMSG,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMSG,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMSG,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMSG,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMSG,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 14,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMSG,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 60,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMSG,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMSG,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMSG,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMSG,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMSG,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMSG,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMSG,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMSG,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FMSG,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoupPowder,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoupPowder,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 100.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoupPowder,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoupPowder,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoupPowder,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoupPowder,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoupPowder,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoupPowder,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoupPowder,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoupPowder,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 14,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoupPowder,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 60,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoupPowder,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoupPowder,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoupPowder,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoupPowder,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoupPowder,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoupPowder,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoupPowder,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoupPowder,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FSoupPowder,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRicePaper,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 5.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRicePaper,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 1.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRicePaper,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 55.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRicePaper,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRicePaper,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRicePaper,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.6,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRicePaper,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRicePaper,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRicePaper,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRicePaper,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.2,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRicePaper,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRicePaper,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRicePaper,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.05,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRicePaper,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.06,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRicePaper,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 30,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRicePaper,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRicePaper,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRicePaper,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRicePaper,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 8,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FRicePaper,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 3.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCoriander,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCoriander,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCoriander,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCoriander,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 100,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCoriander,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCoriander,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCoriander,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCoriander,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCoriander,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCoriander,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCoriander,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCoriander,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCoriander,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCoriander,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCoriander,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 80,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCoriander,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCoriander,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCoriander,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCoriander,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FCoriander,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShiitake,
                    NutrientId = proteinId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShiitake,
                    NutrientId = lipidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 0.3,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShiitake,
                    NutrientId = glucidId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 6.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShiitake,
                    NutrientId = calciumId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 100,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShiitake,
                    NutrientId = ironId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShiitake,
                    NutrientId = zincId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShiitake,
                    NutrientId = iodineId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShiitake,
                    NutrientId = vitaminAId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShiitake,
                    NutrientId = vitaminDId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShiitake,
                    NutrientId = vitaminEId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 1.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShiitake,
                    NutrientId = vitaminKId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 300,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShiitake,
                    NutrientId = vitaminB1Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShiitake,
                    NutrientId = vitaminB2Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShiitake,
                    NutrientId = vitaminB6Id,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 0.1,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShiitake,
                    NutrientId = folateId,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 80,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShiitake,
                    NutrientId = vitaminB12Id,
                    NutrientEquivalent = 1e-06,
                    Unit = "μg",
                    AmountPerUnit = 0.0,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShiitake,
                    NutrientId = vitaminCId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 20,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShiitake,
                    NutrientId = cholineId,
                    NutrientEquivalent = 0.001,
                    Unit = "mg",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShiitake,
                    NutrientId = fiberId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 15,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },
                new FoodNutrient
                {
                    FoodId = FShiitake,
                    NutrientId = saltId,
                    NutrientEquivalent = 1.0,
                    Unit = "g",
                    AmountPerUnit = 2.5,
                    TotalWeight = 100.0,
                    FoodEquivalent = "100g"
                },

                new FoodNutrient { FoodId = FRadish, NutrientId = proteinId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 0.7, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FRadish, NutrientId = lipidId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 0.1, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FRadish, NutrientId = glucidId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 3.4, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FRadish, NutrientId = calciumId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 25, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FRadish, NutrientId = ironId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.3, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FRadish, NutrientId = zincId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.3, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FRadish, NutrientId = iodineId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 2, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FRadish, NutrientId = vitaminAId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 7, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FRadish, NutrientId = vitaminDId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 0.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FRadish, NutrientId = vitaminEId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.1, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FRadish, NutrientId = vitaminKId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 1.3, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FRadish, NutrientId = vitaminB1Id, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.03, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FRadish, NutrientId = vitaminB2Id, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.04, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FRadish, NutrientId = vitaminB6Id, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.07, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FRadish, NutrientId = folateId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 25, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FRadish, NutrientId = vitaminB12Id, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 0.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FRadish, NutrientId = vitaminCId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 15.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FRadish, NutrientId = cholineId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 6.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FRadish, NutrientId = fiberId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 1.6, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FRadish, NutrientId = saltId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 0.02, TotalWeight = 100.0, FoodEquivalent = "100g" },

                new FoodNutrient { FoodId = FBanhMi, NutrientId = proteinId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 9.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FBanhMi, NutrientId = lipidId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 5.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FBanhMi, NutrientId = glucidId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 48.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FBanhMi, NutrientId = calciumId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 90, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FBanhMi, NutrientId = ironId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 3.5, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FBanhMi, NutrientId = zincId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.9, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FBanhMi, NutrientId = iodineId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 4, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FBanhMi, NutrientId = vitaminAId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 20, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FBanhMi, NutrientId = vitaminDId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 0.2, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FBanhMi, NutrientId = vitaminEId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.4, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FBanhMi, NutrientId = vitaminKId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 1.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FBanhMi, NutrientId = vitaminB1Id, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.25, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FBanhMi, NutrientId = vitaminB2Id, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.15, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FBanhMi, NutrientId = vitaminB6Id, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.1, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FBanhMi, NutrientId = folateId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 80, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FBanhMi, NutrientId = vitaminB12Id, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 0.2, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FBanhMi, NutrientId = vitaminCId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 2.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FBanhMi, NutrientId = cholineId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 14.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FBanhMi, NutrientId = fiberId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 2.5, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FBanhMi, NutrientId = saltId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 1.2, TotalWeight = 100.0, FoodEquivalent = "100g" },

                new FoodNutrient { FoodId = FMayo, NutrientId = proteinId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 1.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FMayo, NutrientId = lipidId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 75.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FMayo, NutrientId = glucidId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 1.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FMayo, NutrientId = calciumId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 20, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FMayo, NutrientId = ironId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.3, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FMayo, NutrientId = zincId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.2, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FMayo, NutrientId = iodineId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 4, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FMayo, NutrientId = vitaminAId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 80, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FMayo, NutrientId = vitaminDId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 1.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FMayo, NutrientId = vitaminEId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 8.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FMayo, NutrientId = vitaminKId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 100.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FMayo, NutrientId = vitaminB1Id, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.05, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FMayo, NutrientId = vitaminB2Id, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.08, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FMayo, NutrientId = vitaminB6Id, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.1, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FMayo, NutrientId = folateId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 10, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FMayo, NutrientId = vitaminB12Id, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 0.4, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FMayo, NutrientId = vitaminCId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FMayo, NutrientId = cholineId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 40.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FMayo, NutrientId = fiberId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 0.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FMayo, NutrientId = saltId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 1.2, TotalWeight = 100.0, FoodEquivalent = "100g" },

                new FoodNutrient { FoodId = FChilliSauce, NutrientId = proteinId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 1.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FChilliSauce, NutrientId = lipidId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 0.3, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FChilliSauce, NutrientId = glucidId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 20.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FChilliSauce, NutrientId = calciumId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 18, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FChilliSauce, NutrientId = ironId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.6, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FChilliSauce, NutrientId = zincId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.2, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FChilliSauce, NutrientId = iodineId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 2, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FChilliSauce, NutrientId = vitaminAId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 150, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FChilliSauce, NutrientId = vitaminDId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 0.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FChilliSauce, NutrientId = vitaminEId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.8, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FChilliSauce, NutrientId = vitaminKId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 7, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FChilliSauce, NutrientId = vitaminB1Id, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.06, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FChilliSauce, NutrientId = vitaminB2Id, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.04, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FChilliSauce, NutrientId = vitaminB6Id, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.2, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FChilliSauce, NutrientId = folateId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 14, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FChilliSauce, NutrientId = vitaminB12Id, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 0.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FChilliSauce, NutrientId = vitaminCId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 30.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FChilliSauce, NutrientId = cholineId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 6.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FChilliSauce, NutrientId = fiberId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 1.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FChilliSauce, NutrientId = saltId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 3.0, TotalWeight = 100.0, FoodEquivalent = "100g" },

                new FoodNutrient { FoodId = FSoysauce, NutrientId = proteinId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 5.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FSoysauce, NutrientId = lipidId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 0.1, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FSoysauce, NutrientId = glucidId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 5.6, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FSoysauce, NutrientId = calciumId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 33, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FSoysauce, NutrientId = ironId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 1.5, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FSoysauce, NutrientId = zincId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.6, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FSoysauce, NutrientId = iodineId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 5, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FSoysauce, NutrientId = vitaminAId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FSoysauce, NutrientId = vitaminDId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FSoysauce, NutrientId = vitaminEId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.5, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FSoysauce, NutrientId = vitaminKId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 3, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FSoysauce, NutrientId = vitaminB1Id, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.07, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FSoysauce, NutrientId = vitaminB2Id, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.15, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FSoysauce, NutrientId = vitaminB6Id, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.14, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FSoysauce, NutrientId = folateId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 15, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FSoysauce, NutrientId = vitaminB12Id, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 0.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FSoysauce, NutrientId = vitaminCId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FSoysauce, NutrientId = cholineId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 12.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FSoysauce, NutrientId = fiberId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 0.8, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FSoysauce, NutrientId = saltId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 14.0, TotalWeight = 100.0, FoodEquivalent = "100g" },

                new FoodNutrient { FoodId = FKetchup, NutrientId = proteinId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 1.8, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FKetchup, NutrientId = lipidId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 0.2, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FKetchup, NutrientId = glucidId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 25.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FKetchup, NutrientId = calciumId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 15, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FKetchup, NutrientId = ironId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.5, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FKetchup, NutrientId = zincId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.2, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FKetchup, NutrientId = iodineId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 2, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FKetchup, NutrientId = vitaminAId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 20, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FKetchup, NutrientId = vitaminDId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 0.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FKetchup, NutrientId = vitaminEId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.5, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FKetchup, NutrientId = vitaminKId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 8, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FKetchup, NutrientId = vitaminB1Id, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.05, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FKetchup, NutrientId = vitaminB2Id, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.02, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FKetchup, NutrientId = vitaminB6Id, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 0.1, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FKetchup, NutrientId = folateId, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 10, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FKetchup, NutrientId = vitaminB12Id, NutrientEquivalent = 1e-06, Unit = "μg", AmountPerUnit = 0.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FKetchup, NutrientId = vitaminCId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 15.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FKetchup, NutrientId = cholineId, NutrientEquivalent = 0.001, Unit = "mg", AmountPerUnit = 7.0, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FKetchup, NutrientId = fiberId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 0.5, TotalWeight = 100.0, FoodEquivalent = "100g" },
new FoodNutrient { FoodId = FKetchup, NutrientId = saltId, NutrientEquivalent = 1.0, Unit = "g", AmountPerUnit = 2.2, TotalWeight = 100.0, FoodEquivalent = "100g" }
            );
            // ---------------------------------------------------
            // DISH
            // ---------------------------------------------------
            var DishComGa = Guid.NewGuid();
            var DishPhoGa = Guid.NewGuid();
            var DishCaKhoTo = Guid.NewGuid();
            var DishThitNuongXa = Guid.NewGuid();
            var DishComChienTom = Guid.NewGuid();
            var DishCanhChua = Guid.NewGuid();
            var DishGoiGa = Guid.NewGuid();
            var DishTomXaoRauCu = Guid.NewGuid();
            var DishDauHuSotCa = Guid.NewGuid();
            var DishComTrang = Guid.NewGuid();

            var DishBunBoHue = Guid.NewGuid();
            var DishGaXaoNam = Guid.NewGuid();
            var DishCanhRauMuong = Guid.NewGuid();
            var DishComNepGa = Guid.NewGuid();
            var DishTomNuong = Guid.NewGuid();
            var DishCanhBiDo = Guid.NewGuid();
            var DishRauXaoCuQua = Guid.NewGuid();
            var DishCaChienNuocMam = Guid.NewGuid();
            var DishGoiCuonTom = Guid.NewGuid();
            var DishChaoGa = Guid.NewGuid();

            var DishBanhMi = Guid.NewGuid();

            modelBuilder.Entity<Dish>().HasData(
                new Dish
                {
                    Id = DishComGa,
                    DishName = "Chicken Rice",
                    ImageUrl = null,
                    Description = "A simple dish composed of chicken breast served with fragrant rice and vegetables"
                },
                new Dish
                {
                    Id = DishPhoGa,
                    DishName = "Chicken Noodle Soup (Chicken Pho)",
                    ImageUrl = null,
                    Description = "Traditional Vietnamese noodle soup with chicken, herbs, and aromatic broth"
                },
                new Dish
                {
                    Id = DishCaKhoTo,
                    DishName = "Braised Fish in Clay Pot",
                    ImageUrl = null,
                    Description = "Vietnamese braised cod fish with caramelized fish sauce in clay pot"
                },
                new Dish
                {
                    Id = DishThitNuongXa,
                    DishName = "Lemongrass Grilled Pork",
                    ImageUrl = null,
                    Description = "Grilled pork marinated with lemongrass and Vietnamese spices"
                },
                new Dish
                {
                    Id = DishComChienTom,
                    DishName = "Shrimp Fried Rice",
                    ImageUrl = null,
                    Description = "Vietnamese style fried rice with fresh shrimp and vegetables"
                },
                new Dish
                {
                    Id = DishCanhChua,
                    DishName = "Sweet and Sour Soup",
                    ImageUrl = null,
                    Description = "Traditional Vietnamese soup with pineapple, tomatoes, and fish"
                },
                new Dish
                {
                    Id = DishGoiGa,
                    DishName = "Vietnamese Chicken Salad",
                    ImageUrl = null,
                    Description = "Fresh Vietnamese salad with shredded chicken and vegetables"
                },
                new Dish
                {
                    Id = DishTomXaoRauCu,
                    DishName = "Shrimp Stir-fry with Vegetables",
                    ImageUrl = null,
                    Description = "Fresh shrimp stir-fried with seasonal vegetables"
                },
                new Dish
                {
                    Id = DishDauHuSotCa,
                    DishName = "Tofu in Tomato Sauce",
                    ImageUrl = null,
                    Description = "Braised tofu in rich tomato sauce with herbs"
                },
                new Dish
                {
                    Id = DishComTrang,
                    DishName = "Plain Steamed Rice",
                    ImageUrl = null,
                    Description = "Simple steamed white rice, a staple of Vietnamese cuisine"
                },
                new Dish
                {
                    Id = DishBunBoHue,
                    DishName = "Spicy Beef Noodle Soup",
                    ImageUrl = null,
                    Description = "Spicy Vietnamese noodle soup with beef and aromatic herbs from Hue"
                },
                new Dish
                {
                    Id = DishGaXaoNam,
                    DishName = "Chicken Stir-fry with Mushrooms",
                    ImageUrl = null,
                    Description = "Tender chicken stir-fried with shiitake mushrooms and vegetables"
                },
                new Dish
                {
                    Id = DishCanhRauMuong,
                    DishName = "Spinach and Shrimp Soup",
                    ImageUrl = null,
                    Description = "Light soup with fresh spinach and shrimp in clear broth"
                },
                new Dish
                {
                    Id = DishComNepGa,
                    DishName = "Glutinous Rice with Chicken",
                    ImageUrl = null,
                    Description = "Sticky rice topped with seasoned chicken breast"
                },
                new Dish
                {
                    Id = DishTomNuong,
                    DishName = "Grilled Shrimp",
                    ImageUrl = null,
                    Description = "Fresh shrimp grilled with garlic and herbs"
                },
                new Dish
                {
                    Id = DishCanhBiDo,
                    DishName = "Pumpkin and Pork Soup",
                    ImageUrl = null,
                    Description = "Sweet soup with pork and seasonal vegetables"
                },
                new Dish
                {
                    Id = DishRauXaoCuQua,
                    DishName = "Mixed Vegetable Stir-fry",
                    ImageUrl = null,
                    Description = "Healthy stir-fry with eggplant, broccoli, and mixed vegetables"
                },
                new Dish
                {
                    Id = DishCaChienNuocMam,
                    DishName = "Pan-fried Fish with Fish Sauce",
                    ImageUrl = null,
                    Description = "Crispy fried cod with caramelized fish sauce glaze"
                },
                new Dish
                {
                    Id = DishGoiCuonTom,
                    DishName = "Fresh Spring Rolls with Shrimp",
                    ImageUrl = null,
                    Description = "Fresh rice paper rolls with shrimp and herbs"
                },
                new Dish
                {
                    Id = DishChaoGa,
                    DishName = "Chicken Rice Porridge",
                    ImageUrl = null,
                    Description = "Comforting rice porridge with shredded chicken"
                },
                new Dish
                {
                    Id = DishBanhMi,
                    DishName = "Grilled Pork Banh Mi",
                    ImageUrl = null,
                    Description = "A Delicious banh mi filled with grilled pork!"
                }
            );
            // ---------------------------------------------------
            // FOOD DISH RELATIONSHIP
            // ---------------------------------------------------
            modelBuilder.Entity<FoodDish>().HasData(

            // Dish 1: Chicken Rice (Cơm Gà)
            new FoodDish { FoodId = FChicken, DishId = DishComGa, Amount = 80, Unit = "g" },
            new FoodDish { FoodId = FRice, DishId = DishComGa, Amount = 60, Unit = "g" },
            new FoodDish { FoodId = FCucumber, DishId = DishComGa, Amount = 30, Unit = "g" },
            new FoodDish { FoodId = FOnion, DishId = DishComGa, Amount = 25, Unit = "g" },
            new FoodDish { FoodId = FGarlic, DishId = DishComGa, Amount = 5, Unit = "g" },
            new FoodDish { FoodId = FVegetableOil, DishId = DishComGa, Amount = 8, Unit = "g" },
            new FoodDish { FoodId = FFishSauce, DishId = DishComGa, Amount = 5, Unit = "g" },
            new FoodDish { FoodId = FTurmeric, DishId = DishComGa, Amount = 2, Unit = "g" },

            // Dish 2: Chicken Noodle Soup (Phở Gà)
            new FoodDish { FoodId = FChicken, DishId = DishPhoGa, Amount = 70, Unit = "g" },
            new FoodDish { FoodId = FNoodles, DishId = DishPhoGa, Amount = 80, Unit = "g" },
            new FoodDish { FoodId = FOnion, DishId = DishPhoGa, Amount = 40, Unit = "g" },
            new FoodDish { FoodId = FGarlic, DishId = DishPhoGa, Amount = 8, Unit = "g" },
            new FoodDish { FoodId = FSpringOnion, DishId = DishPhoGa, Amount = 10, Unit = "g" },
            new FoodDish { FoodId = FStarAnise, DishId = DishPhoGa, Amount = 2, Unit = "g" },
            new FoodDish { FoodId = FCinnamon, DishId = DishPhoGa, Amount = 1, Unit = "g" },
            new FoodDish { FoodId = FFishSauce, DishId = DishPhoGa, Amount = 6, Unit = "g" },
            new FoodDish { FoodId = FTableSalt, DishId = DishPhoGa, Amount = 3, Unit = "g" },

            // Dish 3: Braised Fish in Clay Pot (Cá Kho Tộ)
            new FoodDish { FoodId = FCod, DishId = DishCaKhoTo, Amount = 100, Unit = "g" },
            new FoodDish { FoodId = FFishSauce, DishId = DishCaKhoTo, Amount = 8, Unit = "g" },
            new FoodDish { FoodId = FSugar, DishId = DishCaKhoTo, Amount = 6, Unit = "g" },
            new FoodDish { FoodId = FGarlic, DishId = DishCaKhoTo, Amount = 6, Unit = "g" },
            new FoodDish { FoodId = FVegetableOil, DishId = DishCaKhoTo, Amount = 5, Unit = "g" },
            new FoodDish { FoodId = FBlackPepper, DishId = DishCaKhoTo, Amount = 1, Unit = "g" },
            new FoodDish { FoodId = FWater, DishId = DishCaKhoTo, Amount = 30, Unit = "ml" },

            // Dish 4: Lemongrass Grilled Pork
            new FoodDish { FoodId = FPork, DishId = DishThitNuongXa, Amount = 90, Unit = "g" },
            new FoodDish { FoodId = FLemongrass, DishId = DishThitNuongXa, Amount = 15, Unit = "g" },
            new FoodDish { FoodId = FGarlic, DishId = DishThitNuongXa, Amount = 8, Unit = "g" },
            new FoodDish { FoodId = FFishSauce, DishId = DishThitNuongXa, Amount = 6, Unit = "g" },
            new FoodDish { FoodId = FSugar, DishId = DishThitNuongXa, Amount = 4, Unit = "g" },
            new FoodDish { FoodId = FVegetableOil, DishId = DishThitNuongXa, Amount = 5, Unit = "g" },
            new FoodDish { FoodId = FBlackPepper, DishId = DishThitNuongXa, Amount = 1, Unit = "g" },

            // Dish 5: Shrimp Fried Rice
            new FoodDish { FoodId = FShrimp, DishId = DishComChienTom, Amount = 70, Unit = "g" },
            new FoodDish { FoodId = FRice, DishId = DishComChienTom, Amount = 80, Unit = "g" },
            new FoodDish { FoodId = FEgg, DishId = DishComChienTom, Amount = 50, Unit = "g" },
            new FoodDish { FoodId = FSpringOnion, DishId = DishComChienTom, Amount = 15, Unit = "g" },
            new FoodDish { FoodId = FGarlic, DishId = DishComChienTom, Amount = 5, Unit = "g" },
            new FoodDish { FoodId = FVegetableOil, DishId = DishComChienTom, Amount = 8, Unit = "g" },
            new FoodDish { FoodId = FFishSauce, DishId = DishComChienTom, Amount = 4, Unit = "g" },

            // Dish 6: Sweet and Sour Soup (Canh Chua)
            new FoodDish { FoodId = FShrimp, DishId = DishCanhChua, Amount = 60, Unit = "g" },
            new FoodDish { FoodId = FPineapple, DishId = DishCanhChua, Amount = 50, Unit = "g" },
            new FoodDish { FoodId = FTomato, DishId = DishCanhChua, Amount = 40, Unit = "g" },
            new FoodDish { FoodId = FBeanSprouts, DishId = DishCanhChua, Amount = 30, Unit = "g" },
            new FoodDish { FoodId = FOnion, DishId = DishCanhChua, Amount = 20, Unit = "g" },
            new FoodDish { FoodId = FVinegar, DishId = DishCanhChua, Amount = 5, Unit = "g" },
            new FoodDish { FoodId = FSugar, DishId = DishCanhChua, Amount = 3, Unit = "g" },
            new FoodDish { FoodId = FFishSauce, DishId = DishCanhChua, Amount = 4, Unit = "g" },
            new FoodDish { FoodId = FWater, DishId = DishCanhChua, Amount = 250, Unit = "ml" },

            // Dish 7: Vietnamese Chicken Salad (Gỏi Gà)
            new FoodDish { FoodId = FChicken, DishId = DishGoiGa, Amount = 80, Unit = "g" },
            new FoodDish { FoodId = FLettuce, DishId = DishGoiGa, Amount = 60, Unit = "g" },
            new FoodDish { FoodId = FCarrot, DishId = DishGoiGa, Amount = 40, Unit = "g" },
            new FoodDish { FoodId = FCucumber, DishId = DishGoiGa, Amount = 35, Unit = "g" },
            new FoodDish { FoodId = FPeanuts, DishId = DishGoiGa, Amount = 15, Unit = "g" },
            new FoodDish { FoodId = FFishSauce, DishId = DishGoiGa, Amount = 5, Unit = "g" },
            new FoodDish { FoodId = FSugar, DishId = DishGoiGa, Amount = 3, Unit = "g" },
            new FoodDish { FoodId = FVinegar, DishId = DishGoiGa, Amount = 4, Unit = "g" },

            // Dish 8: Shrimp Stir-fry with Vegetables
            new FoodDish { FoodId = FShrimp, DishId = DishTomXaoRauCu, Amount = 80, Unit = "g" },
            new FoodDish { FoodId = FBroccoli, DishId = DishTomXaoRauCu, Amount = 60, Unit = "g" },
            new FoodDish { FoodId = FCarrot, DishId = DishTomXaoRauCu, Amount = 40, Unit = "g" },
            new FoodDish { FoodId = FBeanSprouts, DishId = DishTomXaoRauCu, Amount = 30, Unit = "g" },
            new FoodDish { FoodId = FGarlic, DishId = DishTomXaoRauCu, Amount = 6, Unit = "g" },
            new FoodDish { FoodId = FVegetableOil, DishId = DishTomXaoRauCu, Amount = 8, Unit = "g" },
            new FoodDish { FoodId = FFishSauce, DishId = DishTomXaoRauCu, Amount = 5, Unit = "g" },

            // Dish 9: Tofu in Tomato Sauce
            new FoodDish { FoodId = FTofu, DishId = DishDauHuSotCa, Amount = 100, Unit = "g" },
            new FoodDish { FoodId = FTomato, DishId = DishDauHuSotCa, Amount = 80, Unit = "g" },
            new FoodDish { FoodId = FOnion, DishId = DishDauHuSotCa, Amount = 30, Unit = "g" },
            new FoodDish { FoodId = FGarlic, DishId = DishDauHuSotCa, Amount = 5, Unit = "g" },
            new FoodDish { FoodId = FSugar, DishId = DishDauHuSotCa, Amount = 3, Unit = "g" },
            new FoodDish { FoodId = FVegetableOil, DishId = DishDauHuSotCa, Amount = 6, Unit = "g" },
            new FoodDish { FoodId = FFishSauce, DishId = DishDauHuSotCa, Amount = 4, Unit = "g" },
            new FoodDish { FoodId = FWater, DishId = DishDauHuSotCa, Amount = 50, Unit = "ml" },

            // Dish 10: Plain Steamed Rice (Single ingredient dish)
            new FoodDish { FoodId = FRice, DishId = DishComTrang, Amount = 100, Unit = "g" },

            // Dish 11: Spicy Beef Noodle Soup (Bún Bò Huế)
            new FoodDish { FoodId = FBeef, DishId = DishBunBoHue, Amount = 80, Unit = "g" },
            new FoodDish { FoodId = FNoodles, DishId = DishBunBoHue, Amount = 90, Unit = "g" },
            new FoodDish { FoodId = FLemongrass, DishId = DishBunBoHue, Amount = 10, Unit = "g" },
            new FoodDish { FoodId = FOnion, DishId = DishBunBoHue, Amount = 35, Unit = "g" },
            new FoodDish { FoodId = FGarlic, DishId = DishBunBoHue, Amount = 8, Unit = "g" },
            new FoodDish { FoodId = FChiliPowder, DishId = DishBunBoHue, Amount = 2, Unit = "g" },
            new FoodDish { FoodId = FFishSauce, DishId = DishBunBoHue, Amount = 8, Unit = "g" },
            new FoodDish { FoodId = FSpringOnion, DishId = DishBunBoHue, Amount = 12, Unit = "g" },
            new FoodDish { FoodId = FWater, DishId = DishBunBoHue, Amount = 300, Unit = "ml" },

            // Dish 12: Chicken Stir-fry with Mushrooms
            new FoodDish { FoodId = FChicken, DishId = DishGaXaoNam, Amount = 85, Unit = "g" },
            new FoodDish { FoodId = FShiitake, DishId = DishGaXaoNam, Amount = 50, Unit = "g" },
            new FoodDish { FoodId = FOnion, DishId = DishGaXaoNam, Amount = 30, Unit = "g" },
            new FoodDish { FoodId = FGarlic, DishId = DishGaXaoNam, Amount = 6, Unit = "g" },
            new FoodDish { FoodId = FVegetableOil, DishId = DishGaXaoNam, Amount = 8, Unit = "g" },
            new FoodDish { FoodId = FFishSauce, DishId = DishGaXaoNam, Amount = 5, Unit = "g" },
            new FoodDish { FoodId = FBlackPepper, DishId = DishGaXaoNam, Amount = 1, Unit = "g" },

            // Dish 13: Spinach and Shrimp Soup
            new FoodDish { FoodId = FSpinach, DishId = DishCanhRauMuong, Amount = 80, Unit = "g" },
            new FoodDish { FoodId = FShrimp, DishId = DishCanhRauMuong, Amount = 60, Unit = "g" },
            new FoodDish { FoodId = FGarlic, DishId = DishCanhRauMuong, Amount = 5, Unit = "g" },
            new FoodDish { FoodId = FOnion, DishId = DishCanhRauMuong, Amount = 25, Unit = "g" },
            new FoodDish { FoodId = FFishSauce, DishId = DishCanhRauMuong, Amount = 4, Unit = "g" },
            new FoodDish { FoodId = FTableSalt, DishId = DishCanhRauMuong, Amount = 2, Unit = "g" },
            new FoodDish { FoodId = FVegetableOil, DishId = DishCanhRauMuong, Amount = 3, Unit = "g" },
            new FoodDish { FoodId = FWater, DishId = DishCanhRauMuong, Amount = 200, Unit = "ml" },

            // Dish 14: Glutinous Rice with Chicken
            new FoodDish { FoodId = FGlutinousRice, DishId = DishComNepGa, Amount = 80, Unit = "g" },
            new FoodDish { FoodId = FChicken, DishId = DishComNepGa, Amount = 70, Unit = "g" },
            new FoodDish { FoodId = FGarlic, DishId = DishComNepGa, Amount = 5, Unit = "g" },
            new FoodDish { FoodId = FOnion, DishId = DishComNepGa, Amount = 20, Unit = "g" },
            new FoodDish { FoodId = FFishSauce, DishId = DishComNepGa, Amount = 5, Unit = "g" },
            new FoodDish { FoodId = FSugar, DishId = DishComNepGa, Amount = 2, Unit = "g" },
            new FoodDish { FoodId = FVegetableOil, DishId = DishComNepGa, Amount = 6, Unit = "g" },

            // Dish 15: Grilled Shrimp
            new FoodDish { FoodId = FShrimp, DishId = DishTomNuong, Amount = 120, Unit = "g" },
            new FoodDish { FoodId = FGarlic, DishId = DishTomNuong, Amount = 8, Unit = "g" },
            new FoodDish { FoodId = FLemongrass, DishId = DishTomNuong, Amount = 5, Unit = "g" },
            new FoodDish { FoodId = FChiliPowder, DishId = DishTomNuong, Amount = 1, Unit = "g" },
            new FoodDish { FoodId = FFishSauce, DishId = DishTomNuong, Amount = 4, Unit = "g" },
            new FoodDish { FoodId = FVegetableOil, DishId = DishTomNuong, Amount = 5, Unit = "g" },

            // Dish 16: Pumpkin and Pork Soup
            new FoodDish { FoodId = FPork, DishId = DishCanhBiDo, Amount = 60, Unit = "g" },
            new FoodDish { FoodId = FOnion, DishId = DishCanhBiDo, Amount = 25, Unit = "g" },
            new FoodDish { FoodId = FGarlic, DishId = DishCanhBiDo, Amount = 5, Unit = "g" },
            new FoodDish { FoodId = FFishSauce, DishId = DishCanhBiDo, Amount = 5, Unit = "g" },
            new FoodDish { FoodId = FTableSalt, DishId = DishCanhBiDo, Amount = 2, Unit = "g" },
            new FoodDish { FoodId = FPumpkin, DishId = DishCanhBiDo, Amount = 50, Unit = "g" },
            new FoodDish { FoodId = FWater, DishId = DishCanhBiDo, Amount = 300, Unit = "ml" },

            // Dish 17: Mixed Vegetable Stir-fry
            new FoodDish { FoodId = FEggplant, DishId = DishRauXaoCuQua, Amount = 60, Unit = "g" },
            new FoodDish { FoodId = FBroccoli, DishId = DishRauXaoCuQua, Amount = 50, Unit = "g" },
            new FoodDish { FoodId = FCarrot, DishId = DishRauXaoCuQua, Amount = 40, Unit = "g" },
            new FoodDish { FoodId = FBeanSprouts, DishId = DishRauXaoCuQua, Amount = 35, Unit = "g" },
            new FoodDish { FoodId = FGarlic, DishId = DishRauXaoCuQua, Amount = 6, Unit = "g" },
            new FoodDish { FoodId = FVegetableOil, DishId = DishRauXaoCuQua, Amount = 8, Unit = "g" },
            new FoodDish { FoodId = FFishSauce, DishId = DishRauXaoCuQua, Amount = 4, Unit = "g" },

            // Dish 18: Pan-fried Fish with Fish Sauce
            new FoodDish { FoodId = FCod, DishId = DishCaChienNuocMam, Amount = 100, Unit = "g" },
            new FoodDish { FoodId = FFishSauce, DishId = DishCaChienNuocMam, Amount = 8, Unit = "g" },
            new FoodDish { FoodId = FSugar, DishId = DishCaChienNuocMam, Amount = 4, Unit = "g" },
            new FoodDish { FoodId = FGarlic, DishId = DishCaChienNuocMam, Amount = 6, Unit = "g" },
            new FoodDish { FoodId = FVegetableOil, DishId = DishCaChienNuocMam, Amount = 10, Unit = "g" },
            new FoodDish { FoodId = FBlackPepper, DishId = DishCaChienNuocMam, Amount = 1, Unit = "g" },
            new FoodDish { FoodId = FSpringOnion, DishId = DishCaChienNuocMam, Amount = 8, Unit = "g" },

            // Dish 19: Fresh Spring Rolls with Shrimp
            new FoodDish { FoodId = FRicePaper, DishId = DishGoiCuonTom, Amount = 20, Unit = "g" },
            new FoodDish { FoodId = FShrimp, DishId = DishGoiCuonTom, Amount = 60, Unit = "g" },
            new FoodDish { FoodId = FLettuce, DishId = DishGoiCuonTom, Amount = 40, Unit = "g" },
            new FoodDish { FoodId = FCucumber, DishId = DishGoiCuonTom, Amount = 30, Unit = "g" },
            new FoodDish { FoodId = FBeanSprouts, DishId = DishGoiCuonTom, Amount = 25, Unit = "g" },
            new FoodDish { FoodId = FSpringOnion, DishId = DishGoiCuonTom, Amount = 8, Unit = "g" },

            // Dish 20: Chicken Rice Porridge
            new FoodDish { FoodId = FRice, DishId = DishChaoGa, Amount = 60, Unit = "g" },
            new FoodDish { FoodId = FWater, DishId = DishChaoGa, Amount = 100, Unit = "ml" },
            new FoodDish { FoodId = FChicken, DishId = DishChaoGa, Amount = 70, Unit = "g" },
            new FoodDish { FoodId = FGarlic, DishId = DishChaoGa, Amount = 5, Unit = "g" },
            new FoodDish { FoodId = FOnion, DishId = DishChaoGa, Amount = 20, Unit = "g" },
            new FoodDish { FoodId = FFishSauce, DishId = DishChaoGa, Amount = 4, Unit = "g" },
            new FoodDish { FoodId = FSpringOnion, DishId = DishChaoGa, Amount = 10, Unit = "g" },
            new FoodDish { FoodId = FBlackPepper, DishId = DishChaoGa, Amount = 1, Unit = "g" },
            new FoodDish { FoodId = FVegetableOil, DishId = DishChaoGa, Amount = 3, Unit = "g" },

            // Dish 21: Grilled Pork Banh Mi
            new FoodDish { FoodId = FBanhMi, DishId = DishBanhMi, Amount = 80, Unit = "g" },
            new FoodDish { FoodId = FCoriander, DishId = DishBanhMi, Amount = 10, Unit = "g" },
            new FoodDish { FoodId = FCucumber, DishId = DishBanhMi, Amount = 30, Unit = "g" },
            new FoodDish { FoodId = FSugar, DishId = DishBanhMi, Amount = 4, Unit = "g" },
            new FoodDish { FoodId = FSpringOnion, DishId = DishBanhMi, Amount = 5, Unit = "g" },
            new FoodDish { FoodId = FRadish, DishId = DishBanhMi, Amount = 20, Unit = "g" },
            new FoodDish { FoodId = FCarrot, DishId = DishBanhMi, Amount = 10, Unit = "g" },
            new FoodDish { FoodId = FWater, DishId = DishBanhMi, Amount = 20, Unit = "g" },
            new FoodDish { FoodId = FSoysauce, DishId = DishBanhMi, Amount = 2, Unit = "g" },
            new FoodDish { FoodId = FKetchup, DishId = DishBanhMi, Amount = 8, Unit = "g" },
            new FoodDish { FoodId = FVinegar, DishId = DishBanhMi, Amount = 5, Unit = "g" },
            new FoodDish { FoodId = FPork, DishId = DishBanhMi, Amount = 70, Unit = "g" },
            new FoodDish { FoodId = FMayo, DishId = DishBanhMi, Amount = 5, Unit = "g" }
            );
            // ---------------------------------------------------
            // MEAL
            // ---------------------------------------------------
            //modelBuilder.Entity<Meal>().HasData(
            //    new Meal
            //    {
            //        Id = Guid.NewGuid(),
            //        MealType = MealType.Breakfast,
            //        TotalCalories = 399
            //    }
            //);

        }
    }
}
