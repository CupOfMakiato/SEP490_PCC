using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.OnlineConsultation;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class OnlineConsultationService : IOnlineConsultationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOnlineConsultationRepository _onlineConsultationRepository;

        public OnlineConsultationService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IOnlineConsultationRepository onlineConsultationRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _onlineConsultationRepository = onlineConsultationRepository;
        }

        public async Task<Result<ViewOnlineConsultationDTO>> CreateOnlineConsultation(AddOnlineConsultationDTO onlineConsultation)
        {
            var user = await _unitOfWork.UserRepository
                .GetByIdAsync(onlineConsultation.UserId);

            if (user == null)
            {
                return new Result<ViewOnlineConsultationDTO>
                {
                    Error = 1,
                    Message = "Didn't find any user, please try again!",
                    Data = null
                };
            }

            var consultant = await _unitOfWork.ConsultantRepository
                .GetConsultantByIdAsync(onlineConsultation.ConsultantId);

            if (consultant == null)
            {
                return new Result<ViewOnlineConsultationDTO>
                {
                    Error = 1,
                    Message = "Didn't find any consultant, please try again!",
                    Data = null
                };
            }

            var onlineConsultationMapper = _mapper.Map<OnlineConsultation>(onlineConsultation);

            await _onlineConsultationRepository.AddAsync(onlineConsultationMapper);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<ViewOnlineConsultationDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Create online consultation successfully" : "Create online consultation fail",
                Data = _mapper.Map<ViewOnlineConsultationDTO>(onlineConsultationMapper)
            };
        }

        public async Task<Result<ViewOnlineConsultationDTO>> GetOnlineConsultationByIdAsync(Guid onlineConsultationId)
        {
            var result = _mapper.Map<ViewOnlineConsultationDTO>(
                await _onlineConsultationRepository.GetOnlineConsultationByIdAsync(onlineConsultationId));

            return new Result<ViewOnlineConsultationDTO>
            {
                Error = 0,
                Message = "View online consultation successfully",
                Data = result
            };
        }

        public async Task<Result<List<ViewOnlineConsultationDTO>>> GetOnlineConsultationsByConsultantIdAsync(Guid consultantId)
        {
            var result = _mapper.Map<List<ViewOnlineConsultationDTO>>(
                await _onlineConsultationRepository.GetOnlineConsultationsByConsultantIdAsync(consultantId));

            return new Result<List<ViewOnlineConsultationDTO>>
            {
                Error = 0,
                Message = "View online consultation successfully",
                Data = result
            };
        }

        public async Task<Result<List<ViewOnlineConsultationDTO>>> GetOnlineConsultationsByUserIdAsync(Guid userId)
        {
            var result = _mapper.Map<List<ViewOnlineConsultationDTO>>(
                await _onlineConsultationRepository.GetOnlineConsultationsByUserIdAsync(userId));

            return new Result<List<ViewOnlineConsultationDTO>>
            {
                Error = 0,
                Message = "View online consultation successfully",
                Data = result
            };
        }

        public async Task<Result<bool>> SoftDeleteOnlineConsultation(Guid onlineConsultationId)
        {
            var onlineConsultation = await _onlineConsultationRepository.GetOnlineConsultationByIdAsync(onlineConsultationId);

            if (onlineConsultation == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any online consultation, please try again!",
                    Data = false
                };
            }

            _onlineConsultationRepository.SoftRemove(onlineConsultation);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Remove online consultation successfully" : "Remove clinic fail",
                Data = true
            };
        }

        public async Task<Result<ViewOnlineConsultationDTO>> UpdateOnlineConsultation(UpdateOnlineConsultationDTO onlineConsultation)
        {
            var onlineConsultationObj = await _onlineConsultationRepository.GetOnlineConsultationByIdAsync(onlineConsultation.Id);

            if (onlineConsultationObj is null)
            {
                return new Result<ViewOnlineConsultationDTO>
                {
                    Error = 1,
                    Message = "Didn't find any online consultation, please try again!",
                    Data = null
                };
            }

            _mapper.Map(onlineConsultation, onlineConsultationObj);

            _onlineConsultationRepository.Update(onlineConsultationObj);

            var result = _unitOfWork.SaveChangeAsync().Result;

            return new Result<ViewOnlineConsultationDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Update online consultation successfully" : "Update online consultation fail",
                Data = _mapper.Map<ViewOnlineConsultationDTO>(onlineConsultationObj)
            };
        }
    }
}
