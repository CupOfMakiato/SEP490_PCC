using AutoMapper;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Doctor;
using Server.Application.Interfaces;
using Server.Application.Repositories;
using Server.Domain.Entities;
using Server.Domain.Enums;

namespace Server.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IDoctorRepository doctorRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _doctorRepository = doctorRepository;
        }

        public async Task<Result<ViewDoctorDTO>> CreateDoctor(AddDoctorDTO doctor)
        {
            var existingClinic = await _unitOfWork.ClinicRepository.GetClinicByIdAsync(doctor.ClinicId);

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

            if (await _unitOfWork.UserRepository.ExistsAsync(u => u.Email == doctor.Email))
            {
                throw new Exception("User with this email or phone number already exists.");
            }

            var user = new User
            {
                UserName = doctor.UserName,
                Email = doctor.Email,
                Balance = 0,
                PhoneNumber = doctor.PhoneNumber,
                Status = StatusEnums.Pending,
                IsStaff = false,
                RoleId = 7,
                CreationDate = DateTime.Now,
                OtpExpiryTime = DateTime.UtcNow.AddMinutes(10)
            };

            await _unitOfWork.UserRepository.AddAsync(user);

            var doctorMapper = _mapper.Map<Doctor>(doctor);

            doctorMapper.UserId = user.Id;

            doctorMapper.ClinicId = doctor.ClinicId;

            await _doctorRepository.AddAsync(doctorMapper);

            var result = await _unitOfWork.SaveChangeAsync();

            return new Result<ViewDoctorDTO>
            {
                Error = result > 0 ? 0 : 1,
                Message = result > 0 ? "Add new doctor successfully" : "Add new doctor failed",
                Data = _mapper.Map<ViewDoctorDTO>(doctorMapper)
            };
        }

        public async Task<Result<List<ViewDoctorDTO>>> GetAllDoctorsAsync()
        {
            var dotocrs = await _doctorRepository.GetAllDoctorsAsync();

            return new Result<List<ViewDoctorDTO>>
            {
                Error = 0,
                Message = "Get all doctors successfully",
                Data = _mapper.Map<List<ViewDoctorDTO>>(dotocrs)
            };
        }

        public async Task<Result<ViewDoctorDTO>> GetDoctorByIdAsync(Guid doctorId)
        {
            var doctor = await _doctorRepository.GetDoctorByIdAsync(doctorId);

            if (doctor == null)
            {
                return new Result<ViewDoctorDTO>
                {
                    Error = 1,
                    Message = "Doctor not found",
                    Data = null
                };
            }

            var clinic = await _unitOfWork.ClinicRepository.GetClinicByIdAsync(doctor.ClinicId);

            if (clinic == null)
            {
                return new Result<ViewDoctorDTO>
                {
                    Error = 1,
                    Message = "Didn't find any clinic, please try again!",
                    Data = null
                };
            }

            if (!clinic.IsActive)
            {
                return new Result<ViewDoctorDTO>
                {
                    Error = 1,
                    Message = "Clinic is not active",
                    Data = null
                };
            }

            var doctorMapper = _mapper.Map<ViewDoctorDTO>(doctor);

            return new Result<ViewDoctorDTO>
            {
                Error = 0,
                Message = "View doctor successfully",
                Data = doctorMapper
            };
        }

        public async Task<Result<bool>> SoftDeleteDoctor(Guid doctorId)
        {
            var doctor = await _doctorRepository.GetDoctorByIdAsync(doctorId);

            if (doctor == null)
            {
                return new Result<bool>
                {
                    Error = 1,
                    Message = "Doctor not found",
                    Data = false
                };
            }

            var clinic = await _unitOfWork.ClinicRepository.GetClinicByIdAsync(doctor.ClinicId);

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
                    Message = "Clinic is not active, cannot remove doctor.",
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
            var doctorObj = await _doctorRepository.GetDoctorByIdAsync(doctor.Id);

            if (doctorObj == null)
            {
                return new Result<ViewDoctorDTO>
                {
                    Error = 1,
                    Message = "Doctor not found",
                    Data = null
                };
            }

            var clinic = await _unitOfWork.ClinicRepository.GetClinicByIdAsync(doctorObj.ClinicId);

            if (clinic == null)
            {
                return new Result<ViewDoctorDTO>
                {
                    Error = 1,
                    Message = "Didn't find any clinic, please try again!",
                    Data = null
                };
            }

            if (!clinic.IsActive)
            {
                return new Result<ViewDoctorDTO>
                {
                    Error = 1,
                    Message = "Clinic is not active",
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
