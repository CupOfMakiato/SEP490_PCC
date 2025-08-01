using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Feedback;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IFeedbackRepository feedbackRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _feedbackRepository = feedbackRepository;
        }

        public async Task<Result<ViewFeedbackDTO>> CreateFeedbackAsync(AddFeedbackDTO feedback)
        {
            var user = await _unitOfWork.UserRepository
                .GetByIdAsync(feedback.UserId);

            if (user == null)
            {
                return new Result<ViewFeedbackDTO>
                {
                    Error = 1,
                    Message = "Didn't find any user, please try again!",
                    Data = null
                };
            }

            var clinic = await _unitOfWork.ClinicRepository
                .GetClinicByIdAsync(feedback.ClinicId);

            if (clinic == null)
            {
                return new Result<ViewFeedbackDTO>
                {
                    Error = 1,
                    Message = "Didn't find any clinic, please try again!",
                    Data = null
                };
            }

            if (!clinic.IsActive)
            {
                return new Result<ViewFeedbackDTO>
                {
                    Error = 1,
                    Message = "Clinic is not active, cannot create feedback.",
                    Data = null
                };
            }

            var feedbackMapper = _mapper.Map<Feedback>(feedback);

            await _feedbackRepository.AddAsync(feedbackMapper);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<ViewFeedbackDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Create feedback successfully" : "Create feedback fail",
                Data = _mapper.Map<ViewFeedbackDTO>(feedbackMapper)
            };
        }

        public async Task<Result<ViewFeedbackDTO>> GetFeedbackByIdAsync(Guid feedbackId)
        {
            var feedback = await _feedbackRepository
                .GetFeedbackByIdAsync(feedbackId);

            if (feedback == null)
            {
                return new Result<ViewFeedbackDTO>
                {
                    Error = 1,
                    Message = "Didn't find any feedback, please try again!",
                    Data = null
                };
            }

            var clinic = await _unitOfWork.ClinicRepository
                .GetClinicByIdAsync(feedback.ClinicId);

            if (clinic == null)
            {
                return new Result<ViewFeedbackDTO>
                {
                    Error = 1,
                    Message = "Didn't find any clinic, please try again!",
                    Data = null
                };
            }

            if (!clinic.IsActive)
            {
                return new Result<ViewFeedbackDTO>
                {
                    Error = 1,
                    Message = "Clinic is not active",
                    Data = null
                };
            }

            var result = _mapper.Map<ViewFeedbackDTO>(feedback);

            return new Result<ViewFeedbackDTO>
            {
                Error = 0,
                Message = "Get feedback successfully",
                Data = result
            };
        }

        public async Task<Result<bool>> SoftDeleteFeedbackAsync(Guid feedbackId)
        {
            var feedback = await _feedbackRepository
                .GetFeedbackByIdAsync(feedbackId);

            if (feedback == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any feedback, please try again!",
                    Data = false
                };
            }

            var clinic = await _unitOfWork.ClinicRepository
                .GetClinicByIdAsync(feedback.ClinicId);

            if (clinic == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Didn't find any clinic, please try again!",
                    Data = false
                };
            }

            if (!clinic.IsActive)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Clinic is not active, cannot delete feedback.",
                    Data = false
                };
            }

            _feedbackRepository.SoftRemove(feedback);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Delete feedback successfully" : "Delete feedback fail",
                Data = result > 0
            };
        }

        public async Task<Result<ViewFeedbackDTO>> UpdateFeedbackAsync(UpdateFeedbackDTO feedback)
        {
            var feedbackObj = await _feedbackRepository
                .GetFeedbackByIdAsync(feedback.Id);

            if (feedbackObj == null)
            {
                return new Result<ViewFeedbackDTO>
                {
                    Error = 1,
                    Message = "Didn't find any feedback, please try again!",
                    Data = null
                };
            }

            var clinic = await _unitOfWork.ClinicRepository
                .GetClinicByIdAsync(feedbackObj.ClinicId);

            if (clinic == null)
            {
                return new Result<ViewFeedbackDTO>
                {
                    Error = 1,
                    Message = "Didn't find any clinic, please try again!",
                    Data = null
                };
            }

            if (!clinic.IsActive)
            {
                return new Result<ViewFeedbackDTO>
                {
                    Error = 1,
                    Message = "Clinic is not active, cannot update feedback.",
                    Data = null
                };
            }

            _mapper.Map(feedback, feedbackObj);

            _feedbackRepository.Update(feedbackObj);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<ViewFeedbackDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Update feedback successfully" : "Update feedback fail",
                Data = _mapper.Map<ViewFeedbackDTO>(feedbackObj)
            };
        }
    }
}
