using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Consultant;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class ConsultantService : IConsultantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConsultantRepository _consultantRepository;

        public ConsultantService(IUnitOfWork unitOfWork, IMapper mapper, IConsultantRepository consultantRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _consultantRepository = consultantRepository;
        }

        public async Task<Result<object>> CreateConsultant(AddConsultantDTO consultant)
        {
            var clinic = await _unitOfWork.ClinicRepository.GetByIdAsync(consultant.ClinicId);

            if (clinic == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Clinic not found, please try again!",
                    Data = null
                };
            }

            var user = new User
            {
                //properties...
            };

            await _unitOfWork.UserRepository.AddAsync(user);

            var consultantMapper = _mapper.Map<Consultant>(consultant);

            consultantMapper.UserId = user.Id;
            consultantMapper.ClinicId = clinic.Id;

            await _unitOfWork.ConsultantRepository.AddAsync(consultantMapper);
            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Add new consultant successfully" : "Add new consultant fail",
                Data = null
            };
        }

        public async Task<Result<ViewConsultantDTO>> GetConsultantByIdAsync(Guid consultantId)
        {
            var result = _mapper.Map<ViewConsultantDTO>(await _consultantRepository.GetConsultantByIdAsync(consultantId));

            return new Result<ViewConsultantDTO>
            {
                Error = 0,
                Message = "View consultant successfully",
                Data = result
            };
        }

        public async Task<Result<List<ViewConsultantDTO>>> GetConsultantByNameAsync(string name)
        {
            var result = _mapper.Map<List<ViewConsultantDTO>>(await _consultantRepository.GetConsultantByNameAsync(name));

            return new Result<List<ViewConsultantDTO>>
            {
                Error = 0,
                Message = "View consultant by name successfully",
                Data = result
            };
        }

        public async Task<Result<List<ViewConsultantDTO>>> GetConsultantsAsync()
        {
            var result = _mapper.Map<List<ViewConsultantDTO>>(await _consultantRepository.GetConsultantsAsync());

            return new Result<List<ViewConsultantDTO>>
            {
                Error = 0,
                Message = "View all consultants successfully",
                Data = result
            };
        }

        public async Task<Result<object>> SoftDeleteConsultant(Guid consultantId)
        {
            var consultant = await _unitOfWork.ConsultantRepository.GetByIdAsync(consultantId);

            if (consultant == null)
            {
                return new Result<object>
                {
                    Error = 1,
                    Message = "Didn't find any consultant, please try again!",
                    Data = null
                };
            }

            _consultantRepository.SoftRemove(consultant);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<object>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Remove consultant successfully" : "Remove consultant fail",
                Data = result
            };
        }

        public async Task<Result<object>> UpdateConsultant(UpdateConsultantDTO consultant)
        {
            //var consultantObj = await _unitOfWork.ConsultantRepository.GetByIdAsync(consultant.Id);

            //if (consultantObj is null)
            //{
            //    return new Result<object>
            //    {
            //        Error = 1,
            //        Message = "Didn't find any consultant, please try again!",
            //        Data = null
            //    };
            //}

            //_mapper.Map(consultant, consultantObj);

            //_unitOfWork.ConsultantRepository.Update(consultantObj);

            //var result = _unitOfWork.SaveChangeAsync().Result;

            //return new Result<object>
            //{
            //    Error = result > 0 ? 0 : 1,
            //    Message = result > 0 ? "Update consultant successfully" : "Update consultant fail",
            //    Data = null
            //};
            return new Result<object>
            {
                Error = 1,
                Message = "Update consultant functionality is not implemented yet!",
                Data = null
            };
        }
    }
}
