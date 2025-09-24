using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Macs;
using Server.Domain.Entities;
using System.Security.Cryptography;
using System.Text;

namespace Server.Infrastructure.Data
{
    public static class ConsultationSeedData
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Clinic User
            var clinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = clinicUserId,
                UserName = "Tu Du Hospital",
                Email = "web.admin@tudu.com.vn",
                PhoneNumber = "(028) 3952.6568",
                Password = HashPassword("clinic#1"),
                Balance = 0,
                RoleId = 5, // Assuming 5 is the role ID for clinics
                CreationDate = new DateTime(2025, 09, 05),
                Address = "284 Cong Quynh, Ben Thanh Ward, District 1, Ho Chi Minh City",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Clinic
            var clinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = clinicId,
                UserId = clinicUserId,
                Address = "284 Cong Quynh, Ben Thanh Ward, District 1, Ho Chi Minh City",
                Description = "Tu Du Hospital is the leading hospital in Obstetrics - Gynecology and infertility treatment in the South of Vietnam. It is tasked with supervising, transferring techniques to many provinces, and providing medical examination, advanced interventions in obstetrics and gynecology, as well as assisted reproduction.",
                IsInsuranceAccepted = true,
                Specializations = "Obstetrics (pregnancy, delivery, neonatal care);Gynecology (gynecological surgery, endoscopy);Infertility - Assisted Reproduction (IVF, artificial insemination);Fetal interventions;Gynecologic and breast cancer screening;Family planning",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Doctor Users
            var doctorUser1Id = Guid.NewGuid();
            var doctorUser2Id = Guid.NewGuid();
            var doctorUser3Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = doctorUser1Id,
                    UserName = "Dang Thi Tran Hanh",
                    Email = "dang.tran.hanh@tudu.com.vn",
                    PhoneNumber = "+84-28-3952-6568",
                    Password = HashPassword("doctor#1"),
                    Address = "Emergency/Obstetrics Department, Tu Du Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7, // Assuming 7 is the role ID for doctors
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = doctorUser2Id,
                    UserName = "Le Van Minh",
                    Email = "le.minh@tudu.com.vn",
                    PhoneNumber = "+84-914-111-222",
                    Password = HashPassword("doctor#2"),
                    Address = "Surgery Department - Tu Du Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7, // Assuming 7 is the role ID for doctors
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = doctorUser3Id,
                    UserName = "Phan Thi Huong",
                    Email = "phan.huong@tudu.com.vn",
                    PhoneNumber = "+84-915-333-444",
                    Password = HashPassword("doctor#3"),
                    Address = "Assisted Reproduction Unit, Tu Du Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7, // Assuming 7 is the role ID for doctors
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Doctors
            var doctor1Id = Guid.NewGuid();
            var doctor2Id = Guid.NewGuid();
            var doctor3Id = Guid.NewGuid();

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = doctor1Id,
                    UserId = doctorUser1Id,
                    ClinicId = clinicId,
                    Gender = "Female",
                    Specialization = "Obstetrics and Gynecology, Emergency Obstetrics",
                    Certificate = "Specialist Doctor Level I in Obstetrics and Gynecology",
                    ExperienceYear = 25,
                    WorkPosition = "Head of Emergency Department",
                    Description = "Dr. Dang Thi Tran Hanh is currently Head of the Emergency Department at Tu Du Hospital.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = doctor2Id,
                    UserId = doctorUser2Id,
                    ClinicId = clinicId,
                    Gender = "Male",
                    Specialization = "Gynecological surgery, endoscopy",
                    Certificate = "Specialist Doctor Level II",
                    ExperienceYear = 12,
                    WorkPosition = "Chief Surgeon",
                    Description = "Doctor specialized in laparoscopic gynecological surgery, involved in many complex surgeries.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = doctor3Id,
                    UserId = doctorUser3Id,
                    ClinicId = clinicId,
                    Gender = "Female",
                    Specialization = "Infertility - IVF",
                    Certificate = "Assisted Reproduction Specialist",
                    ExperienceYear = 15,
                    WorkPosition = "IVF Team Leader",
                    Description = "Participates in IVF treatment and assisted reproduction interventions.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Consultants
            var consultantUser1Id = Guid.NewGuid();
            var consultantUser2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = consultantUser1Id,
                    UserName = "Huynh Thi Anh",
                    Email = "huynh.anh@tudu.com.vn",
                    PhoneNumber = "+84-912-345-678",
                    Password = HashPassword("consultant#1"),
                    Address = "Outpatient Department, Tu Du Hospital, 284 Cong Quynh, District 1",
                    RoleId = 6, // Assuming 6 is the role ID for consultants
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = consultantUser2Id,
                    UserName = "Ngo Thi Lan",
                    Email = "ngo.lan@tudu.com.vn",
                    PhoneNumber = "+84-913-222-333",
                    Password = HashPassword("consultant#2"),
                    Address = "Maternal Nutrition Counseling Center, Tu Du Hospital",
                    RoleId = 6, // Assuming 6 is the role ID for consultants
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            var consultant1Id = Guid.NewGuid();
            var consultant2Id = Guid.NewGuid();

            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = consultant1Id,
                    UserId = consultantUser1Id,
                    ClinicId = clinicId,
                    Specialization = "Prenatal check-up counseling, cervical cancer screening",
                    Certificate = "Master of Obstetrics and Gynecology",
                    Gender = "Female",
                    ExperienceYears = 10,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = consultant2Id,
                    UserId = consultantUser2Id,
                    ClinicId = clinicId,
                    Specialization = "Maternal nutrition counseling",
                    Certificate = "Bachelor of Clinical Nutrition",
                    Gender = "Female",
                    ExperienceYears = 6,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                }
            );

            // Seed Feedbacks
            var feedback1Id = Guid.NewGuid();
            var feedback2Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = feedback1Id,
                    ClinicId = clinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Good professional service, but waiting time is long due to high patient volume.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = feedback2Id,
                    ClinicId = clinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 10,
                    Comment = "Experienced doctors, professional examination process.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );


            // Hung Vuong Hospital
            // Seed Hung Vuong Clinic User
            var hvClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = hvClinicUserId,
                UserName = "Hung Vuong Hospital",
                Email = "bv.hungvuong@tphcm.gov.vn",
                PhoneNumber = "(028) 3855 8532",
                Password = HashPassword("clinic#2"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "128 Hong Bang, Ward 12, District 5, Ho Chi Minh City, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Hung Vuong Clinic
            var hvClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = hvClinicId,
                UserId = hvClinicUserId,
                Address = "128 Hong Bang, Ward 12, District 5, Ho Chi Minh City, Vietnam",
                Description = "A Central-level, Category I hospital specialized in Obstetrics – Gynecology. Around 900 beds (including 100 neonatal beds), with more than 1,300 staff across clinical, paraclinical, and functional departments. Each year, the hospital handles tens of thousands of births and thousands of surgeries.",
                IsInsuranceAccepted = true,
                Specializations = "Obstetrics (pregnancy, delivery);Gynecology (including gynecological surgery);Infertility – Assisted reproduction;Antenatal & premium maternity care;Breast clinic – breast cancer screening;Pelvic floor / Urogynecology;Neonatal examination & care",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Hung Vuong Doctor Users
            var hvDoctorUser1Id = Guid.NewGuid();
            var hvDoctorUser2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = hvDoctorUser1Id,
                    UserName = "Nguyen Thi Hien",
                    Email = "nguyen.thi.hien@bvhungvuong.vn",
                    PhoneNumber = "+84-28-3855-8532",
                    Password = HashPassword("doctor#4"),
                    Address = "Deputy Head of Pediatrics Department, Hung Vuong Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = hvDoctorUser2Id,
                    UserName = "Phung Chi Nhan",
                    Email = "phung.chinhan@bvhungvuong.vn",
                    PhoneNumber = "+84-28-3855 8532",
                    Password = HashPassword("doctor#5"),
                    Address = "Emergency & ICU Department, Hung Vuong Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Hung Vuong Doctors
            var hvDoctor1Id = Guid.NewGuid();
            var hvDoctor2Id = Guid.NewGuid();

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = hvDoctor1Id,
                    UserId = hvDoctorUser1Id,
                    ClinicId = hvClinicId,
                    Gender = "Female",
                    Specialization = "Pediatrics",
                    Certificate = "Specialist Level I",
                    ExperienceYear = 15,
                    WorkPosition = "Deputy Head of Department",
                    Description = "Deputy Head of Pediatrics, participating in pediatric examination and treatment.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = hvDoctor2Id,
                    UserId = hvDoctorUser2Id,
                    ClinicId = hvClinicId,
                    Gender = "Male",
                    Specialization = "Emergency & Intensive Care",
                    Certificate = "Specialist Level I",
                    ExperienceYear = 10,
                    WorkPosition = "Doctor",
                    Description = "Doctor at Emergency & ICU Department.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Hung Vuong Consultant User
            var hvConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = hvConsultantUserId,
                UserName = "Assoc. Prof. Dr. Huynh Nguyen Khanh Trang",
                Email = "huynh.khanhtrang@bvhungvuong.vn",
                PhoneNumber = "+84-28-3855-8532",
                Password = HashPassword("consultant#3"),
                Address = "Obstetric Pathology Department, Hung Vuong Hospital",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Hung Vuong Consultant
            var hvConsultantId = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = hvConsultantId,
                UserId = hvConsultantUserId,
                ClinicId = hvClinicId,
                Specialization = "Obstetrics – High-risk pregnancy",
                Certificate = "Associate Professor, PhD, Specialist Level II",
                Gender = "Female",
                ExperienceYears = 30,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Hung Vuong Feedbacks
            var hvFeedback1Id = Guid.NewGuid();
            var hvFeedback2Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = hvFeedback1Id,
                    ClinicId = hvClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Good medical expertise, full facilities, but the waiting time is quite long.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = hvFeedback2Id,
                    ClinicId = hvClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Health insurance service accepted smoothly, friendly staff.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );



            // University Medical Center HCMC
            // Seed UMC Clinic User
            var dhydClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = dhydClinicUserId,
                UserName = "University Medical Center Ho Chi Minh City",
                Email = "bvdhyd@umc.edu.vn",
                PhoneNumber = "(84.28) 3855 4269",
                Password = HashPassword("clinic#3"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "Campus 1: 215 Hong Bang, Ward 11, District 5, HCMC; Campus 2: 201 Nguyen Chi Thanh, Cho Lon Ward, District 5, HCMC; Campus 3: 221B Hoang Van Thu, Phu Nhuan Ward, HCMC",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed UMC Clinic
            var dhydClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = dhydClinicId,
                UserId = dhydClinicUserId,
                Address = "Campus 1: 215 Hong Bang, Ward 11, District 5, HCMC; Campus 2: 201 Nguyen Chi Thanh, Cho Lon Ward, District 5, HCMC; Campus 3: 221B Hoang Van Thu, Phu Nhuan Ward, HCMC",
                Description = "University Medical Center HCMC is a multidisciplinary hospital combining healthcare, teaching, and scientific research. With 3 main campuses, it provides outpatient, inpatient, surgical, and specialized services.",
                IsInsuranceAccepted = true,
                Specializations = "General Surgery;Internal Medicine;Diagnostic Imaging;Obstetrics & Gynecology;Pediatrics;Cardiology;Orthopedics;Plastic & Aesthetic Surgery;ENT;Rheumatology;Dermatology;Expert consultations at specialty clinics",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed UMC Doctor Users
            var dhydDoctorUser1Id = Guid.NewGuid();
            var dhydDoctorUser2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = dhydDoctorUser1Id,
                    UserName = "Assoc. Prof. Dr. Vo Tan Duc",
                    Email = "vo.tan.duc@umc.edu.vn",
                    PhoneNumber = "+84-28-3855 4269",
                    Password = HashPassword("doctor#6"),
                    Address = "Diagnostic Imaging Department, UMC Campus 1",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = dhydDoctorUser2Id,
                    UserName = "Specialist II Tran Huu Loi",
                    Email = "tran.huu.loi@umc.edu.vn",
                    PhoneNumber = "+84-28-3855 4269",
                    Password = HashPassword("doctor#7"),
                    Address = "General Internal Medicine Clinic, UMC Campus 1",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed UMC Doctors
            var dhydDoctor1Id = Guid.NewGuid();
            var dhydDoctor2Id = Guid.NewGuid();

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = dhydDoctor1Id,
                    UserId = dhydDoctorUser1Id,
                    ClinicId = dhydClinicId,
                    Gender = "Male",
                    Specialization = "Diagnostic Imaging",
                    Certificate = "Assoc. Prof., PhD, MD",
                    ExperienceYear = 25,
                    WorkPosition = "Head of Diagnostic Imaging Department",
                    Description = "Head of Diagnostic Imaging Department; author of multiple scientific works and lecturer.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = dhydDoctor2Id,
                    UserId = dhydDoctorUser2Id,
                    ClinicId = dhydClinicId,
                    Gender = "Male",
                    Specialization = "General Internal Medicine",
                    Certificate = "Specialist Level II",
                    ExperienceYear = 20,
                    WorkPosition = "Internal Medicine Doctor",
                    Description = "Practicing at General Internal Medicine Clinic with years of internal medicine experience.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed UMC Consultant Users
            var dhydConsultantUser1Id = Guid.NewGuid();
            var dhydConsultantUser2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = dhydConsultantUser1Id,
                    UserName = "Prof. Dr. Pham Kien Huu",
                    Email = "pham.kienhuu@umc.edu.vn",
                    PhoneNumber = "+84-28-3855 4269",
                    Password = HashPassword("consultant#4"),
                    Address = "Specialty Clinic, UMC Campus 1, 215 Hong Bang, District 5",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = dhydConsultantUser2Id,
                    UserName = "Assoc. Prof. Dr. Le Anh Thu",
                    Email = "le.anhthu@umc.edu.vn",
                    PhoneNumber = "+84-28-3855 4269",
                    Password = HashPassword("consultant#5"),
                    Address = "Rheumatology Specialty Clinic, UMC Campus 1",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed UMC Consultants
            var dhydConsultant1Id = Guid.NewGuid();
            var dhydConsultant2Id = Guid.NewGuid();

            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = dhydConsultant1Id,
                    UserId = dhydConsultantUser1Id,
                    ClinicId = dhydClinicId,
                    Specialization = "Ear – Nose – Throat",
                    Certificate = "Professor, PhD, MD",
                    Gender = "Male",
                    ExperienceYears = 30,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = dhydConsultant2Id,
                    UserId = dhydConsultantUser2Id,
                    ClinicId = dhydClinicId,
                    Specialization = "Rheumatology",
                    Certificate = "Associate Professor, PhD, MD",
                    Gender = "Female",
                    ExperienceYears = 40,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                }
            );

            // Seed UMC Feedbacks
            var dhydFeedback1Id = Guid.NewGuid();
            var dhydFeedback2Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = dhydFeedback1Id,
                    ClinicId = dhydClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Modern facilities, dedicated doctors; waiting time is a bit long.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = dhydFeedback2Id,
                    ClinicId = dhydClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Excellent specialist consultations, modern equipment.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );


            // FV Hospital (Franco-Vietnamese Hospital)
            // Seed FV Clinic User
            var fvClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = fvClinicUserId,
                UserName = "FV Hospital (Franco-Vietnamese Hospital)",
                Email = "information@fvhospital.com",
                PhoneNumber = "(028) 35 11 33 33",
                Password = HashPassword("clinic#4"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "6 Nguyen Luong Bang Street, Tan My Ward, District 7, Ho Chi Minh City, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed FV Clinic
            var fvClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = fvClinicId,
                UserId = fvClinicUserId,
                Address = "6 Nguyen Luong Bang Street, Tan My Ward, District 7, Ho Chi Minh City, Vietnam",
                Description = "FV Hospital is a high-standard international hospital in District 7, Ho Chi Minh City, established in 2003 by French-Vietnamese doctors. With international quality, modern medical equipment, and more than 30 specialties, FV serves both local and international patients. The hospital has 220 inpatient beds, 24/7 emergency services, outpatient clinics, obstetrics & gynecology, oncology, cardiology, pediatrics, ophthalmology, endoscopy, laboratory & imaging diagnostics.",
                IsInsuranceAccepted = true,
                Specializations = "Cancer – Hy Vong Cancer Care Centre;Obstetrics & Gynecology;Pediatrics & Neonatology;Ophthalmology;Gastroenterology – Hepatology;Internal Medicine;Metabolism;Imaging Diagnostics;Surgery — General Surgery;Cardiology;24/7 Emergency;International consultations / internationalized medical services",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed FV Doctor Users
            var fvDoctorUser1Id = Guid.NewGuid();
            var fvDoctorUser2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = fvDoctorUser1Id,
                    UserName = "Dr. Le Minh Duc",
                    Email = "le.minh.duc@fvhospital.com",
                    PhoneNumber = "+84-28-3511-3333",
                    Password = HashPassword("doctor#8"),
                    Address = "FV Hospital, 6 Nguyen Luong Bang, District 7, HCMC",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = fvDoctorUser2Id,
                    UserName = "Dr. Le Dinh Phuong",
                    Email = "le.dinh.phuong@fvhospital.com",
                    PhoneNumber = "+84-28-3511-3333",
                    Password = HashPassword("doctor#9"),
                    Address = "FV Hospital, District 7, HCMC",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed FV Doctors
            var fvDoctor1Id = Guid.NewGuid();
            var fvDoctor2Id = Guid.NewGuid();

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = fvDoctor1Id,
                    UserId = fvDoctorUser1Id,
                    ClinicId = fvClinicId,
                    Gender = "Male",
                    Specialization = "Obstetrics & Gynecology",
                    Certificate = "Specialist Degree I/II or equivalent",
                    ExperienceYear = 15,
                    WorkPosition = "Specialist Doctor",
                    Description = "One of the public doctors listed on the FV Hospital website, practicing in obstetrics & gynecology.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = fvDoctor2Id,
                    UserId = fvDoctorUser2Id,
                    ClinicId = fvClinicId,
                    Gender = "Male",
                    Specialization = "Internal Medicine",
                    Certificate = "Medical Specialist",
                    ExperienceYear = 12,
                    WorkPosition = "Internal Medicine Doctor",
                    Description = "A doctor in the Department of Internal Medicine, with public consultation schedules listed on the hospital website.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed FV Consultant User
            var fvConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = fvConsultantUserId,
                UserName = "Dr. Jane Smith",
                Email = "jane.smith@fvhospital.com",
                PhoneNumber = "+84-28-3511-3333",
                Password = HashPassword("consultant#6"),
                Address = "Specialist Clinic, FV Hospital, District 7",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed FV Consultant
            var fvConsultantId = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = fvConsultantId,
                UserId = fvConsultantUserId,
                ClinicId = fvClinicId,
                Specialization = "",
                Certificate = "PhD, Specialist Doctor II",
                Gender = "Female",
                ExperienceYears = 20,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed FV Feedbacks
            var fvFeedback1Id = Guid.NewGuid();
            var fvFeedback2Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = fvFeedback1Id,
                    ClinicId = fvClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "International standard services, friendly staff, good hygiene — but prices are quite high.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = fvFeedback2Id,
                    ClinicId = fvClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Clean hospital, doctors with high expertise; emergency services are very fast.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );


            // Vinmec Central Park International Hospital
            // Seed Vinmec Clinic User
            var vinmecClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = vinmecClinicUserId,
                UserName = "Vinmec Central Park International Hospital",
                Email = "contact@vinmec.com",
                PhoneNumber = "(028) 3622 1166",
                Password = HashPassword("clinic#5"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "208 Nguyen Huu Canh, Ward 22, Binh Thanh District, Ho Chi Minh City, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Vinmec Clinic
            var vinmecClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = vinmecClinicId,
                UserId = vinmecClinicUserId,
                Address = "208 Nguyen Huu Canh, Ward 22, Binh Thanh District, Ho Chi Minh City, Vietnam",
                Description = "Vinmec Central Park is a member hospital of the Vinmec Healthcare System, equipped with modern facilities, a team of both local and international doctors, accredited by JCI international standards. It provides a wide range of specialized care such as oncology, cardiology, surgery, obstetrics & gynecology, pediatrics, diagnostic imaging, and operates 24/7 for emergency services.",
                IsInsuranceAccepted = true,
                Specializations = "Cardiology;Oncology;General Surgery;Obstetrics & Gynecology;Pediatrics;Neurology & Psychiatry;ENT (Otolaryngology);Dermatology;Endocrinology;Gastroenterology & Hepatology;Vaccination;Orthopedics & Traumatology;Medical Check-up;General Medicine;Pulmonology;Rehabilitation",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Vinmec Doctor Users
            var vinmecDoctorUser1Id = Guid.NewGuid();
            var vinmecDoctorUser2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = vinmecDoctorUser1Id,
                    UserName = "Dr. Nguyen Van Phan",
                    Email = "nguyen.van.phan@vinmec.com",
                    PhoneNumber = "+84-28-3622-1166",
                    Password = HashPassword("doctor#10"),
                    Address = "Vinmec Central Park, Binh Thanh, TP. HCM",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = vinmecDoctorUser2Id,
                    UserName = "Dr. Nguyen Thi Thu Trang",
                    Email = "nguyen.thu.trang@vinmec.com",
                    PhoneNumber = "+84-28-3622-1166",
                    Password = HashPassword("doctor#11"),
                    Address = "Vinmec Central Park, Bình Thạnh, TP. HCM",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Vinmec Doctors
            var vinmecDoctor1Id = Guid.NewGuid();
            var vinmecDoctor2Id = Guid.NewGuid();

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = vinmecDoctor1Id,
                    UserId = vinmecDoctorUser1Id,
                    ClinicId = vinmecClinicId,
                    Gender = "Male",
                    Specialization = "Cardiovascular Surgery",
                    Certificate = "MD / Specialist",
                    ExperienceYear = 40,
                    WorkPosition = "Cardiac Surgeon",
                    Description = "A cardiovascular surgeon with over 40 years of experience, recognized as one of the prominent doctors at Vinmec Central Park.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = vinmecDoctor2Id,
                    UserId = vinmecDoctorUser2Id,
                    ClinicId = vinmecClinicId,
                    Gender = "Female",
                    Specialization = "Dermatology / Aesthetic Laser",
                    Certificate = "MD / Specialist",
                    ExperienceYear = 15,
                    WorkPosition = "Dermatologist",
                    Description = "An internationally trained dermatologist specializing in aesthetic laser and skin care.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Vinmec Consultant User
            var vinmecConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = vinmecConsultantUserId,
                UserName = "Dr. Jane Doe",
                Email = "jane.doe@vinmec.com",
                PhoneNumber = "+84-28-3622-1166",
                Password = HashPassword("consultant#7"),
                Address = "Vinmec Central Park, Binh Thanh District",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Vinmec Consultant
            var vinmecConsultantId = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = vinmecConsultantId,
                UserId = vinmecConsultantUserId,
                ClinicId = vinmecClinicId,
                Specialization = "Oncology",
                Certificate = "PhD, Specialist Level II",
                Gender = "Female",
                ExperienceYears = 20,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Vinmec Feedbacks
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = Guid.NewGuid(),
                    ClinicId = vinmecClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 10,
                    Comment = "Very clean facilities, friendly staff; emergency services were quick and effective.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = Guid.NewGuid(),
                    ClinicId = vinmecClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 10,
                    Comment = "High-quality international services, prices are a bit high but worth the value.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );



            // Hoan My Saigon General Hospital
            // Seed Hoan My Clinic User
            var hoanmyClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = hoanmyClinicUserId,
                UserName = "Hoan My Saigon General Hospital",
                Email = "contact@hoanmysaigon.com",
                PhoneNumber = "(028) 3990 2468",
                Password = HashPassword("clinic#6"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "60-60A Phan Xich Long, Ward 1, Phu Nhuan District, Ho Chi Minh City, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Hoan My Clinic
            var hoanmyClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = hoanmyClinicId,
                UserId = hoanmyClinicUserId,
                Address = "60-60A Phan Xich Long, Ward 1, Phu Nhuan District, Ho Chi Minh City, Vietnam",
                Description = "Hoan My Saigon Hospital is a private hospital established in 1999 with about 300 beds, serving both inpatient and outpatient needs. It is known for multi-specialty services, premium health check-up packages, and 24/7 emergency care. As a member of the Hoan My Medical Corporation, it is highly rated for quality and patient services.",
                IsInsuranceAccepted = true,
                Specializations = "General Medicine;Surgery;Obstetrics & Gynecology;Pediatrics;24/7 Emergency;General Health Check-up;Nephrology & Urology;Oncology;Diagnostic Imaging;Internal Medicine;Orthopedics;ENT;Endoscopy & Gastroenterology;Periodic Check-ups",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Hoan My Doctor Users
            var hoanmyDoctorUser1Id = Guid.NewGuid();
            var hoanmyDoctorUser2Id = Guid.NewGuid();
            var hoanmyDoctorUser3Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = hoanmyDoctorUser1Id,
                    UserName = "Dr. Vu Đinh Kha",
                    Email = "vu.dinh.kha@hoanmysaigon.com",
                    PhoneNumber = "+84-28-3990-2468",
                    Password = HashPassword("doctor#12"),
                    Address = "60-60A Phan Xich Long Street, Ward 1, Phu Nhuan District, Ho Chi Minh City",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = hoanmyDoctorUser2Id,
                    UserName = "Dr. Tran Nguyen Anh Huy",
                    Email = "tran.anh.huy@hoanmysaigon.com",
                    PhoneNumber = "+84-28-3990-2468",
                    Password = HashPassword("doctor#13"),
                    Address = "60-60A Phan Xich Long Street, Ward 1, Phu Nhuan District, Ho Chi Minh City",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = hoanmyDoctorUser3Id,
                    UserName = "Dr. Tran Dinh Thanh",
                    Email = "tran.dinh.thanh@hoanmysaigon.com",
                    PhoneNumber = "+84-28-3990-2468",
                    Password = HashPassword("doctor#14"),
                    Address = "60-60A Phan Xich Long Street, Ward 1, Phu Nhuan District, Ho Chi Minh City",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Hoan My Doctors
            var hoanmyDoctor1Id = Guid.NewGuid();
            var hoanmyDoctor2Id = Guid.NewGuid();
            var hoanmyDoctor3Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = hoanmyDoctor1Id,
                    UserId = hoanmyDoctorUser1Id,
                    ClinicId = hoanmyClinicId,
                    Gender = "Male",
                    Specialization = "Nephrology & Urology",
                    Certificate = "Specialist Level II",
                    ExperienceYear = 21,
                    WorkPosition = "Head of Urology Department",
                    Description = "Graduated in Medicine in 1995, with Specialist I & II in Urology, Dr. Vu Dinh Kha has over 21 years of experience in nephrology and urology at Hoan My Saigon.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = hoanmyDoctor2Id,
                    UserId = hoanmyDoctorUser2Id,
                    ClinicId = hoanmyClinicId,
                    Gender = "Male",
                    Specialization = "Cardiology",
                    Certificate = "Specialist Level II",
                    ExperienceYear = 22,
                    WorkPosition = "Head of Cardiology Department",
                    Description = "Head of the Cardiology Department with over 22 years of experience; performing interventional cardiology and treating complex heart diseases.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = hoanmyDoctor3Id,
                    UserId = hoanmyDoctorUser3Id,
                    ClinicId = hoanmyClinicId,
                    Gender = "Male",
                    Specialization = "Oncology",
                    Certificate = "Specialist Level II",
                    ExperienceYear = 30,
                    WorkPosition = "Head of Oncology Department",
                    Description = "Currently Head of Oncology at Hoan My Saigon; Dr. Tran Dinh Thanh previously worked for many years at Pham Ngoc Thach Hospital before joining Hoan My.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Hoan My Consultant User
            var hoanmyConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = hoanmyConsultantUserId,
                UserName = "Dr. Ngo Ba Duong",
                Email = "duong.ngo@hoanmysaigon.com",
                PhoneNumber = "+84-28-3990-2468",
                Password = HashPassword("consultant#8"),
                Address = "60-60A Phan Xich Long Street, Ward 1, Phu Nhuan District, Ho Chi Minh City",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });
            // Seed Hoan My Consultant
            var hoanmyConsultantId = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = hoanmyConsultantId,
                UserId = hoanmyConsultantUserId,
                ClinicId = hoanmyClinicId,
                Specialization = "General Internal Medicine Consultation",
                Certificate = "Specialist Level I/II Certificate",
                Gender = "Female",
                ExperienceYears = 20,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Hoan My Feedbacks
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = Guid.NewGuid(),
                    ClinicId = hoanmyClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Good services, dedicated doctors; treatment rooms and equipment are sufficient, but some services are a bit pricey.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = Guid.NewGuid(),
                    ClinicId = hoanmyClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 7,
                    Comment = "Long waiting times, but doctors gave clear explanations and staff were friendly.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Tam Anh General Hospital Ho Chi Minh City

            // Seed Tam Anh Clinic User
            var tamanhClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = tamanhClinicUserId,
                UserName = "Tam Anh General Hospital HCMC",
                Email = "cskh@hcm.tahospital.vn",
                PhoneNumber = "(028) 7102 6789",
                Password = HashPassword("clinic#7"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "2B Pho Quang, Ward 2, Tan Binh District, Ho Chi Minh City, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Tam Anh Clinic
            var tamanhClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = tamanhClinicId,
                UserId = tamanhClinicUserId,
                Address = "2B Pho Quang, Ward 2, Tan Binh District, Ho Chi Minh City, Vietnam",
                Description = "Tam Anh General Hospital HCMC is a premium hospital built to 5-star standards, operating since 2021. It brings together leading domestic doctors, modern medical equipment, and offers general healthcare, on-demand medical services, and specialized treatments. It is highly rated for service quality and luxurious facilities.",
                IsInsuranceAccepted = true,
                Specializations = "Diagnostic Imaging;Orthopedics;Musculoskeletal;Intensive Care;Anesthesiology & Resuscitation;Oncology;Infection Control;Pediatrics;Gastrointestinal Endoscopy;Obstetrics & Gynecology;Neonatology;ENT;Urology;Diabetes / Endocrinology;Vaccination;General Internal Medicine",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Tam Anh Doctor Users
            var tamanhDoctorUser1Id = Guid.NewGuid();
            var tamanhDoctorUser2Id = Guid.NewGuid();
            var tamanhDoctorUser3Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = tamanhDoctorUser1Id,
                    UserName = "PhD. MD. Do Minh Hung",
                    Email = "do.minh.hung@tahospital.vn",
                    PhoneNumber = "+84-28-7102-6789",
                    Password = HashPassword("doctor#15"),
                    Address = "Gastrointestinal Endoscopy & Laparoscopic Surgery Center, Tam Anh Hospital HCMC",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = tamanhDoctorUser2Id,
                    UserName = "PhD. MD. Cam Ngoc Phuong",
                    Email = "cam.ngoc.phuong@tahospital.vn",
                    PhoneNumber = "+84-28-7102-6789",
                    Password = HashPassword("doctor#16"),
                    Address = "Neonatology Center, Tam Anh Hospital HCMC",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = tamanhDoctorUser3Id,
                    UserName = "Dr. Tran Gia Hung",
                    Email = "gia.hung@tahospital.vn",
                    PhoneNumber = "+84-28-7102-6789",
                    Password = HashPassword("doctor#17"),
                    Address = "Diagnostic Imaging Department, Tam Anh Hospital HCMC",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Tam Anh Doctors
            var tamanhDoctor1Id = Guid.NewGuid();
            var tamanhDoctor2Id = Guid.NewGuid();
            var tamanhDoctor3Id = Guid.NewGuid();

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = tamanhDoctor1Id,
                    UserId = tamanhDoctorUser1Id,
                    ClinicId = tamanhClinicId,
                    Gender = "Male",
                    Specialization = "Gastroenterology - Hepatology",
                    Certificate = "PhD, Specialist Doctor",
                    ExperienceYear = 30,
                    WorkPosition = "Director, Endoscopy & Laparoscopic Surgery Center",
                    Description = "Leading expert in gastrointestinal endoscopy and laparoscopic surgery, with many years of experience in major hospitals.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = tamanhDoctor2Id,
                    UserId = tamanhDoctorUser2Id,
                    ClinicId = tamanhClinicId,
                    Gender = "Female",
                    Specialization = "Neonatology",
                    Certificate = "PhD, Specialist Doctor",
                    ExperienceYear = 30,
                    WorkPosition = "Director, Neonatology Center",
                    Description = "Director of the Neonatology Center, with extensive experience in newborn and child healthcare.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = tamanhDoctor3Id,
                    UserId = tamanhDoctorUser3Id,
                    ClinicId = tamanhClinicId,
                    Gender = "Male",
                    Specialization = "Diagnostic Imaging",
                    Certificate = "Specialist Level II",
                    ExperienceYear = 20,
                    WorkPosition = "Senior Doctor",
                    Description = "A doctor specializing in diagnostic imaging with many years of experience.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Tam Anh Consultant Users
            var tamanhConsultantUser1Id = Guid.NewGuid();
            var tamanhConsultantUser2Id = Guid.NewGuid();
            var tamanhConsultantUser3Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = tamanhConsultantUser1Id,
                    UserName = "Assoc. Prof. PhD. MD. Pham Nguyen Vinh",
                    Email = "pham.nguyen.vinh@tahospital.vn",
                    PhoneNumber = "+84-28-7102-6789",
                    Password = HashPassword("consultant#9"),
                    Address = "Cardiology Center, Tam Anh General Hospital HCMC",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = tamanhConsultantUser2Id,
                    UserName = "People’s Doctor, Assoc. Prof. PhD. MD. Vu Le Chuyen",
                    Email = "vu.le.chuyen@tahospital.vn",
                    PhoneNumber = "+84-28-7102-6789",
                    Password = HashPassword("consultant#10"),
                    Address = "Urology - Nephrology - Andrology Center, Tam Anh General Hospital HCMC",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = tamanhConsultantUser3Id,
                    UserName = "Specialist Level II, MD. Nguyen Ba My Nhi",
                    Email = "nguyen.ba.my.nhi@tahospital.vn",
                    PhoneNumber = "+84-28-7102-6789",
                    Password = HashPassword("consultant#11"),
                    Address = "Obstetrics & Gynecology Center, Tam Anh Hospital HCMC",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Tam Anh Consultants
            var tamanhConsultant1Id = Guid.NewGuid();
            var tamanhConsultant2Id = Guid.NewGuid();
            var tamanhConsultant3Id = Guid.NewGuid();

            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = tamanhConsultant1Id,
                    UserId = tamanhConsultantUser1Id,
                    ClinicId = tamanhClinicId,
                    Specialization = "Cardiology",
                    Certificate = "Assoc. Prof., PhD, MD",
                    Gender = "Male",
                    ExperienceYears = 25,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = tamanhConsultant2Id,
                    UserId = tamanhConsultantUser2Id,
                    ClinicId = tamanhClinicId,
                    Specialization = "Urology - Andrology",
                    Certificate = "Assoc. Prof., PhD, Senior Specialist Doctor",
                    Gender = "Male",
                    ExperienceYears = 40,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = tamanhConsultant3Id,
                    UserId = tamanhConsultantUser3Id,
                    ClinicId = tamanhClinicId,
                    Specialization = "Obstetrics & Gynecology",
                    Certificate = "Specialist Level II",
                    Gender = "Female",
                    ExperienceYears = 30,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                }
            );

            // Seed Tam Anh Feedbacks
            var tamanhFeedback1Id = Guid.NewGuid();
            var tamanhFeedback2Id = Guid.NewGuid();
            var tamanhFeedback3Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = tamanhFeedback1Id,
                    ClinicId = tamanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Good service, clean facilities, highly skilled doctors.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = tamanhFeedback2Id,
                    ClinicId = tamanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Long waiting time, slightly high cost but good quality.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = tamanhFeedback3Id,
                    ClinicId = tamanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Helpful staff, great support with appointment booking and procedures.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );


            // ND115 Hospital

            // Seed ND115 Clinic User
            var nd115ClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = nd115ClinicUserId,
                UserName = "Nhan Dan 115 Hospital",
                Email = "bvnd115tphcm@gmail.com",
                PhoneNumber = "(028) 38.683.496",
                Password = HashPassword("clinic#8"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "High-Tech Zone: 818 Su Van Hanh, Hoa Hung Ward, Ho Chi Minh City; Emergency Gate (Gate 4): 527 Su Van Hanh, Hoa Hung Ward; Request-based Examination (Gate 3): 527 Su Van Hanh, Hoa Hung Ward; Insurance Examination: 88 Thanh Thai, Hoa Hung Ward; Research & Development Center (Gate 1): 3 Duong Quang Trung, Hoa Hung Ward",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed ND115 Clinic
            var nd115ClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = nd115ClinicId,
                UserId = nd115ClinicUserId,
                Address = "High-Tech Zone: 818 Su Van Hanh, Hoa Hung Ward, Ho Chi Minh City; Emergency Gate (Gate 4): 527 Su Van Hanh, Hoa Hung Ward; Request-based Examination (Gate 3): 527 Su Van Hanh, Hoa Hung Ward; Insurance Examination: 88 Thanh Thai, Hoa Hung Ward; Research & Development Center (Gate 1): 3 Duong Quang Trung, Hoa Hung Ward",
                Description = "People's Hospital 115 is a grade I multi-specialty hospital under the Department of Health of Ho Chi Minh City. With over 30 years of operation, it has 5 key specialties, 7 clinical divisions, 45 departments, about 1,600 beds; nearly 70% of doctors hold postgraduate qualifications. Key specialties include Neurology, Cardiology, Urology – Nephrology, Neurovascular Interventions, Emergency – Anesthesia – Critical Care, and Toxicology.",
                IsInsuranceAccepted = true,
                Specializations = "Neurology (Stroke);Cardiology & Interventional Cardiology;Urology – Nephrology, Kidney Transplant;Neurovascular Interventions;Emergency, Anesthesia – Intensive Care;Toxicology;General Surgery;Orthopedics & Trauma Surgery;Internal Neurology;Gastroenterology & Hepatology;Endocrinology;Rheumatology;Traditional Medicine & Rehabilitation;On-demand Examination;Health Insurance Examination",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed ND115 Doctor Users
            var nd115DoctorUser1Id = Guid.NewGuid();
            var nd115DoctorUser2Id = Guid.NewGuid();
            var nd115DoctorUser3Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = nd115DoctorUser1Id,
                    UserName = "MD, Specialist Level II Pham Duc Dat",
                    Email = "pham.duc.dat@bv115.vn",
                    PhoneNumber = "+84-28-3865-2368",
                    Password = HashPassword("doctor#18"),
                    Address = "Interventional Cardiology Department, People's Hospital 115",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = nd115DoctorUser2Id,
                    UserName = "MSc, MD Ta Cong Thanh",
                    Email = "ta.cong.thanh@bv115.vn",
                    PhoneNumber = "+84-28-3865-2368",
                    Password = HashPassword("doctor#19"),
                    Address = "Interventional Cardiology Department, People's Hospital 115",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = nd115DoctorUser3Id,
                    UserName = "MD, Specialist Level II Ton That Tuan Khiem",
                    Email = "tonthat.tuan.khiem@bv115.vn",
                    PhoneNumber = "+84-28-3865-2368",
                    Password = HashPassword("doctor#20"),
                    Address = "Interventional Cardiology Department, People's Hospital 115",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed ND115 Doctors
            var nd115Doctor1Id = Guid.NewGuid();
            var nd115Doctor2Id = Guid.NewGuid();
            var nd115Doctor3Id = Guid.NewGuid();

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = nd115Doctor1Id,
                    UserId = nd115DoctorUser1Id,
                    ClinicId = nd115ClinicId,
                    Gender = "Male",
                    Specialization = "Interventional Cardiology",
                    Certificate = "Specialist Level II Doctor",
                    ExperienceYear = 23,
                    WorkPosition = "Head of Interventional Cardiology Department",
                    Description = "Leading interventional cardiologist at People's Hospital 115; mentioned in articles 'Top Cardiologists at 115 Hospital' with over 20 years of experience.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = nd115Doctor2Id,
                    UserId = nd115DoctorUser2Id,
                    ClinicId = nd115ClinicId,
                    Gender = "Male",
                    Specialization = "Interventional Cardiology",
                    Certificate = "Master of Science, Medical Doctor",
                    ExperienceYear = 20,
                    WorkPosition = "Interventional Cardiologist",
                    Description = "Listed among the Top 5 cardiologists at People's Hospital 115; many years of experience in interventional cardiology.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = nd115Doctor3Id,
                    UserId = nd115DoctorUser3Id,
                    ClinicId = nd115ClinicId,
                    Gender = "Male",
                    Specialization = "Interventional Cardiology",
                    Certificate = "Specialist Level II Doctor",
                    ExperienceYear = 18,
                    WorkPosition = "Senior Doctor",
                    Description = "Recognized among the outstanding cardiologists at People's Hospital 115.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed ND115 Consultant Users
            var nd115ConsultantUser1Id = Guid.NewGuid();
            var nd115ConsultantUser2Id = Guid.NewGuid();
            var nd115ConsultantUser3Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = nd115ConsultantUser1Id,
                    UserName = "Meritorious Doctor, Assoc. Prof. Dr. Nguyen Huy Thang",
                    Email = "nguyen.huy.thang@bv115.vn",
                    PhoneNumber = "+84-28-3865-2368",
                    Password = HashPassword("consultant#12"),
                    Address = "Cerebrovascular Diseases Department, People's Hospital 115",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = nd115ConsultantUser2Id,
                    UserName = "PhD, MD Truong Hoang Minh",
                    Email = "truong.hoang.minh@bv115.vn",
                    PhoneNumber = "+84-28-3865-2368",
                    Password = HashPassword("consultant#13"),
                    Address = "Urology – Kidney Transplant Department, People's Hospital 115",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = nd115ConsultantUser3Id,
                    UserName = "MD, Specialist Level II Nguyen Huu Tam",
                    Email = "nguyen.huu.tam@bv115.vn",
                    PhoneNumber = "+84-28-3865-2368",
                    Password = HashPassword("consultant#14"),
                    Address = "Orthopedics Department, People's Hospital 115",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed ND115 Consultants
            var nd115Consultant1Id = Guid.NewGuid();
            var nd115Consultant2Id = Guid.NewGuid();
            var nd115Consultant3Id = Guid.NewGuid();

            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = nd115Consultant1Id,
                    UserId = nd115ConsultantUser1Id,
                    ClinicId = nd115ClinicId,
                    Specialization = "Neurology – Cerebrovascular Diseases",
                    Certificate = "Associate Professor, PhD, Senior Specialist Doctor",
                    Gender = "Male",
                    ExperienceYears = 30,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = nd115Consultant2Id,
                    UserId = nd115ConsultantUser2Id,
                    ClinicId = nd115ClinicId,
                    Specialization = "Urology, Kidney Transplant",
                    Certificate = "PhD, Specialist Level II Doctor",
                    Gender = "Male",
                    ExperienceYears = 28,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = nd115Consultant3Id,
                    UserId = nd115ConsultantUser3Id,
                    ClinicId = nd115ClinicId,
                    Specialization = "Orthopedic Surgery",
                    Certificate = "Specialist Level II Doctor",
                    Gender = "Male",
                    ExperienceYears = 25,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                }
            );

            // Seed ND115 Feedbacks
            var nd115Feedback1Id = Guid.NewGuid();
            var nd115Feedback2Id = Guid.NewGuid();
            var nd115Feedback3Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = nd115Feedback1Id,
                    ClinicId = nd115ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "The hospital is spacious with good expertise; however, it is very crowded, leading to long waiting times.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = nd115Feedback2Id,
                    ClinicId = nd115ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Good technical facilities, dedicated doctors, but procedures are somewhat complicated.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = nd115Feedback3Id,
                    ClinicId = nd115ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Insurance examination is convenient; doctors explain thoroughly.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );


            // Thong Nhat Hospital HCMC

            // Seed Thong Nhat Clinic User
            var thongnhatClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = thongnhatClinicUserId,
                UserName = "Thong Nhat Hospital HCMC",
                Email = "thongnhathospital@bvtn.org.vn",
                PhoneNumber = "(028) 3869 0277",
                Password = HashPassword("clinic#9"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "No. 1 Ly Thuong Kiet, Ward 7, Tan Binh District, Ho Chi Minh City, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Thong Nhat Clinic
            var thongnhatClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = thongnhatClinicId,
                UserId = thongnhatClinicUserId,
                Address = "No. 1 Ly Thuong Kiet, Ward 7, Tan Binh District, Ho Chi Minh City, Vietnam",
                Description = "A grade I general hospital under the Ministry of Health, established on 01/11/1975, providing various inpatient & outpatient specialties, including obstetrics & gynecology services, antenatal care, private services, and health insurance examinations.",
                IsInsuranceAccepted = true,
                Specializations = "Routine antenatal checkups / Obstetrics & Gynecology;Prenatal counseling;Fetal ultrasound;Fetal growth monitoring;Prenatal testing;Gynecology examinations;Private maternity services;On-demand examinations",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Thong Nhat Doctor Users
            var thongnhatDoctorUser1Id = Guid.NewGuid();
            var thongnhatDoctorUser2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = thongnhatDoctorUser1Id,
                    UserName = "Dr. Nguyen Thi Phuong Hanh",
                    Email = "nguyen.phuong.hanh@bvtn.org.vn",
                    PhoneNumber = "(028) 3869 0277",
                    Password = HashPassword("doctor#21"),
                    Address = "Obstetrics & Gynecology Department, Thong Nhat Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = thongnhatDoctorUser2Id,
                    UserName = "Dr. Le Minh Duc",
                    Email = "le.minh.duc@bvtn.org.vn",
                    PhoneNumber = "(028) 3869 0277",
                    Password = HashPassword("doctor#22"),
                    Address = "Outpatient Department / Obstetrics & Gynecology, Thong Nhat Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Thong Nhat Doctors
            var thongnhatDoctor1Id = Guid.NewGuid();
            var thongnhatDoctor2Id = Guid.NewGuid();

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = thongnhatDoctor1Id,
                    UserId = thongnhatDoctorUser1Id,
                    ClinicId = thongnhatClinicId,
                    Gender = "Female",
                    Specialization = "Obstetrics & Gynecology / Antenatal care & delivery",
                    Certificate = "Specialist Level II Doctor",
                    ExperienceYear = 20,
                    WorkPosition = "Obstetrics & Gynecology Specialist",
                    Description = "One of the doctors providing antenatal checkups and delivery services, with long experience in obstetrics & gynecology.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = thongnhatDoctor2Id,
                    UserId = thongnhatDoctorUser2Id,
                    ClinicId = thongnhatClinicId,
                    Gender = "Male",
                    Specialization = "Fetal ultrasound & specialized maternity care",
                    Certificate = "Specialist Level I Doctor",
                    ExperienceYear = 15,
                    WorkPosition = "Fetal ultrasound doctor",
                    Description = "Performs routine fetal ultrasounds and monitors fetal growth.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Thong Nhat Consultant User
            var thongnhatConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = thongnhatConsultantUserId,
                UserName = "Dr. Ngo Thi Kim Anh",
                Email = "ngothi.kimanh@bvtn.org.vn",
                PhoneNumber = "(028) 3869 0277",
                Password = HashPassword("consultant#15"),
                Address = "Outpatient Department / Obstetrics & Gynecology, Thong Nhat Hospital",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Thong Nhat Consultant
            var thongnhatConsultantId = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = thongnhatConsultantId,
                UserId = thongnhatConsultantUserId,
                ClinicId = thongnhatClinicId,
                Specialization = "Obstetrics & Gynecology / Antenatal care",
                Certificate = "Specialist Level I Doctor",
                Gender = "Female",
                ExperienceYears = 28,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Thong Nhat Feedbacks
            var thongnhatFeedback1Id = Guid.NewGuid();
            var thongnhatFeedback2Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = thongnhatFeedback1Id,
                    ClinicId = thongnhatClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Antenatal care is generally good, doctors are friendly, but waiting time is long.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = thongnhatFeedback2Id,
                    ClinicId = thongnhatClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Private antenatal care service is good, ultrasound is clear, staff are dedicated.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );


            // Cho Ray Hospital

            // Seed Cho Ray Clinic User
            var chorayClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = chorayClinicUserId,
                UserName = "Cho Ray Hospital",
                Email = "bvchoray@choray.vn",
                PhoneNumber = "0283 8554 137",
                Password = HashPassword("clinic#10"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "201B Nguyen Chi Thanh, Ward 12, District 5, Ho Chi Minh City, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Cho Ray Clinic
            var chorayClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = chorayClinicId,
                UserId = chorayClinicUserId,
                Address = "201B Nguyen Chi Thanh, Ward 12, District 5, Ho Chi Minh City, Vietnam",
                Description = "Cho Ray Hospital is a special-class central general hospital with over 100 years of operation, offering many advanced specialties and handling complex and critical cases. It provides obstetrics & gynecology services, prenatal consultation, health insurance support, and appointment booking.",
                IsInsuranceAccepted = true,
                Specializations = "Prenatal checkups / obstetrics & gynecology;Fetal ultrasound;Prenatal testing;Fetal growth monitoring;Delivery / natural birth / cesarean section;Gynecology checkups;Pre-pregnancy consultation;Premium maternity services;On-demand medical services;Health insurance examination",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Cho Ray Doctor Users
            var chorayDoctorUser1Id = Guid.NewGuid();
            var chorayDoctorUser2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = chorayDoctorUser1Id,
                    UserName = "Dr. Nguyen Thi Hoa",
                    Email = "nguyen.thi.hoa@choray.vn",
                    PhoneNumber = "0283 8554 137",
                    Password = HashPassword("doctor#23"),
                    Address = "Department of Obstetrics & Gynecology, Cho Ray Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = chorayDoctorUser2Id,
                    UserName = "Dr. Le Van Tuan",
                    Email = "le.van.tuan@choray.vn",
                    PhoneNumber = "0283 8554 137",
                    Password = HashPassword("doctor#24"),
                    Address = "Ultrasound Department / Obstetrics & Gynecology, Cho Ray Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Cho Ray Doctors
            var chorayDoctor1Id = Guid.NewGuid();
            var chorayDoctor2Id = Guid.NewGuid();

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = chorayDoctor1Id,
                    UserId = chorayDoctorUser1Id,
                    ClinicId = chorayClinicId,
                    Gender = "Female",
                    Specialization = "Obstetrics & Gynecology / Delivery",
                    Certificate = "Specialist Doctor Level I",
                    ExperienceYear = 18,
                    WorkPosition = "Obstetrician & Gynecologist",
                    Description = "Handles childbirth cases, pregnancy monitoring, maternity checkups, and pre-pregnancy consultation.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = chorayDoctor2Id,
                    UserId = chorayDoctorUser2Id,
                    ClinicId = chorayClinicId,
                    Gender = "Male",
                    Specialization = "Fetal ultrasound / gynecological procedures",
                    Certificate = "Specialist Doctor Level I",
                    ExperienceYear = 15,
                    WorkPosition = "Fetal Ultrasound Specialist",
                    Description = "Performs prenatal ultrasound and early detection of abnormalities during pregnancy.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Cho Ray Consultant User
            var chorayConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = chorayConsultantUserId,
                UserName = "Dr. Tran Thi Thanh Mai",
                Email = "tran.thanh.mai@choray.vn",
                PhoneNumber = "0283 8554 137",
                Password = HashPassword("consultant#16"),
                Address = "Department of Obstetrics & Gynecology, Cho Ray Hospital",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Cho Ray Consultant
            var chorayConsultantId = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = chorayConsultantId,
                UserId = chorayConsultantUserId,
                ClinicId = chorayClinicId,
                Specialization = "Obstetrics & Gynecology / Prenatal checkups & pregnancy monitoring",
                Certificate = "Specialist Doctor Level II",
                Gender = "Female",
                ExperienceYears = 20,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Cho Ray Feedbacks
            var chorayFeedback1Id = Guid.NewGuid();
            var chorayFeedback2Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = chorayFeedback1Id,
                    ClinicId = chorayClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Good prenatal checkup, highly qualified doctors, but waiting time is long due to many patients.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = chorayFeedback2Id,
                    ClinicId = chorayClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Comprehensive obstetrics & gynecology services; clear ultrasound results, friendly clinic staff.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );


            // Nhi Dong 1 Hospital

            // Seed Nhi Dong 1 Clinic User
            var nhidong1ClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = nhidong1ClinicUserId,
                UserName = "Nhi Dong 1 Hospital",
                Email = "bvnhidong@nhidong.org.vn",
                PhoneNumber = "(028) 3927 1119",
                Password = HashPassword("clinic#11"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "341 Su Van Hanh, Vuon Lai Ward, Ho Chi Minh City, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Nhi Dong 1 Clinic
            var nhidong1ClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = nhidong1ClinicId,
                UserId = nhidong1ClinicUserId,
                Address = "341 Su Van Hanh, Vuon Lai Ward, Ho Chi Minh City, Vietnam",
                Description = "A grade I pediatric specialty hospital, a frontline facility for pediatric healthcare for children from newborns to about 15 years old in Southern Vietnam. Departments include neonatology, respiratory, infectious diseases, cardiology, nutrition, neurology, diagnostic imaging, pediatric surgery, etc. Supports both health insurance and private service. No obstetrics/antenatal care for women, as it focuses solely on pediatrics.",
                IsInsuranceAccepted = true,
                Specializations = "Neonatology;Pediatric Respiratory – Asthma;Pediatric Infectious Diseases;Pediatric Cardiology;Pediatric Nephrology;Pediatric Neurology;Pediatric Nutrition;Pediatric Gastroenterology – Hepatology;Pediatric Imaging;General Pediatrics;Pediatric Surgery;Pediatric On-demand Consultation;Private Pediatric Services",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Nhi Dong 1 Doctor Users
            var nhidong1DoctorUser1Id = Guid.NewGuid();
            var nhidong1DoctorUser2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = nhidong1DoctorUser1Id,
                    UserName = "MSc. Dr. Nguyen Ngoc Bach",
                    Email = "nguyen.ngoc.bach@nhidong.org.vn",
                    PhoneNumber = "(028) 3927 1119",
                    Password = HashPassword("doctor#25"),
                    Address = "Pediatric On-demand Clinic – Nhi Dong 1",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = nhidong1DoctorUser2Id,
                    UserName = "Dr. Huynh Kim Anh",
                    Email = "huynh.kim.anh@nhidong.org.vn",
                    PhoneNumber = "(028) 3927 1119",
                    Password = HashPassword("doctor#26"),
                    Address = "Neonatology Department – Nhi Dong 1",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Nhi Dong 1 Doctors
            var nhidong1Doctor1Id = Guid.NewGuid();
            var nhidong1Doctor2Id = Guid.NewGuid();

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = nhidong1Doctor1Id,
                    UserId = nhidong1DoctorUser1Id,
                    ClinicId = nhidong1ClinicId,
                    Gender = "Male",
                    Specialization = "Pediatric On-demand Services",
                    Certificate = "Master’s Degree, Medical Specialist",
                    ExperienceYear = 20,
                    WorkPosition = "Senior Specialist Doctor",
                    Description = "Provides pediatric on-demand services and specialist consultations; available for scheduled appointments via Medpro.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = nhidong1Doctor2Id,
                    UserId = nhidong1DoctorUser2Id,
                    ClinicId = nhidong1ClinicId,
                    Gender = "Female",
                    Specialization = "Neonatology / Newborn Care",
                    Certificate = "Specialist Level I",
                    ExperienceYear = 15,
                    WorkPosition = "Neonatologist",
                    Description = "Provides newborn care, delivery support, and neonatal health monitoring.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Nhi Dong 1 Consultant User
            var nhidong1ConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = nhidong1ConsultantUserId,
                UserName = "CKII Dr. Tran Thi My Hanh",
                Email = "tran.my.hanh@nhidong.org.vn",
                PhoneNumber = "(028) 3927 1119",
                Password = HashPassword("consultant#17"),
                Address = "Infectious Diseases Department – Nhi Dong 1",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Nhi Dong 1 Consultant
            var nhidong1ConsultantId = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = nhidong1ConsultantId,
                UserId = nhidong1ConsultantUserId,
                ClinicId = nhidong1ClinicId,
                Specialization = "Pediatric Infectious Diseases",
                Certificate = "Specialist Level II",
                Gender = "Female",
                ExperienceYears = 25,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Nhi Dong 1 Feedbacks
            var nhidong1Feedback1Id = Guid.NewGuid();
            var nhidong1Feedback2Id = Guid.NewGuid();
            var nhidong1Feedback3Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = nhidong1Feedback1Id,
                    ClinicId = nhidong1ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 5,
                    Comment = "Very good pediatric care, friendly staff, but long waiting times for on-demand services.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = nhidong1Feedback2Id,
                    ClinicId = nhidong1ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 4,
                    Comment = "Modern pediatric equipment and top-tier doctors; however, the hospital is very crowded, making it difficult to book quick appointments.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = nhidong1Feedback3Id,
                    ClinicId = nhidong1ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 5,
                    Comment = "Booking via Medpro is convenient; service doctors are good — parents are satisfied.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );


            // Nhi Dong 2 Hospital

            // Seed Nhi Dong 2 Clinic User
            var nhidong2ClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = nhidong2ClinicUserId,
                UserName = "Nhi Dong 2 Hospital",
                Email = "contact@benhviennhi.org.vn",
                PhoneNumber = "(028) 3829 5723 / (028) 3829 5724",
                Password = HashPassword("clinic#12"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "14 Ly Tu Trong, Ben Nghe Ward, District 1, Ho Chi Minh City, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Nhi Dong 2 Clinic
            var nhidong2ClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = nhidong2ClinicId,
                UserId = nhidong2ClinicUserId,
                Address = "14 Ly Tu Trong, Ben Nghe Ward, District 1, Ho Chi Minh City, Vietnam",
                Description = "A grade I pediatric specialty hospital under the Ho Chi Minh City Department of Health, serving children from newborn to under 16 years old. Includes 38 clinical and subclinical departments, about 1,400 beds, modern equipment, providing internal and surgical treatment, private services, and high-quality on-demand clinics. No obstetrics/regular prenatal checkups for women since it specializes in pediatrics, but there is prenatal counseling when related to diagnosing congenital defects during pregnancy.",
                IsInsuranceAccepted = true,
                Specializations = "Pediatric Infectious Diseases;Neonatology;Pediatric Respiratory;Pediatric Cardiology;Pediatric Nephrology – Endocrinology;Pediatric Neurology;Pediatric Gastroenterology – Hepatology;Pediatric Oncology – Hematology;Pediatric Private Services;High-quality On-demand Clinics;General Pediatrics;Pediatric Imaging;Neonatal Intensive Care / Pediatric Toxicology;Pediatric Psychology;Pediatric Surgery",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Nhi Dong 2 Doctor User
            var nhidong2DoctorUser1Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = nhidong2DoctorUser1Id,
                UserName = "Dr. Le Thi Huong (sample)",
                Email = "le.thi.huong@benhviennhi.org.vn",
                PhoneNumber = "(028) 3829 5723",
                Password = HashPassword("doctor#27"),
                Address = "Child Health Department / On-demand Clinic, Nhi Dong 2",
                CreationDate = new DateTime(2025, 09, 05),
                RoleId = 7,
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Nhi Dong 2 Doctor
            var nhidong2Doctor1Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = nhidong2Doctor1Id,
                UserId = nhidong2DoctorUser1Id,
                ClinicId = nhidong2ClinicId,
                Gender = "Female",
                Specialization = "Pediatric Private Services",
                Certificate = "Specialist Level I",
                ExperienceYear = 12,
                WorkPosition = "Attending Doctor",
                Description = "Provides pediatric private consultations, general checkups, and scheduled pediatric visits.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 05)
            });

            // Seed Nhi Dong 2 Consultant Users
            var nhidong2ConsultantUser1Id = Guid.NewGuid();
            var nhidong2ConsultantUser2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = nhidong2ConsultantUser1Id,
                    UserName = "Dr. Phan Tan Duc",
                    Email = "phan.tan.duc@benhviennhi.org.vn",
                    PhoneNumber = "(028) 3829 5723",
                    Password = HashPassword("consultant#18"),
                    Address = "Nhi Dong 2 Hospital, District 1, HCMC",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = nhidong2ConsultantUser2Id,
                    UserName = "MSc. Dr. Nguyen Hong Van Khanh",
                    Email = "nguyen.hong.van.khanh@benhviennhi.org.vn",
                    PhoneNumber = "(028) 3829 5723",
                    Password = HashPassword("consultant#19"),
                    Address = "Nhi Dong 2 Hospital, Hepatobiliary – Pancreas Department",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Nhi Dong 2 Consultants
            var nhidong2Consultant1Id = Guid.NewGuid();
            var nhidong2Consultant2Id = Guid.NewGuid();

            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = nhidong2Consultant1Id,
                    UserId = nhidong2ConsultantUser1Id,
                    ClinicId = nhidong2ClinicId,
                    Specialization = "Pediatric Nephro-urology / Pediatric Urological Surgery",
                    Certificate = "Specialist Level II",
                    Gender = "Male",
                    ExperienceYears = 20,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = nhidong2Consultant2Id,
                    UserId = nhidong2ConsultantUser2Id,
                    ClinicId = nhidong2ClinicId,
                    Specialization = "Pediatric Hepatobiliary – Pancreas",
                    Certificate = "Master’s Degree, Medical Specialist",
                    Gender = "Female",
                    ExperienceYears = 15,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                }
            );

            // Seed Nhi Dong 2 Feedbacks
            var nhidong2Feedback1Id = Guid.NewGuid();
            var nhidong2Feedback2Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = nhidong2Feedback1Id,
                    ClinicId = nhidong2ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 10,
                    Comment = "Excellent pediatric care, friendly staff, but long waiting times in the morning due to many children.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = nhidong2Feedback2Id,
                    ClinicId = nhidong2ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "On-demand service clinic is clear and well-equipped; parents are satisfied.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );


            // Thu Duc City Hospital

            // Seed Thu Duc Clinic User
            var thuducClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = thuducClinicUserId,
                UserName = "Thu Duc City Hospital",
                Email = "bv.dkthuduc@tphcm.gov.vn",
                PhoneNumber = "09 6633 1010",
                Password = HashPassword("clinic#13"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "29 Phu Chau, Tam Phu Ward, Thu Duc City, Ho Chi Minh City, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Thu Duc Clinic
            var thuducClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = thuducClinicId,
                UserId = thuducClinicUserId,
                Address = "29 Phu Chau, Tam Phu Ward, Thu Duc City, Ho Chi Minh City, Vietnam",
                Description = "Thu Duc City Hospital is a Grade I hospital under the Ministry of Health standards, fully equipped with medical specialties (including Obstetrics & Gynecology), providing inpatient & outpatient services, high-quality healthcare, pregnancy check-ups, ultrasound, and reproductive health care. The Obstetrics Department has 15 doctors, 42 nurses, and 70 beds.",
                IsInsuranceAccepted = true,
                Specializations = "Antenatal check-ups / Obstetrics & Gynecology;Gynecology examination;Pregnancy ultrasound;Delivery & C-section;Prenatal counseling;Postnatal maternal care;Premium obstetrics services;Reproductive health check;On-demand services;Health insurance check",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Thu Duc Doctor Users
            var thuducDoctorUser1Id = Guid.NewGuid();
            var thuducDoctorUser2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = thuducDoctorUser1Id,
                    UserName = "Dr. Le Minh Thu",
                    Email = "le.minh.thu@bvthuduc.vn",
                    PhoneNumber = "09 6633 1010",
                    Password = HashPassword("doctor#29"),
                    Address = "Obstetrics Department, Thu Duc City Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = thuducDoctorUser2Id,
                    UserName = "Dr. Tran Thi Hanh",
                    Email = "tran.thi.hanh@bvthuduc.vn",
                    PhoneNumber = "09 6633 1010",
                    Password = HashPassword("doctor#30"),
                    Address = "Obstetrics Department, Thu Duc City Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Thu Duc Doctors
            var thuducDoctor1Id = Guid.NewGuid();
            var thuducDoctor2Id = Guid.NewGuid();

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = thuducDoctor1Id,
                    UserId = thuducDoctorUser1Id,
                    ClinicId = thuducClinicId,
                    Gender = "Female",
                    Specialization = "Antenatal check-ups / pregnancy counseling",
                    Certificate = "Specialist Doctor Level I",
                    ExperienceYear = 12,
                    WorkPosition = "Obstetrician & Gynecologist",
                    Description = "Performs antenatal check-ups, routine ultrasound, monitors normal pregnancy, and provides obstetrics & gynecology premium services.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = thuducDoctor2Id,
                    UserId = thuducDoctorUser2Id,
                    ClinicId = thuducClinicId,
                    Gender = "Female",
                    Specialization = "Pregnancy ultrasound / reproductive healthcare",
                    Certificate = "Specialist Doctor Level I",
                    ExperienceYear = 10,
                    WorkPosition = "Obstetric Ultrasound Specialist",
                    Description = "Responsible for pregnancy ultrasound, routine maternal health checks, and fetal development assessment.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Thu Duc Consultant Users
            var thuducConsultantUser1Id = Guid.NewGuid();
            var thuducConsultantUser2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = thuducConsultantUser1Id,
                    UserName = "Assoc. Prof. Dr. Nguyen Thi Ngoc Bich",
                    Email = "nguyen.thi.ngoc.bich@bvthuduc.vn",
                    PhoneNumber = "09 6633 1010",
                    Password = HashPassword("consultant#20"),
                    Address = "Obstetrics Department, Thu Duc City Hospital",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = thuducConsultantUser2Id,
                    UserName = "Assoc. Prof. Dr. Huynh Thi Kim Lien",
                    Email = "huynh.thi.kim.lien@bvthuduc.vn",
                    PhoneNumber = "09 6633 1010",
                    Password = HashPassword("consultant#21"),
                    Address = "Obstetrics Department, Thu Duc City Hospital",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Thu Duc Consultants
            var thuducConsultant1Id = Guid.NewGuid();
            var thuducConsultant2Id = Guid.NewGuid();

            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = thuducConsultant1Id,
                    UserId = thuducConsultantUser1Id,
                    ClinicId = thuducClinicId,
                    Specialization = "Obstetrics & Gynecology / pregnancy care / C-section",
                    Certificate = "Specialist Doctor Level II",
                    Gender = "Female",
                    ExperienceYears = 20,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = thuducConsultant2Id,
                    UserId = thuducConsultantUser2Id,
                    ClinicId = thuducClinicId,
                    Specialization = "Obstetrics & Gynecology / gynecology care / delivery",
                    Certificate = "Specialist Doctor Level II",
                    Gender = "Female",
                    ExperienceYears = 18,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                }
            );

            // Seed Thu Duc Feedbacks
            var thuducFeedback1Id = Guid.NewGuid();
            var thuducFeedback2Id = Guid.NewGuid();
            var thuducFeedback3Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = thuducFeedback1Id,
                    ClinicId = thuducClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Good antenatal check-ups, friendly doctors, relatively clean facilities.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = thuducFeedback2Id,
                    ClinicId = thuducClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Waiting time for OB-GYN check-up is a bit long, but overall service quality is good.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = thuducFeedback3Id,
                    ClinicId = thuducClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 10,
                    Comment = "Affordable obstetrics service fees, clear ultrasound results.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );


            // District 1 General Hospital

            // Seed District 1 Clinic User
            var quan1ClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = quan1ClinicUserId,
                UserName = "District 1 General Hospital",
                Email = "bvq1@bvq1.vn",
                PhoneNumber = "(028) 3820 6746",
                Password = HashPassword("clinic#14"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "Branch 1: 338 Hai Ba Trung, Tan Dinh Ward, District 1, HCMC; Branch 2: 235-237 Tran Hung Dao, Co Giang Ward, District 1, HCMC",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed District 1 Clinic
            var quan1ClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = quan1ClinicId,
                UserId = quan1ClinicUserId,
                Address = "Branch 1: 338 Hai Ba Trung, Tan Dinh Ward, District 1, HCMC; Branch 2: 235-237 Tran Hung Dao, Co Giang Ward, District 1, HCMC",
                Description = "District 1 General Hospital is a district-level general medical facility under the management of Ho Chi Minh City Department of Health. The hospital has multiple specialties, including Obstetrics & Gynecology (OB-GYN Department). Branch 2 has recently been put into operation to provide obstetrics and maternity care services to meet local demand.",
                IsInsuranceAccepted = true,
                Specializations = "Obstetrics & Gynecology / Antenatal check-ups;Gynecology examination;Pregnancy ultrasound;Prenatal testing / OB-GYN imaging;Reproductive health check;On-demand services;Health insurance examination;Internal medicine;Surgery;Emergency care",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed District 1 Doctor Users
            var quan1DoctorUser1Id = Guid.NewGuid();
            var quan1DoctorUser2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = quan1DoctorUser1Id,
                    UserName = "Dr. Le Thi Hoa",
                    Email = "le.thi.hoa@bvq1.vn",
                    PhoneNumber = "(028) 3820 6746",
                    Password = HashPassword("doctor#31"),
                    Address = "Obstetrics & Gynecology Department, District 1 Hospital - Branch 2",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = quan1DoctorUser2Id,
                    UserName = "Dr. Tran Van Dat",
                    Email = "tran.van.dat@bvq1.vn",
                    PhoneNumber = "(028) 3820 6746",
                    Password = HashPassword("doctor#32"),
                    Address = "General Clinic / Obstetrics & Gynecology Department, District 1 Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed District 1 Doctors
            var quan1Doctor1Id = Guid.NewGuid();
            var quan1Doctor2Id = Guid.NewGuid();

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = quan1Doctor1Id,
                    UserId = quan1DoctorUser1Id,
                    ClinicId = quan1ClinicId,
                    Gender = "Female",
                    Specialization = "Pregnancy ultrasound / delivery",
                    Certificate = "Specialist Doctor Level II",
                    ExperienceYear = 12,
                    WorkPosition = "Obstetrician & Gynecologist",
                    Description = "Performs antenatal check-ups, routine ultrasounds, and OB-GYN services at District 1 Hospital - Branch 2.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = quan1Doctor2Id,
                    UserId = quan1DoctorUser2Id,
                    ClinicId = quan1ClinicId,
                    Gender = "Male",
                    Specialization = "Gynecology examination / cervical cancer screening",
                    Certificate = "Specialist Doctor Level I",
                    ExperienceYear = 10,
                    WorkPosition = "Gynecologist",
                    Description = "Provides gynecological check-ups and reproductive health care for women at District 1 Hospital.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed District 1 Consultant User
            var quan1ConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = quan1ConsultantUserId,
                UserName = "Dr. Ngo Thi Anh Thu",
                Email = "ngo.thi.anhthu@bvq1.vn",
                PhoneNumber = "(028) 3820 6746",
                Password = HashPassword("consultant#22"),
                Address = "Obstetrics Department, District 1 Hospital - Branch 2",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed District 1 Consultant
            var quan1ConsultantId = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = quan1ConsultantId,
                UserId = quan1ConsultantUserId,
                ClinicId = quan1ClinicId,
                Specialization = "Obstetrics & Gynecology / Antenatal care & pregnancy counseling",
                Certificate = "Specialist Doctor Level I",
                Gender = "Female",
                ExperienceYears = 15,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed District 1 Feedbacks
            var quan1Feedback1Id = Guid.NewGuid();
            var quan1Feedback2Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = quan1Feedback1Id,
                    ClinicId = quan1ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Antenatal check-ups are acceptable, but not many specialized doctors yet, waiting time is a bit long.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = quan1Feedback2Id,
                    ClinicId = quan1ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "The new OB-GYN department at Branch 2 is improved, clean, and convenient.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );


            // District 3 Hospital

            // Seed District 3 Clinic User
            var district3ClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = district3ClinicUserId,
                UserName = "District 3 Hospital",
                Email = "bv.q3@tphcm.gov.vn",
                PhoneNumber = "0283 9310 400",
                Password = HashPassword("clinic#15"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "114-116-118 Tran Quoc Thao, Ward 7, District 3, Ho Chi Minh City, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed District 3 Clinic
            var district3ClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = district3ClinicId,
                UserId = district3ClinicUserId,
                Address = "114-116-118 Tran Quoc Thao, Ward 7, District 3, Ho Chi Minh City, Vietnam",
                Description = "District 3 Hospital is a Grade I general hospital under the Ho Chi Minh City Department of Health. It provides inpatient and outpatient services across multiple specialties, including Obstetrics and Gynecology (OB-GYN) and prenatal care. Established in 1992, the hospital is equipped with various diagnostic imaging machines, ultrasound, and laboratory testing facilities for OB-GYN services.",
                IsInsuranceAccepted = true,
                Specializations = "Routine prenatal check-ups / OB-GYN;Gynecology;Obstetric & fetal ultrasound;Prenatal / OB-GYN laboratory tests;Private maternity services;Reproductive health checkups;On-demand services;Health insurance consultations;General internal & surgical care;Diagnostic imaging;Toxicology & emergency resuscitation",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed District 3 Doctor Users
            var district3DoctorUser1Id = Guid.NewGuid();
            var district3DoctorUser2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = district3DoctorUser1Id,
                    UserName = "Dr. Nguyen Thi Thao",
                    Email = "nguyen.thi.thao@bvquan3.medinet.gov.vn",
                    PhoneNumber = "0283 9310 400",
                    Password = HashPassword("doctor#33"),
                    Address = "Obstetrics Department, District 3 Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = district3DoctorUser2Id,
                    UserName = "Dr. Le Van Hung",
                    Email = "le.van.hung@bvquan3.medinet.gov.vn",
                    PhoneNumber = "0283 9310 400",
                    Password = HashPassword("doctor#34"),
                    Address = "Obstetrics Department, District 3 Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed District 3 Doctors
            var district3Doctor1Id = Guid.NewGuid();
            var district3Doctor2Id = Guid.NewGuid();

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = district3Doctor1Id,
                    UserId = district3DoctorUser1Id,
                    ClinicId = district3ClinicId,
                    Gender = "Female",
                    Specialization = "OB-GYN / Prenatal care & delivery",
                    Certificate = "Specialist Level I Doctor",
                    ExperienceYear = 12,
                    WorkPosition = "OB-GYN Doctor",
                    Description = "Performs ultrasound, routine prenatal checkups, provides care for pregnant women and newborns after birth.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = district3Doctor2Id,
                    UserId = district3DoctorUser2Id,
                    ClinicId = district3ClinicId,
                    Gender = "Male",
                    Specialization = "Obstetric ultrasound / Pregnancy monitoring",
                    Certificate = "Specialist Level I Doctor",
                    ExperienceYear = 15,
                    WorkPosition = "OB-GYN Ultrasound Doctor",
                    Description = "Performs fetal anomaly scans, evaluates fetal heart, placenta, and amniotic fluid; conducts routine prenatal checkups.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed District 3 Consultant User
            var district3ConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = district3ConsultantUserId,
                UserName = "MSc. Dr. Ha Thi Lien Chi",
                Email = "ha.thi.lienchi@bvquan3.medinet.gov.vn",
                PhoneNumber = "0283 9310 400",
                Password = HashPassword("consultant#23"),
                Address = "Obstetrics Department, District 3 Hospital",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed District 3 Consultant
            var district3ConsultantId = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = district3ConsultantId,
                UserId = district3ConsultantUserId,
                ClinicId = district3ClinicId,
                Specialization = "OB-GYN / Prenatal consultations",
                Certificate = "Master's Degree, Specialist Level I Doctor",
                Gender = "Female",
                ExperienceYears = 20,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed District 3 Feedbacks
            var district3Feedback1Id = Guid.NewGuid();
            var district3Feedback2Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = district3Feedback1Id,
                    ClinicId = district3ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "OB-GYN checkup was good, doctors are attentive; however, the waiting area is small and wait time is long.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = district3Feedback2Id,
                    ClinicId = district3ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Clear ultrasound images, friendly obstetrics staff, I’m satisfied with the maternity service.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );


            // District 7 Hospital

            // Seed District 7 Clinic User
            var quan7ClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = quan7ClinicUserId,
                UserName = "District 7 Hospital",
                Email = "bv.q7@tphcm.gov.vn",
                PhoneNumber = "0283 7730 777",
                Password = HashPassword("clinic#16"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "101 Nguyen Thi Thap, Tan Phu Ward, District 7, Ho Chi Minh City, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed District 7 Clinic
            var quan7ClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = quan7ClinicId,
                UserId = quan7ClinicUserId,
                Address = "101 Nguyen Thi Thap, Tan Phu Ward, District 7, Ho Chi Minh City, Vietnam",
                Description = "District 7 Hospital is a grade II general hospital under the Department of Health of Ho Chi Minh City. The hospital provides a wide range of medical services, especially Obstetrics & Gynecology, including antenatal check-ups, pregnancy ultrasound, prenatal counseling, and reproductive healthcare. It is a popular choice for pregnant women in District 7 and South Saigon thanks to its convenient location and reasonable cost.",
                IsInsuranceAccepted = true,
                Specializations = "Antenatal check-ups;Obstetric ultrasound;Gynecology examination;Reproductive healthcare;Prenatal counseling;Delivery & postpartum care;Health insurance services;Private medical services;Pediatrics;General internal & surgery",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed District 7 Doctor Users
            var quan7DoctorUser1Id = Guid.NewGuid();
            var quan7DoctorUser2Id = Guid.NewGuid();
            var quan7DoctorUser3Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = quan7DoctorUser1Id,
                    UserName = "Dr. Tran Thanh Tung",
                    Email = "thanh.tung@bvquan7.medinet.gov.vn",
                    PhoneNumber = "0283 7730 777",
                    Password = HashPassword("doctor#35"),
                    Address = "Obstetrics Department, District 7 Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = quan7DoctorUser2Id,
                    UserName = "Dr. Le Thi Minh Thu",
                    Email = "minh.thu@bvquan7.medinet.gov.vn",
                    PhoneNumber = "0283 7730 777",
                    Password = HashPassword("doctor#36"),
                    Address = "Obstetrics Department, District 7 Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = quan7DoctorUser3Id,
                    UserName = "Dr. Vo Van Nhan",
                    Email = "van.nhan@bvquan7.medinet.gov.vn",
                    PhoneNumber = "0283 7730 777",
                    Password = HashPassword("doctor#37"),
                    Address = "Obstetrics Department, District 7 Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed District 7 Doctors
            var quan7Doctor1Id = Guid.NewGuid();
            var quan7Doctor2Id = Guid.NewGuid();
            var quan7Doctor3Id = Guid.NewGuid();

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = quan7Doctor1Id,
                    UserId = quan7DoctorUser1Id,
                    ClinicId = quan7ClinicId,
                    Gender = "Male",
                    Specialization = "Delivery, obstetric & gynecologic surgery",
                    Certificate = "Specialist Level II in Obstetrics & Gynecology",
                    ExperienceYear = 20,
                    WorkPosition = "Head of Obstetrics Department",
                    Description = "Specialized in delivery, cesarean section, high-risk pregnancy management, and antenatal care.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = quan7Doctor2Id,
                    UserId = quan7DoctorUser2Id,
                    ClinicId = quan7ClinicId,
                    Gender = "Female",
                    Specialization = "Pregnancy ultrasound & prenatal diagnosis",
                    Certificate = "Specialist Level I",
                    ExperienceYear = 12,
                    WorkPosition = "Obstetric Sonographer",
                    Description = "Performs fetal morphology ultrasound, congenital anomaly counseling, and monitoring of fetal growth.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = quan7Doctor3Id,
                    UserId = quan7DoctorUser3Id,
                    ClinicId = quan7ClinicId,
                    Gender = "Male",
                    Specialization = "Gynecology & reproductive health",
                    Certificate = "Specialist Level I in Obstetrics & Gynecology",
                    ExperienceYear = 14,
                    WorkPosition = "Obstetrician-Gynecologist",
                    Description = "Provides antenatal check-ups, treats gynecological diseases, and gives reproductive health counseling.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed District 7 Consultant Users
            var quan7ConsultantUser1Id = Guid.NewGuid();
            var quan7ConsultantUser2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = quan7ConsultantUser1Id,
                    UserName = "MSc. Dr. Nguyen Thi Bich Van",
                    Email = "bich.van@bvquan7.medinet.gov.vn",
                    PhoneNumber = "0283 7730 777",
                    Password = HashPassword("consultant#24"),
                    Address = "Obstetrics Department, District 7 Hospital",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = quan7ConsultantUser2Id,
                    UserName = "Specialist I. Dr. Phan Thi Hong Tham",
                    Email = "hong.tham@bvquan7.medinet.gov.vn",
                    PhoneNumber = "0283 7730 777",
                    Password = HashPassword("consultant#25"),
                    Address = "Obstetrics Department, District 7 Hospital",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed District 7 Consultants
            var quan7Consultant1Id = Guid.NewGuid();
            var quan7Consultant2Id = Guid.NewGuid();

            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = quan7Consultant1Id,
                    UserId = quan7ConsultantUser1Id,
                    ClinicId = quan7ClinicId,
                    Specialization = "Obstetrics & Gynecology",
                    Certificate = "Master of Medicine, Specialist Level I in Obstetrics & Gynecology",
                    Gender = "Female",
                    ExperienceYears = 18,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = quan7Consultant2Id,
                    UserId = quan7ConsultantUser2Id,
                    ClinicId = quan7ClinicId,
                    Specialization = "Antenatal care & prenatal counseling",
                    Certificate = "Specialist Level I",
                    Gender = "Female",
                    ExperienceYears = 15,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                }
            );

            // Seed District 7 Feedbacks
            var quan7Feedback1Id = Guid.NewGuid();
            var quan7Feedback2Id = Guid.NewGuid();
            var quan7Feedback3Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = quan7Feedback1Id,
                    ClinicId = quan7ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "The obstetricians are very dedicated. I feel reassured having my antenatal check-ups here because the cost is reasonable and services are good.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = quan7Feedback2Id,
                    ClinicId = quan7ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "The maternity staff have a good attitude. Having female doctors makes me feel more comfortable during pregnancy check-ups.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = quan7Feedback3Id,
                    ClinicId = quan7ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "The facilities are not as modern as international hospitals, but the obstetrics & gynecology services are reliable.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );


            // Go Vap District Hospital

            // Seed Go Vap Clinic User
            var govapClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = govapClinicUserId,
                UserName = "Go Vap District Hospital",
                Email = "bv.govap@tphcm.gov.vn",
                PhoneNumber = "0283 8944 160",
                Password = HashPassword("clinic#17"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "212 Le Duc Tho, Ward 15, Go Vap District, Ho Chi Minh City, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Go Vap Clinic
            var govapClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = govapClinicId,
                UserId = govapClinicUserId,
                Address = "212 Le Duc Tho, Ward 15, Go Vap District, Ho Chi Minh City, Vietnam",
                Description = "Go Vap District Hospital is a Grade II general hospital under the HCMC Department of Health. The hospital is strong in multidisciplinary treatment, especially in Obstetrics & Gynecology with services such as prenatal check-ups, ultrasounds, antenatal counseling, and maternal & child healthcare for residents of Go Vap and nearby areas.",
                IsInsuranceAccepted = true,
                Specializations = "Prenatal check-ups;Obstetric ultrasound;Gynecology check-ups;Reproductive health check-ups;Antenatal counseling;Delivery and postpartum care;Health insurance (BHYT) services;On-demand services;Pediatrics;General internal medicine",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Go Vap Doctor Users
            var govapDoctorUser1Id = Guid.NewGuid();
            var govapDoctorUser2Id = Guid.NewGuid();
            var govapDoctorUser3Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = govapDoctorUser1Id,
                    UserName = "Specialist II. Dr. Le Thi My Duyen",
                    Email = "my.duyen@bvquan-govap.medinet.gov.vn",
                    PhoneNumber = "0283 8944 160",
                    Password = HashPassword("doctor#38"),
                    Address = "Obstetrics Department, Go Vap District Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = govapDoctorUser2Id,
                    UserName = "Dr. Hoang Thi Kieu Oanh",
                    Email = "kieu.oanh@bvquan-govap.medinet.gov.vn",
                    PhoneNumber = "0283 8944 160",
                    Password = HashPassword("doctor#39"),
                    Address = "Obstetrics Department, Go Vap District Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = govapDoctorUser3Id,
                    UserName = "Dr. Dang Van Toan",
                    Email = "van.toan@bvquan-govap.medinet.gov.vn",
                    PhoneNumber = "0283 8944 160",
                    Password = HashPassword("doctor#40"),
                    Address = "Obstetrics Department, Go Vap District Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Go Vap Doctors
            var govapDoctor1Id = Guid.NewGuid();
            var govapDoctor2Id = Guid.NewGuid();
            var govapDoctor3Id = Guid.NewGuid();

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = govapDoctor1Id,
                    UserId = govapDoctorUser1Id,
                    ClinicId = govapClinicId,
                    Gender = "Female",
                    Specialization = "Obstetric surgery",
                    Certificate = "Specialist II in Obstetrics & Gynecology",
                    ExperienceYear = 22,
                    WorkPosition = "Head of Obstetrics Department",
                    Description = "Specialized in obstetric surgery, C-sections, managing high-risk pregnancies, and treating gynecological conditions.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = govapDoctor2Id,
                    UserId = govapDoctorUser2Id,
                    ClinicId = govapClinicId,
                    Gender = "Female",
                    Specialization = "Obstetric ultrasound",
                    Certificate = "Specialist I in Obstetrics & Gynecology",
                    ExperienceYear = 10,
                    WorkPosition = "Ultrasound Doctor",
                    Description = "Performs routine prenatal ultrasounds, prenatal diagnosis, and pregnancy monitoring.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = govapDoctor3Id,
                    UserId = govapDoctorUser3Id,
                    ClinicId = govapClinicId,
                    Gender = "Male",
                    Specialization = "Gynecology & Family Planning",
                    Certificate = "Specialist I in Obstetrics & Gynecology",
                    ExperienceYear = 15,
                    WorkPosition = "Obstetrician-Gynecologist",
                    Description = "Provides gynecological examinations, treatment of infections, reproductive health counseling, and family planning services.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Go Vap Consultant Users
            var govapConsultantUser1Id = Guid.NewGuid();
            var govapConsultantUser2Id = Guid.NewGuid();
            var govapConsultantUser3Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = govapConsultantUser1Id,
                    UserName = "MSc. Dr. Nguyen Thi Hong Nhung",
                    Email = "hong.nhung@bvquan-govap.medinet.gov.vn",
                    PhoneNumber = "0283 8944 160",
                    Password = HashPassword("consultant#26"),
                    Address = "Obstetrics Department, Go Vap District Hospital",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = govapConsultantUser2Id,
                    UserName = "Specialist I. Dr. Tran Minh Thao",
                    Email = "minh.thao@bvquan-govap.medinet.gov.vn",
                    PhoneNumber = "0283 8944 160",
                    Password = HashPassword("consultant#27"),
                    Address = "Obstetrics Department, Go Vap District Hospital",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = govapConsultantUser3Id,
                    UserName = "Dr. Phan Quoc Thai",
                    Email = "quoc.thai@bvquan-govap.medinet.gov.vn",
                    PhoneNumber = "0283 8944 160",
                    Password = HashPassword("consultant#28"),
                    Address = "Obstetrics Department, Go Vap District Hospital",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Go Vap Consultants
            var govapConsultant1Id = Guid.NewGuid();
            var govapConsultant2Id = Guid.NewGuid();
            var govapConsultant3Id = Guid.NewGuid();

            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = govapConsultant1Id,
                    UserId = govapConsultantUser1Id,
                    ClinicId = govapClinicId,
                    Specialization = "Prenatal check-ups & OB-GYN counseling",
                    Certificate = "Master of Medicine, Specialist I in Obstetrics & Gynecology",
                    Gender = "Female",
                    ExperienceYears = 17,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = govapConsultant2Id,
                    UserId = govapConsultantUser2Id,
                    ClinicId = govapClinicId,
                    Specialization = "Antenatal counseling",
                    Certificate = "Specialist I in Obstetrics & Gynecology",
                    Gender = "Female",
                    ExperienceYears = 12,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = govapConsultant3Id,
                    UserId = govapConsultantUser3Id,
                    ClinicId = govapClinicId,
                    Specialization = "Reproductive health check-ups",
                    Certificate = "General Practitioner, Specialist I in Obstetrics & Gynecology",
                    Gender = "Male",
                    ExperienceYears = 13,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                }
            );

            // Seed Go Vap Feedbacks
            var govapFeedback1Id = Guid.NewGuid();
            var govapFeedback2Id = Guid.NewGuid();
            var govapFeedback3Id = Guid.NewGuid();
            var govapFeedback4Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = govapFeedback1Id,
                    ClinicId = govapClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "I had prenatal check-ups here, the doctor gave thorough advice, costs were reasonable, and health insurance was accepted.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = govapFeedback2Id,
                    ClinicId = govapClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "There are many female doctors and nurses, which made me feel more comfortable for gynecological exams.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = govapFeedback3Id,
                    ClinicId = govapClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "The hospital was crowded, had to wait, but doctors were enthusiastic and attentive.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = govapFeedback4Id,
                    ClinicId = govapClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "I gave birth here, doctors were very dedicated, services were good, and I felt safe.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );


            // Binh Thanh District Hospital

            // Seed Binh Thanh Clinic User
            var binhthanhClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = binhthanhClinicUserId,
                UserName = "Binh Thanh District Hospital",
                Email = "bv.binhthanh@tphcm.gov.vn",
                PhoneNumber = "0283 8411 283",
                Password = HashPassword("clinic#18"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "112 Bui Huu Nghia, Ward 2, Binh Thanh District, Ho Chi Minh City, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Binh Thanh Clinic
            var binhthanhClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = binhthanhClinicId,
                UserId = binhthanhClinicUserId,
                Address = "112 Bui Huu Nghia, Ward 2, Binh Thanh District, Ho Chi Minh City, Vietnam",
                Description = "Binh Thanh District Hospital is a grade II general hospital under the Ho Chi Minh City Department of Health. With more than 300 inpatient beds, the hospital meets the healthcare needs of local residents. The Obstetrics and Gynecology Department is one of its main specialties, providing antenatal check-ups, ultrasound, prenatal counseling, and maternal-child healthcare services.",
                IsInsuranceAccepted = true,
                Specializations = "Antenatal check-ups;Obstetric ultrasound;Gynecology consultation;Prenatal counseling;Reproductive health care;Delivery and postpartum care;On-demand medical services;Health insurance services;Pediatrics;General internal medicine",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Binh Thanh Doctor Users
            var binhthanhDoctorUser1Id = Guid.NewGuid();
            var binhthanhDoctorUser2Id = Guid.NewGuid();
            var binhthanhDoctorUser3Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = binhthanhDoctorUser1Id,
                    UserName = "Assoc. Prof. Dr. Le Thi Bich Hanh",
                    Email = "bich.hanh@bvbinhthanh.medinet.gov.vn",
                    PhoneNumber = "0283 8411 283",
                    Password = HashPassword("doctor#41"),
                    Address = "Obstetrics Department, Binh Thanh District Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = binhthanhDoctorUser2Id,
                    UserName = "Dr. Nguyen Minh Thu",
                    Email = "minh.thu@bvbinhthanh.medinet.gov.vn",
                    PhoneNumber = "0283 8411 283",
                    Password = HashPassword("doctor#42"),
                    Address = "Obstetrics Department, Binh Thanh District Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = binhthanhDoctorUser3Id,
                    UserName = "Dr. Tran Quoc Khanh",
                    Email = "quoc.khanh@bvbinhthanh.medinet.gov.vn",
                    PhoneNumber = "0283 8411 283",
                    Password = HashPassword("doctor#43"),
                    Address = "Obstetrics Department, Binh Thanh District Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Binh Thanh Doctors
            var binhthanhDoctor1Id = Guid.NewGuid();
            var binhthanhDoctor2Id = Guid.NewGuid();
            var binhthanhDoctor3Id = Guid.NewGuid();

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = binhthanhDoctor1Id,
                    UserId = binhthanhDoctorUser1Id,
                    ClinicId = binhthanhClinicId,
                    Gender = "Female",
                    Specialization = "Obstetric and gynecologic surgery",
                    Certificate = "Assoc. Prof. in Obstetrics & Gynecology",
                    ExperienceYear = 23,
                    WorkPosition = "Head of Obstetrics Department",
                    Description = "Specializes in C-sections, high-risk obstetrics, and complex gynecologic treatments.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = binhthanhDoctor2Id,
                    UserId = binhthanhDoctorUser2Id,
                    ClinicId = binhthanhClinicId,
                    Gender = "Female",
                    Specialization = "Prenatal ultrasound & diagnosis",
                    Certificate = "Specialist Level I",
                    ExperienceYear = 11,
                    WorkPosition = "Ultrasound Doctor",
                    Description = "Performs fetal morphology scans, congenital anomaly counseling, and fetal growth monitoring.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = binhthanhDoctor3Id,
                    UserId = binhthanhDoctorUser3Id,
                    ClinicId = binhthanhClinicId,
                    Gender = "Male",
                    Specialization = "Gynecology & infection treatment",
                    Certificate = "Specialist Level I in Obstetrics & Gynecology",
                    ExperienceYear = 16,
                    WorkPosition = "Obstetrician-Gynecologist",
                    Description = "Provides gynecological examinations, infection treatments, family planning, and reproductive health counseling.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Binh Thanh Consultant Users
            var binhthanhConsultantUser1Id = Guid.NewGuid();
            var binhthanhConsultantUser2Id = Guid.NewGuid();
            var binhthanhConsultantUser3Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = binhthanhConsultantUser1Id,
                    UserName = "MSc. Dr. Nguyen Thi Kim Anh",
                    Email = "kim.anh@bvbinhthanh.medinet.gov.vn",
                    PhoneNumber = "0283 8411 283",
                    Password = HashPassword("consultant#29"),
                    Address = "Obstetrics Department, Binh Thanh District Hospital",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = binhthanhConsultantUser2Id,
                    UserName = "Specialist I Dr. Vo Thi Thu Trang",
                    Email = "thu.trang@bvbinhthanh.medinet.gov.vn",
                    PhoneNumber = "0283 8411 283",
                    Password = HashPassword("consultant#30"),
                    Address = "Obstetrics Department, Binh Thanh District Hospital",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = binhthanhConsultantUser3Id,
                    UserName = "Dr. Phan Minh Huy",
                    Email = "minh.huy@bvbinhthanh.medinet.gov.vn",
                    PhoneNumber = "0283 8411 283",
                    Password = HashPassword("consultant#31"),
                    Address = "Obstetrics Department, Binh Thanh District Hospital",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Binh Thanh Consultants
            var binhthanhConsultant1Id = Guid.NewGuid();
            var binhthanhConsultant2Id = Guid.NewGuid();
            var binhthanhConsultant3Id = Guid.NewGuid();

            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = binhthanhConsultant1Id,
                    UserId = binhthanhConsultantUser1Id,
                    ClinicId = binhthanhClinicId,
                    Specialization = "Antenatal care & prenatal counseling",
                    Certificate = "Master of Medicine, Specialist Level I in Obstetrics & Gynecology",
                    Gender = "Female",
                    ExperienceYears = 18,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = binhthanhConsultant2Id,
                    UserId = binhthanhConsultantUser2Id,
                    ClinicId = binhthanhClinicId,
                    Specialization = "Reproductive health consultation",
                    Certificate = "Specialist Level I",
                    Gender = "Female",
                    ExperienceYears = 14,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = binhthanhConsultant3Id,
                    UserId = binhthanhConsultantUser3Id,
                    ClinicId = binhthanhClinicId,
                    Specialization = "Family planning counseling",
                    Certificate = "General Practitioner, Specialist Level I in Obstetrics & Gynecology",
                    Gender = "Male",
                    ExperienceYears = 12,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                }
            );

            // Seed Binh Thanh Feedbacks
            var binhthanhFeedback1Id = Guid.NewGuid();
            var binhthanhFeedback2Id = Guid.NewGuid();
            var binhthanhFeedback3Id = Guid.NewGuid();
            var binhthanhFeedback4Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = binhthanhFeedback1Id,
                    ClinicId = binhthanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "The hospital is clean, obstetricians provide thorough counseling, especially suitable for pregnant women in Binh Thanh.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = binhthanhFeedback2Id,
                    ClinicId = binhthanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "The female doctor doing the ultrasound was gentle, which made me feel comfortable and reassured.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = binhthanhFeedback3Id,
                    ClinicId = binhthanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "The hospital is quite crowded, but the nurses and obstetricians are very dedicated.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = binhthanhFeedback4Id,
                    ClinicId = binhthanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 10,
                    Comment = "I gave birth here, the doctors are skilled, quick handling, and the cost is more reasonable compared to private hospitals.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );


            // Binh Tan District Hospital

            // Seed Binh Tan District Clinic User
            var binhtanClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = binhtanClinicUserId,
                UserName = "Binh Tan District Hospital",
                Email = "bvbinhtan@tphcm.gov.vn",
                PhoneNumber = "0283 7520 427",
                Password = HashPassword("clinic#19"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "638 Ten Lua Street, Binh Tri Dong B Ward, Binh Tan District, Ho Chi Minh City, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Binh Tan District Clinic
            var binhtanClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = binhtanClinicId,
                UserId = binhtanClinicUserId,
                Address = "638 Ten Lua Street, Binh Tri Dong B Ward, Binh Tan District, Ho Chi Minh City, Vietnam",
                Description = "Binh Tan District Hospital is a grade II general hospital with more than 300 beds. The Obstetrics and Gynecology Department provides antenatal check-ups, ultrasounds, prenatal counseling, reproductive health care, and safe and friendly delivery services for pregnant women.",
                IsInsuranceAccepted = true,
                Specializations = "Regular antenatal check-ups;Obstetric ultrasound;Gynecology examination;Prenatal counseling;Reproductive health care;Normal delivery and cesarean section;Postpartum follow-up;Family planning;Health insurance services;Private medical services",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Binh Tan District Doctor Users
            var binhtanDoctorUser1Id = Guid.NewGuid();
            var binhtanDoctorUser2Id = Guid.NewGuid();
            var binhtanDoctorUser3Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = binhtanDoctorUser1Id,
                    UserName = "Assoc. Prof. Dr. Nguyen Thi Thanh Tam",
                    Email = "thanh.tam@bvbinhtan.medinet.gov.vn",
                    PhoneNumber = "0283 7520 427",
                    Password = HashPassword("doctor#44"),
                    Address = "Obstetrics Department, Binh Tan District Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = binhtanDoctorUser2Id,
                    UserName = "Dr. Phan Huu Loc",
                    Email = "huu.loc@bvbinhtan.medinet.gov.vn",
                    PhoneNumber = "0283 7520 427",
                    Password = HashPassword("doctor#45"),
                    Address = "Obstetrics Department, Binh Tan District Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = binhtanDoctorUser3Id,
                    UserName = "Dr. Dang Thi Thu Trang",
                    Email = "thu.trang@bvbinhtan.medinet.gov.vn",
                    PhoneNumber = "0283 7520 427",
                    Password = HashPassword("doctor#46"),
                    Address = "Obstetrics Department, Binh Tan District Hospital",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Binh Tan District Doctors
            var binhtanDoctor1Id = Guid.NewGuid();
            var binhtanDoctor2Id = Guid.NewGuid();
            var binhtanDoctor3Id = Guid.NewGuid();

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = binhtanDoctor1Id,
                    UserId = binhtanDoctorUser1Id,
                    ClinicId = binhtanClinicId,
                    Gender = "Female",
                    Specialization = "Obstetric and gynecological surgery",
                    Certificate = "Associate Professor, PhD in Obstetrics and Gynecology",
                    ExperienceYear = 22,
                    WorkPosition = "Head of Obstetrics Department",
                    Description = "Specializes in delivery, cesarean section, managing complex obstetric and gynecological cases, and postpartum care.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = binhtanDoctor2Id,
                    UserId = binhtanDoctorUser2Id,
                    ClinicId = binhtanClinicId,
                    Gender = "Male",
                    Specialization = "Ultrasound & fetal imaging diagnosis",
                    Certificate = "Specialist Level I in Obstetrics and Gynecology",
                    ExperienceYear = 14,
                    WorkPosition = "Ultrasound doctor",
                    Description = "Specializes in fetal morphology ultrasound and monitoring high-risk pregnancies.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = binhtanDoctor3Id,
                    UserId = binhtanDoctorUser3Id,
                    ClinicId = binhtanClinicId,
                    Gender = "Female",
                    Specialization = "Gynecology examination",
                    Certificate = "Specialist Level I",
                    ExperienceYear = 9,
                    WorkPosition = "Obstetrician and Gynecologist",
                    Description = "Examination and treatment of gynecological diseases, infections, and reproductive health counseling.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Binh Tan District Consultant Users
            var binhtanConsultantUser1Id = Guid.NewGuid();
            var binhtanConsultantUser2Id = Guid.NewGuid();
            var binhtanConsultantUser3Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = binhtanConsultantUser1Id,
                    UserName = "Dr. Tran Thi Thu Ha",
                    Email = "thu.ha@bvbinhtan.medinet.gov.vn",
                    PhoneNumber = "0283 7520 427",
                    Password = HashPassword("consultant#32"),
                    Address = "Obstetrics Department, Binh Tan District Hospital",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = binhtanConsultantUser2Id,
                    UserName = "Dr. Le Minh Tuan",
                    Email = "minh.tuan@bvbinhtan.medinet.gov.vn",
                    PhoneNumber = "0283 7520 427",
                    Password = HashPassword("consultant#33"),
                    Address = "Obstetrics Department, Binh Tan District Hospital",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = binhtanConsultantUser3Id,
                    UserName = "Dr. Ngo Thi Phuong Linh",
                    Email = "phuong.linh@bvbinhtan.medinet.gov.vn",
                    PhoneNumber = "0283 7520 427",
                    Password = HashPassword("consultant#34"),
                    Address = "Obstetrics Department, Binh Tan District Hospital",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Binh Tan District Consultants
            var binhtanConsultant1Id = Guid.NewGuid();
            var binhtanConsultant2Id = Guid.NewGuid();
            var binhtanConsultant3Id = Guid.NewGuid();

            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = binhtanConsultant1Id,
                    UserId = binhtanConsultantUser1Id,
                    ClinicId = binhtanClinicId,
                    Specialization = "Antenatal check-ups & prenatal counseling",
                    Certificate = "Specialist Level I in Obstetrics and Gynecology",
                    Gender = "Female",
                    ExperienceYears = 15,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = binhtanConsultant2Id,
                    UserId = binhtanConsultantUser2Id,
                    ClinicId = binhtanClinicId,
                    Specialization = "High-risk pregnancy counseling",
                    Certificate = "General practitioner, Specialist Level I in Obstetrics and Gynecology",
                    Gender = "Male",
                    ExperienceYears = 13,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = binhtanConsultant3Id,
                    UserId = binhtanConsultantUser3Id,
                    ClinicId = binhtanClinicId,
                    Specialization = "Reproductive health & family planning counseling",
                    Certificate = "Specialist Level I",
                    Gender = "Female",
                    ExperienceYears = 10,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                }
            );

            // Seed Binh Tan District Feedbacks
            var binhtanFeedback1Id = Guid.NewGuid();
            var binhtanFeedback2Id = Guid.NewGuid();
            var binhtanFeedback3Id = Guid.NewGuid();
            var binhtanFeedback4Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = binhtanFeedback1Id,
                    ClinicId = binhtanClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "The obstetricians and gynecologists here are very dedicated and provide thorough counseling during antenatal check-ups.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = binhtanFeedback2Id,
                    ClinicId = binhtanClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "I gave birth at this hospital, the service was good and the cost was reasonable.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = binhtanFeedback3Id,
                    ClinicId = binhtanClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "I felt reassured having an ultrasound here, the doctor explained everything clearly for expectant mothers.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = binhtanFeedback4Id,
                    ClinicId = binhtanClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Although the hospital is crowded, the staff provides quick support, so waiting time is not too long.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );


            // Van Hanh General Hospital

            // Seed Van Hanh Clinic User
            var vanhanhClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = vanhanhClinicUserId,
                UserName = "Van Hanh General Hospital",
                Email = "benhvienvanhanh@gmail.com",
                PhoneNumber = "(+84) 028 3863 2553",
                Password = HashPassword("clinic#20"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "781/B1-B3-B5 Le Hong Phong, Ward 12, District 10, Ho Chi Minh City, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Van Hanh Clinic
            var vanhanhClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = vanhanhClinicId,
                UserId = vanhanhClinicUserId,
                Address = "781/B1-B3-B5 Le Hong Phong, Ward 12, District 10, Ho Chi Minh City, Vietnam",
                Description = "Van Hanh General Hospital is a reputable private hospital in District 10, Ho Chi Minh City, established in 2000, with a wide scale of hospital beds and highly specialized medical staff. The Obstetrics and Gynecology Department is well-known for comprehensive maternity packages, prenatal check-ups, 4D ultrasound, antenatal counseling, fetal malformation screening, maternal and newborn care. The hospital focuses strongly on modern equipment and infertility treatment services.",
                IsInsuranceAccepted = true,
                Specializations = "Routine prenatal check-ups;Obstetric ultrasound (2D, 3D, 4D);Gynecological examination;Prenatal counseling;Fetal malformation screening;Comprehensive delivery package;Infertility / assisted reproduction;Maternal & postpartum care;Obstetrics & gynecology service examination;Outpatient & inpatient obstetrics;On-demand medical services;Health insurance examination",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Van Hanh Doctor User
            var vanhanhDoctorUser1Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = vanhanhDoctorUser1Id,
                UserName = "Dr. Vuong Thi Ngoc Lan",
                Email = "doctorVanHanh@gmail.com",
                PhoneNumber = "(+84) 028 3863 2553",
                Password = HashPassword("doctor#47"),
                Address = "Infertility / Obstetrics & Gynecology Department, Van Hanh General Hospital",
                CreationDate = new DateTime(2025, 09, 05),
                RoleId = 7,
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Van Hanh Doctor
            var vanhanhDoctor1Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = vanhanhDoctor1Id,
                UserId = vanhanhDoctorUser1Id,
                ClinicId = vanhanhClinicId,
                Gender = "Female",
                Specialization = "Infertility, routine prenatal check-ups",
                Certificate = "Specialist in Obstetrics and Gynecology",
                ExperienceYear = 20,
                WorkPosition = "Doctor / Infertility Specialist",
                Description = "A highly recognized doctor in the infertility field at Van Hanh; also provides routine prenatal and gynecological consultations.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 05)
            });

            // Seed Van Hanh Consultant User
            var vanhanhConsultantUser1Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = vanhanhConsultantUser1Id,
                UserName = "Dr. Phung Huy Tuan",
                Email = "consultantVanHanh@gmail.com",
                PhoneNumber = "(+84) 028 3863 2553",
                Password = HashPassword("consultant#35"),
                Address = "3rd-4th Floor, Van Hanh General Hospital, 700 Su Van Hanh Extension, Ward 12, District 10, Ho Chi Minh City",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Van Hanh Consultant
            var vanhanhConsultant1Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = vanhanhConsultant1Id,
                UserId = vanhanhConsultantUser1Id,
                ClinicId = vanhanhClinicId,
                Specialization = "Infertility / IVF",
                Certificate = "Specialist in Obstetrics and Gynecology",
                Gender = "Male",
                ExperienceYears = 20,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Van Hanh Feedbacks
            var vanhanhFeedback1Id = Guid.NewGuid();
            var vanhanhFeedback2Id = Guid.NewGuid();
            var vanhanhFeedback3Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = vanhanhFeedback1Id,
                    ClinicId = vanhanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Good maternity service, attentive doctors. Comprehensive delivery package cost at Van Hanh is more affordable compared to many international hospitals.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = vanhanhFeedback2Id,
                    ClinicId = vanhanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "High-quality delivery and inpatient maternity rooms, friendly staff.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = vanhanhFeedback3Id,
                    ClinicId = vanhanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Infertility service at Van Hanh is well rated; however, the scheduling and paperwork process involves quite a few steps.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );


            // Mekong Obstetrics and Gynecology Hospital

            // Seed Mekong Clinic User
            var mekongClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = mekongClinicUserId,
                UserName = "Mekong Obstetrics and Gynecology Hospital",
                Email = "info@mekonghospital.vn",
                PhoneNumber = "(84-28) 3844 2986 / 3844 2988",
                Password = HashPassword("clinic#21"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "243-243A-243B Hoang Van Thu Street, Ward 1, Tan Binh District, Ho Chi Minh City, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Mekong Clinic
            var mekongClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = mekongClinicId,
                UserId = mekongClinicUserId,
                Address = "243-243A-243B Hoang Van Thu Street, Ward 1, Tan Binh District, Ho Chi Minh City, Vietnam",
                Description = "Mekong Obstetrics and Gynecology Hospital is a specialized hospital in Obstetrics - Gynecology and Neonatology, established in 2002, inherited from the Department of Obstetrics – University of Medicine and Pharmacy at Ho Chi Minh City (Campus 4). The hospital has a scale of about 110 beds and 50 cribs, providing services such as antenatal check-ups, ultrasound, infertility/assisted reproduction, fetal malformation screening, maternity services & high-quality obstetrics and gynecology.",
                IsInsuranceAccepted = true,
                Specializations = "Antenatal check-ups;Obstetric ultrasound (2D, 3D, 4D);Gynecology examination;Prenatal counseling;Infertility / assisted reproduction;Fetal malformation screening;Normal delivery / Cesarean section;Neonatology;Women’s health check-up services;Obstetrics and gynecology covered by health insurance;Prenatal testing;Obstetric and gynecological imaging diagnostics;Anesthesiology and resuscitation;Obstetric emergency",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Mekong Doctor User
            var mekongDoctorUser1Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = mekongDoctorUser1Id,
                UserName = "Dr. Pham Thanh Hoang",
                Email = "doctorMeKong@gmail.com",
                PhoneNumber = "(84-28) 3844 2986",
                Password = HashPassword("doctor#48"),
                Address = "Board of Directors / Obstetrics Department, Mekong Obstetrics and Gynecology Hospital",
                CreationDate = new DateTime(2025, 09, 05),
                RoleId = 7,
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Mekong Doctor
            var mekongDoctor1Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = mekongDoctor1Id,
                UserId = mekongDoctorUser1Id,
                ClinicId = mekongClinicId,
                Gender = "Male",
                Specialization = "Obstetrics and Gynecology / Hospital management",
                Certificate = "Specialist Doctor Level I / Master",
                ExperienceYear = 20,
                WorkPosition = "Deputy Director",
                Description = "A leading doctor at Mekong, often mentioned in articles about excellent obstetricians at Mekong.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 05)
            });

            // Seed Mekong Consultant User
            var mekongConsultantUser1Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = mekongConsultantUser1Id,
                UserName = "Dr. Nguyen Thi Ngoc Lan",
                Email = "consultantMeKong@gmail.com",
                PhoneNumber = "(84-28) 3844 2986",
                Password = HashPassword("consultant#36"),
                Address = "Obstetrics Department, Mekong Obstetrics and Gynecology Hospital",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Mekong Consultant
            var mekongConsultant1Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = mekongConsultant1Id,
                UserId = mekongConsultantUser1Id,
                ClinicId = mekongClinicId,
                Specialization = "Obstetrics and Gynecology / Antenatal check-ups / Ultrasound / Fetal malformation screening",
                Certificate = "Specialist Doctor in Obstetrics and Gynecology",
                Gender = "Female",
                ExperienceYears = 30,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Mekong Feedbacks
            var mekongFeedback1Id = Guid.NewGuid();
            var mekongFeedback2Id = Guid.NewGuid();
            var mekongFeedback3Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = mekongFeedback1Id,
                    ClinicId = mekongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Good obstetrics and gynecology examination, clear fetal ultrasound, dedicated doctors; service cost is higher than public hospitals but worth it.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = mekongFeedback2Id,
                    ClinicId = mekongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Had a normal delivery here; delivery room is nice and clean; however, the admission procedure took quite a long time.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = mekongFeedback3Id,
                    ClinicId = mekongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 10,
                    Comment = "Good infertility support service, friendly staff.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );


            // Saigon International Maternity Hospital (SIHospital)

            // Seed SIHospital Clinic User
            var sihospitalClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = sihospitalClinicUserId,
                UserName = "Saigon International Maternity Hospital (SIHospital)",
                Email = "info@sihospital.com.vn",
                PhoneNumber = "0899-909-269",
                Password = HashPassword("clinic#22"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "63 Bui Thi Xuan Street, Pham Ngu Lao Ward, District 1, Ho Chi Minh City, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed SIHospital Clinic
            var sihospitalClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = sihospitalClinicId,
                UserId = sihospitalClinicUserId,
                Address = "63 Bui Thi Xuan Street, Pham Ngu Lao Ward, District 1, Ho Chi Minh City, Vietnam",
                Description = "SIHospital is a specialized hospital in obstetrics, gynecology, neonatology, and assisted reproduction (IVF) with over 24 years of experience. It is known for services such as antenatal check-ups, ultrasound, gynecological examinations, infertility treatment, prenatal counseling, and high-quality maternal & child care in the center of Ho Chi Minh City.",
                IsInsuranceAccepted = true,
                Specializations = "Obstetrics & Gynecology / Antenatal check-ups;Fetal ultrasound (2D, 3D, 4D);Gynecological examination & treatment;Infertility / IVF / Assisted reproduction;Prenatal counseling;Fetal malformation screening;Normal delivery / Cesarean section;Neonatology;Private gynecology & obstetrics services;On-demand medical examination;Obstetrics & gynecology laboratory tests;Health insurance covered services",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed SIHospital Doctor Users
            var sihospitalDoctorUser1Id = Guid.NewGuid();
            var sihospitalDoctorUser2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = sihospitalDoctorUser1Id,
                    UserName = "MD Specialist I Le Nguyen Quang Huy",
                    Email = "lenguyenquanghuy@gmail.com",
                    PhoneNumber = "0899-909-269",
                    Password = HashPassword("doctor#49"),
                    Address = "SIHospital, District 1, Ho Chi Minh City",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = sihospitalDoctorUser2Id,
                    UserName = "MD Specialist I Duong Thi Kim Cuc",
                    Email = "duongthikimcuc@gmail.com",
                    PhoneNumber = "0899-909-269",
                    Password = HashPassword("doctor#50"),
                    Address = "SIHospital, District 1, Ho Chi Minh City",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed SIHospital Doctors
            var sihospitalDoctor1Id = Guid.NewGuid();
            var sihospitalDoctor2Id = Guid.NewGuid();

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = sihospitalDoctor1Id,
                    UserId = sihospitalDoctorUser1Id,
                    ClinicId = sihospitalClinicId,
                    Gender = "Male",
                    Specialization = "Gynecology / Gynecological examination",
                    Certificate = "Specialist Level I",
                    ExperienceYear = 15,
                    WorkPosition = "Gynecologist",
                    Description = "One of the doctors at SIHospital, specializing in gynecological examinations and obstetrics & gynecology support.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = sihospitalDoctor2Id,
                    UserId = sihospitalDoctorUser2Id,
                    ClinicId = sihospitalClinicId,
                    Gender = "Female",
                    Specialization = "Obstetrics & Gynecology",
                    Certificate = "Specialist Level I",
                    ExperienceYear = 12,
                    WorkPosition = "Obstetrician & Gynecologist",
                    Description = "Participates in antenatal check-ups and deliveries at SIHospital.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed SIHospital Consultant Users
            var sihospitalConsultantUser1Id = Guid.NewGuid();
            var sihospitalConsultantUser2Id = Guid.NewGuid();
            var sihospitalConsultantUser3Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = sihospitalConsultantUser1Id,
                    UserName = "MSc, MD Specialist II Tran Anh Tuan",
                    Email = "trananhtuan@gmail.com",
                    PhoneNumber = "0899-909-269",
                    Password = HashPassword("consultant#37"),
                    Address = "SIHospital, District 1, Ho Chi Minh City",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = sihospitalConsultantUser2Id,
                    UserName = "MSc, MD Specialist II Dang Thi Hien",
                    Email = "dangthihien@gmail.com",
                    PhoneNumber = "0899-909-269",
                    Password = HashPassword("consultant#38"),
                    Address = "SIHospital, District 1, Ho Chi Minh City",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = sihospitalConsultantUser3Id,
                    UserName = "MD Nguyen Thi Thu Hong",
                    Email = "nguyenthithuhong@gmail.com",
                    PhoneNumber = "0899-909-269",
                    Password = HashPassword("consultant#39"),
                    Address = "SIHospital, District 1, Ho Chi Minh City",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed SIHospital Consultants
            var sihospitalConsultant1Id = Guid.NewGuid();
            var sihospitalConsultant2Id = Guid.NewGuid();
            var sihospitalConsultant3Id = Guid.NewGuid();

            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = sihospitalConsultant1Id,
                    UserId = sihospitalConsultantUser1Id,
                    ClinicId = sihospitalClinicId,
                    Specialization = "Deputy Medical Director / Obstetrics & Gynecology",
                    Certificate = "Master, Specialist Level II",
                    Gender = "Male",
                    ExperienceYears = 28,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = sihospitalConsultant2Id,
                    UserId = sihospitalConsultantUser2Id,
                    ClinicId = sihospitalClinicId,
                    Specialization = "Obstetrics & Gynecology",
                    Certificate = "Master, Specialist Level II",
                    Gender = "Female",
                    ExperienceYears = 31,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = sihospitalConsultant3Id,
                    UserId = sihospitalConsultantUser3Id,
                    ClinicId = sihospitalClinicId,
                    Specialization = "Head of Delivery Department / Obstetrics & Gynecology",
                    Certificate = "Specialist Level II",
                    Gender = "Female",
                    ExperienceYears = 26,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                }
            );

            // Seed SIHospital Feedbacks
            var sihospitalFeedback1Id = Guid.NewGuid();
            var sihospitalFeedback2Id = Guid.NewGuid();
            var sihospitalFeedback3Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = sihospitalFeedback1Id,
                    ClinicId = sihospitalClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 10,
                    Comment = "Good obstetrics and gynecology services, clear antenatal check-ups, dedicated doctors.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = sihospitalFeedback2Id,
                    ClinicId = sihospitalClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Detailed fetal ultrasound, clean rooms, high cost but worth it.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = sihospitalFeedback3Id,
                    ClinicId = sihospitalClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Convenient booking process, good counseling support for high-risk cases.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );


            // Saigon International General Clinic (Saigon Healthcare)

            // Seed Saigon Healthcare Clinic User
            var saigonHealthcareClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = saigonHealthcareClinicUserId,
                UserName = "Saigon Healthcare Clinic",
                Email = "cskh@saigonhealthcare.vn",
                PhoneNumber = "098 226 45 45",
                Password = HashPassword("clinic#23"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "45 Thanh Thai Street, Dien Hong Ward, District 10, Ho Chi Minh City, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Saigon Healthcare Clinic
            var saigonHealthcareClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = saigonHealthcareClinicId,
                UserId = saigonHealthcareClinicUserId,
                Address = "45 Thanh Thai Street, Dien Hong Ward, District 10, Ho Chi Minh City, Vietnam",
                Description = "Saigon Healthcare Clinic is a private multi-specialty clinic with various departments, including obstetrics and gynecology / prenatal care. It provides periodic prenatal check-ups, obstetric ultrasounds, gynecological examinations, and reproductive health counseling. Flexible consultation hours and comprehensive maternal care services.",
                IsInsuranceAccepted = false,
                Specializations = "Periodic prenatal check-ups;Obstetric ultrasound;Gynecological examination;Reproductive health counseling;Women's healthcare services;On-demand medical consultation",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Saigon Healthcare Doctor User
            var saigonHealthcareDoctorUser1Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = saigonHealthcareDoctorUser1Id,
                UserName = "Dr. Nguyen Thi Minh Truc",
                Email = "nguyenthiminhtrucSgHealthcare@gmail.com",
                PhoneNumber = "098 226 45 45",
                Password = HashPassword("doctor#51"),
                Address = "Department of Obstetrics & Gynecology, Saigon Healthcare Clinic, District 10, HCMC",
                CreationDate = new DateTime(2025, 09, 17),
                RoleId = 7,
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Saigon Healthcare Doctor
            var saigonHealthcareDoctor1Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = saigonHealthcareDoctor1Id,
                UserId = saigonHealthcareDoctorUser1Id,
                ClinicId = saigonHealthcareClinicId,
                Gender = "Female",
                Specialization = "Prenatal care & obstetric ultrasound",
                Certificate = "Specialist Doctor Level I",
                ExperienceYear = 12,
                WorkPosition = "Obstetrician-Gynecologist",
                Description = "Provides regular prenatal check-ups, monitors normal pregnancy, and performs obstetric ultrasounds at this clinic.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 17)
            });

            // Seed Saigon Healthcare Consultant User
            var saigonHealthcareConsultantUser1Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = saigonHealthcareConsultantUser1Id,
                UserName = "Dr. Pham Thi Hong Mai",
                Email = "phamthihongmai@gmail.com",
                PhoneNumber = "098 226 45 45",
                Password = HashPassword("consultant#40"),
                Address = "Saigon Healthcare Clinic, District 10, HCMC",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Saigon Healthcare Consultant
            var saigonHealthcareConsultant1Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = saigonHealthcareConsultant1Id,
                UserId = saigonHealthcareConsultantUser1Id,
                ClinicId = saigonHealthcareClinicId,
                Specialization = "Obstetrics & Gynecology",
                Certificate = "Specialist Doctor Level I",
                Gender = "Female",
                ExperienceYears = 25,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Saigon Healthcare Feedbacks
            var saigonHealthcareFeedback1Id = Guid.NewGuid();
            var saigonHealthcareFeedback2Id = Guid.NewGuid();
            var saigonHealthcareFeedback3Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = saigonHealthcareFeedback1Id,
                    ClinicId = saigonHealthcareClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Quick obstetrics & gynecology consultation, attentive doctors; clean clinic.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = saigonHealthcareFeedback2Id,
                    ClinicId = saigonHealthcareClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "The cost is a bit high, but the service is worth it.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = saigonHealthcareFeedback3Id,
                    ClinicId = saigonHealthcareClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Good prenatal ultrasound, having a female doctor makes expectant mothers feel comfortable.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );


            // Binh Duong General Hospital

            // Seed Binh Duong Clinic User
            var binhduongClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = binhduongClinicUserId,
                UserName = "Binh Duong General Hospital",
                Email = "benhvienbinhduong.bdgh@gmail.com",
                PhoneNumber = "02743 822920",
                Password = HashPassword("clinic#24"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "No. 05, Pham Ngoc Thach Street, Phu Loi Ward, Thu Dau Mot City, Binh Duong Province, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Binh Duong Clinic
            var binhduongClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = binhduongClinicId,
                UserId = binhduongClinicUserId,
                Address = "No. 05, Pham Ngoc Thach Street, Phu Loi Ward, Thu Dau Mot City, Binh Duong Province, Vietnam",
                Description = "Binh Duong General Hospital is a Grade I general hospital, established in 1890 (originating from Phu Cuong Hospital), serving as a major healthcare facility for local residents. The Obstetrics & Gynecology Department operates on a large scale, providing prenatal care, delivery, and gynecology consultation. The hospital is undergoing renaming and expansion, with a new 1,500-bed project in development.",
                IsInsuranceAccepted = true,
                Specializations = "General medicine;Obstetrics & gynecology;Periodic prenatal check-ups;Obstetric ultrasound;Gynecology;Delivery / vaginal birth and C-section;Prenatal counseling;Postnatal care;Pediatrics;Imaging diagnostics;Laboratory testing;Traditional medicine;Endocrinology;Physiotherapy",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Binh Duong Doctor User
            var binhduongDoctorUser1Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = binhduongDoctorUser1Id,
                UserName = "Dr. Tran Van Minh",
                Email = "doctorvanminh@gmail.com",
                PhoneNumber = null,
                Password = HashPassword("doctor#52"),
                Address = "Obstetrics & Gynecology Department, Binh Duong General Hospital",
                CreationDate = new DateTime(2025, 09, 17),
                RoleId = 7,
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Binh Duong Doctor
            var binhduongDoctor1Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = binhduongDoctor1Id,
                UserId = binhduongDoctorUser1Id,
                ClinicId = binhduongClinicId,
                Gender = "Male",
                Specialization = "Obstetric ultrasound",
                Certificate = "Specialist Level I",
                ExperienceYear = 15,
                WorkPosition = "Obstetrician-Gynecologist",
                Description = "Performs routine prenatal ultrasounds and monitors fetal development.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 17)
            });

            // Seed Binh Duong Consultant Users
            var binhduongConsultantUser1Id = Guid.NewGuid();
            var binhduongConsultantUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = binhduongConsultantUser1Id,
                    UserName = "Dr. Nguyen Thi Kim Hue",
                    Email = "kimhue@gmail.com",
                    PhoneNumber = null,
                    Password = HashPassword("consultant#41"),
                    Address = "Obstetrics & Gynecology Department, Binh Duong General Hospital",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = binhduongConsultantUser2Id,
                    UserName = "MSc. Dr. Ho Thi Hoang Anh",
                    Email = "hoanganh@gmail.com",
                    PhoneNumber = null,
                    Password = HashPassword("consultant#42"),
                    Address = "Obstetrics & Gynecology Department, Binh Duong General Hospital",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Binh Duong Consultants
            var binhduongConsultant1Id = Guid.NewGuid();
            var binhduongConsultant2Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = binhduongConsultant1Id,
                    UserId = binhduongConsultantUser1Id,
                    ClinicId = binhduongClinicId,
                    Specialization = "Obstetrics & Gynecology / Prenatal care & consultation",
                    Certificate = "Specialist Level II",
                    Gender = "Female",
                    ExperienceYears = 30,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = binhduongConsultant2Id,
                    UserId = binhduongConsultantUser2Id,
                    ClinicId = binhduongClinicId,
                    Specialization = "Obstetrics & Gynecology",
                    Certificate = "Master’s Degree, Specialist Level I/II",
                    Gender = "Female",
                    ExperienceYears = 25,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                }
            );

            // Seed Binh Duong Feedbacks
            var binhduongFeedback1Id = Guid.NewGuid();
            var binhduongFeedback2Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = binhduongFeedback1Id,
                    ClinicId = binhduongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Prenatal care at Binh Duong General Hospital is good, dedicated doctors, but the obstetrics department is quite crowded so waiting time is long.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = binhduongFeedback2Id,
                    ClinicId = binhduongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Obstetrics & gynecology services have improved; facilities are better but the number of obstetricians should be increased.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );


            // Hoan My Binh Duong Hospital

            // Seed Hoan My Binh Duong Clinic User
            var hoanmyBinhduongClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = hoanmyBinhduongClinicUserId,
                UserName = "Hoan My Binh Duong Hospital",
                Email = "info@hoanmy.com",
                PhoneNumber = "0274 3777 999",
                Password = HashPassword("clinic#25"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "45 Ho Van Cong, Tuong Binh Hiep Ward, Thu Dau Mot City, Binh Duong, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Hoan My Binh Duong Clinic
            var hoanmyBinhduongClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = hoanmyBinhduongClinicId,
                UserId = hoanmyBinhduongClinicUserId,
                Address = "45 Ho Van Cong, Tuong Binh Hiep Ward, Thu Dau Mot City, Binh Duong, Vietnam",
                Description = "Hoan My Binh Duong Hospital is a high-quality private hospital under the Hoan My system, providing a wide range of healthcare services. Its Obstetrics & Gynecology Department offers maternity packages, prenatal check-ups, natural delivery & C-section services, maternal support, and postpartum care. The hospital is equipped with modern facilities and family rooms tailored for maternity needs.",
                IsInsuranceAccepted = true,
                Specializations = "Prenatal check-ups;Obstetrics & Gynecology;Natural birth;Cesarean birth;Maternity package;Obstetric ultrasound;Gynecology check-up;Mother & newborn care;Obstetrics & gynecology services;Emergency obstetrics;Family birthing room;Maternity pick-up service",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Hoan My Binh Duong Doctor Users
            var hoanmyBinhduongDoctorUser1Id = Guid.NewGuid();
            var hoanmyBinhduongDoctorUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = hoanmyBinhduongDoctorUser1Id,
                    UserName = "Dr. Nguyen Thi Minh Thao",
                    Email = "minhhao@gmail.com",
                    PhoneNumber = "0274 3777 999",
                    Password = HashPassword("doctor#53"),
                    Address = "Hoan My Binh Duong, Obstetrics & Gynecology Department",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = hoanmyBinhduongDoctorUser2Id,
                    UserName = "Dr. Tran Van Hoang",
                    Email = "tranvanhoang@gmail.com",
                    PhoneNumber = "0274 3777 999",
                    Password = HashPassword("doctor#54"),
                    Address = "Hoan My Binh Duong, Obstetrics & Gynecology Department",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Hoan My Binh Duong Doctors
            var hoanmyBinhduongDoctor1Id = Guid.NewGuid();
            var hoanmyBinhduongDoctor2Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = hoanmyBinhduongDoctor1Id,
                    UserId = hoanmyBinhduongDoctorUser1Id,
                    ClinicId = hoanmyBinhduongClinicId,
                    Gender = "Female",
                    Specialization = "Obstetrics & Gynecology / Natural birth",
                    Certificate = "Specialist Level I",
                    ExperienceYear = 13,
                    WorkPosition = "Obstetrician & Gynecologist",
                    Description = "Performs natural deliveries and provides prenatal care at Hoan My Binh Duong.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = hoanmyBinhduongDoctor2Id,
                    UserId = hoanmyBinhduongDoctorUser2Id,
                    ClinicId = hoanmyBinhduongClinicId,
                    Gender = "Male",
                    Specialization = "Obstetrics & Gynecology / Cesarean birth",
                    Certificate = "Specialist Level II",
                    ExperienceYear = 18,
                    WorkPosition = "Obstetrician & Gynecologist",
                    Description = "Performs C-sections and provides care for high-risk pregnancies.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Seed Hoan My Binh Duong Consultant User
            var hoanmyBinhduongConsultantUser1Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = hoanmyBinhduongConsultantUser1Id,
                UserName = "OB/GYN Consultant - Hoan My Binh Duong",
                Email = "hoanmyConsultant@gmail.com",
                PhoneNumber = "0274 3777 999",
                Password = HashPassword("consultant#43"),
                Address = "Hoan My Binh Duong, Obstetrics & Gynecology Department",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Hoan My Binh Duong Consultant
            var hoanmyBinhduongConsultant1Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = hoanmyBinhduongConsultant1Id,
                UserId = hoanmyBinhduongConsultantUser1Id,
                ClinicId = hoanmyBinhduongClinicId,
                Specialization = "Obstetrics & Gynecology / Prenatal check-ups",
                Certificate = "Specialist Doctor Level I/II",
                Gender = "Female",
                ExperienceYears = 15,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Hoan My Binh Duong Feedbacks
            var hoanmyBinhduongFeedback1Id = Guid.NewGuid();
            var hoanmyBinhduongFeedback2Id = Guid.NewGuid();
            var hoanmyBinhduongFeedback3Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = hoanmyBinhduongFeedback1Id,
                    ClinicId = hoanmyBinhduongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Good maternity package service, dedicated doctors, and beautiful family birthing rooms.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = hoanmyBinhduongFeedback2Id,
                    ClinicId = hoanmyBinhduongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Reasonable cost compared to other private hospitals, clear ultrasound imaging.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = hoanmyBinhduongFeedback3Id,
                    ClinicId = hoanmyBinhduongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Fast procedures, good postpartum support service, but daytime check-up queues are a bit long.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );


            // Medic Binh Duong General Hospital

            // Seed Medic Binh Duong Clinic User
            var medicBinhduongClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = medicBinhduongClinicUserId,
                UserName = "Medic Binh Duong General Hospital",
                Email = "info@medicbinhduong.vn",
                PhoneNumber = "0274 3846 997",
                Password = HashPassword("clinic#26"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "123 Binh Duong Boulevard, Phu Tho Ward, Thu Dau Mot City, Binh Duong, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Medic Binh Duong Clinic
            var medicBinhduongClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = medicBinhduongClinicId,
                UserId = medicBinhduongClinicUserId,
                Address = "123 Binh Duong Boulevard, Phu Tho Ward, Thu Dau Mot City, Binh Duong, Vietnam",
                Description = "Medic Binh Duong General Hospital is one of the private healthcare facilities under the MEDIC system, providing high-quality medical services with strengths in diagnostic imaging, laboratory testing, and obstetrics & gynecology. The hospital offers prenatal check-up packages, 2D/3D/4D ultrasound, normal delivery, C-section services, and postpartum care for mothers.",
                IsInsuranceAccepted = true,
                Specializations = "Prenatal check-up;2D/3D/4D ultrasound;Obstetrics & Gynecology;Normal delivery;Cesarean section;Gynecological examination;Pre- and postnatal care;Prenatal screening tests;Pregnancy nutrition counseling",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Medic Binh Duong Doctor Users
            var medicBinhduongDoctorUser1Id = Guid.NewGuid();
            var medicBinhduongDoctorUser2Id = Guid.NewGuid();
            var medicBinhduongDoctorUser3Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = medicBinhduongDoctorUser1Id,
                    UserName = "Assoc. Prof. Dr. Nguyen Thi Mai Anh",
                    Email = "maianh@medicbinhduong.vn",
                    PhoneNumber = "0274 3846 997",
                    Password = HashPassword("doctor#55"),
                    Address = "Obstetrics & Gynecology Department, Medic Binh Duong",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = medicBinhduongDoctorUser2Id,
                    UserName = "Dr. Le Thanh Binh",
                    Email = "thanhbinh@medicbinhduong.vn",
                    PhoneNumber = "0274 3846 997",
                    Password = HashPassword("doctor#56"),
                    Address = "Obstetrics & Gynecology Department, Medic Binh Duong",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = medicBinhduongDoctorUser3Id,
                    UserName = "Dr. Nguyen Thi Ngoc Huong",
                    Email = "ngochuong@medicbinhduong.vn",
                    PhoneNumber = "0274 3846 997",
                    Password = HashPassword("doctor#57"),
                    Address = "Obstetrics & Gynecology Department, Medic Binh Duong",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Medic Binh Duong Doctors
            var medicBinhduongDoctor1Id = Guid.NewGuid();
            var medicBinhduongDoctor2Id = Guid.NewGuid();
            var medicBinhduongDoctor3Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = medicBinhduongDoctor1Id,
                    UserId = medicBinhduongDoctorUser1Id,
                    ClinicId = medicBinhduongClinicId,
                    Gender = "Female",
                    Specialization = "Normal delivery, cesarean section",
                    Certificate = "Specialist Level II in Obstetrics & Gynecology",
                    ExperienceYear = 20,
                    WorkPosition = "Head of Obstetrics & Gynecology Department",
                    Description = "Over 20 years of experience in obstetrics and gynecology, directly monitoring and assisting deliveries at the hospital.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = medicBinhduongDoctor2Id,
                    UserId = medicBinhduongDoctorUser2Id,
                    ClinicId = medicBinhduongClinicId,
                    Gender = "Male",
                    Specialization = "Ultrasound and prenatal diagnosis",
                    Certificate = "Specialist Level I",
                    ExperienceYear = 10,
                    WorkPosition = "Obstetric ultrasound doctor",
                    Description = "Specialized in fetal ultrasound, diagnosing abnormalities, and counseling mothers-to-be.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = medicBinhduongDoctor3Id,
                    UserId = medicBinhduongDoctorUser3Id,
                    ClinicId = medicBinhduongClinicId,
                    Gender = "Female",
                    Specialization = "Gynecological examination and postpartum care",
                    Certificate = "General practitioner with orientation in Obstetrics & Gynecology",
                    ExperienceYear = 8,
                    WorkPosition = "Obstetrician & Gynecologist",
                    Description = "Monitoring the health of mothers and babies after birth, providing family planning counseling.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Seed Medic Binh Duong Consultant Users
            var medicBinhduongConsultantUser1Id = Guid.NewGuid();
            var medicBinhduongConsultantUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = medicBinhduongConsultantUser1Id,
                    UserName = "MSc. Dr. Nguyen Thi Hong Van",
                    Email = "hongvan@medicbinhduong.vn",
                    PhoneNumber = "0274 3846 997",
                    Password = HashPassword("consultant#44"),
                    Address = "Obstetrics & Gynecology Department, Medic Binh Duong",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = medicBinhduongConsultantUser2Id,
                    UserName = "Specialist I. Dr. Tran Minh Quan",
                    Email = "minhquan@medicbinhduong.vn",
                    PhoneNumber = "0274 3846 997",
                    Password = HashPassword("consultant#45"),
                    Address = "Obstetrics & Gynecology Department, Medic Binh Duong",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Medic Binh Duong Consultants
            var medicBinhduongConsultant1Id = Guid.NewGuid();
            var medicBinhduongConsultant2Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = medicBinhduongConsultant1Id,
                    UserId = medicBinhduongConsultantUser1Id,
                    ClinicId = medicBinhduongClinicId,
                    Specialization = "Pregnancy counseling, fetal ultrasound",
                    Certificate = "Master’s Degree, Specialist Level I in Obstetrics & Gynecology",
                    Gender = "Female",
                    ExperienceYears = 14,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = medicBinhduongConsultant2Id,
                    UserId = medicBinhduongConsultantUser2Id,
                    ClinicId = medicBinhduongClinicId,
                    Specialization = "Obstetrics & Gynecology counseling",
                    Certificate = "Specialist Level I in Obstetrics & Gynecology",
                    Gender = "Male",
                    ExperienceYears = 12,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                }
            );

            // Seed Medic Binh Duong Feedbacks
            var medicBinhduongFeedback1Id = Guid.NewGuid();
            var medicBinhduongFeedback2Id = Guid.NewGuid();
            var medicBinhduongFeedback3Id = Guid.NewGuid();
            var medicBinhduongFeedback4Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = medicBinhduongFeedback1Id,
                    ClinicId = medicBinhduongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "4D ultrasound images are clear, and the doctor gives thorough advice to expectant mothers.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = medicBinhduongFeedback2Id,
                    ClinicId = medicBinhduongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Dedicated obstetric team, safe C-section, and attentive postoperative care.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = medicBinhduongFeedback3Id,
                    ClinicId = medicBinhduongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Procedures are quite fast, but waiting time is a bit long during peak hours.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = medicBinhduongFeedback4Id,
                    ClinicId = medicBinhduongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 10,
                    Comment = "The hospital provides comprehensive prenatal care packages, very convenient and reasonably priced.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );


            // Saigon Binh Duong General Hospital

            // Seed Saigon Binh Duong Clinic User
            var saigonBinhduongClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = saigonBinhduongClinicUserId,
                UserName = "Saigon Binh Duong General Hospital",
                Email = "info@bvsaigonbinhduong.vn",
                PhoneNumber = "(0274) 366 8989",
                Password = HashPassword("clinic#27"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "39 Ho Van Cong, Quarter 4, Tuong Binh Hiep Ward, Thu Dau Mot City, Binh Duong, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Saigon Binh Duong Clinic
            var saigonBinhduongClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = saigonBinhduongClinicId,
                UserId = saigonBinhduongClinicUserId,
                Address = "39 Ho Van Cong, Quarter 4, Tuong Binh Hiep Ward, Thu Dau Mot City, Binh Duong, Vietnam",
                Description = "Saigon Binh Duong General Hospital is a private general hospital established in 2009, with a team of specialized doctors and modern equipment. The Obstetrics & Gynecology Department is one of the key departments, providing prenatal check-ups, periodic fetal monitoring, natural delivery, C-section, and family planning services.",
                IsInsuranceAccepted = true,
                Specializations = "Prenatal check-ups;Obstetrics & Gynecology;Natural birth / C-section;Family planning;General ultrasound / Fetal ultrasound;Gynecology check-ups;Gynecological surgery;Paraclinical services (lab tests, diagnostic imaging);Obstetrics - Surgery - Anesthesiology;Emergency & general check-ups",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Saigon Binh Duong Doctor Users
            var saigonBinhduongDoctorUser1Id = Guid.NewGuid();
            var saigonBinhduongDoctorUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = saigonBinhduongDoctorUser1Id,
                    UserName = "OB-GYN / Gynecologist",
                    Email = "BsSaiGonBinhDuong@gmail.com",
                    PhoneNumber = "(0274) 366 8989",
                    Password = HashPassword("doctor#58"),
                    Address = "Obstetrics Department, Saigon Binh Duong General Hospital",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = saigonBinhduongDoctorUser2Id,
                    UserName = "OB-GYN / C-section Specialist",
                    Email = "doctorSaiGon@gmail.com",
                    PhoneNumber = "(0274) 366 8989",
                    Password = HashPassword("doctor#59"),
                    Address = "Obstetrics Department, Saigon Binh Duong General Hospital",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Saigon Binh Duong Doctors
            var saigonBinhduongDoctor1Id = Guid.NewGuid();
            var saigonBinhduongDoctor2Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = saigonBinhduongDoctor1Id,
                    UserId = saigonBinhduongDoctorUser1Id,
                    ClinicId = saigonBinhduongClinicId,
                    Gender = "Female",
                    Specialization = "Fetal ultrasound / Prenatal care",
                    Certificate = "Specialist Level I",
                    ExperienceYear = 12,
                    WorkPosition = "Obstetrician & Gynecologist",
                    Description = "Performs routine prenatal check-ups, general ultrasound, and fetal monitoring.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = saigonBinhduongDoctor2Id,
                    UserId = saigonBinhduongDoctorUser2Id,
                    ClinicId = saigonBinhduongClinicId,
                    Gender = "Female",
                    Specialization = "C-section, high-risk pregnancy",
                    Certificate = "Specialist Level II",
                    ExperienceYear = 18,
                    WorkPosition = "Obstetric Surgeon",
                    Description = "Performs C-sections and handles high-risk pregnancies.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Seed Saigon Binh Duong Consultant User
            var saigonBinhduongConsultantUser1Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = saigonBinhduongConsultantUser1Id,
                UserName = "Dr. Le Chi Thien",
                Email = "lechithien@gmail.com",
                PhoneNumber = "(0274) 366 8989",
                Password = HashPassword("consultant#46"),
                Address = "Obstetrics Department, Saigon Binh Duong General Hospital",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Saigon Binh Duong Consultant
            var saigonBinhduongConsultant1Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = saigonBinhduongConsultant1Id,
                UserId = saigonBinhduongConsultantUser1Id,
                ClinicId = saigonBinhduongClinicId,
                Specialization = "Obstetrics & Gynecology / Head of Obstetrics Dept.",
                Certificate = "Specialist Level I",
                Gender = "Male",
                ExperienceYears = 20,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Saigon Binh Duong Feedbacks
            var saigonBinhduongFeedback1Id = Guid.NewGuid();
            var saigonBinhduongFeedback2Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = saigonBinhduongFeedback1Id,
                    ClinicId = saigonBinhduongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Good prenatal check-ups, the OB-GYN is very dedicated, modern equipment available.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = saigonBinhduongFeedback2Id,
                    ClinicId = saigonBinhduongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Costs are higher compared to public hospitals, and appointments for service check-ups need to be scheduled in advance.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );


            // Van Phuc General Hospital System (Van Phuc Chain)

            // Seed Van Phuc City Clinic User
            var vanphucClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = vanphucClinicUserId,
                UserName = "Van Phuc City General Hospital",
                Email = "vanphuccity@gmail.com",
                PhoneNumber = "1900 966 979",
                Password = HashPassword("clinic#28"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "No. 1, Street 10, Van Phuc Residential Area 1, Hiep Binh Ward, Thu Duc City, Ho Chi Minh City, Vietnam; Two main branches located in Thu Dau Mot City (Van Phuc 1) and Di An City (Van Phuc 2), Binh Duong Province.",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Van Phuc City Clinic
            var vanphucClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = vanphucClinicId,
                UserId = vanphucClinicUserId,
                Address = "No. 1, Street 10, Van Phuc Residential Area 1, Hiep Binh Ward, Thu Duc City, Ho Chi Minh City, Vietnam; Two main branches located in Thu Dau Mot City (Van Phuc 1) and Di An City (Van Phuc 2), Binh Duong Province.",
                Description = "Van Phuc City General Hospital System is a private hospital chain with two large branches in Binh Duong, offering multi-specialty services with a strong Obstetrics & Gynecology Department. Provides prenatal check-ups, maternity packages, natural delivery, C-sections, postpartum care, and mother & newborn care with modern medical equipment.",
                IsInsuranceAccepted = true,
                Specializations = "Obstetrics & Gynecology;Prenatal check-ups;Natural birth & C-sections;Gynecology check-ups;Postpartum care;On-demand medical services;Obstetric ultrasound;Gynecologic cancer screening;Reproductive health check-ups;Health insurance check-ups",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Van Phuc City Doctor Users
            var vanphucDoctorUser1Id = Guid.NewGuid();
            var vanphucDoctorUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = vanphucDoctorUser1Id,
                    UserName = "OB-GYN Doctor (Van Phuc 1)",
                    Email = "vanphuccitydoctor@gmail.com",
                    PhoneNumber = null,
                    Password = HashPassword("doctor#60"),
                    Address = "Van Phuc 1 Branch, Binh Duong",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = vanphucDoctorUser2Id,
                    UserName = "OB-GYN Doctor (Van Phuc 2)",
                    Email = "vanphucDoctor@gmail.com",
                    PhoneNumber = null,
                    Password = HashPassword("doctor#61"),
                    Address = "Van Phuc 2 Branch, Binh Duong",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Van Phuc City Doctors
            var vanphucDoctor1Id = Guid.NewGuid();
            var vanphucDoctor2Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = vanphucDoctor1Id,
                    UserId = vanphucDoctorUser1Id,
                    ClinicId = vanphucClinicId,
                    Gender = "Female",
                    Specialization = "Prenatal check-ups & Postpartum care",
                    Certificate = "Specialist Level I",
                    ExperienceYear = 12,
                    WorkPosition = "Obstetrician & Gynecologist",
                    Description = "Performs routine prenatal check-ups, deliveries, and postpartum care for normal cases.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = vanphucDoctor2Id,
                    UserId = vanphucDoctorUser2Id,
                    ClinicId = vanphucClinicId,
                    Gender = "Male",
                    Specialization = "C-sections / High-risk pregnancies",
                    Certificate = "Specialist Level II",
                    ExperienceYear = 18,
                    WorkPosition = "Obstetrician & Gynecologist",
                    Description = "Performs C-sections and manages high-risk pregnancies.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Seed Van Phuc City Consultant Users
            var vanphucConsultantUser1Id = Guid.NewGuid();
            var vanphucConsultantUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = vanphucConsultantUser1Id,
                    UserName = "Dr. Lam Thi Kim Ngan",
                    Email = "kimngan@gmail.com",
                    PhoneNumber = null,
                    Password = HashPassword("consultant#47"),
                    Address = "OB-GYN Dept., Van Phuc City",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = vanphucConsultantUser2Id,
                    UserName = "Dr. Hoang Thi Minh Hieu",
                    Email = "minhhieu@gmail.com",
                    PhoneNumber = null,
                    Password = HashPassword("consultant#48"),
                    Address = "OB-GYN Dept., Van Phuc City",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Van Phuc City Consultants
            var vanphucConsultant1Id = Guid.NewGuid();
            var vanphucConsultant2Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = vanphucConsultant1Id,
                    UserId = vanphucConsultantUser1Id,
                    ClinicId = vanphucClinicId,
                    Specialization = "Obstetrics & Gynecology",
                    Certificate = "Specialist Level I",
                    Gender = "Female",
                    ExperienceYears = 15,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = vanphucConsultant2Id,
                    UserId = vanphucConsultantUser2Id,
                    ClinicId = vanphucClinicId,
                    Specialization = "Obstetrics & Gynecology / Maternity care",
                    Certificate = "Specialist Level I / II",
                    Gender = "Female",
                    ExperienceYears = 18,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                }
            );

            // Seed Van Phuc City Feedbacks
            var vanphucFeedback1Id = Guid.NewGuid();
            var vanphucFeedback2Id = Guid.NewGuid();
            var vanphucFeedback3Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = vanphucFeedback1Id,
                    ClinicId = vanphucClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Good OB-GYN services, clean facilities, reasonable costs.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = vanphucFeedback2Id,
                    ClinicId = vanphucClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Normal delivery at Van Phuc 1 was good, nurses and doctors were very caring.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = vanphucFeedback3Id,
                    ClinicId = vanphucClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Clear fetal ultrasound results, thorough consultation, felt reassured.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );


            // My Phuoc General Hospital

            // Seed My Phuoc Clinic User
            var myphuocClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = myphuocClinicUserId,
                UserName = "My Phuoc General Hospital",
                Email = "customerservice.mph@gmail.com",
                PhoneNumber = "0274 3535 777",
                Password = HashPassword("clinic#29"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "TC3 Street, Group 6, Quarter 3, My Phuoc Ward, Ben Cat City, Binh Duong Province, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed My Phuoc Clinic
            var myphuocClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = myphuocClinicId,
                UserId = myphuocClinicUserId,
                Address = "TC3 Street, Group 6, Quarter 3, My Phuoc Ward, Ben Cat City, Binh Duong Province, Vietnam",
                Description = "My Phuoc General Hospital (MPH) is a private hospital under Becamex IDC Corporation, serving people in Binh Duong and neighboring areas. The hospital has a large scale (Phase II: 489 beds; 16 specialties, 8 functional rooms) with many modern medical equipment. The Obstetrics Department provides antenatal check-ups, normal delivery/cesarean section, fetal malformation screening, prenatal testing, and maternal & neonatal care.",
                IsInsuranceAccepted = true,
                Specializations = "Antenatal care;Obstetric ultrasound;Gynecology examination;Normal delivery & Cesarean section;Prenatal counseling;Fetal anomaly screening;Prenatal testing;IUD/Implant contraception;Maternal & postpartum care;Mother & Baby services;Health insurance check-up;Obstetric emergency",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed My Phuoc Doctor User
            var myphuocDoctorUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = myphuocDoctorUserId,
                UserName = "My Phuoc OB-GYN Doctor",
                Email = "myphuocdoctor@gmail.com",
                PhoneNumber = "0274 3535 777",
                Password = HashPassword("doctor#62"),
                Address = "Obstetrics Department, My Phuoc General Hospital",
                CreationDate = new DateTime(2025, 09, 17),
                RoleId = 7,
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed My Phuoc Doctor
            var myphuocDoctorId = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = myphuocDoctorId,
                UserId = myphuocDoctorUserId,
                ClinicId = myphuocClinicId,
                Gender = "Female",
                Specialization = "Antenatal check-up & OB-GYN services",
                Certificate = "Specialist Doctor Level I",
                ExperienceYear = 10,
                WorkPosition = "OB-GYN Doctor",
                Description = "Performs childbirth procedures at MPH, general gynecology examination & mother-baby services.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 17)
            });

            // Seed My Phuoc Consultant User
            var myphuocConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = myphuocConsultantUserId,
                UserName = "My Phuoc OB-GYN Consultant",
                Email = "tuvanmyphuoc@gmail.com",
                PhoneNumber = "0274 3535 777",
                Password = HashPassword("consultant#49"),
                Address = "Obstetrics Department, My Phuoc General Hospital",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed My Phuoc Consultant
            var myphuocConsultantId = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = myphuocConsultantId,
                UserId = myphuocConsultantUserId,
                ClinicId = myphuocClinicId,
                Specialization = "OB-GYN / antenatal care & ultrasound",
                Certificate = "Specialist Doctor Level I",
                Gender = "Female",
                ExperienceYears = 10,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed My Phuoc Feedback
            var myphuocFeedback1Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(new Feedback
            {
                Id = myphuocFeedback1Id,
                ClinicId = myphuocClinicId,
                UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                Rating = 9,
                Comment = "I feel very lucky and extremely satisfied when choosing My Phuoc Hospital as my companion throughout pregnancy and childbirth...",
                CreationDate = new DateTime(2025, 09, 17)
            });


            // Ben Cat Medical Center

            // Seed Ben Cat Medical Center Clinic User
            var bencatClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = bencatClinicUserId,
                UserName = "Ben Cat Medical Center",
                Email = "hotro@ttytebencat.com",
                PhoneNumber = "0274 3564 247",
                Password = HashPassword("clinic#30"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "Quarter 5, My Phuoc Ward, Ben Cat Town, Binh Duong Province, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Ben Cat Medical Center Clinic
            var bencatClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = bencatClinicId,
                UserId = bencatClinicUserId,
                Address = "Quarter 5, My Phuoc Ward, Ben Cat Town, Binh Duong Province, Vietnam",
                Description = "Ben Cat Medical Center is a district-level healthcare facility (Class III) under the Department of Health of Binh Duong. The center has an Obstetrics Department, providing obstetrics, gynecology, and reproductive healthcare services for local people. Facilities are being improved, with Phase 2 expansion ongoing. 24/7 emergency services available. ([cskh.org.vn](https://cskh.org.vn/trung-tam-y-te-thi-xa-ben-cat/))",
                IsInsuranceAccepted = true,
                Specializations = "Antenatal care / OB-GYN;Gynecology examination;Reproductive healthcare;Delivery / Natural birth;Obstetric ultrasound;OB-GYN laboratory tests;Obstetric emergency;Health insurance examination;General internal medicine;Pediatrics;Medical imaging",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Ben Cat Medical Center Doctor User (simulated)
            var bencatDoctorUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = bencatDoctorUserId,
                UserName = "Ben Cat Medical Center Doctor",
                Email = "bacsytrungtambencat@gmail.com",
                PhoneNumber = "0274 3564 247",
                Password = HashPassword("doctor#63"),
                Address = "Obstetrics Department, Ben Cat Medical Center",
                CreationDate = new DateTime(2025, 09, 17),
                RoleId = 7,
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Ben Cat Medical Center Doctor (simulated)
            var bencatDoctorId = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = bencatDoctorId,
                UserId = bencatDoctorUserId,
                ClinicId = bencatClinicId,
                Gender = "Female",
                Specialization = "OB-GYN / Delivery",
                Certificate = "Specialist Doctor Level I – OB-GYN",
                ExperienceYear = 20,
                WorkPosition = "Doctor",
                Description = "Performs natural delivery, OB-GYN examination at the local medical center.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 17)
            });

            // Seed Ben Cat Medical Center Consultant User (simulated)
            var bencatConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = bencatConsultantUserId,
                UserName = "Ben Cat Medical Center Consultant",
                Email = "tuvanytebencat@gmail.com",
                PhoneNumber = "0274 3564 247",
                Password = HashPassword("consultant#50"),
                Address = "Obstetrics Department, Ben Cat Medical Center",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Ben Cat Medical Center Consultant (simulated)
            var bencatConsultantId = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = bencatConsultantId,
                UserId = bencatConsultantUserId,
                ClinicId = bencatClinicId,
                Specialization = "OB-GYN / Antenatal care",
                Certificate = "Specialist Doctor Level I – OB-GYN",
                Gender = "Male",
                ExperienceYears = 13,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Ben Cat Medical Center Feedback
            var bencatFeedback1Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(new Feedback
            {
                Id = bencatFeedback1Id,
                ClinicId = bencatClinicId,
                UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                Rating = 4,
                Comment = "People reported that OB-GYN services have improved; doctors are friendly but waiting time can be long during peak hours.",
                CreationDate = new DateTime(2025, 09, 17)
            });


            // Tan Uyen Medical Center

            // Seed Tan Uyen Medical Center Clinic User
            var tanuyenClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = tanuyenClinicUserId,
                UserName = "Tan Uyen City Medical Center",
                Email = "ttytetanuyen@gmail.com",
                PhoneNumber = "(0274) 3656 340",
                Password = HashPassword("clinic#31"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "DT 747 Road, Quarter 7, Uyen Hung Ward, Tan Uyen City, Binh Duong Province, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Tan Uyen Medical Center Clinic
            var tanuyenClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = tanuyenClinicId,
                UserId = tanuyenClinicUserId,
                Address = "DT 747 Road, Quarter 7, Uyen Hung Ward, Tan Uyen City, Binh Duong Province, Vietnam",
                Description = "Tan Uyen City Medical Center is a public healthcare facility at the city level, providing general medical services with an obstetrics and gynecology department. Services include gynecological examinations, prenatal checkups, obstetric emergency care, and maternal care for local patients. Health insurance is accepted.",
                IsInsuranceAccepted = true,
                Specializations = "Prenatal checkups;Obstetrics & Gynecology;Gynecological exams;Obstetric ultrasound;Reproductive health care;Obstetric emergency;General medicine;Pediatrics;Imaging diagnostics;Laboratory testing",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Tan Uyen Medical Center Doctor User (simulated)
            var tanuyenDoctorUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = tanuyenDoctorUserId,
                UserName = "Doctor at Tan Uyen Medical Center",
                Email = "bacsitanuyen@gmail.com",
                PhoneNumber = "(0274) 3656 340",
                Password = HashPassword("doctor#64"),
                Address = "Obstetrics Department, Tan Uyen City Medical Center",
                CreationDate = new DateTime(2025, 09, 17),
                RoleId = 7,
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Tan Uyen Medical Center Doctor (simulated)
            var tanuyenDoctorId = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = tanuyenDoctorId,
                UserId = tanuyenDoctorUserId,
                ClinicId = tanuyenClinicId,
                Gender = "Male",
                Specialization = "Natural birth / vaginal delivery",
                Certificate = "Specialist Doctor Level I – Obstetrics and Gynecology",
                ExperienceYear = 18,
                WorkPosition = "Doctor",
                Description = "Performs vaginal deliveries, provides maternal care for local patients, and conducts routine prenatal checkups.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 17)
            });

            // Seed Tan Uyen Medical Center Consultant User (simulated)
            var tanuyenConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = tanuyenConsultantUserId,
                UserName = "Consultant at Tan Uyen Medical Center",
                Email = "tuvantanuyen@gmail.com",
                PhoneNumber = "(0274) 3656 340",
                Password = HashPassword("consultant#51"),
                Address = "Obstetrics Department, Tan Uyen City Medical Center",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Tan Uyen Medical Center Consultant (simulated)
            var tanuyenConsultantId = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = tanuyenConsultantId,
                UserId = tanuyenConsultantUserId,
                ClinicId = tanuyenClinicId,
                Specialization = "Obstetrics & Gynecology / prenatal checkups & gynecological consultation",
                Certificate = "Specialist Doctor Level I – Obstetrics and Gynecology",
                Gender = "Male",
                ExperienceYears = 14,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Tan Uyen Medical Center Feedbacks
            var tanuyenFeedback1Id = Guid.NewGuid();
            var tanuyenFeedback2Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = tanuyenFeedback1Id,
                    ClinicId = tanuyenClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 4,
                    Comment = "OB-GYN service is fine; local doctors are friendly; but the number of patients is high so waiting time is long.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = tanuyenFeedback2Id,
                    ClinicId = tanuyenClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 4,
                    Comment = "Routine prenatal checkup at a nearby medical center, convenient; equipment is not very modern.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );


            // Thuan An Medical Center

            // Seed Thuan An City Medical Center Clinic User
            var thuananClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = thuananClinicUserId,
                UserName = "Thuan An City Medical Center",
                Email = "bvthuanan@binhduong.gov.vn",
                PhoneNumber = "0274 3755 434",
                Password = HashPassword("clinic#32"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "Nguyen Van Tiet Street, Dong Tu Quarter, Lai Thieu Ward, Thuan An City, Binh Duong Province, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Thuan An City Medical Center Clinic
            var thuananClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = thuananClinicId,
                UserId = thuananClinicUserId,
                Address = "Nguyen Van Tiet Street, Dong Tu Quarter, Lai Thieu Ward, Thuan An City, Binh Duong Province, Vietnam",
                Description = "Thuan An City Medical Center is a public Grade II hospital providing general healthcare services for Thuan An area. The Obstetrics & Gynecology Department offers prenatal checkups, cesarean sections, obstetric services, gynecological examinations, and laparoscopic surgery for ectopic pregnancy. It has a capacity of about 250 beds. The center was formed by merging local healthcare facilities, including the Medical Center – Hospital – Family Planning & Population services.",
                IsInsuranceAccepted = true,
                Specializations = "Prenatal checkups;Obstetrics & Gynecology / gynecological exams;Cesarean section / obstetric surgery;Obstetric ultrasound;OB-GYN service examinations;Laparoscopic surgery for ectopic pregnancy;Reproductive health checkups;Obstetric emergency;Health insurance examinations;General medicine / internal, surgery, pediatrics;Imaging diagnostics & laboratory tests",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Thuan An City Medical Center Doctor User (simulated)
            var thuananDoctorUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = thuananDoctorUserId,
                UserName = "Doctor at Thuan An Medical Center",
                Email = "doctortpthuanan@gmail.com",
                PhoneNumber = "0274 3755 434",
                Password = HashPassword("doctor#65"),
                Address = "Obstetrics Department, Thuan An City Medical Center",
                CreationDate = new DateTime(2025, 09, 17),
                RoleId = 7,
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Thuan An City Medical Center Doctor (simulated)
            var thuananDoctorId = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = thuananDoctorId,
                UserId = thuananDoctorUserId,
                ClinicId = thuananClinicId,
                Gender = "Female",
                Specialization = "Prenatal checkups / delivery",
                Certificate = "Specialist Doctor Level I – Obstetrics and Gynecology",
                ExperienceYear = 21,
                WorkPosition = "Doctor",
                Description = "Provides routine prenatal checkups, delivery, and cesarean sections at Thuan An City Medical Center.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 17)
            });

            // Seed Thuan An City Medical Center Consultant User (simulated)
            var thuananConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = thuananConsultantUserId,
                UserName = "Consultant at Thuan An Medical Center",
                Email = "tuvanvientpthuanan@gmail.com",
                PhoneNumber = "0274 3755 434",
                Password = HashPassword("consultant#52"),
                Address = "Obstetrics Department, Thuan An City Medical Center",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Thuan An City Medical Center Consultant (simulated)
            var thuananConsultantId = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = thuananConsultantId,
                UserId = thuananConsultantUserId,
                ClinicId = thuananClinicId,
                Specialization = "Obstetrics & Gynecology / prenatal consultation",
                Certificate = "Specialist Doctor Level I – Obstetrics and Gynecology",
                Gender = "Female",
                ExperienceYears = 12,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Thuan An City Medical Center Feedbacks
            var thuananFeedback1Id = Guid.NewGuid();
            var thuananFeedback2Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = thuananFeedback1Id,
                    ClinicId = thuananClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 4,
                    Comment = "OB-GYN service at Thuan An Medical Center is quite good, doctors are approachable, and costs are reasonable.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = thuananFeedback2Id,
                    ClinicId = thuananClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 4,
                    Comment = "Prenatal checkup service is fine, but mornings are usually very crowded and waiting time is long.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );


            // Thu Dau Mot City Medical Center

            // Seed Thu Dau Mot City Medical Center Clinic User
            var thudaumotClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = thudaumotClinicUserId,
                UserName = "Thu Dau Mot City Medical Center",
                Email = "ttytethudaumot@gmail.com",
                PhoneNumber = "0274 3822 054",
                Password = HashPassword("clinic#33"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "03 Van Cong Khai, Phu Cuong, Thu Dau Mot City, Binh Duong Province, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Thu Dau Mot City Medical Center Clinic
            var thudaumotClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = thudaumotClinicId,
                UserId = thudaumotClinicUserId,
                Address = "03 Van Cong Khai, Phu Cuong, Thu Dau Mot City, Binh Duong Province, Vietnam",
                Description = "Thu Dau Mot City Medical Center is a public-level city medical facility providing general healthcare services with multiple specialties, including Obstetrics and Gynecology / Antenatal care. The center serves local residents and neighboring areas, accepts health insurance (BHYT). OB-GYN services can sometimes be crowded due to high demand.",
                IsInsuranceAccepted = true,
                Specializations = "Obstetrics & Gynecology;Antenatal care;Gynecology;Obstetric ultrasound;Reproductive health care;Normal delivery;Basic OB-GYN surgery;Maternity lab tests;Insurance-based medical care;General internal & surgical examinations",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Thu Dau Mot City Medical Center Doctor User (simulated)
            var thudaumotDoctorUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = thudaumotDoctorUserId,
                UserName = "Doctor Thu Dau Mot",
                Email = "bacsithudaumot@gmail.com",
                PhoneNumber = "0274 3822 054",
                Password = HashPassword("doctor#66"),
                Address = "OB-GYN Department, Thu Dau Mot Medical Center",
                CreationDate = new DateTime(2025, 09, 17),
                RoleId = 7,
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Thu Dau Mot City Medical Center Doctor (simulated)
            var thudaumotDoctorId = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = thudaumotDoctorId,
                UserId = thudaumotDoctorUserId,
                ClinicId = thudaumotClinicId,
                Gender = "Female",
                Specialization = "Normal delivery",
                Certificate = "Specialist Level I – Obstetrics & Gynecology",
                ExperienceYear = 12,
                WorkPosition = "Doctor",
                Description = "Performs normal deliveries, antenatal check-ups, and mother & baby care.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 17)
            });

            // Seed Thu Dau Mot City Medical Center Consultant User (simulated)
            var thudaumotConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = thudaumotConsultantUserId,
                UserName = "Consultant TDM",
                Email = "tuvanthudaumot@gmail.com",
                PhoneNumber = "0274 3822 054",
                Password = HashPassword("consultant#53"),
                Address = "OB-GYN Department, Thu Dau Mot Medical Center",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Thu Dau Mot City Medical Center Consultant (simulated)
            var thudaumotConsultantId = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = thudaumotConsultantId,
                UserId = thudaumotConsultantUserId,
                ClinicId = thudaumotClinicId,
                Specialization = "Antenatal consultation & OB-GYN",
                Certificate = "Obstetrics & Gynecology",
                Gender = "Male",
                ExperienceYears = 10,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Thu Dau Mot City Medical Center Feedback
            var thudaumotFeedback1Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(new Feedback
            {
                Id = thudaumotFeedback1Id,
                ClinicId = thudaumotClinicId,
                UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                Rating = 4,
                Comment = "The OB-GYN clinic is nearby and convenient; however, sometimes the waiting time is long.",
                CreationDate = new DateTime(2025, 09, 17)
            });

            // Dong Nai General Hospital

            // Seed Dong Nai General Hospital Clinic User
            var dongnaiClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = dongnaiClinicUserId,
                UserName = "Dong Nai General Hospital",
                Email = "info@benhviendongnai.com.vn",
                PhoneNumber = "0251 896 9966",
                Password = HashPassword("clinic#34"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "No. 2 Dong Khoi, Tam Hiep Ward, Bien Hoa City, Dong Nai Province, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Dong Nai General Hospital Clinic
            var dongnaiClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = dongnaiClinicId,
                UserId = dongnaiClinicUserId,
                Address = "No. 2 Dong Khoi, Tam Hiep Ward, Bien Hoa City, Dong Nai Province, Vietnam",
                Description = "Dong Nai General Hospital is a provincial-level general hospital with a large capacity (~1100 beds), offering a wide range of specialties including a strong Obstetrics & Gynecology department. It provides antenatal check-ups, ultrasounds, deliveries, and reproductive healthcare for local women. The hospital publishes official addresses, OB-GYN departments, schedules, and maternity services on its website.",
                IsInsuranceAccepted = true,
                Specializations = "Antenatal care;Obstetrics & Gynecology;Gynecology;Obstetric ultrasound;Normal & C-section delivery;Prenatal counseling;Fetal anomaly screening;Family planning;Private women’s clinic;General health check-ups & supporting specialties",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Dong Nai General Hospital Doctor User (simulated)
            var dongnaiDoctorUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = dongnaiDoctorUserId,
                UserName = "OB-GYN Specialist Dong Nai",
                Email = "khoasanbvdkdn@gmail.com",
                PhoneNumber = "0877.39.38.37",
                Password = HashPassword("doctor#67"),
                Address = "OB-GYN Department, Dong Nai General Hospital",
                CreationDate = new DateTime(2025, 09, 17),
                RoleId = 7,
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Dong Nai General Hospital Doctor (simulated)
            var dongnaiDoctorId = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = dongnaiDoctorId,
                UserId = dongnaiDoctorUserId,
                ClinicId = dongnaiClinicId,
                Gender = "Female",
                Specialization = "Obstetric ultrasound / Antenatal care",
                Certificate = "Specialist Level I",
                ExperienceYear = 10,
                WorkPosition = "OB-GYN Doctor",
                Description = "Performs fetal ultrasound, routine check-ups, and monitors high-risk pregnancies at the OB-GYN department of Dong Nai General Hospital.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 17)
            });

            // Seed Dong Nai General Hospital Consultant Users
            var dongnaiConsultantUser1Id = Guid.NewGuid();
            var dongnaiConsultantUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = dongnaiConsultantUser1Id,
                    UserName = "Meritorious Physician MSc. Dr. Nguyen Manh Hoan",
                    Email = "khoasanbvdkdn@gmail.com",
                    PhoneNumber = "0877.39.38.37",
                    Password = HashPassword("consultant#54"),
                    Address = "OB-GYN Department – Dong Nai General Hospital, 2 Dong Khoi, Tam Hoa, Bien Hoa, Dong Nai",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = dongnaiConsultantUser2Id,
                    UserName = "Specialist Level II Dr. Hoang Le Minh Tuan",
                    Email = "khoasanbvdkdn@gmail.com",
                    PhoneNumber = "0877.39.38.37",
                    Password = HashPassword("consultant#55"),
                    Address = "OB-GYN Department – Dong Nai General Hospital",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Dong Nai General Hospital Consultants
            var dongnaiConsultant1Id = Guid.NewGuid();
            var dongnaiConsultant2Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = dongnaiConsultant1Id,
                    UserId = dongnaiConsultantUser1Id,
                    ClinicId = dongnaiClinicId,
                    Specialization = "OB-GYN / Head of OB-GYN Department",
                    Certificate = "MSc., Senior Specialist Doctor",
                    Gender = "Male",
                    ExperienceYears = 20,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = dongnaiConsultant2Id,
                    UserId = dongnaiConsultantUser2Id,
                    ClinicId = dongnaiClinicId,
                    Specialization = "OB-GYN / Deputy Head of OB-GYN Department",
                    Certificate = "Specialist Level II",
                    Gender = "Male",
                    ExperienceYears = 18,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                }
            );

            // Seed Dong Nai General Hospital Feedbacks
            var dongnaiFeedback1Id = Guid.NewGuid();
            var dongnaiFeedback2Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = dongnaiFeedback1Id,
                    ClinicId = dongnaiClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "The OB-GYN department in Dong Nai is very strong, with highly experienced doctors and modern equipment; however, mornings are crowded, so waiting is long.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = dongnaiFeedback2Id,
                    ClinicId = dongnaiClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Delivery services here are good, and delivery rooms are relatively well-equipped; however, administrative procedures need improvement.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );


            // Thong Nhat General Hospital (Dong Nai)

            // Seed Thong Nhat General Hospital (Dong Nai) Clinic User
            var thongnhatDNClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = thongnhatDNClinicUserId,
                UserName = "Thong Nhat General Hospital (Dong Nai)",
                Email = "contact@bvthongnhatdn.vn",
                PhoneNumber = "0251 3883 660",
                Password = HashPassword("clinic#35"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "234 National Highway 1A, Tan Bien Ward, Bien Hoa City, Dong Nai Province, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Thong Nhat General Hospital (Dong Nai) Clinic
            var thongnhatDNClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = thongnhatDNClinicId,
                UserId = thongnhatDNClinicUserId,
                Address = "234 National Highway 1A, Tan Bien Ward, Bien Hoa City, Dong Nai Province, Vietnam",
                Description = "Thong Nhat General Hospital is a provincial-level Grade I hospital with more than 1,000 beds, providing comprehensive multi-specialty services. The Obstetrics Department is large-scale, offering antenatal care, delivery (natural birth & C-section), postnatal care, obstetric ultrasound, maternal support, and mother & baby care. The hospital also provides on-demand obstetrics and gynecology services.",
                IsInsuranceAccepted = true,
                Specializations = "Antenatal check-up;Obstetrics & Gynecology;Gynecology;Natural birth & C-section;Obstetric ultrasound;Prenatal counseling;Maternal & neonatal care;On-demand obstetrics & gynecology;Health insurance services;General medical services",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Thong Nhat General Hospital (Dong Nai) Doctor User (simulated)
            var thongnhatDoctorUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = thongnhatDoctorUserId,
                UserName = "Obstetrician Thong Nhat",
                Email = "sbsanphukhoathongnhat@gmail.com",
                PhoneNumber = "0251 3886 099",
                Password = HashPassword("doctor#68"),
                Address = "Obstetrics Department, Thong Nhat General Hospital, Dong Nai",
                CreationDate = new DateTime(2025, 09, 17),
                RoleId = 7,
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Thong Nhat General Hospital (Dong Nai) Doctor (simulated)
            var thongnhatDoctorId = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = thongnhatDoctorId,
                UserId = thongnhatDoctorUserId,
                ClinicId = thongnhatDNClinicId,
                Gender = "Female",
                Specialization = "Antenatal care / delivery",
                Certificate = "General Practitioner specialized in Obstetrics & Gynecology",
                ExperienceYear = 10,
                WorkPosition = "Obstetrician",
                Description = "Provides antenatal check-ups, obstetric ultrasound, normal deliveries, and childbirth at the Obstetrics Department.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 17)
            });

            // Seed Thong Nhat General Hospital (Dong Nai) Consultant Users
            var thongnhatConsultantUser1Id = Guid.NewGuid();
            var thongnhatConsultantUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = thongnhatConsultantUser1Id,
                    UserName = "Specialist I. Ly Thi Xuan Lan",
                    Email = "xuanlan@gmail.com",
                    PhoneNumber = "0251 3886 098",
                    Password = HashPassword("consultant#56"),
                    Address = "Obstetrics Department, Thong Nhat General Hospital, Dong Nai",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = thongnhatConsultantUser2Id,
                    UserName = "Specialist I. Pham Thanh Duong",
                    Email = "phamthanhduong@gmail.com",
                    PhoneNumber = "0251 3886 098",
                    Password = HashPassword("consultant#57"),
                    Address = "Obstetrics Department, Thong Nhat General Hospital, Dong Nai",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Thong Nhat General Hospital (Dong Nai) Consultants
            var thongnhatConsultant1Id = Guid.NewGuid();
            var thongnhatConsultant2Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = thongnhatConsultant1Id,
                    UserId = thongnhatConsultantUser1Id,
                    ClinicId = thongnhatDNClinicId,
                    Specialization = "Deputy Head of Obstetrics / On-demand obstetrics",
                    Certificate = "Specialist Level I",
                    Gender = "Female",
                    ExperienceYears = 15,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = thongnhatConsultant2Id,
                    UserId = thongnhatConsultantUser2Id,
                    ClinicId = thongnhatDNClinicId,
                    Specialization = "Deputy Head of Obstetrics",
                    Certificate = "Specialist Level I",
                    Gender = "Male",
                    ExperienceYears = 15,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                }
            );

            // Seed Thong Nhat General Hospital (Dong Nai) Feedbacks
            var thongnhatDNFeedback1Id = Guid.NewGuid();
            var thongnhatDNFeedback2Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = thongnhatDNFeedback1Id,
                    ClinicId = thongnhatDNClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "The Obstetrics Department is crowded, doctors are skilled, and the service is good. However, waiting times can be long if you don’t book in advance.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = thongnhatDNFeedback2Id,
                    ClinicId = thongnhatDNClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "C-section was fine here, clean delivery rooms, reasonable costs compared to private hospitals.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Hoan My Dong Nai Hospital

            // Seed Hoan My Dong Nai Hospital Clinic User
            var hoanmyDongnaiClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = hoanmyDongnaiClinicUserId,
                UserName = "Hoan My Dong Nai Hospital",
                Email = "contactus.dongnai@hoanmy.com",
                PhoneNumber = "0251 3955 955",
                Password = HashPassword("clinic#36"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "1048A Pham Van Thuan Street, Tam Hiep Ward, Bien Hoa City, Dong Nai Province, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Hoan My Dong Nai Hospital Clinic
            var hoanmyDongnaiClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = hoanmyDongnaiClinicId,
                UserId = hoanmyDongnaiClinicUserId,
                Address = "1048A Pham Van Thuan Street, Tam Hiep Ward, Bien Hoa City, Dong Nai Province, Vietnam",
                Description = "Hoan My Dong Nai Hospital is an international general hospital, with an Obstetrics & Gynecology department trusted by many expectant mothers. Covering an area of ~35,000 m2, equipped with modern facilities, it offers antenatal care, C-section & natural delivery, pregnancy counseling, and mother & baby care. With a highly qualified medical team, it provides both health insurance and premium services.",
                IsInsuranceAccepted = true,
                Specializations = "Antenatal check-up;Obstetrics & Gynecology;Gynecology;Obstetric ultrasound;Natural birth & C-section;Prenatal counseling;Maternal & postnatal care;On-demand obstetrics & gynecology;Imaging diagnostics;Obstetric laboratory tests;International healthcare services",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Hoan My Dong Nai Hospital Doctor User (simulated)
            var hoanmyDongnaiDoctorUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = hoanmyDongnaiDoctorUserId,
                UserName = "Obstetrician Hoan My Dong Nai",
                Email = "bssanphukhoahoanmydn@gmail.com",
                PhoneNumber = "0251 3955 955",
                Password = HashPassword("doctor#69"),
                Address = "Obstetrics Department, Hoan My Dong Nai Hospital",
                CreationDate = new DateTime(2025, 09, 17),
                RoleId = 7,
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Hoan My Dong Nai Hospital Doctor (simulated)
            var hoanmyDongnaiDoctorId = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = hoanmyDongnaiDoctorId,
                UserId = hoanmyDongnaiDoctorUserId,
                ClinicId = hoanmyDongnaiClinicId,
                Gender = "Female",
                Specialization = "Obstetric ultrasound / antenatal care",
                Certificate = "Specialist Level I",
                ExperienceYear = 10,
                WorkPosition = "Obstetrician",
                Description = "Performs pregnancy ultrasound, regular antenatal check-ups, and monitoring mother & baby health.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 17)
            });

            // Seed Hoan My Dong Nai Hospital Consultant Users
            var hoanmyDongnaiConsultantUser1Id = Guid.NewGuid();
            var hoanmyDongnaiConsultantUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = hoanmyDongnaiConsultantUser1Id,
                    UserName = "Specialist I. Nguyen Thi Kim Nga",
                    Email = "nguyenthikimnga@gmail.com",
                    PhoneNumber = "0251 3955 955",
                    Password = HashPassword("consultant#58"),
                    Address = "Obstetrics Department, Hoan My Dong Nai Hospital",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = hoanmyDongnaiConsultantUser2Id,
                    UserName = "Doctor Nguyen Thi Tinh",
                    Email = "nguyenthitinh@gmail.com",
                    PhoneNumber = "0251 3955 955",
                    Password = HashPassword("consultant#59"),
                    Address = "Obstetrics Department, Hoan My Dong Nai Hospital",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Hoan My Dong Nai Hospital Consultants
            var hoanmyDongnaiConsultant1Id = Guid.NewGuid();
            var hoanmyDongnaiConsultant2Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = hoanmyDongnaiConsultant1Id,
                    UserId = hoanmyDongnaiConsultantUser1Id,
                    ClinicId = hoanmyDongnaiClinicId,
                    Specialization = "Obstetrics & Gynecology / Head of Obstetrics Department",
                    Certificate = "Specialist Level I",
                    Gender = "Female",
                    ExperienceYears = 20,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = hoanmyDongnaiConsultant2Id,
                    UserId = hoanmyDongnaiConsultantUser2Id,
                    ClinicId = hoanmyDongnaiClinicId,
                    Specialization = "Obstetrics & Gynecology / antenatal & gynecology",
                    Certificate = "Master, Resident Doctor in Obstetrics & Gynecology",
                    Gender = "Female",
                    ExperienceYears = 16,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                }
            );

            // Seed Hoan My Dong Nai Hospital Feedbacks
            var hoanmyDongnaiFeedback1Id = Guid.NewGuid();
            var hoanmyDongnaiFeedback2Id = Guid.NewGuid();
            var hoanmyDongnaiFeedback3Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = hoanmyDongnaiFeedback1Id,
                    ClinicId = hoanmyDongnaiClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 10,
                    Comment = "Very professional obstetric services, Dr. Kim Nga is gentle, facilities are clean.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = hoanmyDongnaiFeedback2Id,
                    ClinicId = hoanmyDongnaiClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Service cost is higher than public hospitals, but the amenities & care are excellent.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = hoanmyDongnaiFeedback3Id,
                    ClinicId = hoanmyDongnaiClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Had a C-section here, felt safe with modern operating rooms and attentive staff.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );


            // Long Khanh Regional General Hospital

            // Seed Long Khanh Regional General Hospital Clinic User
            var longkhanhClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = longkhanhClinicUserId,
                UserName = "Long Khanh Regional General Hospital",
                Email = "contact@bvlongkhanh.vn",
                PhoneNumber = "0251 3781 385",
                Password = HashPassword("clinic#37"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "No. 25, Hung Vuong Street, Xuan Trung Ward, Long Khanh City, Dong Nai, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Long Khanh Regional General Hospital Clinic
            var longkhanhClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = longkhanhClinicId,
                UserId = longkhanhClinicUserId,
                Address = "No. 25, Hung Vuong Street, Xuan Trung Ward, Long Khanh City, Dong Nai, Vietnam",
                Description = "Long Khanh Regional General Hospital is a Grade II hospital under the Dong Nai Department of Health, providing healthcare services for the residents of Long Khanh City and surrounding areas. The Department of Obstetrics and Gynecology is one of its key specialties, offering prenatal check-ups, pregnancy management, normal delivery, cesarean sections, postpartum care, and gynecological treatment.",
                IsInsuranceAccepted = true,
                Specializations = "Prenatal check-ups;High-risk pregnancy management;Fetal ultrasound;Normal delivery & C-section;Gynecological examination;Gynecological disease treatment;Family planning;Newborn care",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Long Khanh Regional General Hospital Doctor Users
            var longkhanhDoctorUser1Id = Guid.NewGuid();
            var longkhanhDoctorUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = longkhanhDoctorUser1Id,
                    UserName = "Doctor Pham Thi Hong",
                    Email = "phamthihong@gmail.com",
                    PhoneNumber = "0251 3781 385",
                    Password = HashPassword("doctor#70"),
                    Address = "Obstetrics Department – Long Khanh Regional General Hospital",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = longkhanhDoctorUser2Id,
                    UserName = "Doctor Nguyen Van Binh",
                    Email = "nguyenvanbinh@gmail.com",
                    PhoneNumber = "0251 3781 385",
                    Password = HashPassword("doctor#71"),
                    Address = "Obstetrics Department – Long Khanh Regional General Hospital",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Long Khanh Regional General Hospital Doctors
            var longkhanhDoctor1Id = Guid.NewGuid();
            var longkhanhDoctor2Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = longkhanhDoctor1Id,
                    UserId = longkhanhDoctorUser1Id,
                    ClinicId = longkhanhClinicId,
                    Gender = "Female",
                    Specialization = "Obstetrics & Gynecology",
                    Certificate = "Specialist Level II – Obstetrics",
                    ExperienceYear = 20,
                    WorkPosition = "Head of Obstetrics & Gynecology Department",
                    Description = "Expert in pregnancy monitoring, normal deliveries, cesarean sections, and managing high-risk pregnancies.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = longkhanhDoctor2Id,
                    UserId = longkhanhDoctorUser2Id,
                    ClinicId = longkhanhClinicId,
                    Gender = "Male",
                    Specialization = "Obstetrics & Gynecology",
                    Certificate = "Specialist Level I – Obstetrics & Gynecology",
                    ExperienceYear = 10,
                    WorkPosition = "Attending Physician",
                    Description = "Performs prenatal check-ups, ultrasound, diagnosis, and treatment of gynecological diseases.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Seed Long Khanh Regional General Hospital Consultant Users
            var longkhanhConsultantUser1Id = Guid.NewGuid();
            var longkhanhConsultantUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = longkhanhConsultantUser1Id,
                    UserName = "Doctor Nguyen Thi Lan",
                    Email = "nguyenthilan@gmail.com",
                    PhoneNumber = "0251 3781 385",
                    Password = HashPassword("consultant#60"),
                    Address = "Obstetrics & Gynecology Department – Long Khanh Regional General Hospital",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = longkhanhConsultantUser2Id,
                    UserName = "MSc. Doctor Tran Van Hung",
                    Email = "tranvanhung@gmail.com",
                    PhoneNumber = "0251 3781 385",
                    Password = HashPassword("consultant#61"),
                    Address = "Obstetrics & Gynecology Department – Long Khanh Regional General Hospital",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Long Khanh Regional General Hospital Consultants
            var longkhanhConsultant1Id = Guid.NewGuid();
            var longkhanhConsultant2Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = longkhanhConsultant1Id,
                    UserId = longkhanhConsultantUser1Id,
                    ClinicId = longkhanhClinicId,
                    Specialization = "Pregnancy & Reproductive Health Counseling",
                    Certificate = "Specialist Level I – Obstetrics & Gynecology",
                    Gender = "Female",
                    ExperienceYears = 15,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = longkhanhConsultant2Id,
                    UserId = longkhanhConsultantUser2Id,
                    ClinicId = longkhanhClinicId,
                    Specialization = "Pregnancy & Obstetric Disorders Counseling",
                    Certificate = "Master of Medicine – Obstetrics & Gynecology",
                    Gender = "Male",
                    ExperienceYears = 12,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                }
            );

            // Seed Long Khanh Regional General Hospital Feedbacks
            var longkhanhFeedback1Id = Guid.NewGuid();
            var longkhanhFeedback2Id = Guid.NewGuid();
            var longkhanhFeedback3Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = longkhanhFeedback1Id,
                    ClinicId = longkhanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "The obstetricians here are quite dedicated, but sometimes the waiting time is long due to many patients.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = longkhanhFeedback2Id,
                    ClinicId = longkhanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Thorough prenatal care with detailed guidance for mothers, especially for high-risk pregnancies.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = longkhanhFeedback3Id,
                    ClinicId = longkhanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "The facilities are relatively good, but the waiting area is sometimes crowded.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );


            // Trang Bom Regional General Hospital

            // Seed Trang Bom Regional General Hospital Clinic User
            var trangbomClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = trangbomClinicUserId,
                UserName = "Trang Bom Regional General Hospital",
                Email = "contact@bvtrangbom.vn",
                PhoneNumber = "0251 3867 115",
                Password = HashPassword("clinic#38"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "3/2 Street, Quarter 3, Trang Bom Town, Trang Bom District, Dong Nai, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Trang Bom Regional General Hospital Clinic
            var trangbomClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = trangbomClinicId,
                UserId = trangbomClinicUserId,
                Address = "3/2 Street, Quarter 3, Trang Bom Town, Trang Bom District, Dong Nai, Vietnam",
                Description = "Trang Bom Regional General Hospital is a Grade II hospital under the Dong Nai Department of Health, providing healthcare services for residents of Trang Bom District and nearby areas. The Obstetrics and Gynecology Department specializes in maternity care, pregnancy management, normal delivery, cesarean section, postpartum care, and gynecological treatment.",
                IsInsuranceAccepted = true,
                Specializations = "Prenatal check-ups;Fetal ultrasound;High-risk pregnancy monitoring;Normal delivery & C-section;Gynecological examination & treatment;Family planning;Newborn care",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Trang Bom Regional General Hospital Doctor Users
            var trangbomDoctorUser1Id = Guid.NewGuid();
            var trangbomDoctorUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = trangbomDoctorUser1Id,
                    UserName = "Doctor Pham Thi Mai",
                    Email = "phamthimai@gmail.com",
                    PhoneNumber = "0251 3867 115",
                    Password = HashPassword("doctor#72"),
                    Address = "Obstetrics Department – Trang Bom Regional General Hospital",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = trangbomDoctorUser2Id,
                    UserName = "Doctor Nguyen Van Hoa",
                    Email = "nguyenvanhoa@gmail.com",
                    PhoneNumber = "0251 3867 115",
                    Password = HashPassword("doctor#73"),
                    Address = "Obstetrics Department – Trang Bom Regional General Hospital",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Trang Bom Regional General Hospital Doctors
            var trangbomDoctor1Id = Guid.NewGuid();
            var trangbomDoctor2Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = trangbomDoctor1Id,
                    UserId = trangbomDoctorUser1Id,
                    ClinicId = trangbomClinicId,
                    Gender = "Female",
                    Specialization = "Obstetrics & Gynecology",
                    Certificate = "Specialist Level II – Obstetrics & Gynecology",
                    ExperienceYear = 18,
                    WorkPosition = "Head of Obstetrics & Gynecology Department",
                    Description = "Specialized in high-risk pregnancy management, delivery, and obstetric surgery.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = trangbomDoctor2Id,
                    UserId = trangbomDoctorUser2Id,
                    ClinicId = trangbomClinicId,
                    Gender = "Male",
                    Specialization = "Obstetrics & Gynecology",
                    Certificate = "Specialist Level I – Obstetrics & Gynecology",
                    ExperienceYear = 9,
                    WorkPosition = "Attending Physician",
                    Description = "Performs prenatal check-ups, ultrasound, counseling, and treatment of common gynecological conditions.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Seed Trang Bom Regional General Hospital Consultant Users
            var trangbomConsultantUser1Id = Guid.NewGuid();
            var trangbomConsultantUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = trangbomConsultantUser1Id,
                    UserName = "Doctor Le Thi Thu",
                    Email = "lethithu@gmail.com",
                    PhoneNumber = "0251 3867 115",
                    Password = HashPassword("consultant#62"),
                    Address = "Obstetrics & Gynecology Department – Trang Bom Regional General Hospital",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = trangbomConsultantUser2Id,
                    UserName = "MSc. Doctor Nguyen Van An",
                    Email = "nguyenvanan@gmail.com",
                    PhoneNumber = "0251 3867 115",
                    Password = HashPassword("consultant#63"),
                    Address = "Obstetrics & Gynecology Department – Trang Bom Regional General Hospital",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Trang Bom Regional General Hospital Consultants
            var trangbomConsultant1Id = Guid.NewGuid();
            var trangbomConsultant2Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = trangbomConsultant1Id,
                    UserId = trangbomConsultantUser1Id,
                    ClinicId = trangbomClinicId,
                    Specialization = "Pregnancy & Family Planning Counseling",
                    Certificate = "Specialist Level I – Obstetrics & Gynecology",
                    Gender = "Female",
                    ExperienceYears = 14,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = trangbomConsultant2Id,
                    UserId = trangbomConsultantUser2Id,
                    ClinicId = trangbomClinicId,
                    Specialization = "Pregnancy & Gynecological Disorders Counseling",
                    Certificate = "Master of Medicine – Obstetrics & Gynecology",
                    Gender = "Male",
                    ExperienceYears = 11,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                }
            );

            // Seed Trang Bom Regional General Hospital Feedbacks
            var trangbomFeedback1Id = Guid.NewGuid();
            var trangbomFeedback2Id = Guid.NewGuid();
            var trangbomFeedback3Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = trangbomFeedback1Id,
                    ClinicId = trangbomClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "The obstetricians are dedicated and provide thoughtful guidance for first-time mothers.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = trangbomFeedback2Id,
                    ClinicId = trangbomClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Good prenatal services with 4D ultrasound, but the waiting time can be a bit long.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = trangbomFeedback3Id,
                    ClinicId = trangbomClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Facilities are acceptable for a district-level hospital, and the doctors are approachable.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );


            // Nhon Trach District Medical Center

            // Seed Nhon Trach District Medical Center Clinic User
            var nhontrachClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = nhontrachClinicUserId,
                UserName = "Nhon Trach District Medical Center",
                Email = "contact@ttyt-nhontrach.vn",
                PhoneNumber = "0251 3561 115",
                Password = HashPassword("clinic#39"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "Hiep Phuoc Town, Nhon Trach District, Dong Nai, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Nhon Trach District Medical Center Clinic
            var nhontrachClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = nhontrachClinicId,
                UserId = nhontrachClinicUserId,
                Address = "Hiep Phuoc Town, Nhon Trach District, Dong Nai, Vietnam",
                Description = "Nhon Trach District Medical Center is a Grade II healthcare facility under Dong Nai Department of Health, responsible for providing general medical services to local residents. The Obstetrics and Gynecology Department offers prenatal care, ultrasound, diagnosis and treatment of gynecological diseases, childbirth assistance, obstetric surgery, and family planning counseling.",
                IsInsuranceAccepted = true,
                Specializations = "Prenatal check-ups;2D/4D Ultrasound;High-risk pregnancy monitoring;Gynecological diagnosis & treatment;Normal delivery;C-section;Family planning counseling;Neonatal care",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Nhon Trach District Medical Center Doctor Users
            var nhontrachDoctorUser1Id = Guid.NewGuid();
            var nhontrachDoctorUser2Id = Guid.NewGuid();
            var nhontrachDoctorUser3Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = nhontrachDoctorUser1Id,
                    UserName = "Doctor Pham Thi Ngoc",
                    Email = "phamthingoc@gmail.com",
                    PhoneNumber = "0251 3561 115",
                    Password = HashPassword("doctor#74"),
                    Address = "Obstetrics Department – Nhon Trach Medical Center",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = nhontrachDoctorUser2Id,
                    UserName = "Le Van Minh",
                    Email = "levanminh@gmail.com",
                    PhoneNumber = "0251 3561 115",
                    Password = HashPassword("doctor#75"),
                    Address = "Obstetrics Department – Nhon Trach Medical Center",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = nhontrachDoctorUser3Id,
                    UserName = "Nguyen Thi Mai",
                    Email = "nguyenthimai@gmail.com",
                    PhoneNumber = "0251 3561 115",
                    Password = HashPassword("doctor#76"),
                    Address = "Obstetrics Department – Nhon Trach Medical Center",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Nhon Trach District Medical Center Doctors
            var nhontrachDoctor1Id = Guid.NewGuid();
            var nhontrachDoctor2Id = Guid.NewGuid();
            var nhontrachDoctor3Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = nhontrachDoctor1Id,
                    UserId = nhontrachDoctorUser1Id,
                    ClinicId = nhontrachClinicId,
                    Gender = "Female",
                    Specialization = "Obstetrics & Gynecology",
                    Certificate = "Specialist Level II – Obstetrics & Gynecology",
                    ExperienceYear = 20,
                    WorkPosition = "Head of Obstetrics & Gynecology Department",
                    Description = "Specialized in managing high-risk pregnancies, handling difficult deliveries, and obstetric surgeries.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = nhontrachDoctor2Id,
                    UserId = nhontrachDoctorUser2Id,
                    ClinicId = nhontrachClinicId,
                    Gender = "Male",
                    Specialization = "Obstetrics & Gynecology",
                    Certificate = "Specialist Level I – Obstetrics & Gynecology",
                    ExperienceYear = 12,
                    WorkPosition = "Attending Doctor",
                    Description = "Conducts prenatal check-ups, ultrasound, counseling for natural birth and C-sections.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = nhontrachDoctor3Id,
                    UserId = nhontrachDoctorUser3Id,
                    ClinicId = nhontrachClinicId,
                    Gender = "Female",
                    Specialization = "Obstetrics & Gynecology",
                    Certificate = "Specialist Level I – Obstetrics & Gynecology",
                    ExperienceYear = 9,
                    WorkPosition = "Attending Doctor",
                    Description = "Provides gynecological check-ups, prenatal counseling, and postpartum monitoring.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Seed Nhon Trach District Medical Center Consultant Users
            var nhontrachConsultantUser1Id = Guid.NewGuid();
            var nhontrachConsultantUser2Id = Guid.NewGuid();
            var nhontrachConsultantUser3Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = nhontrachConsultantUser1Id,
                    UserName = "Tran Thi Hong",
                    Email = "tranthihong@gmail.com",
                    PhoneNumber = "0251 3561 115",
                    Password = HashPassword("consultant#64"),
                    Address = "Obstetrics Department – Nhon Trach Medical Center",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = nhontrachConsultantUser2Id,
                    UserName = "MSc. Dr. Nguyen Van Dung",
                    Email = "nguyenvandung@gmail.com",
                    PhoneNumber = "0251 3561 115",
                    Password = HashPassword("consultant#65"),
                    Address = "Obstetrics Department – Nhon Trach Medical Center",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = nhontrachConsultantUser3Id,
                    UserName = "Midwife Bachelor Le Thi Lan",
                    Email = "lethilan@gmail.com",
                    PhoneNumber = "0251 3561 115",
                    Password = HashPassword("consultant#66"),
                    Address = "Consulting Room – Nhon Trach Medical Center",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Nhon Trach District Medical Center Consultants
            var nhontrachConsultant1Id = Guid.NewGuid();
            var nhontrachConsultant2Id = Guid.NewGuid();
            var nhontrachConsultant3Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = nhontrachConsultant1Id,
                    UserId = nhontrachConsultantUser1Id,
                    ClinicId = nhontrachClinicId,
                    Specialization = "Pregnancy counseling & prenatal care",
                    Certificate = "Specialist Level I – Obstetrics & Gynecology",
                    Gender = "Female",
                    ExperienceYears = 13,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = nhontrachConsultant2Id,
                    UserId = nhontrachConsultantUser2Id,
                    ClinicId = nhontrachClinicId,
                    Specialization = "Gynecological counseling & family planning",
                    Certificate = "Master of Medicine – Obstetrics & Gynecology",
                    Gender = "Male",
                    ExperienceYears = 10,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = nhontrachConsultant3Id,
                    UserId = nhontrachConsultantUser3Id,
                    ClinicId = nhontrachClinicId,
                    Specialization = "Midwifery care & maternity counseling",
                    Certificate = "Bachelor of Midwifery",
                    Gender = "Female",
                    ExperienceYears = 8,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                }
            );

            // Seed Nhon Trach District Medical Center Feedbacks
            var nhontrachFeedback1Id = Guid.NewGuid();
            var nhontrachFeedback2Id = Guid.NewGuid();
            var nhontrachFeedback3Id = Guid.NewGuid();
            var nhontrachFeedback4Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = nhontrachFeedback1Id,
                    ClinicId = nhontrachClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Doctors provide thorough consultations and clear explanations for expectant mothers.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = nhontrachFeedback2Id,
                    ClinicId = nhontrachClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Prenatal check-ups are quick, but facilities need some upgrades.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = nhontrachFeedback3Id,
                    ClinicId = nhontrachClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Midwives are very dedicated, providing detailed guidance on mother and newborn care.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = nhontrachFeedback4Id,
                    ClinicId = nhontrachClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Full insurance support available, but sometimes long waiting times due to crowding.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );


            // Vinh Cuu District Medical Center

            // Seed Vinh Cuu District Medical Center Clinic User
            var vinhcuuClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = vinhcuuClinicUserId,
                UserName = "Vinh Cuu District Medical Center",
                Email = "contact@ttyt-vinhcuu.vn",
                PhoneNumber = "0251 3860 234",
                Password = HashPassword("clinic#40"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "Vinh An Town, Vinh Cuu District, Dong Nai, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Vinh Cuu District Medical Center Clinic
            var vinhcuuClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = vinhcuuClinicId,
                UserId = vinhcuuClinicUserId,
                Address = "Vinh An Town, Vinh Cuu District, Dong Nai, Vietnam",
                Description = "Vinh Cuu District Medical Center is a district-level healthcare facility under the Dong Nai Department of Health, responsible for general medical services and reproductive health care. The Obstetrics and Gynecology Department provides prenatal checkups, ultrasound, high-risk pregnancy management, gynecological examinations, family planning counseling, and newborn care.",
                IsInsuranceAccepted = true,
                Specializations = "Routine prenatal checkups;2D/4D ultrasound;High-risk pregnancy monitoring and management;Gynecological examination & treatment;Natural delivery;Cesarean section;Postnatal checkups;Family planning counseling;Newborn care",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Vinh Cuu District Medical Center Doctor Users
            var vinhcuuDoctorUser1Id = Guid.NewGuid();
            var vinhcuuDoctorUser2Id = Guid.NewGuid();
            var vinhcuuDoctorUser3Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = vinhcuuDoctorUser1Id,
                    UserName = "Pham Thi Lan",
                    Email = "phamthilan@gmail.com",
                    PhoneNumber = "0251 3860 234",
                    Password = HashPassword("doctor#77"),
                    Address = "Obstetrics Department – Vinh Cuu Medical Center",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = vinhcuuDoctorUser2Id,
                    UserName = "Nguyen Van Hung",
                    Email = "nguyenvanhung@gmail.com",
                    PhoneNumber = "0251 3860 234",
                    Password = HashPassword("doctor#78"),
                    Address = "Obstetrics Department – Vinh Cuu Medical Center",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = vinhcuuDoctorUser3Id,
                    UserName = "Tran Thi Kim Oanh",
                    Email = "kimoanh@gmail.com",
                    PhoneNumber = "0251 3860 234",
                    Password = HashPassword("doctor#79"),
                    Address = "Obstetrics Department – Vinh Cuu Medical Center",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Vinh Cuu District Medical Center Doctors
            var vinhcuuDoctor1Id = Guid.NewGuid();
            var vinhcuuDoctor2Id = Guid.NewGuid();
            var vinhcuuDoctor3Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = vinhcuuDoctor1Id,
                    UserId = vinhcuuDoctorUser1Id,
                    ClinicId = vinhcuuClinicId,
                    Gender = "Female",
                    Specialization = "Obstetrics & Gynecology",
                    Certificate = "Specialist Level II – Obstetrics & Gynecology",
                    ExperienceYear = 18,
                    WorkPosition = "Head of Obstetrics & Gynecology Department",
                    Description = "Specialized in managing high-risk pregnancies, obstetric surgery, and handling difficult deliveries.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = vinhcuuDoctor2Id,
                    UserId = vinhcuuDoctorUser2Id,
                    ClinicId = vinhcuuClinicId,
                    Gender = "Male",
                    Specialization = "Obstetrics & Gynecology",
                    Certificate = "Specialist Level I – Obstetrics & Gynecology",
                    ExperienceYear = 12,
                    WorkPosition = "Attending Doctor",
                    Description = "Performs prenatal checkups, ultrasound, and provides counseling on natural delivery and cesarean section.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = vinhcuuDoctor3Id,
                    UserId = vinhcuuDoctorUser3Id,
                    ClinicId = vinhcuuClinicId,
                    Gender = "Female",
                    Specialization = "Obstetrics & Gynecology",
                    Certificate = "Specialist Level I – Obstetrics & Gynecology",
                    ExperienceYear = 8,
                    WorkPosition = "Attending Doctor",
                    Description = "Provides gynecological examinations, prenatal counseling, and postnatal mother & baby care.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Seed Vinh Cuu District Medical Center Consultant Users
            var vinhcuuConsultantUser1Id = Guid.NewGuid();
            var vinhcuuConsultantUser2Id = Guid.NewGuid();
            var vinhcuuConsultantUser3Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = vinhcuuConsultantUser1Id,
                    UserName = "Nguyen Thi Hanh",
                    Email = "nguyenthihanh@gmail.com",
                    PhoneNumber = "0251 3860 234",
                    Password = HashPassword("consultant#67"),
                    Address = "Obstetrics Department – Vinh Cuu Medical Center",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = vinhcuuConsultantUser2Id,
                    UserName = "Le Minh Quang",
                    Email = "leminhquang@gmail.com",
                    PhoneNumber = "0251 3860 234",
                    Password = HashPassword("consultant#68"),
                    Address = "Obstetrics Department – Vinh Cuu Medical Center",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = vinhcuuConsultantUser3Id,
                    UserName = "Midwife Tran Thu Thao",
                    Email = "tranthuthao@gmail.com",
                    PhoneNumber = "0251 3860 234",
                    Password = HashPassword("consultant#69"),
                    Address = "Consultation Room – Vinh Cuu Medical Center",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Vinh Cuu District Medical Center Consultants
            var vinhcuuConsultant1Id = Guid.NewGuid();
            var vinhcuuConsultant2Id = Guid.NewGuid();
            var vinhcuuConsultant3Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = vinhcuuConsultant1Id,
                    UserId = vinhcuuConsultantUser1Id,
                    ClinicId = vinhcuuClinicId,
                    Specialization = "Prenatal counseling & antenatal care",
                    Certificate = "Specialist Level I – Obstetrics & Gynecology",
                    Gender = "Female",
                    ExperienceYears = 14,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = vinhcuuConsultant2Id,
                    UserId = vinhcuuConsultantUser2Id,
                    ClinicId = vinhcuuClinicId,
                    Specialization = "Gynecological counseling, family planning",
                    Certificate = "Specialist Level I – Obstetrics & Gynecology",
                    Gender = "Male",
                    ExperienceYears = 11,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = vinhcuuConsultant3Id,
                    UserId = vinhcuuConsultantUser3Id,
                    ClinicId = vinhcuuClinicId,
                    Specialization = "Midwifery care",
                    Certificate = "Bachelor of Midwifery",
                    Gender = "Female",
                    ExperienceYears = 9,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                }
            );

            // Seed Vinh Cuu District Medical Center Feedbacks
            var vinhcuuFeedback1Id = Guid.NewGuid();
            var vinhcuuFeedback2Id = Guid.NewGuid();
            var vinhcuuFeedback3Id = Guid.NewGuid();
            var vinhcuuFeedback4Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = vinhcuuFeedback1Id,
                    ClinicId = vinhcuuClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Doctors are dedicated and provide thorough consultations for pregnant women.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = vinhcuuFeedback2Id,
                    ClinicId = vinhcuuClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Fast prenatal checkups, with full health insurance support.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = vinhcuuFeedback3Id,
                    ClinicId = vinhcuuClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Nurses and midwives are very attentive, providing detailed postnatal care guidance.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = vinhcuuFeedback4Id,
                    ClinicId = vinhcuuClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Sometimes it gets crowded and patients have to wait long, but the quality of care is consistent.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );


            // Long Thanh District Medical Center

            // Seed Long Thanh District Medical Center Clinic User
            var longthanhClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = longthanhClinicUserId,
                UserName = "Long Thanh District Medical Center",
                Email = "contact@ttyt-longthanh.vn",
                PhoneNumber = "0251 3843 567",
                Password = HashPassword("clinic#41"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "Long Thanh Town, Long Thanh District, Dong Nai, Vietnam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Long Thanh District Medical Center Clinic
            var longthanhClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = longthanhClinicId,
                UserId = longthanhClinicUserId,
                Address = "Long Thanh Town, Long Thanh District, Dong Nai, Vietnam",
                Description = "Long Thanh District Medical Center is a district-level healthcare facility under the Dong Nai Department of Health, responsible for comprehensive healthcare services for local residents. The Department of Obstetrics and Gynecology provides prenatal check-ups, ultrasound, pregnancy management, gynecological care, family planning counseling, and postpartum mother-baby care.",
                IsInsuranceAccepted = true,
                Specializations = "Prenatal check-ups;2D/4D Ultrasound;High-risk pregnancy management;Gynecological diagnosis and treatment;Natural delivery;Cesarean section;Postpartum check-ups;Pre- and postnatal counseling;Family planning",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Long Thanh District Medical Center Doctor Users
            var longthanhDoctorUser1Id = Guid.NewGuid();
            var longthanhDoctorUser2Id = Guid.NewGuid();
            var longthanhDoctorUser3Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = longthanhDoctorUser1Id,
                    UserName = "Le Thi Mai",
                    Email = "lethimai@gmail.com",
                    PhoneNumber = "0251 3843 567",
                    Password = HashPassword("doctor#80"),
                    Address = "Obstetrics Department – Long Thanh Medical Center",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = longthanhDoctorUser2Id,
                    UserName = "Nguyen Van Toan",
                    Email = "nguyenvantoan@gmail.com",
                    PhoneNumber = "0251 3843 567",
                    Password = HashPassword("doctor#81"),
                    Address = "Obstetrics Department – Long Thanh Medical Center",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = longthanhDoctorUser3Id,
                    UserName = "Vo Thi Hong",
                    Email = "vothihong@gmail.com",
                    PhoneNumber = "0251 3843 567",
                    Password = HashPassword("doctor#82"),
                    Address = "Obstetrics Department – Long Thanh Medical Center",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Long Thanh District Medical Center Doctors
            var longthanhDoctor1Id = Guid.NewGuid();
            var longthanhDoctor2Id = Guid.NewGuid();
            var longthanhDoctor3Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = longthanhDoctor1Id,
                    UserId = longthanhDoctorUser1Id,
                    ClinicId = longthanhClinicId,
                    Gender = "Female",
                    Specialization = "Obstetrics & Gynecology",
                    Certificate = "Specialist Doctor II – Obstetrics & Gynecology",
                    ExperienceYear = 20,
                    WorkPosition = "Head of Obstetrics & Gynecology Department",
                    Description = "Specialized in high-risk pregnancy management, obstetric surgery, and professional training.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = longthanhDoctor2Id,
                    UserId = longthanhDoctorUser2Id,
                    ClinicId = longthanhClinicId,
                    Gender = "Male",
                    Specialization = "Obstetrics & Gynecology",
                    Certificate = "Specialist Doctor I – Obstetrics & Gynecology",
                    ExperienceYear = 10,
                    WorkPosition = "Attending Physician",
                    Description = "Performs prenatal check-ups, ultrasound, and provides consultation for natural and cesarean deliveries.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = longthanhDoctor3Id,
                    UserId = longthanhDoctorUser3Id,
                    ClinicId = longthanhClinicId,
                    Gender = "Female",
                    Specialization = "Obstetrics & Gynecology",
                    Certificate = "Specialist Doctor I – Obstetrics & Gynecology",
                    ExperienceYear = 8,
                    WorkPosition = "Attending Physician",
                    Description = "Provides gynecological care, prenatal counseling, and postpartum mother-baby care.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Seed Long Thanh District Medical Center Consultant Users
            var longthanhConsultantUser1Id = Guid.NewGuid();
            var longthanhConsultantUser2Id = Guid.NewGuid();
            var longthanhConsultantUser3Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = longthanhConsultantUser1Id,
                    UserName = "Nguyen Thi Hoa",
                    Email = "nguyenthihoa@gmail.com",
                    PhoneNumber = "0251 3843 567",
                    Password = HashPassword("consultant#70"),
                    Address = "Obstetrics Department – Long Thanh Medical Center",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = longthanhConsultantUser2Id,
                    UserName = "Tran Minh Khoi",
                    Email = "tranminhkhoi@gmail.com",
                    PhoneNumber = "0251 3843 567",
                    Password = HashPassword("consultant#71"),
                    Address = "Obstetrics Department – Long Thanh Medical Center",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = longthanhConsultantUser3Id,
                    UserName = "Midwife BSc Pham Thi Thu",
                    Email = "phamthithu@gmailLt.com",
                    PhoneNumber = "0251 3843 567",
                    Password = HashPassword("consultant#72"),
                    Address = "Consulting Room – Long Thanh Medical Center",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Long Thanh District Medical Center Consultants
            var longthanhConsultant1Id = Guid.NewGuid();
            var longthanhConsultant2Id = Guid.NewGuid();
            var longthanhConsultant3Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = longthanhConsultant1Id,
                    UserId = longthanhConsultantUser1Id,
                    ClinicId = longthanhClinicId,
                    Specialization = "Prenatal check-ups & pregnancy management",
                    Certificate = "Specialist Doctor I – Obstetrics & Gynecology",
                    Gender = "Female",
                    ExperienceYears = 15,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = longthanhConsultant2Id,
                    UserId = longthanhConsultantUser2Id,
                    ClinicId = longthanhClinicId,
                    Specialization = "Gynecological care & family planning",
                    Certificate = "Specialist Doctor I – Obstetrics & Gynecology",
                    Gender = "Male",
                    ExperienceYears = 12,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = longthanhConsultant3Id,
                    UserId = longthanhConsultantUser3Id,
                    ClinicId = longthanhClinicId,
                    Specialization = "Midwifery – Prenatal counseling",
                    Certificate = "Bachelor of Midwifery",
                    Gender = "Female",
                    ExperienceYears = 9,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                }
            );

            // Seed Long Thanh District Medical Center Feedbacks
            var longthanhFeedback1Id = Guid.NewGuid();
            var longthanhFeedback2Id = Guid.NewGuid();
            var longthanhFeedback3Id = Guid.NewGuid();
            var longthanhFeedback4Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = longthanhFeedback1Id,
                    ClinicId = longthanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Doctors and nurses are dedicated, providing thorough counseling for pregnant women.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = longthanhFeedback2Id,
                    ClinicId = longthanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Health insurance accepted, procedures are relatively quick.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = longthanhFeedback3Id,
                    ClinicId = longthanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Attentive postpartum mother and baby care, very dedicated midwives.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = longthanhFeedback4Id,
                    ClinicId = longthanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Quite crowded during peak hours, but service quality is still maintained.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );


            // Xuan Loc District Medical Center

            // Seed Xuan Loc District Medical Center Clinic User
            var xuanlocClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = xuanlocClinicUserId,
                UserName = "Xuan Loc District Medical Center",
                Email = "contact@ttytxuanloc.vn",
                PhoneNumber = "0251 3874 567",
                Password = HashPassword("clinic#42"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "No. 45, Nguyen Hue Street, Gia Ray Town, Xuan Loc District, Dong Nai Province",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Xuan Loc District Medical Center Clinic
            var xuanlocClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = xuanlocClinicId,
                UserId = xuanlocClinicUserId,
                Address = "No. 45, Nguyen Hue Street, Gia Ray Town, Xuan Loc District, Dong Nai Province",
                Description = "Xuan Loc District Medical Center is a public district-level healthcare unit, providing general medical services, obstetrics & gynecology, and pediatrics. The center especially focuses on maternal and child healthcare with a team of experienced doctors.",
                IsInsuranceAccepted = true,
                Specializations = "Obstetrics;Pediatrics;Prenatal check-ups;Ultrasound;Pregnancy nutrition counseling;Gynecology",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Xuan Loc District Medical Center Doctor Users
            var xuanlocDoctorUser1Id = Guid.NewGuid();
            var xuanlocDoctorUser2Id = Guid.NewGuid();
            var xuanlocDoctorUser3Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = xuanlocDoctorUser1Id,
                    UserName = "Nguyen Huong Giang",
                    Email = "huonggiang.doctor@ttytxuanloc.vn",
                    PhoneNumber = "0909123456",
                    Password = HashPassword("doctor#83"),
                    Address = "Gia Ray, Xuan Loc, Dong Nai",
                    Avatar = null,
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = xuanlocDoctorUser2Id,
                    UserName = "Tran Minh Tam",
                    Email = "minhtam.doctor@ttytxuanloc.vn",
                    PhoneNumber = "0978123456",
                    Password = HashPassword("doctor#84"),
                    Address = "Xuan Bac, Xuan Loc, Dong Nai",
                    Avatar = null,
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = xuanlocDoctorUser3Id,
                    UserName = "Pham Lien Anh",
                    Email = "lienanh.doctor@ttytxuanloc.vn",
                    PhoneNumber = "0967543210",
                    Password = HashPassword("doctor#85"),
                    Address = "Xuan Tho, Xuan Loc, Dong Nai",
                    Avatar = null,
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Xuan Loc District Medical Center Doctors
            var xuanlocDoctor1Id = Guid.NewGuid();
            var xuanlocDoctor2Id = Guid.NewGuid();
            var xuanlocDoctor3Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = xuanlocDoctor1Id,
                    UserId = xuanlocDoctorUser1Id,
                    ClinicId = xuanlocClinicId,
                    Gender = "Female",
                    Specialization = "Obstetrics",
                    Certificate = "Specialist Level I in Obstetrics & Gynecology",
                    ExperienceYear = 18,
                    WorkPosition = "Head of Obstetrics Department",
                    Description = "Specializes in prenatal check-ups, ultrasound, and handling complicated obstetric cases.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = xuanlocDoctor2Id,
                    UserId = xuanlocDoctorUser2Id,
                    ClinicId = xuanlocClinicId,
                    Gender = "Male",
                    Specialization = "Pediatrics",
                    Certificate = "Specialist Level I in Pediatrics",
                    ExperienceYear = 12,
                    WorkPosition = "Pediatric Doctor",
                    Description = "Focuses on monitoring and caring for newborns, especially babies of postpartum mothers.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = xuanlocDoctor3Id,
                    UserId = xuanlocDoctorUser3Id,
                    ClinicId = xuanlocClinicId,
                    Gender = "Female",
                    Specialization = "Gynecology",
                    Certificate = "Specialist in Gynecology",
                    ExperienceYear = 11,
                    WorkPosition = "Attending Doctor",
                    Description = "Focuses on gynecological issues, reproductive health counseling, and family planning.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Seed Xuan Loc District Medical Center Consultant Users
            var xuanlocConsultantUser1Id = Guid.NewGuid();
            var xuanlocConsultantUser2Id = Guid.NewGuid();
            var xuanlocConsultantUser3Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = xuanlocConsultantUser1Id,
                    UserName = "Nguyen Thi Minh Hoa",
                    Email = "minhhoa.consultant@ttytxuanloc.vn",
                    PhoneNumber = "0912345678",
                    Password = HashPassword("consultant#73"),
                    Address = "Xuan Hiep, Xuan Loc, Dong Nai",
                    Avatar = null,
                    RoleId = 6,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = xuanlocConsultantUser2Id,
                    UserName = "Phan Van Quang",
                    Email = "quangphan.consultant@ttytxuanloc.vn",
                    PhoneNumber = "0912987654",
                    Password = HashPassword("consultant#74"),
                    Address = "Gia Ray, Xuan Loc, Dong Nai",
                    Avatar = null,
                    RoleId = 6,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = xuanlocConsultantUser3Id,
                    UserName = "Le Kim Ngan",
                    Email = "nganle.consultant@ttytxuanloc.vn",
                    PhoneNumber = "0933456789",
                    Password = HashPassword("consultant#75"),
                    Address = "Xuan Hoa, Xuan Loc, Dong Nai",
                    Avatar = null,
                    RoleId = 6,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Xuan Loc District Medical Center Consultants
            var xuanlocConsultant1Id = Guid.NewGuid();
            var xuanlocConsultant2Id = Guid.NewGuid();
            var xuanlocConsultant3Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = xuanlocConsultant1Id,
                    UserId = xuanlocConsultantUser1Id,
                    ClinicId = xuanlocClinicId,
                    Specialization = "Prenatal care counseling",
                    Certificate = "Certificate in Reproductive Health Counseling",
                    Gender = "Female",
                    ExperienceYears = 9,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = xuanlocConsultant2Id,
                    UserId = xuanlocConsultantUser2Id,
                    ClinicId = xuanlocClinicId,
                    Specialization = "Maternal nutrition counseling",
                    Certificate = "Clinical Nutrition Certificate",
                    Gender = "Male",
                    ExperienceYears = 8,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = xuanlocConsultant3Id,
                    UserId = xuanlocConsultantUser3Id,
                    ClinicId = xuanlocClinicId,
                    Specialization = "Prenatal psychology counseling",
                    Certificate = "Clinical Psychology Certificate",
                    Gender = "Female",
                    ExperienceYears = 6,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                }
            );

            // Seed Xuan Loc District Medical Center Feedbacks
            var xuanlocFeedback1Id = Guid.NewGuid();
            var xuanlocFeedback2Id = Guid.NewGuid();
            var xuanlocFeedback3Id = Guid.NewGuid();
            var xuanlocFeedback4Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = xuanlocFeedback1Id,
                    ClinicId = xuanlocClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 10,
                    Comment = "Dr. Giang is very dedicated, carefully monitoring my pregnancy week by week.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = xuanlocFeedback2Id,
                    ClinicId = xuanlocClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Prenatal check-up services are quite good, but sometimes the waiting time is a bit long.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = xuanlocFeedback3Id,
                    ClinicId = xuanlocClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 10,
                    Comment = "Nutrition counseling is very helpful, helping me control weight properly during pregnancy.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = xuanlocFeedback4Id,
                    ClinicId = xuanlocClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 10,
                    Comment = "The psychology counseling team is very enthusiastic, helping me reduce anxiety during pregnancy.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );


        }

        private static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}