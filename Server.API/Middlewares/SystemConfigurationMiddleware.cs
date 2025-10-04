using Server.Application.DTOs.Clinic;
using Server.Application.DTOs.Consultant;
using Server.Application.DTOs.Doctor;
using Server.Application.DTOs.NutrientCategory;
using Server.Application.DTOs.OfflineConsultation;
using Server.Application.DTOs.NutrientSuggestion;
using Server.Application.Interfaces;
using Server.Domain.Enums;
using System.Text;
using System.Text.Json;

namespace Server.API.Middlewares
{
    public class SystemConfigurationMiddleware : IMiddleware
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public SystemConfigurationMiddleware(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task IsNullOrWhiteSpaceBody(string body, HttpContext context)
        {
            if (!string.IsNullOrWhiteSpace(body)) return;
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync("{\"error\":\"Request body is empty\"}");
            return;
        }

        public async Task<string> GetBody(HttpContext context)
        {
            context.Request.EnableBuffering();

            // Move to beginning in case someone has read before
            context.Request.Body.Position = 0;

            using var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true);
            var body = await reader.ReadToEndAsync();

            // Reset position so others can read again
            context.Request.Body.Position = 0;

            await IsNullOrWhiteSpaceBody(body, context);

            return body;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var path = context.Request.Path.Value?.ToLower();
            var jsonOptions = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            if (path is null)
                await context.Response.WriteAsync("Path is null");
            Console.WriteLine(path);
            Console.WriteLine(context.Request.Method);
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var scopeService = scope.ServiceProvider.GetRequiredService<ISystemConfigurationService>();
                var systemConfiguration = await scopeService.GetSystemConfigurationAsync();
                if (systemConfiguration == null)
                {
                    await next(context);
                }

                if (path.StartsWith("/api/nutrientcategory"))
                {
                    switch (path)
                    {
                        case "/api/nutrientsuggestionattribute/create":
                            {
                                var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
                                context.Request.Body = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(body));

                                var request = JsonSerializer.Deserialize<AddNutrientSuggestionAttributeRequest>(body);

                                if (request == null)
                                {
                                    await BadRequest(context, "Request body is invalid");
                                    return;
                                }

                                if (request.NutrientSuggetionId == Guid.Empty)
                                {
                                    await BadRequest(context, "NutrientSuggetionId is required");
                                    return;
                                }

                                if (string.IsNullOrWhiteSpace(request.Unit))
                                {
                                    await BadRequest(context, "Unit is required");
                                    return;
                                }

                                if (request.Amount < 0)
                                {
                                    await BadRequest(context, "Amount must be non-negative");
                                    return;
                                }

                                if (request.NutrientId == Guid.Empty)
                                {
                                    await BadRequest(context, "NutrientId is required");
                                    return;
                                }

                                if (request.Type < 0)
                                {
                                    await BadRequest(context, "Type must be non-negative");
                                    return;
                                }

                                if (request.Trimester < 0 || request.Trimester > 3)
                                {
                                    await BadRequest(context, "Trimester must be between 0 and 3");
                                    return;
                                }

                                if (request.MinEnergyPercentage.HasValue &&
                                    (request.MinEnergyPercentage < 0 || request.MinEnergyPercentage > 100))
                                {
                                    await BadRequest(context, "MinEnergyPercentage must be between 0 and 100");
                                    return;
                                }

                                if (request.MaxEnergyPercentage.HasValue &&
                                    (request.MaxEnergyPercentage < 0 || request.MaxEnergyPercentage > 100))
                                {
                                    await BadRequest(context, "MaxEnergyPercentage must be between 0 and 100");
                                    return;
                                }

                                if (request.MinEnergyPercentage.HasValue && request.MaxEnergyPercentage.HasValue &&
                                    request.MinEnergyPercentage > request.MaxEnergyPercentage)
                                {
                                    await BadRequest(context, "MinEnergyPercentage cannot be greater than MaxEnergyPercentage");
                                    return;
                                }

                                if (request.MinValuePerDay.HasValue && request.MaxValuePerDay.HasValue &&
                                    request.MinValuePerDay > request.MaxValuePerDay)
                                {
                                    await BadRequest(context, $"MinValuePerDay cannot be greater than MaxValuePerDay");
                                    return;
                                }

                            if (updateDto.Description.Length > systemConfiguration.DescriptionMaxLength ||
                                updateDto.Description.Length < systemConfiguration.DescriptionMinLength)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync($"{{\"error\":\"Description length must be from {systemConfiguration.DescriptionMinLength} to {systemConfiguration.DescriptionMaxLength}\"}}");
                                return;
                            }
                            break;
                    }
                }

                if (path.StartsWith("/api/clinic"))
                {
                    switch (path)
                    {
                        case "/api/clinic/view-clinic-by-id":
                            var clinicId = context.Request.Query["clinicId"].FirstOrDefault();
                            if (string.IsNullOrWhiteSpace(clinicId))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Clinic's Id is null or empty\"}");
                                return;
                            }
                            if (!Guid.TryParse(clinicId, out _))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Clinic's Id is not a valid GUID\"}");
                                return;
                            }
                            break;

