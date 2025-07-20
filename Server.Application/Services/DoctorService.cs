using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Doctor;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;

namespace Server.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IUnitOfWork unitOfWork, IMapper mapper, IDoctorRepository doctorRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _doctorRepository = doctorRepository;
        }

        public async Task<Result<ViewDoctorDTO>> CreateDoctor(AddDoctorDTO doctor)
        {
            var existingClinic = await _unitOfWork.ClinicRepository.GetByIdAsync(doctor.ClinicId);

            if (existingClinic == null)
            {
                return new Result<ViewDoctorDTO>
                {
                    Error = 1,
                    Message = "Didn't find any clinic, please try again!",
                    Data = null
                };
            }

            if (!existingClinic.IsActive)
            {
                return new Result<ViewDoctorDTO>
                {
                    Error = 1,
                    Message = "Clinic is not active, cannot create",
                    Data = null
                };
            }

            var doctorMapper = _mapper.Map<Doctor>(doctor);

            await _doctorRepository.AddAsync(doctorMapper);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<ViewDoctorDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Add new doctor successfully" : "Add new doctor failed",
                Data = _mapper.Map<ViewDoctorDTO>(doctorMapper)
            };
        }

        public async Task<Result<ViewDoctorDTO>> GetDoctorByIdAsync(Guid doctorId)
        {
            var doctorMapper = _mapper.Map<ViewDoctorDTO>(
                await _doctorRepository.GetDoctorByIdAsync(doctorId));

            return new Result<ViewDoctorDTO>
            {
                Error = doctorMapper is null ? 1 : 0,
                Message = doctorMapper is null ? "Doctor not found" : "View doctor successfully",
                Data = doctorMapper
            };
        }

        public async Task<Result<bool>> SoftDeleteDoctor(Guid doctorId)
        {
            var doctor = await _doctorRepository.GetByIdAsync(doctorId);

            if (doctor == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Doctor not found",
                    Data = false
                };
            }

            _doctorRepository.SoftRemove(doctor);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<bool>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Delete doctor successfully" : "Delete doctor failed",
                Data = result > 0
            };
        }

        public async Task<Result<ViewDoctorDTO>> UpdateDoctor(UpdateDoctorDTO doctor)
        {
            var doctorObj = await _doctorRepository.GetByIdAsync(doctor.Id);

            if (doctorObj == null)
            {
                return new Result<ViewDoctorDTO>
                {
                    Error = 1,
                    Message = "Doctor not found",
                    Data = null
                };
            }

            _mapper.Map(doctor, doctorObj);

            _doctorRepository.Update(doctorObj);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<ViewDoctorDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Update doctor successfully" : "Update doctor failed",
                Data = _mapper.Map<ViewDoctorDTO>(doctorObj)
            };
        }
    }
}
