using Org.BouncyCastle.Asn1.Ocsp;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.NutrientSuggestion;
using Server.Application.Interfaces;
using Server.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Server.Application.Services
{
    public class NutrientSuggestionService : INutrientSuggestionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NutrientSuggestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<NSAttribute>> AddNutrientSuggestionAttribute(AddNutrientSuggestionAttributeRequest request)
        {
            if (request == null)
                return new Result<NSAttribute>()
                {
                    Error = 1,
                    Message = "Request is null"
                };
            var nutrient = await _unitOfWork.NutrientRepository.GetByIdAsync(request.NutrientId);
            if (nutrient is null)
                return new Result<NSAttribute>()
                {
                    Error = 1,
                    Message = "Invalid NutrientId"
                };
            var attribute = new NSAttribute()
            {
                NutrientId = request.NutrientId,
                Nutrient = nutrient,
                Amount = request.Amount,
                MaxEnergyPercentage = request.MaxEnergyPercentage,
                MaxValuePerDay = request.MaxValuePerDay,
                MinAnimalProteinPercentageRequire = request.MinAnimalProteinPercentageRequire,
                MinEnergyPercentage = request.MinEnergyPercentage,
                MinValuePerDay = request.MinValuePerDay,
                Unit = request.Unit,
                Type = request.Type,                
            };

            await _unitOfWork.NSAttributeRepository.AddAsync(attribute);            

            var ageGroup = await _unitOfWork.AgeGroupRepository.GetByIdAsync((Guid)request.AgeGroudId);
            if (ageGroup is null)
                return new Result<NSAttribute>()
                {
                    Error = 1,
                    Message = "Invalid AgeGroupId"
                };
            var nutrientSuggestion = await _unitOfWork.NutrientSuggetionRepository.GetByIdAsync((Guid)request.NutrientSuggetionId);
            if (nutrientSuggestion is null)
                return new Result<NSAttribute>()
                {
                    Error = 1,
                    Message = "Invalid NutrientSuggetionId"
                };
            var nutrientSuggestionRela = new NutrientSuggestionAttribute()
            {
                AgeGroudId = request.AgeGroudId,
                AgeGroup = ageGroup,
                NutrientSuggetionId = request.NutrientSuggetionId,
                NutrientSuggetion = nutrientSuggestion,
                Attribute = attribute,
                AttributeId = attribute.Id,
                Trimester = request.Trimester,
            };
           await _unitOfWork.NutrientSuggetionRepository.CreateNutrientSuggetionAttribute(nutrientSuggestionRela);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<NSAttribute>()
                {
                    Error = 0,
                    Data = attribute
                };
            return new Result<NSAttribute>()
            {
                Error = 1,
                Message = "Create fail"
            };
        }

        public async Task<Result<NutrientSuggetion>> CreateNutrientSuggestion(CreateNutrientSuggestionRequest request)
        {
            var nutrientSuggestion = new NutrientSuggetion()
            {
                NutrientSuggetionName = request.NutrientSuggetionName
            };
            await _unitOfWork.NutrientSuggetionRepository.AddAsync(nutrientSuggestion);
            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                return new Result<NutrientSuggetion>()
                {
                    Error = 0,
                    Data = nutrientSuggestion
                }; 
            }
            return new Result<NutrientSuggetion>()
            {
                Error = 1,
                Message = "Create fail"
            };
        }

        public async Task<Result<object>> GetEssentialNutritionalNeedsInOneDay(GetEssentialNutritionalNeedsInOneDayRequest request)
        {
            AgeGroup ageGroup;
            if (DateTime.TryParse(request.dateOfBith, out DateTime date))
            {
                ageGroup = await _unitOfWork.AgeGroupRepository.GetAgeGroupByUserDateOfBirth(date);
            }
            else
            {
                ageGroup = await _unitOfWork.AgeGroupRepository.GetAgeGroupFrom20To29();
            }

            int trimester = request.currentWeek switch
            {
                < 12 => 1,
                < 24 => 2,
                _ => 3
            };

            EnergySuggestion energySuggestion;
            if (request.activityLevel < 1 && request.activityLevel > 2 || request.activityLevel is null)
            {
                energySuggestion = await _unitOfWork.EnergySuggestionRepository.GetEnergySuggestionByAgeGroupIdAndTrimester(ageGroup.Id, trimester, 2);
            }
            else
                energySuggestion = await _unitOfWork.EnergySuggestionRepository.GetEnergySuggestionByAgeGroupIdAndTrimester(ageGroup.Id, trimester, (int)request.activityLevel);
            if (energySuggestion is null)
            {
                return new Result<object>()
                {
                    Error = 1,
                    Message = "Not found energy suggestion"
                };
            }
            List<NutrientSuggetion> nutrientSuggetions = await _unitOfWork.NutrientSuggetionRepository.GetNutrientSuggetionListWithAttribute(ageGroup.Id, trimester);
            try
            {
                List<NutrientSuggestionAttribute> nutrientSuggestionAttribute = new List<NutrientSuggestionAttribute>();

                var protein = nutrientSuggetions.FirstOrDefault(ns => ns.NutrientSuggetionName.Equals("Protein")).NutrientSuggestionAttributes.First().Attribute;
                var lipid = nutrientSuggetions.FirstOrDefault(ns => ns.NutrientSuggetionName.Equals("Lipid")).NutrientSuggestionAttributes.First().Attribute;
                var glucid = nutrientSuggetions.FirstOrDefault(ns => ns.NutrientSuggetionName.Equals("Glucid")).NutrientSuggestionAttributes.First().Attribute;

                var mineralNSA = nutrientSuggetions.FirstOrDefault(ns => ns.NutrientSuggetionName.Equals("Minerals")).NutrientSuggestionAttributes;
                var canxi = mineralNSA.FirstOrDefault(ns => ns.Attribute.Nutrient.Name.Equals("Calcium")).Attribute;
                var iron = mineralNSA.FirstOrDefault(ns => ns.Attribute.Nutrient.Name.Equals("Iron")).Attribute;
                var zinc = mineralNSA.FirstOrDefault(ns => ns.Attribute.Nutrient.Name.Equals("Zinc")).Attribute; //kẽm 
                var iodine = mineralNSA.FirstOrDefault(ns => ns.Attribute.Nutrient.Name.Equals("Iodine")).Attribute; //Iốt

                var vitaminNSA = nutrientSuggetions.FirstOrDefault(ns => ns.NutrientSuggetionName.Equals("Vitamins")).NutrientSuggestionAttributes;

                var vitaminA = vitaminNSA.FirstOrDefault(ns => ns.Attribute.Nutrient.Name.Equals("Vitamin A")).Attribute;
                var vitaminD = vitaminNSA.FirstOrDefault(ns => ns.Attribute.Nutrient.Name.Equals("Vitamin D")).Attribute;
                var vitaminE = vitaminNSA.FirstOrDefault(ns => ns.Attribute.Nutrient.Name.Equals("Vitamin E")).Attribute;
                var vitaminK = vitaminNSA.FirstOrDefault(ns => ns.Attribute.Nutrient.Name.Equals("Vitamin K")).Attribute;
                var vitaminB1 = vitaminNSA.FirstOrDefault(ns => ns.Attribute.Nutrient.Name.Equals("Vitamin B1")).Attribute;
                var vitaminB2 = vitaminNSA.FirstOrDefault(ns => ns.Attribute.Nutrient.Name.Equals("Vitamin B2")).Attribute;
                var vitaminB6 = vitaminNSA.FirstOrDefault(ns => ns.Attribute.Nutrient.Name.Equals("Vitamin B6")).Attribute;
                var folate = vitaminNSA.FirstOrDefault(ns => ns.Attribute.Nutrient.Name.Equals("Vitamin B9 (Folate)")).Attribute;
                var vitaminB12 = vitaminNSA.FirstOrDefault(ns => ns.Attribute.Nutrient.Name.Equals("Vitamin B12")).Attribute;
                var vitaminC = vitaminNSA.FirstOrDefault(ns => ns.Attribute.Nutrient.Name.Equals("Vitamin C")).Attribute;
                var choline = vitaminNSA.FirstOrDefault(ns => ns.Attribute.Nutrient.Name.Equals("Choline")).Attribute;

                var otherNSA = nutrientSuggetions.FirstOrDefault(ns => ns.NutrientSuggetionName.Equals("Other Information")).NutrientSuggestionAttributes;

                var fiber = otherNSA.FirstOrDefault(ns => ns.Attribute.Nutrient.Name.Equals("Fiber")).Attribute;
                var salt = otherNSA.FirstOrDefault(ns => ns.Attribute.Nutrient.Name.Equals("Salt")).Attribute;



                return new Result<object>()
                {
                    Error = 0,
                    Data = new
                    {
                        Energy = energySuggestion.BaseCalories + energySuggestion.AdditionalCalories,
                        PLGSubstances = new
                        {
                            Protein = new
                            {
                                demand = $"{protein.MinEnergyPercentage}" +
                                    $" - " +
                                    $"{protein.MaxEnergyPercentage}",
                                unit = "%"
                            },
                            Lipid = new
                            {
                                demand = $"{lipid.MinEnergyPercentage}" +
                                    $" - " +
                                    $"{lipid.MaxEnergyPercentage}",
                                unit = "%"
                            },
                            Glucid = new
                            {
                                demand = $"{glucid.MinEnergyPercentage}" +
                                    $" - " +
                                    $"{glucid.MaxEnergyPercentage}",
                                unit = "%"
                            }
                        },
                        Minerals = new
                        {
                            Canxi = new
                            {
                                demand = $"{canxi.MinValuePerDay} - {canxi.MaxValuePerDay}",
                                unit = $"{canxi.Unit}"
                            },
                            Iron = new
                            {
                                demand = $"{iron.MinValuePerDay}",
                                unit = $"{iron.Unit}"
                            },
                            Zinc = new
                            {
                                demand = $"{zinc.MinValuePerDay}",
                                unit = $"{zinc.Unit}"
                            },
                            Iodine = new
                            {
                                demand = $"{iodine.MinValuePerDay} - {iodine.MaxValuePerDay}",
                                unit = $"{iodine.Unit}"
                            },
                        },
                        Vitamins = new
                        {
                            VitaminA = new
                            {
                                demand = $"{vitaminA.MinValuePerDay}",
                                unit = $"{vitaminA.Unit}"
                            },
                            VitaminD = new
                            {
                                demand = $"{vitaminD.MinValuePerDay}",
                                unit = $"{vitaminD.Unit}"
                            },
                            VitaminE = new
                            {
                                demand = $"{vitaminE.MinValuePerDay}",
                                unit = $"{vitaminE.Unit}"
                            },
                            VitaminK = new
                            {
                                demand = $"{vitaminK.MinValuePerDay}",
                                unit = $"{vitaminK.Unit}"
                            },
                            VitaminB1 = new
                            {
                                demand = $"{vitaminB1.MinValuePerDay}",
                                unit = $"{vitaminB1.Unit}"
                            },
                            VitaminB2 = new
                            {
                                demand = $"{vitaminB2.MinValuePerDay}",
                                unit = $"{vitaminB2.Unit}"
                            },
                            VitaminB6 = new
                            {
                                demand = $"{vitaminB6.MinValuePerDay}",
                                unit = $"{vitaminB6.Unit}"
                            },
                            Folate = new
                            {
                                demand = $"{folate.MinValuePerDay}",
                                unit = $"{folate.Unit}"
                            },
                            VitaminB12 = new
                            {
                                demand = $"{vitaminB12.MinValuePerDay}",
                                unit = $"{vitaminB12.Unit}"
                            },
                            VitaminC = new
                            {
                                demand = $"{vitaminC.MinValuePerDay}",
                                unit = $"{vitaminC.Unit}"
                            },
                            Choline = new
                            {
                                demand = $"{choline.MinValuePerDay}",
                                unit = $"{choline.Unit}"
                            }
                        },
                        OtherInformation = new
                        {
                            Fiber = new
                            {
                                demand = $"{fiber.MinValuePerDay}",
                                unit = $"{fiber.Unit}"
                            },
                            Salt = new
                            {
                                demand = $"< {salt.MaxValuePerDay}",
                                unit = $"{salt.Unit}"
                            }
                        }

                    }
                };
            }
            catch (Exception ex)
            {
                return new Result<object>
                {
                    Error = 1,
                    Data = ex.Message
                };
            }
        }

        public async Task<Result<bool>> SoftDeleteNutrientSuggestion(Guid Id)
        {
            var nutrientSuggestion = await _unitOfWork.NutrientSuggetionRepository.GetByIdAsync(Id);
            if (nutrientSuggestion == null)
                return new Result<bool>()
                {
                    Error = 1,
                    Message = "Invalid Id"
                };
            _unitOfWork.NutrientSuggetionRepository.SoftRemove(nutrientSuggestion);
            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                return new Result<bool>()
                {
                    Error = 0,
                    Data = true
                };
            }
            return new Result<bool>()
            {
                Error = 1,
                Message = "Delete fail"
            };
        }

        public async Task<Result<NutrientSuggetion>> UpdateNutrientSuggestion(UpdateNutrientSuggestionRequest request)
        {
            var nutrientSuggestion = await _unitOfWork.NutrientSuggetionRepository.GetByIdAsync(request.Id);
            if (nutrientSuggestion == null)
                return new Result<NutrientSuggetion>()
                {
                    Error = 1,
                    Message = "Invalid Id"
                };
            nutrientSuggestion.NutrientSuggetionName = request.NutrientSuggetionName;
            _unitOfWork.NutrientSuggetionRepository.Update(nutrientSuggestion);
            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                return new Result<NutrientSuggetion>()
                {
                    Error = 0,
                    Data = nutrientSuggestion
                };
            }
            return new Result<NutrientSuggetion>()
            {
                Error = 1,
                Message = "Update fail"
            };
        }
    }
}