                        case "/api/clinic/suggest-clinics/":
                            var segments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
                            var userIdStr = segments.LastOrDefault();
                            if (string.IsNullOrWhiteSpace(userIdStr))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"UserId is null or empty\"}");
                                return;
                            }
                            if (!Guid.TryParse(userIdStr, out _))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"UserId is not a valid GUID\"}");
                                return;
                            }
                            break;

                        case "/api/clinic/view-clinic-by-user-id/":
                            var userIdSegment = path.Split('/', StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
                            if (string.IsNullOrWhiteSpace(userIdSegment))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"UserId is null or empty\"}");
                                return;
                            }
                            if (!Guid.TryParse(userIdSegment, out _))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"UserId is not a valid GUID\"}");
                                return;
                            }
                            break;

                        case "/api/clinic/create-clinic":
                            var body = await GetBody(context);
                            if (string.IsNullOrWhiteSpace(body))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Request body is empty\"}");
                                return;
                            }

                            AddClinicDTO createDto = null;
                            try
                            {
                                createDto = System.Text.Json.JsonSerializer.Deserialize<AddClinicDTO>(body, jsonOptions);
                            }
                            catch
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Invalid request body format\"}");
                                return;
                            }

                            // UserName validation
                            if (string.IsNullOrWhiteSpace(createDto.UserName))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"UserName is required\"}");
                                return;
                            }
                            if (createDto.UserName.Length > systemConfiguration.NameMaxLength ||
                                createDto.UserName.Length < systemConfiguration.NameMinLength)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync($"{{\"error\":\"UserName length must be from {systemConfiguration.NameMinLength} to {systemConfiguration.NameMaxLength}\"}}");
                                return;
                            }

                            // PasswordHash validation
                            if (string.IsNullOrWhiteSpace(createDto.PasswordHash))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"PasswordHash is required\"}");
                                return;
                            }
                            if (createDto.PasswordHash.Length > 128 || createDto.PasswordHash.Length < 6) // Example limits
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"PasswordHash length must be from 6 to 128 characters\"}");
                                return;
                            }

                            // Address validation
                            if (string.IsNullOrWhiteSpace(createDto.Address))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Address is required\"}");
                                return;
                            }
                            if (createDto.Address.Length > systemConfiguration.DescriptionMaxLength ||
                                createDto.Address.Length < systemConfiguration.DescriptionMinLength)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync($"{{\"error\":\"Address length must be from {systemConfiguration.DescriptionMinLength} to {systemConfiguration.DescriptionMaxLength}\"}}");
                                return;
                            }

                            // Email validation
                            if (string.IsNullOrWhiteSpace(createDto.Email))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Email is required\"}");
                                return;
                            }
                            var emailAttribute = new System.ComponentModel.DataAnnotations.EmailAddressAttribute();
                            if (!emailAttribute.IsValid(createDto.Email))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Invalid email address\"}");
                                return;
                            }

                            // PhoneNumber validation (optional, but if present, check length)
                            if (!string.IsNullOrWhiteSpace(createDto.PhoneNumber) && createDto.PhoneNumber.Length > 20)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"PhoneNumber length must be less than or equal to 20 characters\"}");
                                return;
                            }

                            // Specializations validation
                            if (string.IsNullOrWhiteSpace(createDto.Specializations))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Specializations is required\"}");
                                return;
                            }
                            if (createDto.Specializations.Length > 256 || createDto.Specializations.Length < 3) // Example limits
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Specializations length must be from 3 to 256 characters\"}");
                                return;
                            }
                            break;
                        case "/api/clinic/update-clinic":
                            var updateBody = await GetBody(context);
                            if (string.IsNullOrWhiteSpace(updateBody))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Request body is empty\"}");
                                return;
                            }

                            UpdateClinicDTO updateDto = null;
                            try
                            {
                                updateDto = System.Text.Json.JsonSerializer.Deserialize<UpdateClinicDTO>(updateBody, jsonOptions);
                            }
                            catch
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Invalid request body format\"}");
                                return;
                            }

                            // Address validation
                            if (string.IsNullOrWhiteSpace(updateDto.Address))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Address is required\"}");
                                return;
                            }
                            if (updateDto.Address.Length > systemConfiguration.DescriptionMaxLength ||
                                updateDto.Address.Length < systemConfiguration.DescriptionMinLength)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync($"{{\"error\":\"Address length must be from {systemConfiguration.DescriptionMinLength} to {systemConfiguration.DescriptionMaxLength}\"}}");
                                return;
                            }

                            // Specializations validation
                            if (string.IsNullOrWhiteSpace(updateDto.Specializations))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Specializations is required\"}");
                                return;
                            }
                            if (updateDto.Specializations.Length > 256 || updateDto.Specializations.Length < 3)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Specializations length must be from 3 to 256 characters\"}");
                                return;
                            }
                            break;
                    }
                }

                if (path.StartsWith("/api/doctor"))
                {
                    switch (path)
                    {
                        case "/api/doctor/create-doctor":
                            var body = await GetBody(context);
                            if (string.IsNullOrWhiteSpace(body))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Request body is empty\"}");
                                return;
                            }

                            AddDoctorDTO createDto = null;
                            try
                            {
                                createDto = System.Text.Json.JsonSerializer.Deserialize<AddDoctorDTO>(body, jsonOptions);
                            }
                            catch
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Invalid request body format\"}");
                                return;
                            }

                            // ClinicId validation
                            if (createDto.ClinicId == Guid.Empty)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"ClinicId is required\"}");
                                return;
                            }

                            // DateOfBirth validation (optional, but if present, check reasonable range)
                            if (createDto.DateOfBirth != null && (createDto.DateOfBirth > DateTime.Now || createDto.DateOfBirth < DateTime.Now.AddYears(-100)))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"DateOfBirth is invalid\"}");
                                return;
                            }

                            // PhoneNumber validation (optional, but if present, check length)
                            if (!string.IsNullOrWhiteSpace(createDto.PhoneNumber) && createDto.PhoneNumber.Length > 20)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"PhoneNumber length must be less than or equal to 20 characters\"}");
                                return;
                            }

                            // Email validation
                            if (string.IsNullOrWhiteSpace(createDto.Email))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Email is required\"}");
                                return;
                            }
                            var emailAttribute = new System.ComponentModel.DataAnnotations.EmailAddressAttribute();
                            if (!emailAttribute.IsValid(createDto.Email))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Invalid email address\"}");
                                return;
                            }

                            // UserName validation
                            if (string.IsNullOrWhiteSpace(createDto.UserName))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"UserName is required\"}");
                                return;
                            }
                            if (createDto.UserName.Length > systemConfiguration.NameMaxLength ||
                                createDto.UserName.Length < systemConfiguration.NameMinLength)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync($"{{\"error\":\"UserName length must be from {systemConfiguration.NameMinLength} to {systemConfiguration.NameMaxLength}\"}}");
                                return;
                            }

                            // Gender validation
                            if (string.IsNullOrWhiteSpace(createDto.Gender))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Gender is required\"}");
                                return;
                            }

                            // Specialization validation
                            if (string.IsNullOrWhiteSpace(createDto.Specialization))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Specialization is required\"}");
                                return;
                            }
                            if (createDto.Specialization.Length > 128 || createDto.Specialization.Length < 3)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Specialization length must be from 3 to 128 characters\"}");
                                return;
                            }

                            // Certificate validation
                            if (string.IsNullOrWhiteSpace(createDto.Certificate))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Certificate is required\"}");
                                return;
                            }
                            if (createDto.Certificate.Length > 128 || createDto.Certificate.Length < 3)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Certificate length must be from 3 to 128 characters\"}");
                                return;
                            }

                            // ExperienceYear validation
                            if (createDto.ExperienceYear < 0 || createDto.ExperienceYear > 100)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"ExperienceYear must be between 0 and 100\"}");
                                return;
                            }

                            // WorkPosition validation
                            if (string.IsNullOrWhiteSpace(createDto.WorkPosition))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"WorkPosition is required\"}");
                                return;
                            }
                            if (createDto.WorkPosition.Length > 128 || createDto.WorkPosition.Length < 3)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"WorkPosition length must be from 3 to 128 characters\"}");
                                return;
                            }

                            // Description validation (optional)
                            if (!string.IsNullOrWhiteSpace(createDto.Description))
                            {
                                if (createDto.Description.Length > systemConfiguration.DescriptionMaxLength ||
                                    createDto.Description.Length < systemConfiguration.DescriptionMinLength)
                                {
                                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                    context.Response.ContentType = "application/json";
                                    await context.Response.WriteAsync($"{{\"error\":\"Description length must be from {systemConfiguration.DescriptionMinLength} to {systemConfiguration.DescriptionMaxLength}\"}}");
                                    return;
                                }
                            }
                            break;
                        case "/api/doctor/update-doctor":
                            var updateBody = await GetBody(context);
                            if (string.IsNullOrWhiteSpace(updateBody))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Request body is empty\"}");
                                return;
                            }

                            UpdateDoctorDTO updateDto = null;
                            try
                            {
                                updateDto = System.Text.Json.JsonSerializer.Deserialize<UpdateDoctorDTO>(updateBody, jsonOptions);
                            }
                            catch
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Invalid request body format\"}");
                                return;
                            }

                            // Id validation
                            if (updateDto.Id == Guid.Empty)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Id is required\"}");
                                return;
                            }

                            // DateOfBirth validation (optional, but if present, check reasonable range)
                            if (updateDto.DateOfBirth != null && (updateDto.DateOfBirth > DateTime.Now || updateDto.DateOfBirth < DateTime.Now.AddYears(-100)))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"DateOfBirth is invalid\"}");
                                return;
                            }

                            // PhoneNumber validation (optional, but if present, check length)
                            if (!string.IsNullOrWhiteSpace(updateDto.PhoneNumber) && updateDto.PhoneNumber.Length > 20)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"PhoneNumber length must be less than or equal to 20 characters\"}");
                                return;
                            }

                            // Email validation
                            if (string.IsNullOrWhiteSpace(updateDto.Email))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Email is required\"}");
                                return;
                            }
                            var emailDoctorAttribute = new System.ComponentModel.DataAnnotations.EmailAddressAttribute();
                            if (!emailDoctorAttribute.IsValid(updateDto.Email))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Invalid email address\"}");
                                return;
                            }

                            // UserName validation
                            if (string.IsNullOrWhiteSpace(updateDto.UserName))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"UserName is required\"}");
                                return;
                            }
                            if (updateDto.UserName.Length > systemConfiguration.NameMaxLength ||
                                updateDto.UserName.Length < systemConfiguration.NameMinLength)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync($"{{\"error\":\"UserName length must be from {systemConfiguration.NameMinLength} to {systemConfiguration.NameMaxLength}\"}}");
                                return;
                            }

                            // Gender validation
                            if (string.IsNullOrWhiteSpace(updateDto.Gender))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Gender is required\"}");
                                return;
                            }

                            // Specialization validation
                            if (string.IsNullOrWhiteSpace(updateDto.Specialization))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Specialization is required\"}");
                                return;
                            }
                            if (updateDto.Specialization.Length > 128 || updateDto.Specialization.Length < 3)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Specialization length must be from 3 to 128 characters\"}");
                                return;
                            }

                            // Certificate validation
                            if (string.IsNullOrWhiteSpace(updateDto.Certificate))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Certificate is required\"}");
                                return;
                            }
                            if (updateDto.Certificate.Length > 128 || updateDto.Certificate.Length < 3)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Certificate length must be from 3 to 128 characters\"}");
                                return;
                            }

                            // ExperienceYear validation
                            if (updateDto.ExperienceYear < 0 || updateDto.ExperienceYear > 100)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"ExperienceYear must be between 0 and 100\"}");
                                return;
                            }

                            // WorkPosition validation
                            if (string.IsNullOrWhiteSpace(updateDto.WorkPosition))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"WorkPosition is required\"}");
                                return;
                            }
                            if (updateDto.WorkPosition.Length > 128 || updateDto.WorkPosition.Length < 3)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"WorkPosition length must be from 3 to 128 characters\"}");
                                return;
                            }

                            // Description validation (optional)
                            if (!string.IsNullOrWhiteSpace(updateDto.Description))
                            {
                                if (updateDto.Description.Length > systemConfiguration.DescriptionMaxLength ||
                                    updateDto.Description.Length < systemConfiguration.DescriptionMinLength)
                                {
                                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                    context.Response.ContentType = "application/json";
                                    await context.Response.WriteAsync($"{{\"error\":\"Description length must be from {systemConfiguration.DescriptionMinLength} to {systemConfiguration.DescriptionMaxLength}\"}}");
                                    return;
                                }
                            }
                            break;
                    }
                }
                if (path.StartsWith("/api/consultant"))
                {
                    switch (path)
                    {
                        case "/api/consultant/create-consultant":
                            var body = await GetBody(context);
                            if (string.IsNullOrWhiteSpace(body))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Request body is empty\"}");
                                return;
                            }

                            AddConsultantDTO createDto = null;
                            try
                            {
                                createDto = System.Text.Json.JsonSerializer.Deserialize<AddConsultantDTO>(body, jsonOptions);
                            }
                            catch
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Invalid request body format\"}");
                                return;
                            }

                            // ClinicId validation
                            if (createDto.ClinicId == Guid.Empty)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"ClinicId is required\"}");
                                return;
                            }

                            // Specialization validation
                            if (string.IsNullOrWhiteSpace(createDto.Specialization))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Specialization is required\"}");
                                return;
                            }
                            if (createDto.Specialization.Length > 128 || createDto.Specialization.Length < 3)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Specialization length must be from 3 to 128 characters\"}");
                                return;
                            }

                            // Certificate validation
                            if (string.IsNullOrWhiteSpace(createDto.Certificate))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Certificate is required\"}");
                                return;
                            }
                            if (createDto.Certificate.Length > 128 || createDto.Certificate.Length < 3)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Certificate length must be from 3 to 128 characters\"}");
                                return;
                            }

                            // Gender validation
                            if (string.IsNullOrWhiteSpace(createDto.Gender))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Gender is required\"}");
                                return;
                            }

                            // ExperienceYears validation
                            if (createDto.ExperienceYears < 0 || createDto.ExperienceYears > 100)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"ExperienceYears must be between 0 and 100\"}");
                                return;
                            }

                            // UserName validation
                            if (string.IsNullOrWhiteSpace(createDto.UserName))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"UserName is required\"}");
                                return;
                            }
                            if (createDto.UserName.Length > systemConfiguration.NameMaxLength ||
                                createDto.UserName.Length < systemConfiguration.NameMinLength)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync($"{{\"error\":\"UserName length must be from {systemConfiguration.NameMinLength} to {systemConfiguration.NameMaxLength}\"}}");
                                return;
                            }

                            // PasswordHash validation
                            if (string.IsNullOrWhiteSpace(createDto.PasswordHash))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"PasswordHash is required\"}");
                                return;
                            }
                            if (createDto.PasswordHash.Length > 128 || createDto.PasswordHash.Length < 6)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"PasswordHash length must be from 6 to 128 characters\"}");
                                return;
                            }

                            // DateOfBirth validation (optional, but if present, check reasonable range)
                            if (createDto.DateOfBirth != null && (createDto.DateOfBirth > DateTime.Now || createDto.DateOfBirth < DateTime.Now.AddYears(-100)))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"DateOfBirth is invalid\"}");
                                return;
                            }

                            // PhoneNumber validation (optional, but if present, check length)
                            if (!string.IsNullOrWhiteSpace(createDto.PhoneNumber) && createDto.PhoneNumber.Length > 20)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"PhoneNumber length must be less than or equal to 20 characters\"}");
                                return;
                            }

                            // Email validation
                            if (string.IsNullOrWhiteSpace(createDto.Email))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Email is required\"}");
                                return;
                            }
                            var emailAttribute = new System.ComponentModel.DataAnnotations.EmailAddressAttribute();
                            if (!emailAttribute.IsValid(createDto.Email))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Invalid email address\"}");
                                return;
                            }
                            break;
                        case "/api/consultant/update-consultant":
                            var updateBody = await GetBody(context);
                            if (string.IsNullOrWhiteSpace(updateBody))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Request body is empty\"}");
                                return;
                            }

                            UpdateConsultantDTO updateDto = null;
                            try
                            {
                                updateDto = System.Text.Json.JsonSerializer.Deserialize<UpdateConsultantDTO>(updateBody, jsonOptions);
                            }
                            catch
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Invalid request body format\"}");
                                return;
                            }

                            // Id validation
                            if (updateDto.Id == Guid.Empty)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Id is required\"}");
                                return;
                            }

                            // Specialization validation
                            if (string.IsNullOrWhiteSpace(updateDto.Specialization))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Specialization is required\"}");
                                return;
                            }
                            if (updateDto.Specialization.Length > 128 || updateDto.Specialization.Length < 3)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Specialization length must be from 3 to 128 characters\"}");
                                return;
                            }

                            // Certificate validation
                            if (string.IsNullOrWhiteSpace(updateDto.Certificate))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Certificate is required\"}");
                                return;
                            }
                            if (updateDto.Certificate.Length > 128 || updateDto.Certificate.Length < 3)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Certificate length must be from 3 to 128 characters\"}");
                                return;
                            }

                            // Gender validation
                            if (string.IsNullOrWhiteSpace(updateDto.Gender))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Gender is required\"}");
                                return;
                            }

                            // ExperienceYears validation
                            if (updateDto.ExperienceYears < 0 || updateDto.ExperienceYears > 100)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"ExperienceYears must be between 0 and 100\"}");
                                return;
                            }
                            break;
                    }
                }
                if (path.StartsWith("/api/offline-consultation"))
                {
                    switch (path)
                    {
                        case "/api/offlineconsultation/book-offline-consultation":
                            var body = await GetBody(context);
                            if (string.IsNullOrWhiteSpace(body))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Request body is empty\"}");
                                return;
                            }

                            BookingOfflineConsultationDTO bookingDto = null;
                            try
                            {
                                bookingDto = System.Text.Json.JsonSerializer.Deserialize<BookingOfflineConsultationDTO>(body, jsonOptions);
                            }
                            catch
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Invalid request body format\"}");
                                return;
                            }

                            // UserId validation
                            if (bookingDto.UserId == Guid.Empty)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"UserId is required\"}");
                                return;
                            }

                            // DoctorId validation
                            if (bookingDto.DoctorId == Guid.Empty)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"DoctorId is required\"}");
                                return;
                            }

                            // ConsultationType validation
                            if (!Enum.IsDefined(typeof(ConsultationType), bookingDto.ConsultationType))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"ConsultationType is invalid\"}");
                                return;
                            }

                            // HealthNote validation (optional)
                            if (!string.IsNullOrWhiteSpace(bookingDto.HealthNote))
                            {
                                if (bookingDto.HealthNote.Length > systemConfiguration.DescriptionMaxLength ||
                                    bookingDto.HealthNote.Length < systemConfiguration.DescriptionMinLength)
                                {
                                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                    context.Response.ContentType = "application/json";
                                    await context.Response.WriteAsync($"{{\"error\":\"HealthNote length must be from {systemConfiguration.DescriptionMinLength} to {systemConfiguration.DescriptionMaxLength}\"}}");
                                    return;
                                }
                            }

                            // OneTime consultation validation
                            if (bookingDto.ConsultationType == ConsultationType.OneTime)
                            {
                                if (bookingDto.StartDate == null || bookingDto.EndDate == null)
                                {
                                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                    context.Response.ContentType = "application/json";
                                    await context.Response.WriteAsync("{\"error\":\"StartDate and EndDate are required for OneTime consultation.\"}");
                                    return;
                                }
                                if (bookingDto.StartDate > bookingDto.EndDate)
                                {
                                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                    context.Response.ContentType = "application/json";
                                    await context.Response.WriteAsync("{\"error\":\"StartDate must be before EndDate.\"}");
                                    return;
                                }
                                if (bookingDto.StartDate < DateTime.Now)
                                {
                                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                    context.Response.ContentType = "application/json";
                                    await context.Response.WriteAsync("{\"error\":\"StartDate must be in the future.\"}");
                                    return;
                                }
                            }

                            // Periodic consultation validation
                            if (bookingDto.ConsultationType == ConsultationType.Periodic)
                            {
                                if (bookingDto.FromMonth == null || bookingDto.ToMonth == null || bookingDto.Schedule == null || !bookingDto.Schedule.Any())
                                {
                                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                    context.Response.ContentType = "application/json";
                                    await context.Response.WriteAsync("{\"error\":\"FromMonth, ToMonth, and Schedule are required for Periodic consultation.\"}");
                                    return;
                                }
                                if (bookingDto.FromMonth > bookingDto.ToMonth)
                                {
                                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                    context.Response.ContentType = "application/json";
                                    await context.Response.WriteAsync("{\"error\":\"FromMonth must be before ToMonth.\"}");
                                    return;
                                }
                                if (bookingDto.FromMonth < DateTime.Now)
                                {
                                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                    context.Response.ContentType = "application/json";
                                    await context.Response.WriteAsync("{\"error\":\"FromMonth must be in the future.\"}");
                                    return;
                                }
                            }
                            break;
                        case "/api/offlineconsultation/update-offline-consultation":
                            var updateBody = await GetBody(context);
                            if (string.IsNullOrWhiteSpace(updateBody))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Request body is empty\"}");
                                return;
                            }

                            UpdateOfflineConsultationDTO updateDto = null;
                            try
                            {
                                updateDto = System.Text.Json.JsonSerializer.Deserialize<UpdateOfflineConsultationDTO>(updateBody, jsonOptions);
                            }
                            catch
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Invalid request body format\"}");
                                return;
                            }

                            // Id validation
                            if (updateDto.Id == Guid.Empty)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Id is required\"}");
                                return;
                            }

                            // HealthNote validation (optional)
                            if (!string.IsNullOrWhiteSpace(updateDto.HealthNote))
                            {
                                if (updateDto.HealthNote.Length > systemConfiguration.DescriptionMaxLength ||
                                    updateDto.HealthNote.Length < systemConfiguration.DescriptionMinLength)
                                {
                                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                    context.Response.ContentType = "application/json";
                                    await context.Response.WriteAsync($"{{\"error\":\"HealthNote length must be from {systemConfiguration.DescriptionMinLength} to {systemConfiguration.DescriptionMaxLength}\"}}");
                                    return;
                                }
                            }

                            // OneTime consultation validation
                            if (updateDto.StartDate != null || updateDto.EndDate != null)
                            {
                                if (updateDto.StartDate == null || updateDto.EndDate == null)
                                {
                                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                    context.Response.ContentType = "application/json";
                                    await context.Response.WriteAsync("{\"error\":\"StartDate and EndDate are required for OneTime consultation.\"}");
                                    return;
                                }
                                if (updateDto.StartDate > updateDto.EndDate)
                                {
                                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                    context.Response.ContentType = "application/json";
                                    await context.Response.WriteAsync("{\"error\":\"StartDate must be before EndDate.\"}");
                                    return;
                                }
                                if (updateDto.StartDate < DateTime.Now)
                                {
                                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                    context.Response.ContentType = "application/json";
                                    await context.Response.WriteAsync("{\"error\":\"StartDate must be in the future.\"}");
                                    return;
                                }
                            }

                            // Periodic consultation validation
                            if (updateDto.FromMonth != null || updateDto.ToMonth != null || (updateDto.Schedule != null && updateDto.Schedule.Any()))
                            {
                                if (updateDto.FromMonth == null || updateDto.ToMonth == null || updateDto.Schedule == null || !updateDto.Schedule.Any())
                                {
                                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                    context.Response.ContentType = "application/json";
                                    await context.Response.WriteAsync("{\"error\":\"FromMonth, ToMonth, and Schedule are required for Periodic consultation.\"}");
                                    return;
                                }
                                if (updateDto.FromMonth > updateDto.ToMonth)
                                {
                                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                    context.Response.ContentType = "application/json";
                                    await context.Response.WriteAsync("{\"error\":\"FromMonth must be before ToMonth.\"}");
                                    return;
                                }
                                if (updateDto.FromMonth < DateTime.Now)
                                {
                                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                    context.Response.ContentType = "application/json";
                                    await context.Response.WriteAsync("{\"error\":\"FromMonth must be in the future.\"}");
                                    return;
                                }
                                // Optionally, validate each schedule item
                                foreach (var schedule in updateDto.Schedule)
                                {
                                    if (schedule.Slot == null)
                                    {
                                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                        context.Response.ContentType = "application/json";
                                        await context.Response.WriteAsync("{\"error\":\"Each schedule must have a slot.\"}");
                                        return;
                                    }
                                    if (schedule.Slot.StartTime > schedule.Slot.EndTime)
                                    {
                                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                        context.Response.ContentType = "application/json";
                                        await context.Response.WriteAsync("{\"error\":\"Slot StartTime must be before EndTime.\"}");
                                        return;
                                    }
                                    if (schedule.Slot.StartTime < updateDto.FromMonth || schedule.Slot.EndTime > updateDto.ToMonth)
                                    {
                                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                        context.Response.ContentType = "application/json";
                                        await context.Response.WriteAsync("{\"error\":\"Slot times must be within FromMonth and ToMonth.\"}");
                                        return;
                                    }
                                }
                            }

                            if (updateDto.Attachments != null && updateDto.Attachments.Count > 4)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"You can upload a maximum of 4 attachments per consultation.\"}");
                                return;
                            }
                            break;
                        case "/api/offline-consultation/add-attachments":
                            // For multipart/form-data, files are in context.Request.Form.Files
                            if (!context.Request.HasFormContentType)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Content-Type must be multipart/form-data\"}");
                                return;
                            }

                            var files = context.Request.Form.Files;
                            if (files == null || files.Count == 0)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"No attachments provided.\"}");
                                return;
                            }

                            if (files.Count > 4)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"You can upload a maximum of 4 attachments per consultation.\"}");
                                return;
                            }

                            foreach (var file in files)
                            {
                                if (file.Length == 0)
                                {
                                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                    context.Response.ContentType = "application/json";
                                    await context.Response.WriteAsync("{\"error\":\"One or more attachments are empty.\"}");
                                    return;
                                }
                                if (file.FileName.Length > systemConfiguration.NameMaxLength ||
                                    file.FileName.Length < systemConfiguration.NameMinLength)
                                {
                                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                    context.Response.ContentType = "application/json";
                                    await context.Response.WriteAsync($"{{\"error\":\"Attachment file name length must be from {systemConfiguration.NameMinLength} to {systemConfiguration.NameMaxLength}\"}}");
                                    return;
                                }
                            }
                            break;
                    }
                }
                if (path.StartsWith("/api/online-consultation"))
                {
                    switch (path)
                    {
                        case "/api/onlineconsultation/create-online-consultation":
                            // For multipart/form-data, files are in context.Request.Form.Files
                            if (!context.Request.HasFormContentType)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Content-Type must be multipart/form-data\"}");
                                return;
                            }

                            var form = context.Request.Form;
                            var files = form.Files;

                            // Required fields
                            var userIdStr = form["UserId"].FirstOrDefault();
                            var consultantIdStr = form["ConsultantId"].FirstOrDefault();
                            var trimesterStr = form["Trimester"].FirstOrDefault();
                            var dateStr = form["Date"].FirstOrDefault();
                            var gestationalWeekStr = form["GestationalWeek"].FirstOrDefault();
                            var summary = form["Summary"].FirstOrDefault();

                            if (string.IsNullOrWhiteSpace(userIdStr) || !Guid.TryParse(userIdStr, out var userId))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"UserId is required and must be a valid GUID.\"}");
                                return;
                            }
                            if (string.IsNullOrWhiteSpace(consultantIdStr) || !Guid.TryParse(consultantIdStr, out var consultantId))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"ConsultantId is required and must be a valid GUID.\"}");
                                return;
                            }
                            if (string.IsNullOrWhiteSpace(trimesterStr) || !int.TryParse(trimesterStr, out var trimester) || trimester < 1 || trimester > 3)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Trimester is required and must be 1, 2, or 3.\"}");
                                return;
                            }
                            if (string.IsNullOrWhiteSpace(dateStr) || !DateTime.TryParse(dateStr, out var date))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Date is required and must be a valid date.\"}");
                                return;
                            }
                            if (date < DateTime.Now.Date)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Date must be today or in the future.\"}");
                                return;
                            }
                            if (string.IsNullOrWhiteSpace(gestationalWeekStr) || !int.TryParse(gestationalWeekStr, out var gestationalWeek) || gestationalWeek < 1 || gestationalWeek > 42)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"GestationalWeek is required and must be between 1 and 42.\"}");
                                return;
                            }
                            if (string.IsNullOrWhiteSpace(summary))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Summary is required.\"}");
                                return;
                            }
                            if (summary.Length > systemConfiguration.DescriptionMaxLength || summary.Length < systemConfiguration.DescriptionMinLength)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync($"{{\"error\":\"Summary length must be from {systemConfiguration.DescriptionMinLength} to {systemConfiguration.DescriptionMaxLength}\"}}");
                                return;
                            }

                            // Optional fields length validation
                            var consultantNote = form["ConsultantNote"].FirstOrDefault();
                            if (!string.IsNullOrWhiteSpace(consultantNote) &&
                                (consultantNote.Length > systemConfiguration.DescriptionMaxLength || consultantNote.Length < systemConfiguration.DescriptionMinLength))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync($"{{\"error\":\"ConsultantNote length must be from {systemConfiguration.DescriptionMinLength} to {systemConfiguration.DescriptionMaxLength}\"}}");
                                return;
                            }
                            var userNote = form["UserNote"].FirstOrDefault();
                            if (!string.IsNullOrWhiteSpace(userNote) &&
                                (userNote.Length > systemConfiguration.DescriptionMaxLength || userNote.Length < systemConfiguration.DescriptionMinLength))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync($"{{\"error\":\"UserNote length must be from {systemConfiguration.DescriptionMinLength} to {systemConfiguration.DescriptionMaxLength}\"}}");
                                return;
                            }
                            var vitalSigns = form["VitalSigns"].FirstOrDefault();
                            if (!string.IsNullOrWhiteSpace(vitalSigns) &&
                                (vitalSigns.Length > systemConfiguration.DescriptionMaxLength || vitalSigns.Length < systemConfiguration.DescriptionMinLength))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync($"{{\"error\":\"VitalSigns length must be from {systemConfiguration.DescriptionMinLength} to {systemConfiguration.DescriptionMaxLength}\"}}");
                                return;
                            }
                            var recommendations = form["Recommendations"].FirstOrDefault();
                            if (!string.IsNullOrWhiteSpace(recommendations) &&
                                (recommendations.Length > systemConfiguration.DescriptionMaxLength || recommendations.Length < systemConfiguration.DescriptionMinLength))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync($"{{\"error\":\"Recommendations length must be from {systemConfiguration.DescriptionMinLength} to {systemConfiguration.DescriptionMaxLength}\"}}");
                                return;
                            }

                            // Attachments validation (optional)
                            if (files != null && files.Count > 4)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"You can upload a maximum of 4 attachments per consultation.\"}");
                                return;
                            }
                            foreach (var file in files)
                            {
                                if (file.Length == 0)
                                {
                                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                    context.Response.ContentType = "application/json";
                                    await context.Response.WriteAsync("{\"error\":\"One or more attachments are empty.\"}");
                                    return;
                                }
                                if (file.FileName.Length > systemConfiguration.NameMaxLength ||
                                    file.FileName.Length < systemConfiguration.NameMinLength)
                                {
                                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                    context.Response.ContentType = "application/json";
                                    await context.Response.WriteAsync($"{{\"error\":\"Attachment file name length must be from {systemConfiguration.NameMinLength} to {systemConfiguration.NameMaxLength}\"}}");
                                    return;
                                }
                                // Optionally, check file type, size, etc.
                            }
                            break;
                        case "/api/onlineconsultation/update-online-consultation":
                            // For multipart/form-data, files are in context.Request.Form.Files
                            if (!context.Request.HasFormContentType)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Content-Type must be multipart/form-data\"}");
                                return;
                            }

                            var updateForm = context.Request.Form;
                            var updateFiles = updateForm.Files;

                            // Required fields
                            var idStr = updateForm["Id"].FirstOrDefault();
                            var trimesterUpStr = updateForm["Trimester"].FirstOrDefault();
                            var dateUpStr = updateForm["Date"].FirstOrDefault();
                            var gestationalWeekUpStr = updateForm["GestationalWeek"].FirstOrDefault();
                            var summaryUp = updateForm["Summary"].FirstOrDefault();

                            if (string.IsNullOrWhiteSpace(idStr) || !Guid.TryParse(idStr, out var id))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Id is required and must be a valid GUID.\"}");
                                return;
                            }
                            if (string.IsNullOrWhiteSpace(trimesterUpStr) || !int.TryParse(trimesterUpStr, out var trimesterUp) || trimesterUp < 1 || trimesterUp > 3)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Trimester is required and must be 1, 2, or 3.\"}");
                                return;
                            }
                            if (string.IsNullOrWhiteSpace(dateUpStr) || !DateTime.TryParse(dateUpStr, out var dateUp))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Date is required and must be a valid date.\"}");
                                return;
                            }
                            if (dateUp < DateTime.Now.Date)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Date must be today or in the future.\"}");
                                return;
                            }
                            if (string.IsNullOrWhiteSpace(gestationalWeekUpStr) || !int.TryParse(gestationalWeekUpStr, out var gestationalWeekUp) || gestationalWeekUp < 1 || gestationalWeekUp > 42)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"GestationalWeek is required and must be between 1 and 42.\"}");
                                return;
                            }
                            if (string.IsNullOrWhiteSpace(summaryUp))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"Summary is required.\"}");
                                return;
                            }
                            if (summaryUp.Length > systemConfiguration.DescriptionMaxLength || summaryUp.Length < systemConfiguration.DescriptionMinLength)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync($"{{\"error\":\"Summary length must be from {systemConfiguration.DescriptionMinLength} to {systemConfiguration.DescriptionMaxLength}\"}}");
                                return;
                            }

                            // Optional fields length validation
                            var consultantNoteUp = updateForm["ConsultantNote"].FirstOrDefault();
                            if (!string.IsNullOrWhiteSpace(consultantNoteUp) &&
                                (consultantNoteUp.Length > systemConfiguration.DescriptionMaxLength || consultantNoteUp.Length < systemConfiguration.DescriptionMinLength))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync($"{{\"error\":\"ConsultantNote length must be from {systemConfiguration.DescriptionMinLength} to {systemConfiguration.DescriptionMaxLength}\"}}");
                                return;
                            }
                            var userNoteUp = updateForm["UserNote"].FirstOrDefault();
                            if (!string.IsNullOrWhiteSpace(userNoteUp) &&
                                (userNoteUp.Length > systemConfiguration.DescriptionMaxLength || userNoteUp.Length < systemConfiguration.DescriptionMinLength))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync($"{{\"error\":\"UserNote length must be from {systemConfiguration.DescriptionMinLength} to {systemConfiguration.DescriptionMaxLength}\"}}");
                                return;
                            }
                            var vitalSignsUp = updateForm["VitalSigns"].FirstOrDefault();
                            if (!string.IsNullOrWhiteSpace(vitalSignsUp) &&
                                (vitalSignsUp.Length > systemConfiguration.DescriptionMaxLength || vitalSignsUp.Length < systemConfiguration.DescriptionMinLength))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync($"{{\"error\":\"VitalSigns length must be from {systemConfiguration.DescriptionMinLength} to {systemConfiguration.DescriptionMaxLength}\"}}");
                                return;
                            }
                            var recommendationsUp = updateForm["Recommendations"].FirstOrDefault();
                            if (!string.IsNullOrWhiteSpace(recommendationsUp) &&
                                (recommendationsUp.Length > systemConfiguration.DescriptionMaxLength || recommendationsUp.Length < systemConfiguration.DescriptionMinLength))
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync($"{{\"error\":\"Recommendations length must be from {systemConfiguration.DescriptionMinLength} to {systemConfiguration.DescriptionMaxLength}\"}}");
                                return;
                            }

                            if (updateFiles != null && updateFiles.Count > 4)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("{\"error\":\"You can upload a maximum of 4 attachments per consultation.\"}");
                                return;
                            }
                            foreach (var file in updateFiles)
                            {
                                if (file.Length == 0)
                                {
                                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                    context.Response.ContentType = "application/json";
                                    await context.Response.WriteAsync("{\"error\":\"One or more attachments are empty.\"}");
                                    return;
                                }
                                if (file.FileName.Length > systemConfiguration.NameMaxLength ||
                                    file.FileName.Length < systemConfiguration.NameMinLength)
                                {
                                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                    context.Response.ContentType = "application/json";
                                    await context.Response.WriteAsync($"{{\"error\":\"Attachment file name length must be from {systemConfiguration.NameMinLength} to {systemConfiguration.NameMaxLength}\"}}");
                                    return;
                                }
                            }
                                if (request.MinAnimalProteinPercentageRequire.HasValue &&
                                    (request.MinAnimalProteinPercentageRequire < 0 || request.MinAnimalProteinPercentageRequire > 100))
                                {
                                    await BadRequest(context, "MinAnimalProteinPercentageRequire must be between 0 and 100");
                                    return;
                                }
                            }
                            break;
                    }
                }
            }

            await next(context);
        }

        private static async Task BadRequest(HttpContext context, string errorMessage)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(new { error = errorMessage }));
        }
    }
}
