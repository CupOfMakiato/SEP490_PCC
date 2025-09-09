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

            var FApple = Guid.NewGuid();
            var FWatermelon = Guid.NewGuid();
            var FGrapefruit = Guid.NewGuid();
            var FStrawberry = Guid.NewGuid();
            var FRaspberry = Guid.NewGuid();
            var FOrange = Guid.NewGuid();

            var FOliveOil = Guid.NewGuid();
            var FSunflowerOil = Guid.NewGuid();
            
            var FAlmond = Guid.NewGuid();
            var FWalnut = Guid.NewGuid();
            var FCashew = Guid.NewGuid();
            var FPeanuts = Guid.NewGuid();

            var FMilk = Guid.NewGuid();
            var FButter = Guid.NewGuid();
            var FEgg = Guid.NewGuid();

            var FSoyBean = Guid.NewGuid();

            var FWheatBread = Guid.NewGuid();
            var FRiceBread = Guid.NewGuid();
            var FGFMultigrainBread = Guid.NewGuid();

            var FWater = Guid.NewGuid();
            var FHerbalTea = Guid.NewGuid();

            var FCinnamon = Guid.NewGuid();
            var FTurmeric = Guid.NewGuid();
            var FChiliPowder = Guid.NewGuid();
            var FTableSalt = Guid.NewGuid();
            var FBlackPepper = Guid.NewGuid();

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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
                    
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
                    CreationDate = new DateTime(2025, 09, 08)
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
