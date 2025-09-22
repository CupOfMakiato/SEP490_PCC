using AutoMapper;
using Org.BouncyCastle.Asn1.Ocsp;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.NutrientSuggestion;
using Server.Application.Interfaces;
using Server.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Server.Application.Services
{
    public class NutrientSuggestionService : INutrientSuggestionService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public NutrientSuggestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
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

            var ageGroup = await _unitOfWork.AgeGroupRepository.GetByIdAsync((Guid)request.AgeGroupId);
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
                AgeGroupId = request.AgeGroupId,
                AgeGroup = ageGroup,
                NutrientSuggestionId = request.NutrientSuggetionId,
                NutrientSuggestion = nutrientSuggestion,
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

        public async Task<Result<NSAttribute>> UpdateNutrientSuggestionAttribute(UpdateNutrientSuggestionAttributeRequest request)
        {
            var attribute = await _unitOfWork.NSAttributeRepository.GetNSAttributeById(request.AttributeId);
            if (attribute == null)
                return new Result<NSAttribute>()
                {
                    Error = 1,
                    Message = "Invalid AttributeId"
                };
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
            if (attribute.NutrientId != request.NutrientId)
            {
                attribute.NutrientId = request.NutrientId;
                attribute.Nutrient = nutrient;
            }
            attribute.Amount = request.Amount;
            attribute.MaxEnergyPercentage = request.MaxEnergyPercentage;
            attribute.MaxValuePerDay = request.MaxValuePerDay;
            attribute.MinAnimalProteinPercentageRequire = request.MinAnimalProteinPercentageRequire;
            attribute.MinEnergyPercentage = request.MinEnergyPercentage;
            attribute.MinValuePerDay = request.MinValuePerDay;
            attribute.Unit = request.Unit;
            attribute.Type = request.Type;
            _unitOfWork.NSAttributeRepository.Update(attribute);
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return new Result<NSAttribute>()
                {
                    Error = 0,
                    Data = attribute,
                    Message = "Update successfully"
                };
            return new Result<NSAttribute>()
            {
                Error = 1,
                Message = "Update fail"
            };
        }

        public async Task<Result<NutrientSuggestion>> CreateNutrientSuggestion(CreateNutrientSuggestionRequest request)
        {
            var nutrientSuggestion = new NutrientSuggestion()
            {
                NutrientSuggestionName = request.NutrientSuggetionName
            };
            await _unitOfWork.NutrientSuggetionRepository.AddAsync(nutrientSuggestion);
            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                return new Result<NutrientSuggestion>()
                {
                    Error = 0,
                    Data = nutrientSuggestion
                }; 
            }
            return new Result<NutrientSuggestion>()
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
            List<NutrientSuggestion> nutrientSuggetions = await _unitOfWork.NutrientSuggetionRepository.GetNutrientSuggetionListWithAttribute(ageGroup.Id, trimester);

            if (nutrientSuggetions == null || nutrientSuggetions.Count == 0)
            {
                return new Result<object>()
                {
                    Error = 1,
                    Message = "Not found nutrient suggestion"
                };
            }

            if(nutrientSuggetions.All(ns => ns.NutrientSuggestionAttributes.Count == 0))
                return new Result<object>()
                {
                    Error = 1,
                    Message = "Nutrient suggest lack attributes"
                };

            try
            {
                List<NutrientSuggestionAttribute> nutrientSuggestionAttribute = new List<NutrientSuggestionAttribute>();

                var protein = nutrientSuggetions.FirstOrDefault(ns => ns.NutrientSuggestionName.Equals("Protein")).NutrientSuggestionAttributes.FirstOrDefault().Attribute;
                var lipid = nutrientSuggetions.FirstOrDefault(ns => ns.NutrientSuggestionName.Equals("Lipid")).NutrientSuggestionAttributes.FirstOrDefault().Attribute;
                var glucid = nutrientSuggetions.FirstOrDefault(ns => ns.NutrientSuggestionName.Equals("Glucid")).NutrientSuggestionAttributes.FirstOrDefault().Attribute;

                var mineralNSA = nutrientSuggetions.FirstOrDefault(ns => ns.NutrientSuggestionName.Equals("Minerals")).NutrientSuggestionAttributes;
                var canxi = mineralNSA.FirstOrDefault(ns => ns.Attribute.Nutrient.Name.Equals("Calcium")).Attribute;
                var iron = mineralNSA.FirstOrDefault(ns => ns.Attribute.Nutrient.Name.Equals("Iron")).Attribute;
                var zinc = mineralNSA.FirstOrDefault(ns => ns.Attribute.Nutrient.Name.Equals("Zinc")).Attribute; //kẽm 
                var iodine = mineralNSA.FirstOrDefault(ns => ns.Attribute.Nutrient.Name.Equals("Iodine")).Attribute; //Iốt

                var vitaminNSA = nutrientSuggetions.FirstOrDefault(ns => ns.NutrientSuggestionName.Equals("Vitamins")).NutrientSuggestionAttributes;

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

                var otherNSA = nutrientSuggetions.FirstOrDefault(ns => ns.NutrientSuggestionName.Equals("Other Information")).NutrientSuggestionAttributes;

                var fiber = otherNSA.FirstOrDefault(ns => ns.Attribute.Nutrient.Name.Equals("Fiber")).Attribute;
                var salt = otherNSA.FirstOrDefault(ns => ns.Attribute.Nutrient.Name.Equals("Salt")).Attribute;


                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = null, // Keep original casing
                    DictionaryKeyPolicy = null
                };

                return new Result<object>()
                {
                    Error = 0,
                    Data = new
                    {
                        TotalDemanedEnergy = energySuggestion.BaseCalories + energySuggestion.AdditionalCalories,
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
                            Calcium = new
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


        public async Task<Result<NutrientSuggestion>> UpdateNutrientSuggestion(UpdateNutrientSuggestionRequest request)
        {
            var nutrientSuggestion = await _unitOfWork.NutrientSuggetionRepository.GetByIdAsync(request.Id);
            if (nutrientSuggestion == null)
                return new Result<NutrientSuggestion>()
                {
                    Error = 1,
                    Message = "Invalid Id"
                };
            nutrientSuggestion.NutrientSuggestionName = request.NutrientSuggetionName;
            _unitOfWork.NutrientSuggetionRepository.Update(nutrientSuggestion);
            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                return new Result<NutrientSuggestion>()
                {
                    Error = 0,
                    Data = nutrientSuggestion
                };
            }
            return new Result<NutrientSuggestion>()
            {
                Error = 1,
                Message = "Update fail"
            };
        }

        public async Task<Result<List<NutrientSuggestionDTO>>> ViewNutrientSuggestions()
        {
            var suggestions = await _unitOfWork.NutrientSuggetionRepository.GetNutrientSuggetions();

            if (suggestions == null || !suggestions.Any())
            {
                return new Result<List<NutrientSuggestionDTO>>()
                {
                    Error = 1,
                    Message = "No nutrient suggestions found"
                };
            }

            var dtoList = _mapper.Map<List<NutrientSuggestionDTO>>(suggestions);

            return new Result<List<NutrientSuggestionDTO>>()
            {
                Error = 0,
                Data = dtoList
            };
        }
        public async Task<Result<bool>> DeleteNutrientSuggestion(Guid id)
        {
            var suggestion = await _unitOfWork.NutrientSuggetionRepository.GetNutrientSuggetionById(id);

            if (suggestion == null)
            {
                return new Result<bool>()
                {
                    Error = 1,
                    Message = "Nutrient suggestion not found"
                };
            }

            if (suggestion.NutrientSuggestionAttributes is not null && suggestion.NutrientSuggestionAttributes.Count > 0)
            {
                return new Result<bool>()
                {
                    Error = 1,
                    Message = "Cannot delete nutrient suggestion with associated attributes"
                };
            }

            _unitOfWork.NutrientSuggetionRepository.DeleteNutrientSuggetion(suggestion);

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
                Message = "Delete failed"
            };
        }

        public async Task<Result<NutrientSuggestionDTO>> ViewNutrientSuggestionById(Guid id)
        {
            var suggestion = await _unitOfWork.NutrientSuggetionRepository.GetNutrientSuggetionById(id);

            if (suggestion == null)
            {
                return new Result<NutrientSuggestionDTO>()
                {
                    Error = 1,
                    Message = "Nutrient suggestion not found"
                };
            }

            var dto = _mapper.Map<NutrientSuggestionDTO>(suggestion);

            return new Result<NutrientSuggestionDTO>()
            {
                Error = 0,
                Data = dto
            };
        }

        public async Task<Result<bool>> DeleteAttribute(Guid nutrientSuggestionId, Guid attributeId)
        {
            var nutrientSuggestion = await _unitOfWork.NutrientSuggetionRepository.GetNutrientSuggetionById(nutrientSuggestionId);
            if (nutrientSuggestion is null)
            {
                return new Result<bool>()
                {
                    Error = 1,
                    Message = "Nutrient suggestion not found"
                };
            }
            var nsAttribute = await _unitOfWork.NSAttributeRepository.GetByIdAsync(attributeId);
            if (nsAttribute is null)
            {
                return new Result<bool>()
                {
                    Error = 1,
                    Message = "Attribute not found"
                };
            }
            bool containsAttribute = nutrientSuggestion.NutrientSuggestionAttributes
                .Any(nsa => nsa.AttributeId == attributeId);
            if (!containsAttribute)
                {
                return new Result<bool>()
                {
                    Error = 1,
                    Message = "Attribute does not belong to the specified nutrient suggestion"
                };
            }
            _unitOfWork.NSAttributeRepository.Remove(nsAttribute);
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
                Message = "Delete failed"
            };
        }
    }
}
