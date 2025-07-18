using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Consultation;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class ConsultationService : IConsultationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConsultationRepository _consultationRepository;

        public ConsultationService(IUnitOfWork unitOfWork, IMapper mapper, IConsultationRepository consultationRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _consultationRepository = consultationRepository;
        }

        public async Task<Result<ViewConsultationDTO>> CreateConsultation(AddConsultationDTO consultation)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(consultation.UserId);

            if (user is null)
            {
                return new Result<ViewConsultationDTO>
                {
                    Error = 1,
                    Message = "User not found",
                    Data = null
                };
            }

            var consultant = await _unitOfWork.ConsultantRepository.GetByIdAsync(consultation.ConsultantId);

            if (consultant is null)
            {
                return new Result<ViewConsultationDTO>
                {
                    Error = 1,
                    Message = "Consultant not found",
                    Data = null
                };
            }

            var clinic = await _unitOfWork.ClinicRepository.GetByIdAsync(consultation.ClinicId);

            if (clinic is null)
            {
                return new Result<ViewConsultationDTO>
                {
                    Error = 1,
                    Message = "Clinic not found",
                    Data = null
                };
            }

            var existingUser = await _consultationRepository.GetConsultationByUserIdAsync(consultation.UserId);

            if (existingUser != null)
            {
                return new Result<ViewConsultationDTO>
                {
                    Error = 1,
                    Message = "User already has a consultation",
                    Data = null
                };
            }

            var consultationMapper = _mapper.Map<Consultation>(consultation);

            await _consultationRepository.AddAsync(consultationMapper);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<ViewConsultationDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Add new consultation successfully" : "Add new consultation fail",
                Data = _mapper.Map<ViewConsultationDTO>(consultationMapper)
            };
        }

        public async Task<Result<List<ViewConsultationDTO>>> GetConsultationByConsultantIdAsync(Guid consultantId)
        {
            var result = _mapper.Map<List<ViewConsultationDTO>>
                (await _consultationRepository.GetConsultationByConsultantIdAsync(consultantId));

            return new Result<List<ViewConsultationDTO>>
            {
                Error = 0,
                Message = "View consultation successfully",
                Data = result
            };
        }

        public async Task<Result<ViewConsultationDTO>> GetConsultationByIdAsync(Guid consultationId)
        {
            var result = _mapper.Map<ViewConsultationDTO>(await _consultationRepository.GetConsultationByIdAsync(consultationId));

            return new Result<ViewConsultationDTO>
            {
                Error = 0,
                Message = "View consultation successfully",
                Data = result
            };
        }

        public async Task<Result<bool>> SoftDeleteConsultation(Guid consultationId)
        {
            var consultation = await _consultationRepository.GetByIdAsync(consultationId);

            if (consultation == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any consultation, please try again!",
                    Data = false
                };
            }

            _consultationRepository.SoftRemove(consultation);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Remove consultation successfully" : "Remove consultation fail",
                Data = true
            };
        }

        public async Task<Result<ViewConsultationDTO>> UpdateConsultatation(UpdateConsultationDTO consultation)
        {
            var consultationObj = await _consultationRepository.GetByIdAsync(consultation.Id);

            if (consultationObj is null)
            {
                return new Result<ViewConsultationDTO>
                {
                    Error = 1,
                    Message = "Didn't find any consultation, please try again!",
                    Data = _mapper.Map<ViewConsultationDTO>(consultationObj)
                };
            }

            _mapper.Map(consultation, consultationObj);

            _consultationRepository.Update(consultationObj);

            var result = _unitOfWork.SaveChangeAsync().Result;

            return new Result<ViewConsultationDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Update consultation successfully" : "Update consultation fail",
                Data = _mapper.Map<ViewConsultationDTO>(consultationObj)
            };
        }
    }
}
