using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Clinic;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class ClinicService : IClinicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClinicRepository _clinicRepository;

        public ClinicService(IUnitOfWork unitOfWork, IMapper mapper, IClinicRepository clinicRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _clinicRepository = clinicRepository;
        }

        public async Task<Result<object>> CreateClinic(AddClinicDTO clinic)
        {
            var clinicMapper = _mapper.Map<Clinic>(clinic);

            await _unitOfWork.ClinicRepository.AddAsync(clinicMapper);
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Add new clinic successfully" : "Add new clinic fail",
                Data = null
            };
        }

        public async Task<Result<ViewClinicDTO>> GetClinicByIdAsync(Guid clinicId)
        {
            var result = _mapper.Map<ViewClinicDTO>(await _clinicRepository.GetClinicByIdAsync(clinicId));

            return new Result<ViewClinicDTO>
            {
                Error = 0,
                Message = "View clinic successfully",
                Data = result
            };
        }

        public async Task<Result<List<ViewClinicDTO>>> GetClinicByNameAsync(string name)
        {
            var result = _mapper.Map<List<ViewClinicDTO>>(await _clinicRepository.GetClinicByNameAsync(name));

            return new Result<List<ViewClinicDTO>>
            {
                Error = 0,
                Message = "View clinic by name successfully",
                Data = result
            };
        }

        public async Task<Result<List<ViewClinicDTO>>> GetClinicsAsync()
        {
            var result = _mapper.Map<List<ViewClinicDTO>>(await _clinicRepository.GetClinicsAsync());

            return new Result<List<ViewClinicDTO>>
            {
                Error = 0,
                Message = "View all clinics successfully",
                Data = result
            };
        }

        public async Task<Result<object>> SoftDeleteClinic(Guid clinicId)
        {
            var clinic = await _unitOfWork.ClinicRepository.GetByIdAsync(clinicId);

            if (clinic == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Didn't find any clinic, please try again!",
                    Data = null
                };
            }

            _clinicRepository.SoftRemove(clinic);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Remove clinic successfully" : "Remove clinic fail",
                Data = result
            };
        }

        public async Task<Result<object>> UpdateClinic(UpdateClinicDTO clinic)
        {
            var clinicObj = await _unitOfWork.ClinicRepository.GetByIdAsync(clinic.Id);

            if (clinicObj is null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Didn't find any clinic, please try again!",
                    Data = null
                };
            }

            _mapper.Map(clinic, clinicObj);

            _unitOfWork.ClinicRepository.Update(clinicObj);

            var result = _unitOfWork.SaveChangeAsync().Result;

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Update clinic successfully" : "Update clinic fail",
                Data = null
            };
        }
    }
}
