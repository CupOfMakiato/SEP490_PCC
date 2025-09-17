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
                UserName = "Bệnh viện Từ Dũ",
                Email = "web.admin@tudu.com.vn",
                PhoneNumber = "(028) 3952.6568",
                Password = HashPassword("clinic#1"),
                Balance = 0,
                RoleId = 5, // Assuming 5 is the role ID for clinics
                CreationDate = new DateTime(2025, 09, 05),
                Address = "284 Cống Quỳnh, Phường Bến Thành, Quận 1, TP. Hồ Chí Minh",
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
                Address = "284 Cống Quỳnh, Phường Bến Thành, Quận 1, TP. Hồ Chí Minh",
                Description = "Bệnh viện Từ Dũ là bệnh viện đầu ngành về Sản - Phụ khoa và hỗ trợ điều trị hiếm muộn tại khu vực phía Nam. Được giao nhiệm vụ giám sát, chuyển giao kỹ thuật cho nhiều tỉnh, cung cấp dịch vụ khám chữa bệnh, can thiệp chuyên sâu về sản phụ khoa và hỗ trợ sinh sản.",
                IsInsuranceAccepted = true,
                Specializations = "Sản khoa (thai sản, đỡ đẻ, chăm sóc sơ sinh);Phụ khoa (phẫu thuật phụ khoa, nội soi phụ khoa);Hiếm muộn - Hỗ trợ sinh sản (IVF, thụ tinh nhân tạo);Can thiệp bào thai;Khám và tầm soát ung thư phụ khoa và ung thư vú;Kế hoạch hóa gia đình",
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
                    UserName = "Đặng Thị Trân Hạnh",
                    Email = "dang.tran.hanh@tudu.com.vn",
                    PhoneNumber = "+84-28-3952-6568",
                    Password = HashPassword("doctor#1"),
                    Address = "Khoa Cấp cứu / Sản, Bệnh viện Từ Dũ",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7, // Assuming 7 is the role ID for doctors
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = doctorUser2Id,
                    UserName = "Lê Văn Minh",
                    Email = "le.minh@tudu.com.vn",
                    PhoneNumber = "+84-914-111-222",
                    Password = HashPassword("doctor#2"),
                    Address = "Khoa Phẫu thuật - Bệnh viện Từ Dũ",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7, // Assuming 7 is the role ID for doctors
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = doctorUser3Id,
                    UserName = "Phan Thị Hương",
                    Email = "phan.huong@tudu.com.vn",
                    PhoneNumber = "+84-915-333-444",
                    Password = HashPassword("doctor#3"),
                    Address = "Đơn vị Hỗ trợ sinh sản, Bệnh viện Từ Dũ",
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
                    Specialization = "Sản phụ khoa, cấp cứu sản",
                    Certificate = "Bác sĩ Chuyên khoa I Sản Phụ khoa",
                    ExperienceYear = 25,
                    WorkPosition = "Trưởng khoa Cấp cứu",
                    Description = "Bác sĩ Đặng Thị Trân Hạnh hiện đang giữ vị trí Trưởng khoa Cấp cứu tại Bệnh viện Từ Dũ.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = doctor2Id,
                    UserId = doctorUser2Id,
                    ClinicId = clinicId,
                    Gender = "Male",
                    Specialization = "Phẫu thuật phụ khoa, nội soi",
                    Certificate = "Bác sĩ Chuyên khoa II",
                    ExperienceYear = 12,
                    WorkPosition = "Bác sĩ phẫu thuật chính",
                    Description = "Bác sĩ chuyên phẫu thuật phụ khoa nội soi, tham gia nhiều ca mổ phức tạp.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = doctor3Id,
                    UserId = doctorUser3Id,
                    ClinicId = clinicId,
                    Gender = "Female",
                    Specialization = "Hiếm muộn - IVF",
                    Certificate = "Chuyên gia Hỗ trợ sinh sản",
                    ExperienceYear = 15,
                    WorkPosition = "Trưởng nhóm IVF",
                    Description = "Tham gia điều trị IVF, can thiệp hỗ trợ sinh sản.",
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
                    UserName = "Huỳnh Thị Anh",
                    Email = "huynh.anh@tudu.com.vn",
                    PhoneNumber = "+84-912-345-678",
                    Password = HashPassword("consultant#1"),
                    Address = "Khoa Khám, Bệnh viện Từ Dũ, 284 Cống Quỳnh, Q1",
                    RoleId = 6, // Assuming 6 is the role ID for consultants,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = consultantUser2Id,
                    UserName = "Ngô Thị Lan",
                    Email = "ngo.lan@tudu.com.vn",
                    PhoneNumber = "+84-913-222-333",
                    Password = HashPassword("consultant#2"),
                    Address = "Trung tâm tư vấn dinh dưỡng sản phụ, Bệnh viện Từ Dũ",
                    RoleId = 6, // Assuming 6 is the role ID for consultants,
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
                    Specialization = "Tư vấn khám thai định kỳ, tầm soát ung thư cổ tử cung",
                    Certificate = "Thạc sĩ Sản Phụ khoa",
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
                    Specialization = "Tư vấn dinh dưỡng thai kỳ",
                    Certificate = "Cử nhân Dinh dưỡng lâm sàng",
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
                    Comment = "Dịch vụ chuyên môn tốt, đông bệnh nhân nên thời gian chờ lâu.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = feedback2Id,
                    ClinicId = clinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 10,
                    Comment = "Đội ngũ bác sĩ giàu kinh nghiệm, quy trình khám chuyên nghiệp.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Bv Hùng Vương
            // Seed Hùng Vương Clinic User
            var hvClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = hvClinicUserId,
                UserName = "Bệnh viện Hùng Vương",
                Email = "bv.hungvuong@tphcm.gov.vn",
                PhoneNumber = "(028) 3855 8532",
                Password = HashPassword("clinic#2"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "128 Hồng Bàng, Phường 12, Quận 5, TP. Hồ Chí Minh, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Hùng Vương Clinic
            var hvClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = hvClinicId,
                UserId = hvClinicUserId,
                Address = "128 Hồng Bàng, Phường 12, Quận 5, TP. Hồ Chí Minh, Việt Nam",
                Description = "Bệnh viện chuyên ngành Sản – Phụ khoa tuyến Trung ương, hạng I. Quy mô khoảng 900 giường (trong đó có 100 giường sơ sinh), với hơn 1.300 nhân viên, bao gồm các khoa lâm sàng, cận lâm sàng và phòng chức năng. Trung bình mỗi năm tiếp nhận hàng chục nghìn trẻ sơ sinh chào đời và hàng nghìn ca phẫu thuật.",
                IsInsuranceAccepted = true,
                Specializations = "Sản khoa (thai sản, đỡ đẻ);Phụ khoa (bao gồm phẫu thuật phụ khoa);Hiếm muộn – hỗ trợ sinh sản;Khám tiền sản – thai sản dịch vụ;Khám nhũ – tầm soát ung thư vú;Khám sàn chậu / niệu phụ khoa;Khám trẻ sơ sinh, chăm sóc sơ sinh",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Hùng Vương Doctor Users
            var hvDoctorUser1Id = Guid.NewGuid();
            var hvDoctorUser2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = hvDoctorUser1Id,
                    UserName = "Nguyễn Thị Hiền",
                    Email = "nguyen.thi.hien@bvhungvuong.vn",
                    PhoneNumber = "+84-28-3855-8532",
                    Password = HashPassword("doctor#4"),
                    Address = "Phó trưởng khoa Nhi, Bệnh viện Hùng Vương",
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
                    UserName = "Phùng Chí Nhân",
                    Email = "phung.chinhan@bvhungvuong.vn",
                    PhoneNumber = "+84-28-3855 8532",
                    Password = HashPassword("doctor#5"),
                    Address = "Khoa Hồi sức cấp cứu, Bệnh viện Hùng Vương",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Hùng Vương Doctors
            var hvDoctor1Id = Guid.NewGuid();
            var hvDoctor2Id = Guid.NewGuid();

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = hvDoctor1Id,
                    UserId = hvDoctorUser1Id,
                    ClinicId = hvClinicId,
                    Gender = "Female",
                    Specialization = "Nhi",
                    Certificate = "Bác sĩ Chuyên khoa I",
                    ExperienceYear = 15,
                    WorkPosition = "Phó trưởng khoa",
                    Description = "Phó trưởng khoa Nhi, tham gia khám – điều trị các bệnh nhi.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = hvDoctor2Id,
                    UserId = hvDoctorUser2Id,
                    ClinicId = hvClinicId,
                    Gender = "Male",
                    Specialization = "Hồi sức cấp cứu",
                    Certificate = "Bác sĩ Chuyên khoa I",
                    ExperienceYear = 10,
                    WorkPosition = "Bác sĩ",
                    Description = "Bác sĩ tại Khoa Hồi sức cấp cứu.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Hùng Vương Consultant User
            var hvConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = hvConsultantUserId,
                UserName = "PGS.TS.BS Huỳnh Nguyễn Khánh Trang",
                Email = "huynh.khanhtrang@bvhungvuong.vn",
                PhoneNumber = "+84-28-3855-8532",
                Password = HashPassword("consultant#3"),
                Address = "Khoa Sản bệnh, Bệnh viện Hùng Vương",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Hùng Vương Consultant
            var hvConsultantId = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = hvConsultantId,
                UserId = hvConsultantUserId,
                ClinicId = hvClinicId,
                Specialization = "Sản khoa – thai kỳ bệnh lý",
                Certificate = "Phó Giáo sư, Tiến sĩ, Bác sĩ Chuyên khoa II",
                Gender = "Female",
                ExperienceYears = 30,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Hùng Vương Feedbacks
            var hvFeedback1Id = Guid.NewGuid();
            var hvFeedback2Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = hvFeedback1Id,
                    ClinicId = hvClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Bác sĩ chuyên môn tốt, cơ sở vật chất đầy đủ, nhưng thời gian chờ khá lâu.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = hvFeedback2Id,
                    ClinicId = hvClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Dịch vụ BHYT được chấp nhận dễ dàng, nhân viên thân thiện.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Bv Đại học Y Dược TP. HCM
            // Seed Đại học Y Dược Clinic User
            var dhydClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = dhydClinicUserId,
                UserName = "Bệnh viện Đại học Y Dược TP. Hồ Chí Minh",
                Email = "bvdhyd@umc.edu.vn",
                PhoneNumber = "(84.28) 3855 4269",
                Password = HashPassword("clinic#3"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "Cơ sở 1: 215 Hồng Bàng, Phường 11, Quận 5, TP. Hồ Chí Minh; Cơ sở 2: 201 Nguyễn Chí Thanh, Phường Chợ Lớn, Quận 5, TP. Hồ Chí Minh; Cơ sở 3: 221B Hoàng Văn Thụ, Phường Phú Nhuận, TP. Hồ Chí Minh",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Đại học Y Dược Clinic
            var dhydClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = dhydClinicId,
                UserId = dhydClinicUserId,
                Address = "Cơ sở 1: 215 Hồng Bàng, Phường 11, Quận 5, TP. Hồ Chí Minh; Cơ sở 2: 201 Nguyễn Chí Thanh, Phường Chợ Lớn, Quận 5, TP. Hồ Chí Minh; Cơ sở 3: 221B Hoàng Văn Thụ, Phường Phú Nhuận, TP. Hồ Chí Minh",
                Description = "Bệnh viện Đại học Y Dược TP. HCM là bệnh viện đa khoa, đa chuyên khoa, kết hợp giữa khám chữa bệnh, đào tạo và nghiên cứu khoa học. Có 3 cơ sở chính tại TP.HCM, cung cấp dịch vụ khám ngoại trú, điều trị nội trú, phẫu thuật, khám chuyên khoa sâu.",
                IsInsuranceAccepted = true,
                Specializations = "Ngoại tổng quát;Nội tổng hợp;Chẩn đoán hình ảnh;Sản phụ khoa;Nhi;Tim mạch;Chấn thương chỉnh hình;Thẩm mỹ – Tạo hình;Tai Mũi Họng;Cơ xương khớp;Da liễu;Khám chuyên gia tại phòng khám",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Đại học Y Dược Doctor Users
            var dhydDoctorUser1Id = Guid.NewGuid();
            var dhydDoctorUser2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = dhydDoctorUser1Id,
                    UserName = "PGS. TS. BS Võ Tấn Đức",
                    Email = "vo.tan.duc@umc.edu.vn",
                    PhoneNumber = "+84-28-3855 4269",
                    Password = HashPassword("doctor#6"),
                    Address = "Khoa Chẩn đoán hình ảnh, UMC cơ sở 1",
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
                    UserName = "BS CKII Trần Hữu Lợi",
                    Email = "tran.huu.loi@umc.edu.vn",
                    PhoneNumber = "+84-28-3855 4269",
                    Password = HashPassword("doctor#7"),
                    Address = "Phòng khám Nội Tổng quát, UMC cơ sở 1",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Đại học Y Dược Doctors
            var dhydDoctor1Id = Guid.NewGuid();
            var dhydDoctor2Id = Guid.NewGuid();

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = dhydDoctor1Id,
                    UserId = dhydDoctorUser1Id,
                    ClinicId = dhydClinicId,
                    Gender = "Male",
                    Specialization = "Chẩn đoán hình ảnh",
                    Certificate = "PGS, TS, BS",
                    ExperienceYear = 25,
                    WorkPosition = "Trưởng khoa Chẩn đoán hình ảnh",
                    Description = "Lãnh đạo khoa Chẩn đoán hình ảnh UMC; có nhiều công trình chuyên môn và tham gia đào tạo.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = dhydDoctor2Id,
                    UserId = dhydDoctorUser2Id,
                    ClinicId = dhydClinicId,
                    Gender = "Male",
                    Specialization = "Nội tổng quát",
                    Certificate = "Bác sĩ Chuyên khoa II",
                    ExperienceYear = 20,
                    WorkPosition = "Bác sĩ khám tổng quát",
                    Description = "Làm việc tại phòng khám Nội Tổng quát, nhiều năm kinh nghiệm khám chữa bệnh nội khoa.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Đại học Y Dược Consultant Users
            var dhydConsultantUser1Id = Guid.NewGuid();
            var dhydConsultantUser2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = dhydConsultantUser1Id,
                    UserName = "GS. TS. BS Phạm Kiên Hữu",
                    Email = "pham.kienhuu@umc.edu.vn",
                    PhoneNumber = "+84-28-3855 4269",
                    Password = HashPassword("consultant#4"),
                    Address = "Phòng khám chuyên khoa, UMC cơ sở 1, 215 Hồng Bàng, Quận 5",
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
                    UserName = "PGS. TS. BS Lê Anh Thư",
                    Email = "le.anhthu@umc.edu.vn",
                    PhoneNumber = "+84-28-3855 4269",
                    Password = HashPassword("consultant#5"),
                    Address = "Phòng khám chuyên khoa Cơ xương khớp, UMC cơ sở 1",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Đại học Y Dược Consultants
            var dhydConsultant1Id = Guid.NewGuid();
            var dhydConsultant2Id = Guid.NewGuid();

            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = dhydConsultant1Id,
                    UserId = dhydConsultantUser1Id,
                    ClinicId = dhydClinicId,
                    Specialization = "Tai – Mũi – Họng",
                    Certificate = "Giáo sư, Tiến sĩ, Bác sĩ",
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
                    Specialization = "Cơ xương khớp",
                    Certificate = "Phó Giáo sư, Tiến sĩ, Bác sĩ",
                    Gender = "Female",
                    ExperienceYears = 40,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                }
            );

            // Seed Đại học Y Dược Feedbacks
            var dhydFeedback1Id = Guid.NewGuid();
            var dhydFeedback2Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = dhydFeedback1Id,
                    ClinicId = dhydClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Cơ sở khang trang, bác sĩ nhiệt tình; thời gian chờ hơi lâu.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = dhydFeedback2Id,
                    ClinicId = dhydClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Dịch vụ khám chuyên gia tốt, trang thiết bị hiện đại.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Bệnh viện FV (FV Hospital)
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
                Description = "FV Hospital là bệnh viện quốc tế cao cấp tại Quận 7, TP. HCM, được thành lập năm 2003 bởi các bác sĩ Pháp-Việt. Với chất lượng quốc tế, trang thiết bị y tế hiện đại, hơn 30 chuyên khoa, phục vụ cả bệnh nhân trong nước và quốc tế. Bệnh viện có 220 giường nội trú, dịch vụ cấp cứu 24/7, phòng khám ngoại trú, chăm sóc sản phụ khoa, ung thư, tim mạch, nhi, mắt, nội soi, xét nghiệm & chẩn đoán hình ảnh.",
                IsInsuranceAccepted = true,
                Specializations = "Ung thư – Hy Vọng Cancer Care Centre;Sản – Phụ khoa;Nhi & sơ sinh;Mắt (Ophthalmology);Tiêu hóa – Gan mật;Nội tổng quát;Trao đổi chất;Chẩn đoán hình ảnh;Ngoại — phẫu thuật tổng quát;Tim mạch;Cấp cứu 24/7;Thăm khám quốc tế / quốc tế hóa dịch vụ y tế",
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
                    UserName = "Dr. Lê Minh Đức",
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
                    UserName = "Dr. Lê Đình Phương",
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
                    Specialization = "Sản phụ khoa (Obstetrics & Gynaecology)",
                    Certificate = "Bác sĩ chuyên khoa I/II / tương đương",
                    ExperienceYear = 15,
                    WorkPosition = "Bác sĩ khám chuyên khoa",
                    Description = "Là một trong các bác sĩ công khai trên trang FV Hospital, thường khám chuyên khoa sản phụ khoa.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = fvDoctor2Id,
                    UserId = fvDoctorUser2Id,
                    ClinicId = fvClinicId,
                    Gender = "Male",
                    Specialization = "Nội tổng quát (Internal Medicine)",
                    Certificate = "Bác sĩ chuyên khoa",
                    ExperienceYear = 12,
                    WorkPosition = "Bác sĩ chuyên khoa nội",
                    Description = "Một bác sĩ trong khoa Nội tổng quát, lịch khám được công khai trên trang chủ.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed FV Consultant User
            var fvConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = fvConsultantUserId,
                UserName = "Dr Jane Smith",
                Email = "jane.smith@fvhospital.com",
                PhoneNumber = "+84-28-3511-3333",
                Password = HashPassword("consultant#6"),
                Address = "Phòng khám chuyên khoa, FV Hospital, Quận 7",
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
                Certificate = "Tiến sĩ, Bác sĩ chuyên khoa II",
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
                    Comment = "Dịch vụ quốc tế, nhân viên thân thiện, bảo đảm vệ sinh tốt — nhưng giá hơi cao.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = fvFeedback2Id,
                    ClinicId = fvClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Bệnh viện sạch, bác sĩ chuyên môn tốt; dịch vụ cấp cứu rất nhanh.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Bệnh viện Vinmec Central Park
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
                Address = "208 Nguyễn Hữu Cảnh, Phường 22, Quận Bình Thạnh, TP. Hồ Chí Minh, Vietnam",
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
                Address = "208 Nguyễn Hữu Cảnh, Phường 22, Quận Bình Thạnh, TP. Hồ Chí Minh, Vietnam",
                Description = "Vinmec Central Park là bệnh viện quốc tế thành viên hệ thống Vinmec, với cơ sở vật chất hiện đại, đội ngũ bác sĩ trong nước và quốc tế, tiêu chuẩn quốc tế (JCI), cung cấp nhiều chuyên khoa chuyên sâu như ung thư, tim mạch, ngoại, sản phụ khoa, nhi, chẩn đoán hình ảnh,… hoạt động 24/7 cho cấp cứu.",
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
                    Address = "Vinmec Central Park, Bình Thạnh, TP. HCM",
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
                    Description = "Bác sĩ phẫu thuật tim mạch với hơn 40 năm kinh nghiệm, được nhắc đến trong danh sách các bác sĩ nổi bật của Vinmec Central Park.",
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
                    Description = "Bác sĩ da liễu – thẩm mỹ, được đào tạo quốc tế, chuyên về laser & chăm sóc da.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Vinmec Consultant User
            var vinmecConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = vinmecConsultantUserId,
                UserName = "Dr. Jane Doe (mẫu)",
                Email = "jane.doe@vinmec.com",
                PhoneNumber = "+84-28-3622-1166",
                Password = HashPassword("consultant#7"),
                Address = "Vinmec Central Park, Quận Bình Thạnh",
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
                Certificate = "Tiến sĩ, Bác sĩ chuyên khoa II",
                Gender = "Female",
                ExperienceYears = 20,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Vinmec Feedbacks
            var vinmecFeedback1Id = Guid.NewGuid();
            var vinmecFeedback2Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = vinmecFeedback1Id,
                    ClinicId = vinmecClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 10,
                    Comment = "Cơ sở rất sạch, nhân viên thân thiện; khám cấp cứu và xử lý nhanh chóng.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = vinmecFeedback2Id,
                    ClinicId = vinmecClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 10,
                    Comment = "Dịch vụ quốc tế tốt, chi phí hơi cao nhưng tương xứng chất lượng.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Bệnh viện Hoàn Mỹ Sài Gòn
            // Seed Hoan My Clinic User
            var hoanmyClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = hoanmyClinicUserId,
                UserName = "Bệnh viện Đa khoa Hoàn Mỹ Sài Gòn",
                Email = "contact@hoanmysaigon.com",
                PhoneNumber = "(028) 3990 2468",
                Password = HashPassword("clinic#6"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "60-60A Phan Xích Long, Phường 1, Quận Phú Nhuận, TP. Hồ Chí Minh, Việt Nam",
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
                Address = "60-60A Phan Xích Long, Phường 1, Quận Phú Nhuận, TP. Hồ Chí Minh, Việt Nam",
                Description = "Bệnh viện Hoàn Mỹ Sài Gòn là bệnh viện tư nhân, thành lập năm 1999, với quy mô khoảng 300 giường tại TP. HCM, phục vụ cả ngoại trú và nội trú. Thế mạnh gồm đa chuyên khoa, khám yêu cầu, gói khám tổng quát, dịch vụ cấp cứu 24/7. Thành viên của hệ thống Y khoa Hoàn Mỹ, được nhiều bệnh nhân đánh giá cao về chất lượng và dịch vụ.",
                IsInsuranceAccepted = true,
                Specializations = "Đa khoa tổng hợp;Ngoại - Phẫu thuật;Sản - Phụ khoa;Nhi;Cấp cứu 24/7;Khám sức khỏe tổng quát;Thận - Tiết niệu;Ung bướu;Chẩn đoán hình ảnh;Nội khoa;Phẫu thuật chỉnh hình;Tai Mũi Họng;Nội soi & tiêu hóa;Khám định kỳ",
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
                    UserName = "Dr. Vũ Đình Kha",
                    Email = "vu.dinh.kha@hoanmysaigon.com",
                    PhoneNumber = "+84-28-3990-2468",
                    Password = HashPassword("doctor#12"),
                    Address = "Bệnh viện Hoàn Mỹ Sài Gòn, Phú Nhuận, TP. HCM",
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
                    Address = "Bệnh viện Hoàn Mỹ Sài Gòn, Phú Nhuận, TP. HCM",
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
                    Address = "Bệnh viện Hoàn Mỹ Sài Gòn, Phú Nhuận, TP. HCM",
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
                    Specialization = "Thận & Tiết niệu",
                    Certificate = "Bác sĩ Chuyên khoa II",
                    ExperienceYear = 21,
                    WorkPosition = "Trưởng khoa Ngoại Tiết niệu",
                    Description = "Bác sĩ Vũ Đình Kha tốt nghiệp Y khoa năm 1995, có bằng Chuyên khoa I & II Thận Tiết niệu, hơn 21 năm kinh nghiệm trong thận và tiết niệu tại Hoàn Mỹ.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = hoanmyDoctor2Id,
                    UserId = hoanmyDoctorUser2Id,
                    ClinicId = hoanmyClinicId,
                    Gender = "Male",
                    Specialization = "Tim mạch (Cardiology)",
                    Certificate = "Bác sĩ Chuyên khoa II",
                    ExperienceYear = 22,
                    WorkPosition = "Trưởng khoa Tim mạch",
                    Description = "Lãnh đạo Khoa Tim mạch với hơn 22 năm kinh nghiệm; đảm nhận các can thiệp tim mạch và điều trị các bệnh lý tim đặc biệt.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = hoanmyDoctor3Id,
                    UserId = hoanmyDoctorUser3Id,
                    ClinicId = hoanmyClinicId,
                    Gender = "Male",
                    Specialization = "Ung bướu (Oncology)",
                    Certificate = "Bác sĩ Chuyên khoa II",
                    ExperienceYear = 30,
                    WorkPosition = "Trưởng khoa Ung bướu",
                    Description = "Bác sĩ Trần Đình Thanh hiện là Trưởng khoa Ung bướu tại Hoàn Mỹ Sài Gòn; có nhiều năm làm việc tại Bệnh viện Phạm Ngọc Thạch trước khi chuyển sang Hoàn Mỹ.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Hoan My Consultant User
            var hoanmyConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = hoanmyConsultantUserId,
                UserName = "Dr. Mẫu Tư Vấn",
                Email = "tu.van@hoanmysaigon.com",
                PhoneNumber = "+84-28-3990-2468",
                Password = HashPassword("consultant#8"),
                Address = "Bệnh viện Hoàn Mỹ Sài Gòn, Phú Nhuận, TP. HCM",
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
                Specialization = "Khám chuyên gia nội tổng quát",
                Certificate = "Chứng chỉ chuyên khoa cấp I/II",
                Gender = "Female",
                ExperienceYears = 20,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Hoan My Feedbacks
            var hoanmyFeedback1Id = Guid.NewGuid();
            var hoanmyFeedback2Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = hoanmyFeedback1Id,
                    ClinicId = hoanmyClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Dịch vụ tốt, bác sĩ tận tâm; phòng chữa bệnh và thiết bị đầy đủ, tuy nhiên giá hơi cao với một số dịch vụ.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = hoanmyFeedback2Id,
                    ClinicId = hoanmyClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 7,
                    Comment = "Thời gian chờ khám lâu, nhưng bù lại bác sĩ giải thích rõ ràng, nhân viên thân thiện.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Bệnh viện Tâm Anh TP.HCM

            // Seed Tam Anh Clinic User
            var tamanhClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = tamanhClinicUserId,
                UserName = "Bệnh viện Đa khoa Tâm Anh TP. HCM",
                Email = "cskh@hcm.tahospital.vn",
                PhoneNumber = "(028) 7102 6789",
                Password = HashPassword("clinic#7"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "2B Phổ Quang, Phường 2, Quận Tân Bình, TP. Hồ Chí Minh, Việt Nam",
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
                Address = "2B Phổ Quang, Phường 2, Quận Tân Bình, TP. Hồ Chí Minh, Việt Nam",
                Description = "Bệnh viện Đa khoa Tâm Anh TP.HCM là bệnh viện cao cấp được đầu tư theo chuẩn 5 sao, hoạt động từ năm 2021, quy tụ đội ngũ bác sĩ đầu ngành trong nước, hệ thống trang thiết bị y tế hiện đại, dịch vụ khám chữa bệnh đa khoa, khám theo yêu cầu và điều trị chuyên sâu. Được đánh giá cao về chất lượng dịch vụ và cơ sở vật chất sang trọng.",
                IsInsuranceAccepted = true,
                Specializations = "Chẩn đoán hình ảnh;Chấn thương chỉnh hình;Cơ-Xương-Khớp;Điều trị tích cực;Gây mê hồi sức;Ung bướu;Kiểm soát nhiễm khuẩn;Nhi khoa;Nội soi tiêu hóa;Sản-phụ khoa;Sơ sinh;Tai-Mũi-Họng;Tiết niệu;Tiểu đường / Nội tiết;Vac-xin;Nội tổng hợp",
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
                    UserName = "TS. BS Đỗ Minh Hùng",
                    Email = "do.minh.hung@tahospital.vn",
                    PhoneNumber = "+84-28-7102-6789",
                    Password = HashPassword("doctor#15"),
                    Address = "Trung tâm Nội soi và Phẫu thuật Nội soi Tiêu hóa, Bệnh viện Tâm Anh TP.HCM",
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
                    UserName = "TS. BS Cam Ngọc Phượng",
                    Email = "cam.ngoc.phuong@tahospital.vn",
                    PhoneNumber = "+84-28-7102-6789",
                    Password = HashPassword("doctor#16"),
                    Address = "Trung tâm Sơ sinh, Bệnh viện Tâm Anh TP.HCM",
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
                    UserName = "Dr. Mẫu Khác",
                    Email = "mau.khac@tahospital.vn",
                    PhoneNumber = "+84-28-7102-6789",
                    Password = HashPassword("doctor#17"),
                    Address = "Khoa Chẩn đoán hình ảnh, Bệnh viện Tâm Anh TP.HCM",
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
                    Specialization = "Tiêu hóa - Gan mật",
                    Certificate = "Tiến sĩ, BS chuyên khoa",
                    ExperienceYear = 30,
                    WorkPosition = "Giám đốc Trung tâm Nội soi & Phẫu thuật Nội soi",
                    Description = "Chuyên gia đầu ngành về nội soi và phẫu thuật nội soi tiêu hóa, có nhiều năm kinh nghiệm tại các bệnh viện lớn.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = tamanhDoctor2Id,
                    UserId = tamanhDoctorUser2Id,
                    ClinicId = tamanhClinicId,
                    Gender = "Female",
                    Specialization = "Sơ sinh",
                    Certificate = "Tiến sĩ, BS chuyên khoa",
                    ExperienceYear = 30,
                    WorkPosition = "Giám đốc Trung tâm Sơ sinh",
                    Description = "Giám đốc Trung tâm Sơ sinh, chăm sóc sơ sinh, có nhiều năm kinh nghiệm trong chăm sóc trẻ nhỏ.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = tamanhDoctor3Id,
                    UserId = tamanhDoctorUser3Id,
                    ClinicId = tamanhClinicId,
                    Gender = "Male",
                    Specialization = "Chẩn đoán hình ảnh",
                    Certificate = "BS CKII",
                    ExperienceYear = 20,
                    WorkPosition = "Bác sĩ cao cấp",
                    Description = "Một bác sĩ khám và chẩn đoán hình ảnh với nhiều năm kinh nghiệm.",
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
                    UserName = "PGS. TS. BS Phạm Nguyễn Vinh",
                    Email = "pham.nguyen.vinh@tahospital.vn",
                    PhoneNumber = "+84-28-7102-6789",
                    Password = HashPassword("consultant#9"),
                    Address = "Trung tâm Tim mạch, Bệnh viện Đa khoa Tâm Anh TP.HCM",
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
                    UserName = "TTƯT. PGS. TS. BS Vũ Lê Chuyên",
                    Email = "vu.le.chuyen@tahospital.vn",
                    PhoneNumber = "+84-28-7102-6789",
                    Password = HashPassword("consultant#10"),
                    Address = "Trung tâm Tiết niệu - Thận học - Nam khoa, Bệnh viện Đa khoa Tâm Anh TP.HCM",
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
                    UserName = "BS CKII Nguyễn Bá Mỹ Nhi",
                    Email = "nguyen.ba.my.nhi@tahospital.vn",
                    PhoneNumber = "+84-28-7102-6789",
                    Password = HashPassword("consultant#11"),
                    Address = "Trung tâm Sản Phụ khoa, Bệnh viện Tâm Anh TP.HCM",
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
                    Specialization = "Nội tim mạch (Cardiology)",
                    Certificate = "PGS, Tiến sĩ, Bác sĩ",
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
                    Specialization = "Tiết niệu - Nam học",
                    Certificate = "PGS, Tiến sĩ, BS chuyên khoa cao cấp",
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
                    Specialization = "Sản Phụ khoa",
                    Certificate = "BS CKII",
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
                    Comment = "Dịch vụ tốt, cơ sở sạch đẹp, bác sĩ chuyên môn cao.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = tamanhFeedback2Id,
                    ClinicId = tamanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Thời gian chờ khám lâu, chi phí hơi cao nhưng chất lượng tốt.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = tamanhFeedback3Id,
                    ClinicId = tamanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Nhân viên tận tình, hỗ trợ tốt trong việc đặt lịch và thủ tục.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Bệnh viện Nhân Dân 115

            // Seed ND115 Clinic User
            var nd115ClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = nd115ClinicUserId,
                UserName = "Bệnh viện Nhân Dân 115",
                Email = "bvnd115tphcm@gmail.com",
                PhoneNumber = "(028) 38.683.496",
                Password = HashPassword("clinic#8"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "Khu Kỹ thuật cao: 818 Sư Vạn Hạnh, Phường Hòa Hưng, TP. Hồ Chí Minh; Cổng cấp cứu (Cổng 4): 527 Sư Vạn Hạnh, Phường Hòa Hưng; Khám yêu cầu (Cổng 3): 527 Sư Vạn Hạnh, Phường Hòa Hưng; Khám bảo hiểm: 88 Thành Thái, Phường Hòa Hưng; Trung tâm Nghiên cứu & Phát triển (Cổng 1): 3 Dương Quang Trung, Phường Hòa Hưng",
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
                Address = "Khu Kỹ thuật cao: 818 Sư Vạn Hạnh, Phường Hòa Hưng, TP. Hồ Chí Minh; Cổng cấp cứu (Cổng 4): 527 Sư Vạn Hạnh, Phường Hòa Hưng; Khám yêu cầu (Cổng 3): 527 Sư Vạn Hạnh, Phường Hòa Hưng; Khám bảo hiểm: 88 Thành Thái, Phường Hòa Hưng; Trung tâm Nghiên cứu & Phát triển (Cổng 1): 3 Dương Quang Trung, Phường Hòa Hưng",
                Description = "Bệnh viện Nhân Dân 115 là bệnh viện đa khoa hạng I tuyến cuối trực thuộc Sở Y Tế TP. Hồ Chí Minh. Với hơn 30 năm hoạt động, sở hữu 5 chuyên khoa mũi nhọn, 7 khối lâm sàng, 45 khoa phòng, khoảng 1.600 giường; đội ngũ bác sĩ trình độ sau đại học chiếm gần 70%. BV có các chuyên khoa mũi nhọn như Thần kinh, Tim mạch, Thận – Niệu, Can thiệp Mạch máu - Thần kinh, Cấp cứu – Gây mê – Hồi sức cấp cứu, Chống độc.",
                IsInsuranceAccepted = true,
                Specializations = "Thần kinh (Neurology, đột quỵ);Tim mạch & Tim mạch can thiệp;Thận – Niệu, Ghép thận;Can thiệp mạch máu - Thần kinh;Cấp cứu, Gây mê – Hồi sức cấp cứu;Chống độc;Ngoại Tổng quát;Ngoại Chấn thương Chỉnh hình;Nội Thần kinh;Nội tiêu hóa – Gan mật;Nội Tiết;Cơ Xương Khớp;Y học cổ truyền & Phục hồi chức năng;Khám theo yêu cầu;Khám bảo hiểm y tế",
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
                    UserName = "BS CKII Phạm Đức Đạt",
                    Email = "pham.duc.dat@bv115.vn",
                    PhoneNumber = "+84-28-3865-2368",
                    Password = HashPassword("doctor#18"),
                    Address = "Khoa Tim mạch Can thiệp, Bệnh viện Nhân dân 115",
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
                    UserName = "ThS. BS Tạ Công Thành",
                    Email = "ta.cong.thanh@bv115.vn",
                    PhoneNumber = "+84-28-3865-2368",
                    Password = HashPassword("doctor#19"),
                    Address = "Khoa Tim mạch Can thiệp, Bệnh viện Nhân dân 115",
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
                    UserName = "BS CKII Tôn Thất Tuấn Khiêm",
                    Email = "tonthat.tuan khiem@bv115.vn",
                    PhoneNumber = "+84-28-3865-2368",
                    Password = HashPassword("doctor#20"),
                    Address = "Khoa Tim mạch Can thiệp, Bệnh viện Nhân dân 115",
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
                    Specialization = "Tim mạch can thiệp",
                    Certificate = "Bác sĩ Chuyên khoa II",
                    ExperienceYear = 23,
                    WorkPosition = "Trưởng Khoa Tim mạch Can thiệp",
                    Description = "Là bác sĩ chuyên đầu ngành can thiệp tim mạch tại BV Nhân dân 115; được nhắc tới trong các bài viết “Top bác sĩ tim mạch bệnh viện 115” với trên 20 năm kinh nghiệm.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = nd115Doctor2Id,
                    UserId = nd115DoctorUser2Id,
                    ClinicId = nd115ClinicId,
                    Gender = "Male",
                    Specialization = "Tim mạch can thiệp",
                    Certificate = "Thạc sĩ, Bác sĩ",
                    ExperienceYear = 20,
                    WorkPosition = "Bác sĩ Can thiệp",
                    Description = "Một trong các bác sĩ trong Top 5 tim mạch bệnh viện 115; kinh nghiệm nhiều năm trong lĩnh vực.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = nd115Doctor3Id,
                    UserId = nd115DoctorUser3Id,
                    ClinicId = nd115ClinicId,
                    Gender = "Male",
                    Specialization = "Tim mạch can thiệp",
                    Certificate = "Bác sĩ Chuyên khoa II",
                    ExperienceYear = 18,
                    WorkPosition = "Bác sĩ cao cấp",
                    Description = "Được nhắc tới trong danh sách bác sĩ tim mạch nổi bật tại BV 115.",
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
                    UserName = "TTƯT. PGS. TS. BS Nguyễn Huy Thắng",
                    Email = "nguyen.huy.thang@bv115.vn",
                    PhoneNumber = "+84-28-3865-2368",
                    Password = HashPassword("consultant#12"),
                    Address = "Khoa Bệnh lý Mạch Máu Não, Bệnh viện Nhân dân 115",
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
                    UserName = "TS. BS. Trương Hoàng Minh",
                    Email = "truong.hoang.minh@bv115.vn",
                    PhoneNumber = "+84-28-3865-2368",
                    Password = HashPassword("consultant#13"),
                    Address = "Khoa Ngoại Niệu – Ghép thận, BV Nhân dân 115",
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
                    UserName = "BS CKII Nguyễn Hữu Tâm",
                    Email = "nguyen.huu.tam@bv115.vn",
                    PhoneNumber = "+84-28-3865-2368",
                    Password = HashPassword("consultant#14"),
                    Address = "Khoa Chấn thương Chỉnh hình, BV Nhân dân 115",
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
                    Specialization = "Thần kinh – Bệnh lý mạch máu não",
                    Certificate = "Phó Giáo sư, Tiến sĩ, Bác sĩ chuyên khoa cao cấp",
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
                    Specialization = "Ngoại tiết niệu, Ghép thận",
                    Certificate = "Tiến sĩ, Bác sĩ chuyên khoa II",
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
                    Specialization = "Chấn thương chỉnh hình",
                    Certificate = "Bác sĩ chuyên khoa II",
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
                    Comment = "Bệnh viện rộng, chuyên môn tốt; tuy nhiên số lượng bệnh nhân đông dẫn tới chờ khám lâu.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = nd115Feedback2Id,
                    ClinicId = nd115ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Cơ sở kỹ thuật tốt, các bác sĩ nhiệt tình, nhưng thủ tục hơi rườm rà.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = nd115Feedback3Id,
                    ClinicId = nd115ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Khám bảo hiểm thuận tiện; bác sĩ giải thích rõ ràng.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Bệnh viện Thống Nhất TP.HCM

            // Seed Thong Nhat Clinic User
            var thongnhatClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = thongnhatClinicUserId,
                UserName = "Bệnh viện Thống Nhất TP. HCM",
                Email = "thongnhathospital@bvtn.org.vn",
                PhoneNumber = "(028) 3869 0277",
                Password = HashPassword("clinic#9"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "Số 1 Lý Thường Kiệt, Phường 7, Quận Tân Bình, TP. Hồ Chí Minh, Việt Nam",
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
                Address = "Số 1 Lý Thường Kiệt, Phường 7, Quận Tân Bình, TP. Hồ Chí Minh, Việt Nam",
                Description = "Bệnh viện đa khoa hạng I, trực thuộc Bộ Y tế, thành lập ngày 01/11/1975, cung cấp nhiều chuyên khoa khám chữa bệnh nội trú & ngoại trú, có dịch vụ khám sản phụ khoa, khám thai, khám dịch vụ & khám bảo hiểm y tế.",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ / sản phụ khoa;Tư vấn tiền sản;Siêu âm thai;Theo dõi tăng trưởng thai nhi;Xét nghiệm trước sinh;Khám phụ khoa;Khám sản dịch vụ;Khám theo yêu cầu",
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
                    UserName = "BS Nguyễn Thị Phương Hạnh (mẫu)",
                    Email = "nguyen.phuong.hanh@bvtn.org.vn",
                    PhoneNumber = "(028) 3869 0277",
                    Password = HashPassword("doctor#21"),
                    Address = "Khoa Sản-phụ khoa, Bệnh viện Thống Nhất",
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
                    UserName = "BS Lê Minh Đức (mẫu)",
                    Email = "le.minh.duc@bvtn.org.vn",
                    PhoneNumber = "(028) 3869 0277",
                    Password = HashPassword("doctor#22"),
                    Address = "Khoa Khám bệnh / Sản-phụ khoa, Bệnh viện Thống Nhất",
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
                    Specialization = "Sản phụ khoa / khám thai & đỡ đẻ",
                    Certificate = "Bác sĩ chuyên khoa II",
                    ExperienceYear = 20,
                    WorkPosition = "Bác sĩ chuyên khoa Sản phụ khoa",
                    Description = "Một trong những bác sĩ có lịch khám thai và đỡ đẻ, kinh nghiệm khám sản phụ khoa lâu năm.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = thongnhatDoctor2Id,
                    UserId = thongnhatDoctorUser2Id,
                    ClinicId = thongnhatClinicId,
                    Gender = "Male",
                    Specialization = "Siêu âm thai & khám chuyên sản",
                    Certificate = "Bác sĩ chuyên khoa I",
                    ExperienceYear = 15,
                    WorkPosition = "Bác sĩ siêu âm thai",
                    Description = "Thực hiện siêu âm thai định kỳ, theo dõi tăng trưởng thai nhi.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Thong Nhat Consultant User
            var thongnhatConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = thongnhatConsultantUserId,
                UserName = "BS CKI Ngô Thị Kim Anh",
                Email = "ngothi.kimanh@bvtn.org.vn",
                PhoneNumber = "(028) 3869 0277",
                Password = HashPassword("consultant#15"),
                Address = "Khoa Khám bệnh / Sản-phụ khoa, Bệnh viện Thống Nhất",
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
                Specialization = "Sản phụ khoa / khám thai",
                Certificate = "Bác sĩ Chuyên khoa I",
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
                    Comment = "Khám thai bình thường tốt, bác sĩ dễ thương, nhưng chờ lâu.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = thongnhatFeedback2Id,
                    ClinicId = thongnhatClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Dịch vụ khám thai dịch vụ ổn, siêu âm rõ, nhân viên tận tâm.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Bệnh viện Chợ Rẫy

            // Seed Cho Ray Clinic User
            var chorayClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = chorayClinicUserId,
                UserName = "Bệnh viện Chợ Rẫy",
                Email = "bvchoray@choray.vn",
                PhoneNumber = "0283 8554 137",
                Password = HashPassword("clinic#10"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "201B Nguyễn Chí Thanh, Phường 12, Quận 5, TP. Hồ Chí Minh, Việt Nam",
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
                Address = "201B Nguyễn Chí Thanh, Phường 12, Quận 5, TP. Hồ Chí Minh, Việt Nam",
                Description = "Bệnh viện Chợ Rẫy là bệnh viện đa khoa trung ương hạng đặc biệt, hơn 100 năm hoạt động, có nhiều chuyên khoa sâu, tiếp nhận cả các ca bệnh phức tạp, nguy kịch. Có dịch vụ sản phụ khoa / khám thai / tư vấn thai phụ bằng các khoa chuyên môn, hỗ trợ BHYT, đặt lịch khám.",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ / sản phụ khoa;Siêu âm thai;Xét nghiệm trước sinh;Theo dõi tăng trưởng / phát triển thai nhi;Đỡ đẻ / sinh thường / mổ lấy thai;Khám phụ khoa;Tư vấn tiền sản;Khám sản dịch vụ;Khám bệnh theo yêu cầu;Khám bảo hiểm Y tế",
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
                    UserName = "BS Nguyễn Thị Hoa",
                    Email = "nguyen.thi.hoa@choray.vn",
                    PhoneNumber = "0283 8554 137",
                    Password = HashPassword("doctor#23"),
                    Address = "Khoa Sản phụ khoa, Bệnh viện Chợ Rẫy",
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
                    UserName = "BS Lê Văn Tuấn",
                    Email = "le.van.tuan@choray.vn",
                    PhoneNumber = "0283 8554 137",
                    Password = HashPassword("doctor#24"),
                    Address = "Khoa Siêu âm / Sản phụ khoa, Bệnh viện Chợ Rẫy",
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
                    Specialization = "Sản phụ khoa / đỡ đẻ",
                    Certificate = "Bác sĩ chuyên khoa I",
                    ExperienceYear = 18,
                    WorkPosition = "Bác sĩ sản phụ khoa",
                    Description = "Thực hiện các ca sinh, theo dõi thai kỳ, khám sản dịch vụ và tư vấn tiền sản.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = chorayDoctor2Id,
                    UserId = chorayDoctorUser2Id,
                    ClinicId = chorayClinicId,
                    Gender = "Male",
                    Specialization = "Siêu âm thai / thủ thuật phụ khoa",
                    Certificate = "Bác sĩ chuyên khoa I",
                    ExperienceYear = 15,
                    WorkPosition = "Bác sĩ siêu âm sản",
                    Description = "Khám, thực hiện siêu âm thai định kỳ và phát hiện sớm bất thường trong thai kỳ.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Cho Ray Consultant User
            var chorayConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = chorayConsultantUserId,
                UserName = "BS CKII Trần Thị Thanh Mai",
                Email = "tran.thanh.mai@choray.vn",
                PhoneNumber = "0283 8554 137",
                Password = HashPassword("consultant#16"),
                Address = "Khoa Sản phụ khoa, Bệnh viện Chợ Rẫy",
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
                Specialization = "Sản phụ khoa / khám thai & theo dõi thai kỳ",
                Certificate = "Bác sĩ chuyên khoa II",
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
                    Comment = "Khám thai tốt, bác sĩ chuyên môn cao, tuy nhiên phải chờ lâu vì đông bệnh nhân.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = chorayFeedback2Id,
                    ClinicId = chorayClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Dịch vụ sản phụ khoa đầy đủ; siêu âm rõ, nhân viên phòng khám thân thiện.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Bệnh viện Nhi Đồng 1

            // Seed Nhi Dong 1 Clinic User
            var nhidong1ClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = nhidong1ClinicUserId,
                UserName = "Bệnh viện Nhi Đồng 1",
                Email = "bvnhidong@nhidong.org.vn",
                PhoneNumber = "(028) 3927 1119",
                Password = HashPassword("clinic#11"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "341 Sư Vạn Hạnh, Phường Vườn Lài, TP. Hồ Chí Minh, Việt Nam",
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
                Address = "341 Sư Vạn Hạnh, Phường Vườn Lài, TP. Hồ Chí Minh, Việt Nam",
                Description = "Bệnh viện chuyên khoa Nhi hạng I, tuyến đầu về khám chữa bệnh nhi cho trẻ từ sơ sinh đến khoảng 15 tuổi tại khu vực phía Nam. Có các khoa như sơ sinh, hô hấp, nhiễm, tim mạch, dinh dưỡng, thần kinh, chẩn đoán hình ảnh, phẫu thuật nhi,… Hỗ trợ khám chữa bằng BHYT và khám dịch vụ. Không có chuyên khoa sản / khám thai cho phụ nữ vì chỉ khám nhi.",
                IsInsuranceAccepted = true,
                Specializations = "Nhi sơ sinh;Hô hấp – Suyễn;Nhiễm trùng;Tim mạch trẻ em;Thận trẻ em;Thần kinh trẻ em;Dinh dưỡng;Tiêu hóa – Gan mật trẻ em;Chẩn đoán hình ảnh nhi;Nội tổng quát nhi;Phẫu thuật nhi;Khám bệnh theo yêu cầu nhi;Khám dịch vụ nhi",
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
                    UserName = "ThS. BS Nguyễn Ngọc Bách",
                    Email = "nguyen.ngoc.bach@nhidong.org.vn",
                    PhoneNumber = "(028) 3927 1119",
                    Password = HashPassword("doctor#25"),
                    Address = "Khoa Khám theo yêu cầu nhi – Nhi Đồng 1",
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
                    UserName = "BS Huỳnh Kim Anh",
                    Email = "huynh.kim.anh@nhidong.org.vn",
                    PhoneNumber = "(028) 3927 1119",
                    Password = HashPassword("doctor#26"),
                    Address = "Khoa Sơ sinh – Nhi Đồng 1",
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
                    Specialization = "Khám dịch vụ Nhi",
                    Certificate = "Thạc sĩ, BS chuyên khoa",
                    ExperienceYear = 20,
                    WorkPosition = "Bác sĩ chuyên khoa cao cấp",
                    Description = "Tham gia khám dịch vụ nhi, khám chuyên khoa theo yêu cầu; có lịch khám bệnh theo hẹn qua Medpro.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = nhidong1Doctor2Id,
                    UserId = nhidong1DoctorUser2Id,
                    ClinicId = nhidong1ClinicId,
                    Gender = "Female",
                    Specialization = "Sơ sinh / chăm sóc trẻ sơ sinh",
                    Certificate = "Bác sĩ chuyên khoa I",
                    ExperienceYear = 15,
                    WorkPosition = "Bác sĩ sơ sinh",
                    Description = "Chăm sóc trẻ sơ sinh, hỗ trợ tiếp sinh, theo dõi sức khỏe sơ sinh.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Nhi Dong 1 Consultant User
            var nhidong1ConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = nhidong1ConsultantUserId,
                UserName = "BS CKII Trần Thị Mỹ Hạnh",
                Email = "tran.my.hanh@nhidong.org.vn",
                PhoneNumber = "(028) 3927 1119",
                Password = HashPassword("consultant#17"),
                Address = "Khoa Nhiễm – Nhi Đồng 1",
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
                Specialization = "Nhiễm trẻ em",
                Certificate = "Bác sĩ chuyên khoa II",
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
                    Comment = "Chăm sóc trẻ em rất tốt, nhân viên thân thiện, nhưng chờ đợi lâu cho khám dịch vụ.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = nhidong1Feedback2Id,
                    ClinicId = nhidong1ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 4,
                    Comment = "Thiết bị nhi hiện đại, bác sĩ tuyến đầu; nhưng bệnh viện rất đông nên hơi khó lấy lịch khám nhanh.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = nhidong1Feedback3Id,
                    ClinicId = nhidong1ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 5,
                    Comment = "Khám yêu cầu qua Medpro tiện lợi; bác sĩ dịch vụ tốt — phụ huynh hài lòng.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Bệnh viện Nhi Đồng 2

            // Seed Nhi Dong 2 Clinic User
            var nhidong2ClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = nhidong2ClinicUserId,
                UserName = "Bệnh viện Nhi Đồng 2",
                Email = "contact@benhviennhi.org.vn",
                PhoneNumber = "(028) 3829 5723 / (028) 3829 5724",
                Password = HashPassword("clinic#12"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "14 Lý Tự Trọng, Phường Bến Nghé, Quận 1, TP. Hồ Chí Minh, Việt Nam",
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
                Address = "14 Lý Tự Trọng, Phường Bến Nghé, Quận 1, TP. Hồ Chí Minh, Việt Nam",
                Description = "Bệnh viện chuyên khoa Nhi hạng I thuộc Sở Y tế TP. HCM, phục vụ trẻ em từ 0 đến dưới 16 tuổi. Gồm 38 khoa lâm sàng & cận lâm sàng, khoảng 1.400 giường bệnh, trang thiết bị hiện đại, khám chữa bệnh nội ngoại, khám dịch vụ, phòng khám theo yêu cầu chất lượng cao. Không chuyên sản / khám thai định kỳ cho phụ nữ vì chuyên nhi, nhưng có phòng tư vấn tiền sản khi liên quan tới chẩn đoán dị tật bẩm sinh trong thai kỳ.",
                IsInsuranceAccepted = true,
                Specializations = "Nhiễm trùng;Nhi sơ sinh;Hô hấp trẻ em;Tim mạch trẻ em;Thận – Nội tiết trẻ em;Thần kinh trẻ em;Tiêu hóa - Gan mật trẻ em;Ung bướu - Huyết học trẻ em;Khám dịch vụ nhi;Phòng khám theo yêu cầu chất lượng cao;Khám bệnh tổng quát nhi;Chẩn đoán hình ảnh nhi;Hồi sức sơ sinh / chống độc trẻ em;Khám tâm lý nhi;Phẫu thuật nhi",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Nhi Dong 2 Doctor User
            var nhidong2DoctorUser1Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = nhidong2DoctorUser1Id,
                UserName = "BS Lê Thị Hương (mẫu)",
                Email = "le.thi.huong@benhviennhi.org.vn",
                PhoneNumber = "(028) 3829 5723",
                Password = HashPassword("doctor#27"),
                Address = "Khoa Sức khỏe trẻ em / Khám theo yêu cầu, Nhi Đồng 2",
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
                Specialization = "Khám dịch vụ nhi",
                Certificate = "Bác sĩ chuyên khoa I",
                ExperienceYear = 12,
                WorkPosition = "Bác sĩ điều trị",
                Description = "Thực hiện khám dịch vụ nhi, khám đưa trẻ đến khám theo lịch hẹn, khám nhi tổng quát.",
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
                    UserName = "BS.CK2 Phan Tấn Đức",
                    Email = "phan.tan.duc@benhviennhi.org.vn",
                    PhoneNumber = "(028) 3829 5723",
                    Password = HashPassword("consultant#18"),
                    Address = "Bệnh viện Nhi Đồng 2, Quận 1, TP. HCM",
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
                    UserName = "ThS. BS Nguyễn Hồng Vân Khánh",
                    Email = "nguyen.hong.van.khanh@benhviennhi.org.vn",
                    PhoneNumber = "(028) 3829 5723",
                    Password = HashPassword("consultant#19"),
                    Address = "Bệnh viện Nhi Đồng 2, khoa Gan - mật - tụy",
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
                    Specialization = "Thận – Niệu nhi / Giải phẫu niệu trẻ em",
                    Certificate = "Bác sĩ Chuyên khoa II",
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
                    Specialization = "Gan mật – Tụy nhi",
                    Certificate = "Thạc sĩ, Bác sĩ chuyên khoa",
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
                    Comment = "Khám bệnh nhi rất tốt, nhân viên thân thiện, nhưng có nhiều trẻ nên chờ lâu vào buổi sáng.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = nhidong2Feedback2Id,
                    ClinicId = nhidong2ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Phòng khám dịch vụ theo yêu cầu rõ ràng, thiết bị tốt; phụ huynh hài lòng.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Bệnh viện Thành phố Thủ Đức

            // Seed Thu Duc Clinic User
            var thuducClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = thuducClinicUserId,
                UserName = "Bệnh viện Thành phố Thủ Đức",
                Email = "bv.dkthuduc@tphcm.gov.vn",
                PhoneNumber = "09 6633 1010",
                Password = HashPassword("clinic#13"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "29 Phú Châu, Phường Tam Phú, Thành phố Thủ Đức, TP. Hồ Chí Minh, Việt Nam",
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
                Address = "29 Phú Châu, Phường Tam Phú, Thành phố Thủ Đức, TP. Hồ Chí Minh, Việt Nam",
                Description = "Bệnh viện thành phố Thủ Đức là bệnh viện hạng I theo tiêu chuẩn Bộ Y tế, có đầy đủ các chuyên khoa (gồm Sản phụ khoa), với các dịch vụ khám chữa bệnh nội trú & ngoại trú, khám dịch vụ chất lượng cao, khám thai, siêu âm, chăm sóc sức khỏe sinh sản. Khoa Sản có 15 bác sĩ, 42 điều dưỡng, 70 giường bệnh.",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ / Sản phụ khoa;Khám phụ khoa;Siêu âm thai;Đỡ sinh & mổ lấy thai;Tư vấn tiền sản;Chăm sóc bà mẹ sau sinh;Khám sản dịch vụ;Khám sức khỏe sinh sản;Khám theo yêu cầu;Khám bảo hiểm y tế",
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
                    UserName = "BS Lê Minh Thư (mẫu)",
                    Email = "le.minh.thu@bvthuduc.vn",
                    PhoneNumber = "09 6633 1010",
                    Password = HashPassword("doctor#29"),
                    Address = "Khoa Sản, Bệnh viện Thành phố Thủ Đức",
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
                    UserName = "BS Trần Thị Hạnh (mẫu)",
                    Email = "tran.thi.hanh@bvthuduc.vn",
                    PhoneNumber = "09 6633 1010",
                    Password = HashPassword("doctor#30"),
                    Address = "Khoa Sản, Bệnh viện Thành phố Thủ Đức",
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
                    Specialization = "Khám thai định kỳ / tư vấn thai phụ",
                    Certificate = "Bác sĩ chuyên khoa I",
                    ExperienceYear = 12,
                    WorkPosition = "Bác sĩ Sản phụ khoa",
                    Description = "Thực hiện khám thai, siêu âm định kỳ, theo dõi thai kỳ bình thường, dịch vụ khám sản phụ khoa dịch vụ.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = thuducDoctor2Id,
                    UserId = thuducDoctorUser2Id,
                    ClinicId = thuducClinicId,
                    Gender = "Female",
                    Specialization = "Siêu âm thai / chăm sóc sức khỏe sinh sản",
                    Certificate = "Bác sĩ chuyên khoa I",
                    ExperienceYear = 10,
                    WorkPosition = "Bác sĩ siêu âm sản phụ khoa",
                    Description = "Chịu trách nhiệm siêu âm thai, kiểm tra sức khỏe thai phụ định kỳ, đánh giá phát triển thai nhi.",
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
                    UserName = "BS CKII Nguyễn Thị Ngọc Bích",
                    Email = "nguyen.thi.ngoc.bich@bvthuduc.vn",
                    PhoneNumber = "09 6633 1010",
                    Password = HashPassword("consultant#20"),
                    Address = "Khoa Sản, Bệnh viện Thành phố Thủ Đức",
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
                    UserName = "BS CKII Huỳnh Thị Kim Liên",
                    Email = "huynh.thi.kim.lien@bvthuduc.vn",
                    PhoneNumber = "09 6633 1010",
                    Password = HashPassword("consultant#21"),
                    Address = "Khoa Sản, Bệnh viện Thành phố Thủ Đức",
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
                    Specialization = "Sản phụ khoa / khám thai / mổ lấy thai",
                    Certificate = "Bác sĩ chuyên khoa II",
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
                    Specialization = "Sản phụ khoa / khám phụ khoa / đỡ đẻ",
                    Certificate = "Bác sĩ chuyên khoa II",
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
                    Comment = "Khám thai định kỳ tốt, bác sĩ thân thiện, phòng khám tương đối sạch sẽ.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = thuducFeedback2Id,
                    ClinicId = thuducClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Thời gian chờ khám sản phụ khoa hơi lâu, nhưng chất lượng khám ổn.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = thuducFeedback3Id,
                    ClinicId = thuducClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 10,
                    Comment = "Giá khám dịch vụ sản phụ khoa hợp lý, siêu âm rõ.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Bệnh viện Quận 1

            // Seed Quận 1 Clinic User
            var quan1ClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = quan1ClinicUserId,
                UserName = "Bệnh viện Quận 1",
                Email = "bvq1@bvq1.vn",
                PhoneNumber = "(028) 3820 6746",
                Password = HashPassword("clinic#14"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "Cơ sở 1: 338 Hai Bà Trưng, Phường Tân Định, Quận 1, TP. HCM; Cơ sở 2: 235-237 Trần Hưng Đạo, Phường Cô Giang, Quận 1, TP. HCM",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Quận 1 Clinic
            var quan1ClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = quan1ClinicId,
                UserId = quan1ClinicUserId,
                Address = "Cơ sở 1: 338 Hai Bà Trưng, Phường Tân Định, Quận 1, TP. HCM; Cơ sở 2: 235-237 Trần Hưng Đạo, Phường Cô Giang, Quận 1, TP. HCM",
                Description = "Bệnh viện Đa khoa Quận 1 là cơ sở y tế đa khoa hạng quận, thuộc quản lý Sở Y tế TP. HCM. Bệnh viện gồm nhiều chuyên khoa, trong đó có Sản-Phụ khoa (khoa Phụ sản). Cơ sở 2 mới được đưa vào hoạt động khám sản phụ khoa và chăm sóc sức khỏe thai sản để phục vụ nhu cầu địa phương.",
                IsInsuranceAccepted = true,
                Specializations = "Sản-Phụ khoa / khám thai;Khám phụ khoa;Siêu âm thai;Xét nghiệm trước sinh / chẩn đoán hình ảnh sản phụ khoa;Khám sức khỏe sinh sản;Khám theo yêu cầu;Khám bệnh bảo hiểm y tế;Khám nội khoa;Khám ngoại;Khám cấp cứu",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Quận 1 Doctor Users
            var quan1DoctorUser1Id = Guid.NewGuid();
            var quan1DoctorUser2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = quan1DoctorUser1Id,
                    UserName = "BS Lê Thị Hoa",
                    Email = "le.thi.hoa@bvq1.vn",
                    PhoneNumber = "(028) 3820 6746",
                    Password = HashPassword("doctor#31"),
                    Address = "Khoa Sản – Phụ khoa, Bệnh viện Quận 1 - Cơ sở 2",
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
                    UserName = "BS Trần Văn Đạt",
                    Email = "tran.van.dat@bvq1.vn",
                    PhoneNumber = "(028) 3820 6746",
                    Password = HashPassword("doctor#32"),
                    Address = "Khoa Khám bệnh / Sản phụ khoa, Bệnh viện Quận 1",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Quận 1 Doctors
            var quan1Doctor1Id = Guid.NewGuid();
            var quan1Doctor2Id = Guid.NewGuid();

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = quan1Doctor1Id,
                    UserId = quan1DoctorUser1Id,
                    ClinicId = quan1ClinicId,
                    Gender = "Female",
                    Specialization = "Siêu âm thai / đỡ sinh",
                    Certificate = "Bác sĩ chuyên khoa II",
                    ExperienceYear = 12,
                    WorkPosition = "Bác sĩ Sản phụ khoa",
                    Description = "Thực hiện khám thai, siêu âm định kỳ và các dịch vụ sản phụ khoa dịch vụ tại BV Quận 1 cơ sở 2.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = quan1Doctor2Id,
                    UserId = quan1DoctorUser2Id,
                    ClinicId = quan1ClinicId,
                    Gender = "Male",
                    Specialization = "Khám phụ khoa / tầm soát ung thư cổ tử cung",
                    Certificate = "Bác sĩ CKI",
                    ExperienceYear = 10,
                    WorkPosition = "Bác sĩ phụ khoa",
                    Description = "Khám phụ khoa và chăm sóc sức khỏe sinh sản cho phụ nữ tại BV Quận 1.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Quận 1 Consultant User
            var quan1ConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = quan1ConsultantUserId,
                UserName = "BS CKI Ngô Thị Anh Thư",
                Email = "ngo.thi.anhthu@bvq1.vn",
                PhoneNumber = "(028) 3820 6746",
                Password = HashPassword("consultant#22"),
                Address = "Khoa Phụ sản, Bệnh viện Quận 1 - Cơ sở 2",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Quận 1 Consultant
            var quan1ConsultantId = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = quan1ConsultantId,
                UserId = quan1ConsultantUserId,
                ClinicId = quan1ClinicId,
                Specialization = "Sản phụ khoa / khám thai & tư vấn thai phụ",
                Certificate = "Bác sĩ Chuyên khoa I",
                Gender = "Female",
                ExperienceYears = 15,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Quận 1 Feedbacks
            var quan1Feedback1Id = Guid.NewGuid();
            var quan1Feedback2Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = quan1Feedback1Id,
                    ClinicId = quan1ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Khám thai được, nhưng chưa có nhiều bác sĩ chuyên sâu, thời gian chờ đợi hơi lâu.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = quan1Feedback2Id,
                    ClinicId = quan1ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Phòng sản phụ khoa mới của cơ sở 2 cải thiện tốt, sạch, tiện.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Bệnh viện Quận 3

            // Seed Quận 3 Clinic User
            var quan3ClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = quan3ClinicUserId,
                UserName = "Bệnh viện Quận 3",
                Email = "bv.q3@tphcm.gov.vn",
                PhoneNumber = "0283 9310 400",
                Password = HashPassword("clinic#15"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "114-116-118 Trần Quốc Thảo, Phường 7, Quận 3, TP. Hồ Chí Minh, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Quận 3 Clinic
            var quan3ClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = quan3ClinicId,
                UserId = quan3ClinicUserId,
                Address = "114-116-118 Trần Quốc Thảo, Phường 7, Quận 3, TP. Hồ Chí Minh, Việt Nam",
                Description = "Bệnh viện Quận 3 là bệnh viện đa khoa hạng I trực thuộc Sở Y tế TP. HCM, cung cấp khám chữa bệnh nội trú & ngoại trú nhiều chuyên khoa trong đó có Sản-Phụ khoa / khám thai, phụ khoa. Bệnh viện được xây dựng từ năm 1992, với nhiều trang thiết bị chẩn đoán hình ảnh, siêu âm, xét nghiệm phụ khoa, phụ sản.",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ / Sản-Phụ khoa;Phụ khoa;Siêu âm sản / siêu âm thai;Xét nghiệm phụ sản / xét nghiệm trước sinh;Khám sản dịch vụ;Khám sức khỏe sinh sản;Khám theo yêu cầu;Khám bệnh BHYT;Khám nội & ngoại tổng hợp;Chẩn đoán hình ảnh;Chống độc & hồi sức cấp cứu",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Quận 3 Doctor Users
            var quan3DoctorUser1Id = Guid.NewGuid();
            var quan3DoctorUser2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = quan3DoctorUser1Id,
                    UserName = "BS Nguyễn Thị Thảo",
                    Email = "nguyen.thi.thao@bvquan3.medinet.gov.vn",
                    PhoneNumber = "0283 9310 400",
                    Password = HashPassword("doctor#33"),
                    Address = "Khoa Sản, Bệnh viện Quận 3",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                },
                new User
                {
                    Id = quan3DoctorUser2Id,
                    UserName = "BS Lê Văn Hùng",
                    Email = "le.van.hung@bvquan3.medinet.gov.vn",
                    PhoneNumber = "0283 9310 400",
                    Password = HashPassword("doctor#34"),
                    Address = "Khoa Sản, Bệnh viện Quận 3",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Quận 3 Doctors
            var quan3Doctor1Id = Guid.NewGuid();
            var quan3Doctor2Id = Guid.NewGuid();

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = quan3Doctor1Id,
                    UserId = quan3DoctorUser1Id,
                    ClinicId = quan3ClinicId,
                    Gender = "Female",
                    Specialization = "Sản phụ khoa / khám thai & đỡ đẻ",
                    Certificate = "Bác sĩ chuyên khoa I",
                    ExperienceYear = 12,
                    WorkPosition = "Bác sĩ sản phụ khoa",
                    Description = "Thực hiện siêu âm thai, khám thai định kỳ, chăm sóc sản phụ và trẻ sơ sinh ngay sau sinh.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = quan3Doctor2Id,
                    UserId = quan3DoctorUser2Id,
                    ClinicId = quan3ClinicId,
                    Gender = "Male",
                    Specialization = "Siêu âm sản / theo dõi thai kỳ",
                    Certificate = "Bác sĩ chuyên khoa I",
                    ExperienceYear = 15,
                    WorkPosition = "Bác sĩ siêu âm sản phụ khoa",
                    Description = "Chụp siêu âm thai dị tật, đánh giá tim thai, nhau, nước ối; khám thai định kỳ cho mẹ bầu.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Quận 3 Consultant User
            var quan3ConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = quan3ConsultantUserId,
                UserName = "ThS. BS Hà Thị Liên Chi",
                Email = "ha.thi.lienchi@bvquan3.medinet.gov.vn",
                PhoneNumber = "0283 9310 400",
                Password = HashPassword("consultant#23"),
                Address = "Khoa Sản, Bệnh viện Quận 3",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Quận 3 Consultant
            var quan3ConsultantId = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = quan3ConsultantId,
                UserId = quan3ConsultantUserId,
                ClinicId = quan3ClinicId,
                Specialization = "Sản phụ khoa / khám thai",
                Certificate = "Thạc sĩ, Bác sĩ chuyên khoa I",
                Gender = "Female",
                ExperienceYears = 20,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Quận 3 Feedbacks
            var quan3Feedback1Id = Guid.NewGuid();
            var quan3Feedback2Id = Guid.NewGuid();

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = quan3Feedback1Id,
                    ClinicId = quan3ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Khám sản phụ khoa ổn, bác sĩ tận tâm; phòng chờ hơi chật, chờ lâu.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = quan3Feedback2Id,
                    ClinicId = quan3ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Siêu âm thai rõ nét, nhân viên phụ sản thân thiện, mình hài lòng dịch vụ khám thai dịch vụ.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Bệnh viện Quận 7

            // Seed Quận 7 Clinic User
            var quan7ClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = quan7ClinicUserId,
                UserName = "Bệnh viện Quận 7",
                Email = "bv.q7@tphcm.gov.vn",
                PhoneNumber = "0283 7730 777",
                Password = HashPassword("clinic#16"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "101 Nguyễn Thị Thập, Phường Tân Phú, Quận 7, TP. Hồ Chí Minh, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Quận 7 Clinic
            var quan7ClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = quan7ClinicId,
                UserId = quan7ClinicUserId,
                Address = "101 Nguyễn Thị Thập, Phường Tân Phú, Quận 7, TP. Hồ Chí Minh, Việt Nam",
                Description = "Bệnh viện Quận 7 là bệnh viện đa khoa hạng II trực thuộc Sở Y tế TP.HCM. Bệnh viện cung cấp nhiều dịch vụ khám chữa bệnh, trong đó nổi bật là Sản - Phụ khoa với khám thai định kỳ, siêu âm thai, tư vấn tiền sản và chăm sóc sức khỏe sinh sản. Đây là nơi nhiều thai phụ tại khu vực Quận 7 và Nam Sài Gòn lựa chọn thăm khám do vị trí thuận lợi và chi phí hợp lý.",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ;Siêu âm sản khoa;Khám phụ khoa;Khám sức khỏe sinh sản;Tư vấn tiền sản;Đỡ đẻ và chăm sóc sau sinh;Khám bệnh BHYT;Khám dịch vụ theo yêu cầu;Nhi khoa;Nội - Ngoại tổng quát",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Quận 7 Doctor Users
            var quan7DoctorUser1Id = Guid.NewGuid();
            var quan7DoctorUser2Id = Guid.NewGuid();
            var quan7DoctorUser3Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = quan7DoctorUser1Id,
                    UserName = "BS Trần Thanh Tùng",
                    Email = "thanh.tung@bvquan7.medinet.gov.vn",
                    PhoneNumber = "0283 7730 777",
                    Password = HashPassword("doctor#35"),
                    Address = "Khoa Sản, Bệnh viện Quận 7",
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
                    UserName = "BS Lê Thị Minh Thư",
                    Email = "minh.thu@bvquan7.medinet.gov.vn",
                    PhoneNumber = "0283 7730 777",
                    Password = HashPassword("doctor#36"),
                    Address = "Khoa Sản, Bệnh viện Quận 7",
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
                    UserName = "BS Võ Văn Nhân",
                    Email = "van.nhan@bvquan7.medinet.gov.vn",
                    PhoneNumber = "0283 7730 777",
                    Password = HashPassword("doctor#37"),
                    Address = "Khoa Sản, Bệnh viện Quận 7",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Quận 7 Doctors
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
                    Specialization = "Đỡ đẻ, phẫu thuật sản phụ khoa",
                    Certificate = "BSCKII Sản phụ khoa",
                    ExperienceYear = 20,
                    WorkPosition = "Trưởng khoa Sản",
                    Description = "Chuyên đỡ đẻ, mổ lấy thai, xử lý thai kỳ nguy cơ cao và khám thai định kỳ cho sản phụ.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = quan7Doctor2Id,
                    UserId = quan7DoctorUser2Id,
                    ClinicId = quan7ClinicId,
                    Gender = "Female",
                    Specialization = "Siêu âm thai, chẩn đoán trước sinh",
                    Certificate = "Bác sĩ chuyên khoa I",
                    ExperienceYear = 12,
                    WorkPosition = "Bác sĩ siêu âm sản",
                    Description = "Siêu âm thai hình thái, tư vấn dị tật bẩm sinh, theo dõi sự phát triển của thai.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = quan7Doctor3Id,
                    UserId = quan7DoctorUser3Id,
                    ClinicId = quan7ClinicId,
                    Gender = "Male",
                    Specialization = "Khám phụ khoa & sức khỏe sinh sản",
                    Certificate = "BSCKI Sản phụ khoa",
                    ExperienceYear = 14,
                    WorkPosition = "Bác sĩ sản phụ khoa",
                    Description = "Khám thai định kỳ, điều trị bệnh lý phụ khoa và tư vấn sức khỏe sinh sản.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Quận 7 Consultant Users
            var quan7ConsultantUser1Id = Guid.NewGuid();
            var quan7ConsultantUser2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = quan7ConsultantUser1Id,
                    UserName = "ThS.BS Nguyễn Thị Bích Vân",
                    Email = "bich.van@bvquan7.medinet.gov.vn",
                    PhoneNumber = "0283 7730 777",
                    Password = HashPassword("consultant#24"),
                    Address = "Khoa Sản, Bệnh viện Quận 7",
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
                    UserName = "BSCKI Phan Thị Hồng Thắm",
                    Email = "hong.tham@bvquan7.medinet.gov.vn",
                    PhoneNumber = "0283 7730 777",
                    Password = HashPassword("consultant#25"),
                    Address = "Khoa Sản, Bệnh viện Quận 7",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Quận 7 Consultants
            var quan7Consultant1Id = Guid.NewGuid();
            var quan7Consultant2Id = Guid.NewGuid();

            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = quan7Consultant1Id,
                    UserId = quan7ConsultantUser1Id,
                    ClinicId = quan7ClinicId,
                    Specialization = "Sản phụ khoa",
                    Certificate = "Thạc sĩ Y học, CKI Sản phụ khoa",
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
                    Specialization = "Khám thai & tư vấn tiền sản",
                    Certificate = "Bác sĩ chuyên khoa I",
                    Gender = "Female",
                    ExperienceYears = 15,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                }
            );

            // Seed Quận 7 Feedbacks
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
                    Comment = "Bác sĩ sản rất tận tâm, mình đi khám thai định kỳ ở đây thấy yên tâm vì chi phí vừa phải, dịch vụ ổn.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = quan7Feedback2Id,
                    ClinicId = quan7ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Thái độ nhân viên phụ sản khá tốt, có bác sĩ nữ nên mình thoải mái hơn khi khám thai.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = quan7Feedback3Id,
                    ClinicId = quan7ClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Cơ sở vật chất không hiện đại như bệnh viện quốc tế nhưng dịch vụ sản phụ khoa đáng tin cậy.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Bệnh viện Quận Gò Vấp

            // Seed Quận Gò Vấp Clinic User
            var govapClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = govapClinicUserId,
                UserName = "Bệnh viện Quận Gò Vấp",
                Email = "bv.govap@tphcm.gov.vn",
                PhoneNumber = "0283 8944 160",
                Password = HashPassword("clinic#17"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "212 Lê Đức Thọ, Phường 15, Quận Gò Vấp, TP. Hồ Chí Minh, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Quận Gò Vấp Clinic
            var govapClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = govapClinicId,
                UserId = govapClinicUserId,
                Address = "212 Lê Đức Thọ, Phường 15, Quận Gò Vấp, TP. Hồ Chí Minh, Việt Nam",
                Description = "Bệnh viện Quận Gò Vấp là bệnh viện đa khoa hạng II trực thuộc Sở Y tế TP.HCM. Bệnh viện có thế mạnh trong khám chữa bệnh đa khoa, đặc biệt là khoa Sản phụ khoa với dịch vụ khám thai định kỳ, siêu âm, tư vấn tiền sản và chăm sóc sức khỏe bà mẹ - trẻ em cho người dân khu vực Gò Vấp và vùng lân cận.",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ;Siêu âm sản khoa;Khám phụ khoa;Khám sức khỏe sinh sản;Tư vấn tiền sản;Đỡ đẻ và chăm sóc sau sinh;Khám bệnh BHYT;Khám dịch vụ theo yêu cầu;Nhi khoa;Nội tổng quát",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Quận Gò Vấp Doctor Users
            var govapDoctorUser1Id = Guid.NewGuid();
            var govapDoctorUser2Id = Guid.NewGuid();
            var govapDoctorUser3Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = govapDoctorUser1Id,
                    UserName = "BSCKII Lê Thị Mỹ Duyên",
                    Email = "my.duyen@bvquan-govap.medinet.gov.vn",
                    PhoneNumber = "0283 8944 160",
                    Password = HashPassword("doctor#38"),
                    Address = "Khoa Sản, Bệnh viện Quận Gò Vấp",
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
                    UserName = "BS Hoàng Thị Kiều Oanh",
                    Email = "kieu.oanh@bvquan-govap.medinet.gov.vn",
                    PhoneNumber = "0283 8944 160",
                    Password = HashPassword("doctor#39"),
                    Address = "Khoa Sản, Bệnh viện Quận Gò Vấp",
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
                    UserName = "BS Đặng Văn Toàn",
                    Email = "van.toan@bvquan-govap.medinet.gov.vn",
                    PhoneNumber = "0283 8944 160",
                    Password = HashPassword("doctor#40"),
                    Address = "Khoa Sản, Bệnh viện Quận Gò Vấp",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Quận Gò Vấp Doctors
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
                    Specialization = "Phẫu thuật sản khoa",
                    Certificate = "BSCKII Sản phụ khoa",
                    ExperienceYear = 22,
                    WorkPosition = "Trưởng khoa Sản",
                    Description = "Chuyên phẫu thuật sản, mổ lấy thai, xử lý thai kỳ nguy cơ cao, điều trị bệnh lý phụ khoa.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = govapDoctor2Id,
                    UserId = govapDoctorUser2Id,
                    ClinicId = govapClinicId,
                    Gender = "Female",
                    Specialization = "Siêu âm sản phụ khoa",
                    Certificate = "Bác sĩ chuyên khoa I",
                    ExperienceYear = 10,
                    WorkPosition = "Bác sĩ siêu âm",
                    Description = "Thực hiện siêu âm thai định kỳ, chẩn đoán trước sinh và theo dõi thai kỳ.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = govapDoctor3Id,
                    UserId = govapDoctorUser3Id,
                    ClinicId = govapClinicId,
                    Gender = "Male",
                    Specialization = "Khám phụ khoa & kế hoạch hóa gia đình",
                    Certificate = "BSCKI Sản phụ khoa",
                    ExperienceYear = 15,
                    WorkPosition = "Bác sĩ sản phụ khoa",
                    Description = "Khám phụ khoa, điều trị viêm nhiễm phụ khoa, tư vấn sức khỏe sinh sản và kế hoạch hóa gia đình.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Quận Gò Vấp Consultant Users
            var govapConsultantUser1Id = Guid.NewGuid();
            var govapConsultantUser2Id = Guid.NewGuid();
            var govapConsultantUser3Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = govapConsultantUser1Id,
                    UserName = "ThS.BS Nguyễn Thị Hồng Nhung",
                    Email = "hong.nhung@bvquan-govap.medinet.gov.vn",
                    PhoneNumber = "0283 8944 160",
                    Password = HashPassword("consultant#26"),
                    Address = "Khoa Sản, Bệnh viện Quận Gò Vấp",
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
                    UserName = "BSCKI Trần Minh Thảo",
                    Email = "minh.thao@bvquan-govap.medinet.gov.vn",
                    PhoneNumber = "0283 8944 160",
                    Password = HashPassword("consultant#27"),
                    Address = "Khoa Sản, Bệnh viện Quận Gò Vấp",
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
                    UserName = "BS Phan Quốc Thái",
                    Email = "quoc.thai@bvquan-govap.medinet.gov.vn",
                    PhoneNumber = "0283 8944 160",
                    Password = HashPassword("consultant#28"),
                    Address = "Khoa Sản, Bệnh viện Quận Gò Vấp",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Quận Gò Vấp Consultants
            var govapConsultant1Id = Guid.NewGuid();
            var govapConsultant2Id = Guid.NewGuid();
            var govapConsultant3Id = Guid.NewGuid();

            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = govapConsultant1Id,
                    UserId = govapConsultantUser1Id,
                    ClinicId = govapClinicId,
                    Specialization = "Khám thai & tư vấn sản phụ khoa",
                    Certificate = "Thạc sĩ Y học, CKI Sản phụ khoa",
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
                    Specialization = "Tư vấn tiền sản",
                    Certificate = "Bác sĩ chuyên khoa I",
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
                    Specialization = "Khám sức khỏe sinh sản",
                    Certificate = "Bác sĩ đa khoa, CKI sản phụ khoa",
                    Gender = "Male",
                    ExperienceYears = 13,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                }
            );

            // Seed Quận Gò Vấp Feedbacks
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
                    Comment = "Mình đi khám thai ở đây, bác sĩ tư vấn kỹ, chi phí hợp lý, có BHYT hỗ trợ.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = govapFeedback2Id,
                    ClinicId = govapClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Đội ngũ y tá và bác sĩ nữ nhiều, mình thấy thoải mái hơn khi khám phụ khoa.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = govapFeedback3Id,
                    ClinicId = govapClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Bệnh viện khá đông, phải chờ nhưng bác sĩ nhiệt tình và chu đáo.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = govapFeedback4Id,
                    ClinicId = govapClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Mình sinh bé ở đây, bác sĩ rất tận tâm, dịch vụ ổn, cảm giác an toàn.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Bệnh viện Quận Bình Thạnh

            // Seed Quận Bình Thạnh Clinic User
            var binhthanhClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = binhthanhClinicUserId,
                UserName = "Bệnh viện Quận Bình Thạnh",
                Email = "bv.binhthanh@tphcm.gov.vn",
                PhoneNumber = "0283 8411 283",
                Password = HashPassword("clinic#18"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "112 Bùi Hữu Nghĩa, Phường 2, Quận Bình Thạnh, TP. Hồ Chí Minh, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Quận Bình Thạnh Clinic
            var binhthanhClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = binhthanhClinicId,
                UserId = binhthanhClinicUserId,
                Address = "112 Bùi Hữu Nghĩa, Phường 2, Quận Bình Thạnh, TP. Hồ Chí Minh, Việt Nam",
                Description = "Bệnh viện Quận Bình Thạnh là bệnh viện đa khoa hạng II trực thuộc Sở Y tế TP.HCM. Với quy mô hơn 300 giường bệnh, bệnh viện đáp ứng nhu cầu khám chữa bệnh đa khoa cho người dân. Khoa Sản phụ khoa là một trong những chuyên khoa mũi nhọn, cung cấp dịch vụ khám thai, siêu âm, tư vấn tiền sản và chăm sóc sức khỏe bà mẹ - trẻ em.",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ;Siêu âm sản khoa;Khám phụ khoa;Tư vấn tiền sản;Chăm sóc sức khỏe sinh sản;Đỡ đẻ và chăm sóc sau sinh;Khám dịch vụ theo yêu cầu;Khám bệnh BHYT;Nhi khoa;Nội tổng quát",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Quận Bình Thạnh Doctor Users
            var binhthanhDoctorUser1Id = Guid.NewGuid();
            var binhthanhDoctorUser2Id = Guid.NewGuid();
            var binhthanhDoctorUser3Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = binhthanhDoctorUser1Id,
                    UserName = "BSCKII Lê Thị Bích Hạnh",
                    Email = "bich.hanh@bvbinhthanh.medinet.gov.vn",
                    PhoneNumber = "0283 8411 283",
                    Password = HashPassword("doctor#41"),
                    Address = "Khoa Sản, Bệnh viện Quận Bình Thạnh",
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
                    UserName = "BS Nguyễn Minh Thư",
                    Email = "minh.thu@bvbinhthanh.medinet.gov.vn",
                    PhoneNumber = "0283 8411 283",
                    Password = HashPassword("doctor#42"),
                    Address = "Khoa Sản, Bệnh viện Quận Bình Thạnh",
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
                    UserName = "BS Trần Quốc Khánh",
                    Email = "quoc.khanh@bvbinhthanh.medinet.gov.vn",
                    PhoneNumber = "0283 8411 283",
                    Password = HashPassword("doctor#43"),
                    Address = "Khoa Sản, Bệnh viện Quận Bình Thạnh",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Quận Bình Thạnh Doctors
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
                    Specialization = "Phẫu thuật sản phụ khoa",
                    Certificate = "BSCKII Sản phụ khoa",
                    ExperienceYear = 23,
                    WorkPosition = "Trưởng khoa Sản",
                    Description = "Chuyên mổ lấy thai, xử lý sản khoa nguy cơ cao, điều trị bệnh lý phụ khoa phức tạp.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = binhthanhDoctor2Id,
                    UserId = binhthanhDoctorUser2Id,
                    ClinicId = binhthanhClinicId,
                    Gender = "Female",
                    Specialization = "Siêu âm thai & chẩn đoán trước sinh",
                    Certificate = "Bác sĩ chuyên khoa I",
                    ExperienceYear = 11,
                    WorkPosition = "Bác sĩ siêu âm",
                    Description = "Siêu âm hình thái thai, tư vấn dị tật bẩm sinh, theo dõi phát triển thai nhi.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = binhthanhDoctor3Id,
                    UserId = binhthanhDoctorUser3Id,
                    ClinicId = binhthanhClinicId,
                    Gender = "Male",
                    Specialization = "Khám phụ khoa & điều trị viêm nhiễm",
                    Certificate = "BSCKI Sản phụ khoa",
                    ExperienceYear = 16,
                    WorkPosition = "Bác sĩ sản phụ khoa",
                    Description = "Khám phụ khoa, điều trị viêm nhiễm, tư vấn kế hoạch hóa gia đình và sức khỏe sinh sản.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Quận Bình Thạnh Consultant Users
            var binhthanhConsultantUser1Id = Guid.NewGuid();
            var binhthanhConsultantUser2Id = Guid.NewGuid();
            var binhthanhConsultantUser3Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = binhthanhConsultantUser1Id,
                    UserName = "ThS.BS Nguyễn Thị Kim Ánh",
                    Email = "kim.anh@bvbinhthanh.medinet.gov.vn",
                    PhoneNumber = "0283 8411 283",
                    Password = HashPassword("consultant#29"),
                    Address = "Khoa Sản, Bệnh viện Quận Bình Thạnh",
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
                    UserName = "BSCKI Võ Thị Thu Trang",
                    Email = "thu.trang@bvbinhthanh.medinet.gov.vn",
                    PhoneNumber = "0283 8411 283",
                    Password = HashPassword("consultant#30"),
                    Address = "Khoa Sản, Bệnh viện Quận Bình Thạnh",
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
                    UserName = "BS Phan Minh Huy",
                    Email = "minh.huy@bvbinhthanh.medinet.gov.vn",
                    PhoneNumber = "0283 8411 283",
                    Password = HashPassword("consultant#31"),
                    Address = "Khoa Sản, Bệnh viện Quận Bình Thạnh",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Quận Bình Thạnh Consultants
            var binhthanhConsultant1Id = Guid.NewGuid();
            var binhthanhConsultant2Id = Guid.NewGuid();
            var binhthanhConsultant3Id = Guid.NewGuid();

            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = binhthanhConsultant1Id,
                    UserId = binhthanhConsultantUser1Id,
                    ClinicId = binhthanhClinicId,
                    Specialization = "Khám thai & tư vấn tiền sản",
                    Certificate = "Thạc sĩ Y học, CKI Sản phụ khoa",
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
                    Specialization = "Khám sức khỏe sinh sản",
                    Certificate = "Bác sĩ chuyên khoa I",
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
                    Specialization = "Tư vấn kế hoạch hóa gia đình",
                    Certificate = "Bác sĩ đa khoa, CKI sản phụ khoa",
                    Gender = "Male",
                    ExperienceYears = 12,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                }
            );

            // Seed Quận Bình Thạnh Feedbacks
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
                    Comment = "Bệnh viện sạch sẽ, bác sĩ sản tư vấn kỹ lưỡng, đặc biệt phù hợp với thai phụ ở Bình Thạnh.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = binhthanhFeedback2Id,
                    ClinicId = binhthanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Đi siêu âm thai ở đây bác sĩ nữ nhẹ nhàng, mình cảm thấy thoải mái và yên tâm.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = binhthanhFeedback3Id,
                    ClinicId = binhthanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Bệnh viện khá đông bệnh nhân, nhưng đội ngũ y tá và bác sĩ sản phụ khoa rất nhiệt tình.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = binhthanhFeedback4Id,
                    ClinicId = binhthanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 10,
                    Comment = "Mình sinh bé tại đây, bác sĩ giỏi, xử lý nhanh, chi phí hợp lý hơn so với bệnh viện tư nhân.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Bệnh viện Quận Bình Tân

            // Seed Quận Bình Tân Clinic User
            var binhtanClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = binhtanClinicUserId,
                UserName = "Bệnh viện Quận Bình Tân",
                Email = "bvbinhtan@tphcm.gov.vn",
                PhoneNumber = "0283 7520 427",
                Password = HashPassword("clinic#19"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "638 Tên Lửa, Phường Bình Trị Đông B, Quận Bình Tân, TP. Hồ Chí Minh, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Quận Bình Tân Clinic
            var binhtanClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = binhtanClinicId,
                UserId = binhtanClinicUserId,
                Address = "638 Tên Lửa, Phường Bình Trị Đông B, Quận Bình Tân, TP. Hồ Chí Minh, Việt Nam",
                Description = "Bệnh viện Quận Bình Tân là bệnh viện đa khoa hạng II với quy mô hơn 300 giường bệnh. Khoa Sản phụ khoa cung cấp các dịch vụ khám thai, siêu âm, tư vấn tiền sản, chăm sóc sức khỏe sinh sản và dịch vụ sinh an toàn, thân thiện cho thai phụ.",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ;Siêu âm sản khoa;Khám phụ khoa;Tư vấn tiền sản;Chăm sóc sức khỏe sinh sản;Đỡ sinh thường, sinh mổ;Theo dõi sau sinh;Kế hoạch hóa gia đình;Khám BHYT;Khám dịch vụ",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Quận Bình Tân Doctor Users
            var binhtanDoctorUser1Id = Guid.NewGuid();
            var binhtanDoctorUser2Id = Guid.NewGuid();
            var binhtanDoctorUser3Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = binhtanDoctorUser1Id,
                    UserName = "BSCKII Nguyễn Thị Thanh Tâm",
                    Email = "thanh.tam@bvbinhtan.medinet.gov.vn",
                    PhoneNumber = "0283 7520 427",
                    Password = HashPassword("doctor#44"),
                    Address = "Khoa Sản, Bệnh viện Quận Bình Tân",
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
                    UserName = "BS Phan Hữu Lộc",
                    Email = "huu.loc@bvbinhtan.medinet.gov.vn",
                    PhoneNumber = "0283 7520 427",
                    Password = HashPassword("doctor#45"),
                    Address = "Khoa Sản, Bệnh viện Quận Bình Tân",
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
                    UserName = "BS Đặng Thị Thu Trang",
                    Email = "thu.trang@bvbinhtan.medinet.gov.vn",
                    PhoneNumber = "0283 7520 427",
                    Password = HashPassword("doctor#46"),
                    Address = "Khoa Sản, Bệnh viện Quận Bình Tân",
                    CreationDate = new DateTime(2025, 09, 05),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Quận Bình Tân Doctors
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
                    Specialization = "Phẫu thuật sản phụ khoa",
                    Certificate = "BSCKII Sản phụ khoa",
                    ExperienceYear = 22,
                    WorkPosition = "Trưởng khoa Sản",
                    Description = "Chuyên đỡ đẻ, mổ lấy thai, xử lý các ca sản phụ khoa phức tạp, theo dõi hậu sản.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = binhtanDoctor2Id,
                    UserId = binhtanDoctorUser2Id,
                    ClinicId = binhtanClinicId,
                    Gender = "Male",
                    Specialization = "Siêu âm & chẩn đoán hình ảnh thai",
                    Certificate = "BSCKI Sản phụ khoa",
                    ExperienceYear = 14,
                    WorkPosition = "Bác sĩ siêu âm",
                    Description = "Chuyên siêu âm hình thái thai nhi, theo dõi thai kỳ nguy cơ cao.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = binhtanDoctor3Id,
                    UserId = binhtanDoctorUser3Id,
                    ClinicId = binhtanClinicId,
                    Gender = "Female",
                    Specialization = "Khám phụ khoa",
                    Certificate = "Bác sĩ chuyên khoa I",
                    ExperienceYear = 9,
                    WorkPosition = "Bác sĩ sản phụ khoa",
                    Description = "Khám và điều trị các bệnh lý phụ khoa, viêm nhiễm, tư vấn sức khỏe sinh sản.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Seed Quận Bình Tân Consultant Users
            var binhtanConsultantUser1Id = Guid.NewGuid();
            var binhtanConsultantUser2Id = Guid.NewGuid();
            var binhtanConsultantUser3Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = binhtanConsultantUser1Id,
                    UserName = "BSCKI Trần Thị Thu Hà",
                    Email = "thu.ha@bvbinhtan.medinet.gov.vn",
                    PhoneNumber = "0283 7520 427",
                    Password = HashPassword("consultant#32"),
                    Address = "Khoa Sản, Bệnh viện Quận Bình Tân",
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
                    UserName = "BS Lê Minh Tuấn",
                    Email = "minh.tuan@bvbinhtan.medinet.gov.vn",
                    PhoneNumber = "0283 7520 427",
                    Password = HashPassword("consultant#33"),
                    Address = "Khoa Sản, Bệnh viện Quận Bình Tân",
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
                    UserName = "BS Ngô Thị Phương Linh",
                    Email = "phuong.linh@bvbinhtan.medinet.gov.vn",
                    PhoneNumber = "0283 7520 427",
                    Password = HashPassword("consultant#34"),
                    Address = "Khoa Sản, Bệnh viện Quận Bình Tân",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Quận Bình Tân Consultants
            var binhtanConsultant1Id = Guid.NewGuid();
            var binhtanConsultant2Id = Guid.NewGuid();
            var binhtanConsultant3Id = Guid.NewGuid();

            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = binhtanConsultant1Id,
                    UserId = binhtanConsultantUser1Id,
                    ClinicId = binhtanClinicId,
                    Specialization = "Khám thai & tư vấn tiền sản",
                    Certificate = "BSCKI Sản phụ khoa",
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
                    Specialization = "Tư vấn chăm sóc thai kỳ nguy cơ cao",
                    Certificate = "Bác sĩ đa khoa, CKI Sản phụ khoa",
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
                    Specialization = "Tư vấn sức khỏe sinh sản & kế hoạch hóa gia đình",
                    Certificate = "Bác sĩ chuyên khoa I",
                    Gender = "Female",
                    ExperienceYears = 10,
                    CreationDate = new DateTime(2025, 09, 05),
                    IsDeleted = false
                }
            );

            // Seed Quận Bình Tân Feedbacks
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
                    Comment = "Bác sĩ sản phụ khoa ở đây rất tận tình, tư vấn kỹ khi đi khám thai.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = binhtanFeedback2Id,
                    ClinicId = binhtanClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Mình sinh bé tại bệnh viện, dịch vụ tốt, chi phí hợp lý.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = binhtanFeedback3Id,
                    ClinicId = binhtanClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Đi siêu âm ở đây khá yên tâm, bác sĩ giải thích rõ ràng cho mẹ bầu.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = binhtanFeedback4Id,
                    ClinicId = binhtanClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Đông bệnh nhân nhưng nhân viên hỗ trợ nhanh, không mất nhiều thời gian chờ đợi.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Bệnh viện Đa khoa Vạn Hạnh

            // Seed Vạn Hạnh Clinic User
            var vanhanhClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = vanhanhClinicUserId,
                UserName = "Bệnh viện Đa khoa Vạn Hạnh",
                Email = "benhvienvanhanh@gmail.com",
                PhoneNumber = "(+84) 028 3863 2553",
                Password = HashPassword("clinic#20"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "781/B1-B3-B5 Lê Hồng Phong, Phường 12, Quận 10, TP. Hồ Chí Minh, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Vạn Hạnh Clinic
            var vanhanhClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = vanhanhClinicId,
                UserId = vanhanhClinicUserId,
                Address = "781/B1-B3-B5 Lê Hồng Phong, Phường 12, Quận 10, TP. Hồ Chí Minh, Việt Nam",
                Description = "Bệnh viện Đa khoa Vạn Hạnh là bệnh viện tư nhân uy tín tại Quận 10, TP.HCM, thành lập năm 2000, với quy mô giường bệnh và đội ngũ bác sĩ chuyên môn cao. Khoa Sản phụ khoa nổi bật với dịch vụ thai sản trọn gói, khám thai định kỳ, siêu âm 4D, tư vấn tiền sản, tầm soát dị tật thai nhi, chăm sóc sản phụ và trẻ sơ sinh. Trang thiết bị hiện đại, dịch vụ phụ sản & hiếm muộn được bệnh viện chú trọng.",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ;Siêu âm sản khoa (2D, 3D, 4D);Khám phụ khoa;Tư vấn tiền sản;Tầm soát dị tật thai nhi;Sinh con trọn gói;Hiếm muộn / hỗ trợ sinh sản;Chăm sóc sản phụ & hậu sản;Khám dịch vụ sản phụ khoa;Khám ngoại trú & nội trú sản;Khám theo yêu cầu;Khám bệnh bảo hiểm y tế",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Vạn Hạnh Doctor User
            var vanhanhDoctorUser1Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = vanhanhDoctorUser1Id,
                UserName = "BS Vương Thị Ngọc Lan",
                Email = "doctorVanHanh@gmail.com",
                PhoneNumber = "(+84) 028 3863 2553",
                Password = HashPassword("doctor#47"),
                Address = "Khoa Hiếm muộn / Sản phụ khoa, Bệnh viện Đa khoa Vạn Hạnh",
                CreationDate = new DateTime(2025, 09, 05),
                RoleId = 7,
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Vạn Hạnh Doctor
            var vanhanhDoctor1Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = vanhanhDoctor1Id,
                UserId = vanhanhDoctorUser1Id,
                ClinicId = vanhanhClinicId,
                Gender = "Female",
                Specialization = "Hiếm muộn, khám thai định kỳ",
                Certificate = "Bác sĩ chuyên khoa Sản phụ khoa",
                ExperienceYear = 20,
                WorkPosition = "Bác sĩ / chuyên viên hiếm muộn",
                Description = "Một bác sĩ đặc biệt nổi bật trong lĩnh vực hiếm muộn tại Vạn Hạnh; cũng tiếp nhận khám thai bình thường và phụ khoa.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 05)
            });

            // Seed Vạn Hạnh Consultant User
            var vanhanhConsultantUser1Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = vanhanhConsultantUser1Id,
                UserName = "BS Phùng Huy Tuân",
                Email = "consultantVanHanh@gmail.com",
                PhoneNumber = "(+84) 028 3863 2553",
                Password = HashPassword("consultant#35"),
                Address = "Lầu 3-4, Bệnh viện Đa khoa Vạn Hạnh, 700 Sư Vạn Hạnh nối dài, P.12, Q.10, TP.HCM",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Vạn Hạnh Consultant
            var vanhanhConsultant1Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = vanhanhConsultant1Id,
                UserId = vanhanhConsultantUser1Id,
                ClinicId = vanhanhClinicId,
                Specialization = "Hiếm muộn / IVF",
                Certificate = "Bác sĩ chuyên khoa Sản phụ khoa",
                Gender = "Male",
                ExperienceYears = 20,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Vạn Hạnh Feedbacks
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
                    Comment = "Khám thai dịch vụ tốt, bác sĩ tận tình. Chi phí sinh trọn gói ở Vạn Hạnh hợp lý hơn nhiều bệnh viện quốc tế.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = vanhanhFeedback2Id,
                    ClinicId = vanhanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Phòng sanh và nội trú sản phụ chất lượng cao, nhân viên thân thiện.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = vanhanhFeedback3Id,
                    ClinicId = vanhanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Dịch vụ hiếm muộn ở Vạn Hạnh được đánh giá tốt; quy trình đặt lịch và thủ tục hơi nhiều bước.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Bệnh viện Phụ sản Mê Kông

            // Seed Phụ sản MêKông Clinic User
            var mekongClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = mekongClinicUserId,
                UserName = "Bệnh viện Phụ sản MêKông",
                Email = "info@mekonghospital.vn",
                PhoneNumber = "(84-28) 3844 2986 / 3844 2988",
                Password = HashPassword("clinic#21"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "243-243A-243B Hoàng Văn Thụ, Phường 1, Quận Tân Bình, TP. Hồ Chí Minh, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Phụ sản MêKông Clinic
            var mekongClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = mekongClinicId,
                UserId = mekongClinicUserId,
                Address = "243-243A-243B Hoàng Văn Thụ, Phường 1, Quận Tân Bình, TP. Hồ Chí Minh, Việt Nam",
                Description = "Bệnh viện Phụ sản MêKông là bệnh viện chuyên sâu Sản-Phụ khoa và Nhi sơ sinh, được thành lập năm 2002, kế thừa từ Khoa Phụ sản – Đại học Y Dược TP.HCM (Cơ sở 4). Bệnh viện có quy mô khoảng 110 giường bệnh và 50 nôi, cung cấp các dịch vụ khám thai định kỳ, siêu âm, hỗ trợ sinh sản / hiếm muộn, tầm soát dị tật thai nhi, sinh con dịch vụ & sản phụ khoa chất lượng cao.",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ;Siêu âm sản khoa (2D, 3D, 4D);Khám phụ khoa;Tư vấn tiền sản;Hỗ trợ sinh sản / hiếm muộn;Tầm soát dị tật thai nhi;Sinh thường / Phẫu thuật lấy thai;Sơ sinh;Khám bệnh phụ nữ dịch vụ;Khám BHYT sản phụ khoa;Xét nghiệm trước sinh;Chẩn đoán hình ảnh sản phụ khoa;Gây mê hồi sức;Cấp cứu sản khoa",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Phụ sản MêKông Doctor User
            var mekongDoctorUser1Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = mekongDoctorUser1Id,
                UserName = "BS Phạm Thanh Hoàng",
                Email = "doctorMeKong@gmail.com",
                PhoneNumber = "(84-28) 3844 2986",
                Password = HashPassword("doctor#48"),
                Address = "Ban Giám đốc / Khoa Sản, Bệnh viện Phụ sản MêKông",
                CreationDate = new DateTime(2025, 09, 05),
                RoleId = 7,
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Phụ sản MêKông Doctor
            var mekongDoctor1Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = mekongDoctor1Id,
                UserId = mekongDoctorUser1Id,
                ClinicId = mekongClinicId,
                Gender = "Male",
                Specialization = "Sản phụ khoa / quản lý bệnh viện",
                Certificate = "BSCKI / Thạc sĩ",
                ExperienceYear = 20,
                WorkPosition = "Phó Giám đốc",
                Description = "Một bác sĩ đầu ngành tại MêKông, thường được nhắc đến trong các bài viết về bác sĩ đỡ đẻ giỏi tại MêKông.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 05)
            });

            // Seed Phụ sản MêKông Consultant User
            var mekongConsultantUser1Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = mekongConsultantUser1Id,
                UserName = "BS Nguyễn Thị Ngọc Lan",
                Email = "consultantMeKong@gmail.com",
                PhoneNumber = "(84-28) 3844 2986",
                Password = HashPassword("consultant#36"),
                Address = "Khoa Sản, Bệnh viện Phụ sản MêKông",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 05),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Phụ sản MêKông Consultant
            var mekongConsultant1Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = mekongConsultant1Id,
                UserId = mekongConsultantUser1Id,
                ClinicId = mekongClinicId,
                Specialization = "Sản phụ khoa / khám thai định kỳ / siêu âm / tầm soát dị tật thai",
                Certificate = "Bác sĩ Chuyên khoa Sản phụ khoa",
                Gender = "Female",
                ExperienceYears = 30,
                CreationDate = new DateTime(2025, 09, 05),
                IsDeleted = false
            });

            // Seed Phụ sản MêKông Feedbacks
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
                    Comment = "Khám sản phụ khoa tốt, siêu âm thai rõ, bác sĩ tận tình; chi phí dịch vụ cao hơn bệnh viện công nhưng xứng đáng.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = mekongFeedback2Id,
                    ClinicId = mekongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Sinh thường tại đây; phòng sinh đẹp, sạch sẽ; nhưng chờ làm thủ tục hơi lâu.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = mekongFeedback3Id,
                    ClinicId = mekongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 10,
                    Comment = "Dịch vụ hiếm muộn hỗ trợ tốt, nhân viên thân thiện.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Bệnh viện Quốc tế Phụ sản Sài Gòn (SIHospital)

            // Seed SIHospital Clinic User
            var sihospitalClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = sihospitalClinicUserId,
                UserName = "Bệnh viện Phụ sản Quốc tế Sài Gòn (SIHospital)",
                Email = "info@sihospital.com.vn",
                PhoneNumber = "0899-909-269",
                Password = HashPassword("clinic#22"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 05),
                Address = "63 Bùi Thị Xuân, Phường Phạm Ngũ Lão, Quận 1, TP. Hồ Chí Minh, Việt Nam",
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
                Address = "63 Bùi Thị Xuân, Phường Phạm Ngũ Lão, Quận 1, TP. Hồ Chí Minh, Việt Nam",
                Description = "SIHospital là bệnh viện chuyên sâu sản phụ khoa, nhi sơ sinh và hỗ trợ sinh sản (IVF) với hơn 24 năm kinh nghiệm. Được biết đến với các dịch vụ khám thai định kỳ, siêu âm, khám phụ khoa, hỗ trợ sinh sản, tư vấn tiền sản, chăm sóc bà mẹ & trẻ em chất lượng cao tại trung tâm TP.HCM.",
                IsInsuranceAccepted = true,
                Specializations = "Sản-Phụ khoa / khám thai định kỳ;Siêu âm thai (2D, 3D, 4D);Khám & điều trị phụ khoa;Hỗ trợ sinh sản / IVF / hiếm muộn;Tư vấn tiền sản;Tầm soát dị tật thai nhi;Sinh thường / sinh mổ;Sơ sinh;Khám dịch vụ sản phụ khoa;Khám bệnh theo yêu cầu;Xét nghiệm sản phụ khoa;Khám bệnh bảo hiểm y tế",
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
                    UserName = "BS.CKI Lê Nguyễn Quang Huy",
                    Email = "lenguyenquanghuy@gmail.com",
                    PhoneNumber = "0899-909-269",
                    Password = HashPassword("doctor#49"),
                    Address = "SIHospital, Quận 1, TP. HCM",
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
                    UserName = "BS.CKI Dương Thị Kim Cúc",
                    Email = "duongthikimcuc@gmail.com",
                    PhoneNumber = "0899-909-269",
                    Password = HashPassword("doctor#50"),
                    Address = "SIHospital, Quận 1, TP. HCM",
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
                    Specialization = "Phụ khoa / khám phụ khoa",
                    Certificate = "Chuyên khoa I",
                    ExperienceYear = 15,
                    WorkPosition = "Bác sĩ phụ khoa",
                    Description = "Một trong các bác sĩ thuộc đội ngũ SIHospital, thực hiện khám phụ khoa & hỗ trợ sản phụ khoa.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Doctor
                {
                    Id = sihospitalDoctor2Id,
                    UserId = sihospitalDoctorUser2Id,
                    ClinicId = sihospitalClinicId,
                    Gender = "Female",
                    Specialization = "Sản phụ khoa",
                    Certificate = "Chuyên khoa I",
                    ExperienceYear = 12,
                    WorkPosition = "Bác sĩ sản phụ khoa",
                    Description = "Tham gia khám thai / đỡ đẻ tại SIHospital.",
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
                    UserName = "ThS.BS.CKII Trần Anh Tuấn",
                    Email = "trananhtuan@gmail.com",
                    PhoneNumber = "0899-909-269",
                    Password = HashPassword("consultant#37"),
                    Address = "SIHospital, Quận 1, TP. HCM",
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
                    UserName = "ThS.BS.CKII Đặng Thị Hiện",
                    Email = "dangthihien@gmail.com",
                    PhoneNumber = "0899-909-269",
                    Password = HashPassword("consultant#38"),
                    Address = "SIHospital, Quận 1, TP. HCM",
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
                    UserName = "BS Nguyễn Thị Thu Hồng",
                    Email = "nguyenthithuhong@gmail.com",
                    PhoneNumber = "0899-909-269",
                    Password = HashPassword("consultant#39"),
                    Address = "SIHospital, Quận 1, TP. HCM",
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
                    Specialization = "Phó Giám đốc Y khoa / Sản phụ khoa",
                    Certificate = "Thạc sĩ, Chuyên khoa II",
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
                    Specialization = "Sản phụ khoa",
                    Certificate = "Thạc sĩ, CKII",
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
                    Specialization = "Trưởng khoa Phòng sinh / Sản phụ khoa",
                    Certificate = "BSCKII",
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
                    Comment = "Dịch vụ sản phụ khoa tốt, khám thai rõ, bác sĩ tận tâm.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = sihospitalFeedback2Id,
                    ClinicId = sihospitalClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Siêu âm hình thái thai nhi đẹp, phòng sạch, chi phí cao nhưng đáng giá.",
                    CreationDate = new DateTime(2025, 09, 05)
                },
                new Feedback
                {
                    Id = sihospitalFeedback3Id,
                    ClinicId = sihospitalClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Quy trình đặt khám thuận tiện, hỗ trợ tư vấn khi có nguy cơ cao.",
                    CreationDate = new DateTime(2025, 09, 05)
                }
            );

            // Bệnh viện Đa khoa Quốc tế Sài Gòn (Saigon Healthcare)

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
                Address = "45 Thành Thái, Phường Diên Hồng, Quận 10, TP. Hồ Chí Minh, Việt Nam",
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
                Address = "45 Thành Thái, Phường Diên Hồng, Quận 10, TP. Hồ Chí Minh, Việt Nam",
                Description = "Saigon Healthcare Clinic là phòng khám đa khoa tư nhân có nhiều chuyên khoa, trong đó có sản phụ khoa / khám thai. Cung cấp dịch vụ khám thai định kỳ, siêu âm sản khoa, khám phụ khoa, tư vấn sức khỏe sinh sản. Khung giờ khám linh hoạt, dịch vụ chăm sóc toàn diện cho mẹ bầu.",
                IsInsuranceAccepted = false,
                Specializations = "Khám thai định kỳ;Siêu âm sản khoa;Khám phụ khoa;Tư vấn sức khỏe sinh sản;Khám dịch vụ phụ nữ;Khám bệnh theo yêu cầu",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Saigon Healthcare Doctor User
            var saigonHealthcareDoctorUser1Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = saigonHealthcareDoctorUser1Id,
                UserName = "BS Nguyễn Thị Minh Trúc",
                Email = "nguyenthiminhtrucSgHealthcare@gmail.com",
                PhoneNumber = "098 226 45 45",
                Password = HashPassword("doctor#51"),
                Address = "Khoa Sản phụ khoa, Saigon Healthcare Clinic, Quận 10, TP.HCM",
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
                Specialization = "Khám thai & siêu âm sản khoa",
                Certificate = "Bác sĩ Chuyên khoa I",
                ExperienceYear = 12,
                WorkPosition = "Bác sĩ sản phụ khoa",
                Description = "Khám thai định kỳ, theo dõi thai kỳ bình thường, siêu âm sản khoa tại clinic này.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 17)
            });

            // Seed Saigon Healthcare Consultant User
            var saigonHealthcareConsultantUser1Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = saigonHealthcareConsultantUser1Id,
                UserName = "BSCKI Phạm Thị Hồng Mai",
                Email = "phamthihongmai@gmail.com",
                PhoneNumber = "098 226 45 45",
                Password = HashPassword("consultant#40"),
                Address = "Saigon Healthcare Clinic, Quận 10, TP.HCM",
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
                Specialization = "Sản phụ khoa",
                Certificate = "Bác sĩ Chuyên khoa I",
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
                    Comment = "Khám sản phụ khoa nhanh, bác sĩ nhiệt tình; phòng khám sạch sẽ.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = saigonHealthcareFeedback2Id,
                    ClinicId = saigonHealthcareClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Chi phí hơi cao, nhưng mình thấy dịch vụ tương xứng.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = saigonHealthcareFeedback3Id,
                    ClinicId = saigonHealthcareClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Siêu âm thai tốt, có bác sĩ nữ nên mẹ bầu cảm giác thoải mái.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Bệnh viện Đa khoa tỉnh Bình Dương

            // Seed Bình Dương Clinic User
            var binhduongClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = binhduongClinicUserId,
                UserName = "Bệnh viện Đa khoa Bình Dương",
                Email = "benhvienbinhduong.bdgh@gmail.com",
                PhoneNumber = "02743 822920",
                Password = HashPassword("clinic#24"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "Số 05, đường Phạm Ngọc Thạch, Phường Phú Lợi, Thành phố Thủ Dầu Một, tỉnh Bình Dương, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Bình Dương Clinic
            var binhduongClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = binhduongClinicId,
                UserId = binhduongClinicUserId,
                Address = "Số 05, đường Phạm Ngọc Thạch, Phường Phú Lợi, Thành phố Thủ Dầu Một, tỉnh Bình Dương, Việt Nam",
                Description = "Bệnh viện Đa khoa tỉnh Bình Dương là bệnh viện đa khoa hạng I, thành lập năm 1890 (từ Nhà thương Phú Cường), có chức năng khám chữa bệnh đa khoa lớn cho người dân địa phương. Khoa Phụ sản hoạt động với quy mô lớn để cung cấp dịch vụ khám thai, đỡ đẻ, tư vấn sản phụ khoa. Bệnh viện đang trong quá trình đổi tên và mở rộng cơ sở, có dự án mới 1.500 giường bệnh.",
                IsInsuranceAccepted = true,
                Specializations = "Đa khoa tổng hợp;Sản phụ khoa;Khám thai định kỳ;Siêu âm sản khoa;Phụ khoa;Đỡ đẻ / sinh thường và sinh mổ;Tư vấn tiền sản;Chăm sóc sau sinh;Nhi khoa;Chẩn đoán hình ảnh;Xét nghiệm;Y học cổ truyền;Nội tiết;Vật lý trị liệu",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Bình Dương Doctor User
            var binhduongDoctorUser1Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = binhduongDoctorUser1Id,
                UserName = "BS Trần Văn Minh",
                Email = "doctorvanminh@gmail.com",
                PhoneNumber = null,
                Password = HashPassword("doctor#52"),
                Address = "Khoa Phụ sản, Bệnh viện Đa khoa Bình Dương",
                CreationDate = new DateTime(2025, 09, 17),
                RoleId = 7,
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Bình Dương Doctor
            var binhduongDoctor1Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = binhduongDoctor1Id,
                UserId = binhduongDoctorUser1Id,
                ClinicId = binhduongClinicId,
                Gender = "Male",
                Specialization = "Siêu âm sản khoa",
                Certificate = "Chuyên khoa I",
                ExperienceYear = 15,
                WorkPosition = "Bác sĩ sản phụ khoa",
                Description = "Thực hiện siêu âm thai định kỳ, theo dõi phát triển thai nhi.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 17)
            });

            // Seed Bình Dương Consultant Users
            var binhduongConsultantUser1Id = Guid.NewGuid();
            var binhduongConsultantUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = binhduongConsultantUser1Id,
                    UserName = "BS.CKII Nguyễn Thị Kim Huê",
                    Email = "kimhue@gmail.com",
                    PhoneNumber = null,
                    Password = HashPassword("consultant#41"),
                    Address = "Khoa Phụ sản, Bệnh viện Đa khoa Bình Dương",
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
                    UserName = "ThS. BS Hồ Thị Hoàng Anh",
                    Email = "hoanganh@gmail.com",
                    PhoneNumber = null,
                    Password = HashPassword("consultant#42"),
                    Address = "Khoa Phụ sản, Bệnh viện Đa khoa Bình Dương",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Bình Dương Consultants
            var binhduongConsultant1Id = Guid.NewGuid();
            var binhduongConsultant2Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = binhduongConsultant1Id,
                    UserId = binhduongConsultantUser1Id,
                    ClinicId = binhduongClinicId,
                    Specialization = "Sản phụ khoa / khám thai & tư vấn sản phụ khoa",
                    Certificate = "Chuyên khoa II",
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
                    Specialization = "Sản phụ khoa",
                    Certificate = "Thạc sĩ, Chuyên khoa I/II",
                    Gender = "Female",
                    ExperienceYears = 25,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                }
            );

            // Seed Bình Dương Feedbacks
            var binhduongFeedback1Id = Guid.NewGuid();
            var binhduongFeedback2Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = binhduongFeedback1Id,
                    ClinicId = binhduongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Khám thai tại BV Bình Dương ổn, bác sĩ tận tâm, phòng khám phụ sản khá đông nên chờ lâu.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = binhduongFeedback2Id,
                    ClinicId = binhduongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Dịch vụ sản phụ khoa được cải thiện; cơ sở vật chất tốt hơn nhưng cần tăng số lượng bác sĩ sản.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Bệnh viện Hoàn Mỹ Bình Dương

            // Seed Hoàn Mỹ Bình Dương Clinic User
            var hoanmyBinhduongClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = hoanmyBinhduongClinicUserId,
                UserName = "Bệnh viện Hoàn Mỹ Bình Dương",
                Email = "info@hoanmy.com",
                PhoneNumber = "0274 3777 999",
                Password = HashPassword("clinic#25"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "45 Hồ Văn Cống, Phường Tương Bình Hiệp, TP. Thủ Dầu Một, Bình Dương, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Hoàn Mỹ Bình Dương Clinic
            var hoanmyBinhduongClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = hoanmyBinhduongClinicId,
                UserId = hoanmyBinhduongClinicUserId,
                Address = "45 Hồ Văn Cống, Phường Tương Bình Hiệp, TP. Thủ Dầu Một, Bình Dương, Việt Nam",
                Description = "Bệnh viện Hoàn Mỹ Bình Dương là bệnh viện tư nhân cao cấp trong hệ thống Hoàn Mỹ, cung cấp đa dạng dịch vụ y tế, bao gồm Sản-Phụ khoa với gói sanh trọn gói, khám thai định kỳ, dịch vụ đỡ đẻ, sinh thường & mổ, hỗ trợ sản phụ và chăm sóc sau sinh. Bệnh viện có các cơ sở vật chất hiện đại và phòng gia đình dành cho nhu cầu thai sản.",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ;Sản phụ khoa;Sinh thường;Sinh mổ;Gói sanh trọn gói;Siêu âm sản khoa;Khám phụ khoa;Chăm sóc bà mẹ & trẻ sơ sinh;Khám dịch vụ sản phụ khoa;Cấp cứu sản khoa;Phòng gia đình sinh;Dịch vụ đưa rước sản phụ",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Hoàn Mỹ Bình Dương Doctor Users
            var hoanmyBinhduongDoctorUser1Id = Guid.NewGuid();
            var hoanmyBinhduongDoctorUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = hoanmyBinhduongDoctorUser1Id,
                    UserName = "BS Nguyễn Thị Minh Thảo",
                    Email = "minhhao@gmail.com",
                    PhoneNumber = "0274 3777 999",
                    Password = HashPassword("doctor#53"),
                    Address = "Hoàn Mỹ Bình Dương, Khoa Sản phụ khoa",
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
                    UserName = "BS Trần Văn Hoàng",
                    Email = "tranvanhoang@gmail.com",
                    PhoneNumber = "0274 3777 999",
                    Password = HashPassword("doctor#54"),
                    Address = "Hoàn Mỹ Bình Dương, Khoa Sản phụ khoa",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Hoàn Mỹ Bình Dương Doctors
            var hoanmyBinhduongDoctor1Id = Guid.NewGuid();
            var hoanmyBinhduongDoctor2Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = hoanmyBinhduongDoctor1Id,
                    UserId = hoanmyBinhduongDoctorUser1Id,
                    ClinicId = hoanmyBinhduongClinicId,
                    Gender = "Female",
                    Specialization = "Sản phụ khoa / sinh thường",
                    Certificate = "Chuyên khoa I",
                    ExperienceYear = 13,
                    WorkPosition = "Bác sĩ sản phụ khoa",
                    Description = "Thực hiện sinh thường, theo dõi thai kỳ tại Hoàn Mỹ Bình Dương",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = hoanmyBinhduongDoctor2Id,
                    UserId = hoanmyBinhduongDoctorUser2Id,
                    ClinicId = hoanmyBinhduongClinicId,
                    Gender = "Male",
                    Specialization = "Sản phụ khoa / sinh mổ",
                    Certificate = "Chuyên khoa II",
                    ExperienceYear = 18,
                    WorkPosition = "Bác sĩ sản phụ khoa",
                    Description = "Thực hiện mổ lấy thai, chăm sóc sản phụ có nguy cơ cao",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Seed Hoàn Mỹ Bình Dương Consultant User
            var hoanmyBinhduongConsultantUser1Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = hoanmyBinhduongConsultantUser1Id,
                UserName = "BS chuyên sản Hoàn Mỹ Bình Dương",
                Email = "hoanmyConsultant@gmail.com",
                PhoneNumber = "0274 3777 999",
                Password = HashPassword("consultant#43"),
                Address = "Hoàn Mỹ Bình Dương, Khoa Sản phụ khoa",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Hoàn Mỹ Bình Dương Consultant
            var hoanmyBinhduongConsultant1Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = hoanmyBinhduongConsultant1Id,
                UserId = hoanmyBinhduongConsultantUser1Id,
                ClinicId = hoanmyBinhduongClinicId,
                Specialization = "Sản phụ khoa / khám thai",
                Certificate = "Bác sĩ chuyên khoa I/II",
                Gender = "Female",
                ExperienceYears = 15,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Hoàn Mỹ Bình Dương Feedbacks
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
                    Comment = "Dịch vụ sanh trọn gói tốt, bác sĩ tận tâm, phòng sinh gia đình đẹp.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = hoanmyBinhduongFeedback2Id,
                    ClinicId = hoanmyBinhduongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Chi phí hợp lý so với các bệnh viện tư, siêu âm thai rõ nét.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = hoanmyBinhduongFeedback3Id,
                    ClinicId = hoanmyBinhduongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Thủ tục nhanh, dịch vụ hỗ trợ sau sinh tốt, tuy nhiên chờ khám ban ngày hơi đông.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Bệnh viện Đa khoa Medic Bình Dương

            // Seed Medic Bình Dương Clinic User
            var medicBinhduongClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = medicBinhduongClinicUserId,
                UserName = "Bệnh viện Đa khoa Medic Bình Dương",
                Email = "info@medicbinhduong.vn",
                PhoneNumber = "0274 3846 997",
                Password = HashPassword("clinic#26"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "123 Đại lộ Bình Dương, Phường Phú Thọ, TP. Thủ Dầu Một, Bình Dương, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Medic Bình Dương Clinic
            var medicBinhduongClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = medicBinhduongClinicId,
                UserId = medicBinhduongClinicUserId,
                Address = "123 Đại lộ Bình Dương, Phường Phú Thọ, TP. Thủ Dầu Một, Bình Dương, Việt Nam",
                Description = "Bệnh viện Đa khoa Medic Bình Dương là một trong những cơ sở y tế tư nhân trực thuộc hệ thống MEDIC, cung cấp dịch vụ y tế chất lượng cao với thế mạnh về chẩn đoán hình ảnh, xét nghiệm và chuyên khoa Sản phụ khoa. Bệnh viện cung cấp các gói khám thai định kỳ, siêu âm thai 2D/3D/4D, dịch vụ sinh thường, sinh mổ và chăm sóc sau sinh cho thai phụ.",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ;Siêu âm thai 2D/3D/4D;Sản phụ khoa;Sinh thường;Sinh mổ;Khám phụ khoa;Chăm sóc trước và sau sinh;Xét nghiệm sàng lọc trước sinh;Tư vấn dinh dưỡng thai kỳ",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Medic Bình Dương Doctor Users
            var medicBinhduongDoctorUser1Id = Guid.NewGuid();
            var medicBinhduongDoctorUser2Id = Guid.NewGuid();
            var medicBinhduongDoctorUser3Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = medicBinhduongDoctorUser1Id,
                    UserName = "BSCKII Nguyễn Thị Mai Anh",
                    Email = "maianh@medicbinhduong.vn",
                    PhoneNumber = "0274 3846 997",
                    Password = HashPassword("doctor#55"),
                    Address = "Khoa Sản phụ khoa, Medic Bình Dương",
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
                    UserName = "BS Lê Thanh Bình",
                    Email = "thanhbinh@medicbinhduong.vn",
                    PhoneNumber = "0274 3846 997",
                    Password = HashPassword("doctor#56"),
                    Address = "Khoa Sản phụ khoa, Medic Bình Dương",
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
                    UserName = "BS Nguyễn Thị Ngọc Hương",
                    Email = "ngochuong@medicbinhduong.vn",
                    PhoneNumber = "0274 3846 997",
                    Password = HashPassword("doctor#57"),
                    Address = "Khoa Sản phụ khoa, Medic Bình Dương",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Medic Bình Dương Doctors
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
                    Specialization = "Sinh thường, sinh mổ",
                    Certificate = "Bác sĩ chuyên khoa II Sản phụ khoa",
                    ExperienceYear = 20,
                    WorkPosition = "Trưởng khoa Sản phụ khoa",
                    Description = "Có kinh nghiệm hơn 20 năm trong điều trị sản phụ khoa, trực tiếp theo dõi và đỡ sinh tại bệnh viện.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = medicBinhduongDoctor2Id,
                    UserId = medicBinhduongDoctorUser2Id,
                    ClinicId = medicBinhduongClinicId,
                    Gender = "Male",
                    Specialization = "Siêu âm và chẩn đoán trước sinh",
                    Certificate = "Bác sĩ chuyên khoa I",
                    ExperienceYear = 10,
                    WorkPosition = "Bác sĩ siêu âm sản khoa",
                    Description = "Chuyên về siêu âm thai, chẩn đoán các bất thường và tư vấn chăm sóc mẹ bầu.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = medicBinhduongDoctor3Id,
                    UserId = medicBinhduongDoctorUser3Id,
                    ClinicId = medicBinhduongClinicId,
                    Gender = "Female",
                    Specialization = "Khám phụ khoa và chăm sóc sau sinh",
                    Certificate = "Bác sĩ đa khoa, định hướng Sản phụ khoa",
                    ExperienceYear = 8,
                    WorkPosition = "Bác sĩ Sản phụ khoa",
                    Description = "Theo dõi sức khỏe mẹ và bé sau sinh, hỗ trợ tư vấn kế hoạch hóa gia đình.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Seed Medic Bình Dương Consultant Users
            var medicBinhduongConsultantUser1Id = Guid.NewGuid();
            var medicBinhduongConsultantUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = medicBinhduongConsultantUser1Id,
                    UserName = "ThS.BS Nguyễn Thị Hồng Vân",
                    Email = "hongvan@medicbinhduong.vn",
                    PhoneNumber = "0274 3846 997",
                    Password = HashPassword("consultant#44"),
                    Address = "Khoa Sản phụ khoa, Medic Bình Dương",
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
                    UserName = "BSCKI Trần Minh Quân",
                    Email = "minhquan@medicbinhduong.vn",
                    PhoneNumber = "0274 3846 997",
                    Password = HashPassword("consultant#45"),
                    Address = "Khoa Sản phụ khoa, Medic Bình Dương",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Medic Bình Dương Consultants
            var medicBinhduongConsultant1Id = Guid.NewGuid();
            var medicBinhduongConsultant2Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = medicBinhduongConsultant1Id,
                    UserId = medicBinhduongConsultantUser1Id,
                    ClinicId = medicBinhduongClinicId,
                    Specialization = "Tư vấn thai kỳ, siêu âm thai",
                    Certificate = "Thạc sĩ, Bác sĩ chuyên khoa I Sản phụ khoa",
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
                    Specialization = "Tư vấn sản phụ khoa",
                    Certificate = "Bác sĩ chuyên khoa I Sản phụ khoa",
                    Gender = "Male",
                    ExperienceYears = 12,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                }
            );

            // Seed Medic Bình Dương Feedbacks
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
                    Comment = "Dịch vụ siêu âm 4D rõ nét, bác sĩ tư vấn kỹ lưỡng cho mẹ bầu.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = medicBinhduongFeedback2Id,
                    ClinicId = medicBinhduongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Đội ngũ bác sĩ sản khoa tận tâm, sinh mổ an toàn, chăm sóc hậu phẫu chu đáo.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = medicBinhduongFeedback3Id,
                    ClinicId = medicBinhduongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Thủ tục khá nhanh, nhưng vào giờ cao điểm thì chờ hơi lâu.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = medicBinhduongFeedback4Id,
                    ClinicId = medicBinhduongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 10,
                    Comment = "Có dịch vụ khám thai trọn gói, rất tiện lợi và chi phí hợp lý.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Bệnh viện Sài Gòn Bình Dương

            // Seed Sài Gòn Bình Dương Clinic User
            var saigonBinhduongClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = saigonBinhduongClinicUserId,
                UserName = "Bệnh viện Đa khoa Sài Gòn Bình Dương",
                Email = "info@bvsaigonbinhduong.vn",
                PhoneNumber = "(0274) 366 8989",
                Password = HashPassword("clinic#27"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "39 Hồ Văn Cống, Khu phố 4, Phường Tương Bình Hiệp, Thủ Dầu Một, Bình Dương, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Sài Gòn Bình Dương Clinic
            var saigonBinhduongClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = saigonBinhduongClinicId,
                UserId = saigonBinhduongClinicUserId,
                Address = "39 Hồ Văn Cống, Khu phố 4, Phường Tương Bình Hiệp, Thủ Dầu Một, Bình Dương, Việt Nam",
                Description = "Bệnh viện Đa khoa Sài Gòn Bình Dương là bệnh viện đa khoa tư nhân, thành lập năm 2009, có đội ngũ bác sĩ chuyên sâu và trang thiết bị hiện đại. Khoa Sản phụ khoa là một trong các khoa chủ chốt, thực hiện khám thai, theo dõi thai nhi định kỳ, sinh thường và sinh mổ, kế hoạch hóa sinh sản.",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ;Sản phụ khoa;Sinh thường / Sinh mổ;Kế hoạch hóa sinh sản;Siêu âm tổng quát / siêu âm thai;Khám phụ khoa;Phẫu thuật phụ khoa;Cận lâm sàng (xét nghiệm, chẩn đoán hình ảnh);Ngoại - Sản - Gây mê hồi sức;Khám bệnh & cấp cứu",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Sài Gòn Bình Dương Doctor Users
            var saigonBinhduongDoctorUser1Id = Guid.NewGuid();
            var saigonBinhduongDoctorUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = saigonBinhduongDoctorUser1Id,
                    UserName = "BS Phụ khoa / Sản phụ khoa",
                    Email = "BsSaiGonBinhDuong@gmail.com",
                    PhoneNumber = "(0274) 366 8989",
                    Password = HashPassword("doctor#58"),
                    Address = "Khoa Sản, Bệnh viện Đa khoa Sài Gòn Bình Dương",
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
                    UserName = "BS Sinh mổ / sản phụ khoa",
                    Email = "doctorSaiGon@gmail.com",
                    PhoneNumber = "(0274) 366 8989",
                    Password = HashPassword("doctor#59"),
                    Address = "Khoa Sản, Bệnh viện Đa khoa Sài Gòn Bình Dương",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Sài Gòn Bình Dương Doctors
            var saigonBinhduongDoctor1Id = Guid.NewGuid();
            var saigonBinhduongDoctor2Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = saigonBinhduongDoctor1Id,
                    UserId = saigonBinhduongDoctorUser1Id,
                    ClinicId = saigonBinhduongClinicId,
                    Gender = "Female",
                    Specialization = "Siêu âm thai / theo dõi thai thường",
                    Certificate = "Chuyên khoa I",
                    ExperienceYear = 12,
                    WorkPosition = "Bác sĩ sản phụ khoa",
                    Description = "Thực hiện khám thai định kỳ, siêu âm tổng quát và theo dõi thai nhi.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = saigonBinhduongDoctor2Id,
                    UserId = saigonBinhduongDoctorUser2Id,
                    ClinicId = saigonBinhduongClinicId,
                    Gender = "Female",
                    Specialization = "Sinh mổ, sản phụ khoa nguy cơ",
                    Certificate = "Chuyên khoa II",
                    ExperienceYear = 18,
                    WorkPosition = "Bác sĩ sản mổ",
                    Description = "Thực hiện sinh mổ & xử lý các sản phụ có nguy cơ cao.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Seed Sài Gòn Bình Dương Consultant User
            var saigonBinhduongConsultantUser1Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = saigonBinhduongConsultantUser1Id,
                UserName = "BS CK I Lê Chí Thiện",
                Email = "lechithien@gmail.com",
                PhoneNumber = "(0274) 366 8989",
                Password = HashPassword("consultant#46"),
                Address = "Khoa Sản, Bệnh viện Đa khoa Sài Gòn Bình Dương",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Sài Gòn Bình Dương Consultant
            var saigonBinhduongConsultant1Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = saigonBinhduongConsultant1Id,
                UserId = saigonBinhduongConsultantUser1Id,
                ClinicId = saigonBinhduongClinicId,
                Specialization = "Sản phụ khoa / trưởng khoa Sản",
                Certificate = "Bác sĩ Chuyên khoa I",
                Gender = "Male",
                ExperienceYears = 20,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Sài Gòn Bình Dương Feedbacks
            var saigonBinhduongFeedback1Id = Guid.NewGuid();
            var saigonBinhduongFeedback2Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = saigonBinhduongFeedback1Id,
                    ClinicId = saigonBinhduongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Khám thai ổn, bác sĩ kiêm khám phụ khoa rất tận tâm, máy móc hiện đại.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = saigonBinhduongFeedback2Id,
                    ClinicId = saigonBinhduongClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Chi phí hơi cao so với bệnh viện công, chờ khám dịch vụ cần sắp lịch trước.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Bệnh viện Vạn Phúc (chuỗi bệnh viện Vạn Phúc, có khoa sản)

            // Seed Vạn Phúc City Clinic User
            var vanphucClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = vanphucClinicUserId,
                UserName = "Bệnh viện Đa khoa Vạn Phúc City",
                Email = "vanphuccity@gmail.com",
                PhoneNumber = "1900 966 979",
                Password = HashPassword("clinic#28"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "Số 1, Đường 10, Khu nhà ở Vạn Phúc 1, P. Hiệp Bình, TP. Thủ Đức, TP. Hồ Chí Minh, Việt Nam; Có hai cơ sở chính tại TP. Thủ Dầu Một (Vạn Phúc 1) và TP. Dĩ An (Vạn Phúc 2), tỉnh Bình Dương.",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Vạn Phúc City Clinic
            var vanphucClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = vanphucClinicId,
                UserId = vanphucClinicUserId,
                Address = "Số 1, Đường 10, Khu nhà ở Vạn Phúc 1, P. Hiệp Bình, TP. Thủ Đức, TP. Hồ Chí Minh, Việt Nam; Có hai cơ sở chính tại TP. Thủ Dầu Một (Vạn Phúc 1) và TP. Dĩ An (Vạn Phúc 2), tỉnh Bình Dương.",
                Description = "Hệ thống Bệnh viện Đa khoa Vạn Phúc City là bệnh viện tư nhân với hai cơ sở lớn tại Bình Dương, cung cấp đa khoa, có khoa Sản phụ khoa mạnh. Cung cấp dịch vụ khám thai, khám sản trọn gói, sanh thường, sanh mổ, chăm sóc hậu sản và chăm sóc sản phụ & trẻ sơ sinh với trang thiết bị y tế hiện đại.",
                IsInsuranceAccepted = true,
                Specializations = "Sản phụ khoa;Khám thai định kỳ;Sanh thường & sanh mổ;Khám phụ khoa;Chăm sóc hậu sản;Khám dịch vụ theo yêu cầu;Siêu âm sản khoa;Tầm soát ung thư phụ khoa;Khám sức khỏe sinh sản;Khám bảo hiểm y tế",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Vạn Phúc City Doctor Users
            var vanphucDoctorUser1Id = Guid.NewGuid();
            var vanphucDoctorUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = vanphucDoctorUser1Id,
                    UserName = "BS sản phụ khoa Vạn Phúc 1",
                    Email = "vanphuccitydoctor@gmail.com",
                    PhoneNumber = null,
                    Password = HashPassword("doctor#60"),
                    Address = "Cơ sở Vạn Phúc 1, Bình Dương",
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
                    UserName = "BS sản phụ khoa Vạn Phúc 2",
                    Email = "vanphucDoctor@gmail.com",
                    PhoneNumber = null,
                    Password = HashPassword("doctor#61"),
                    Address = "Cơ sở Vạn Phúc 2, Bình Dương",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Vạn Phúc City Doctors
            var vanphucDoctor1Id = Guid.NewGuid();
            var vanphucDoctor2Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = vanphucDoctor1Id,
                    UserId = vanphucDoctorUser1Id,
                    ClinicId = vanphucClinicId,
                    Gender = "Female",
                    Specialization = "Khám thai & chăm sóc sau sinh",
                    Certificate = "Bác sĩ Chuyên khoa I",
                    ExperienceYear = 12,
                    WorkPosition = "Bác sĩ sản phụ khoa",
                    Description = "Thực hiện khám thai định kỳ, đỡ đẻ, chăm sóc sản phụ bình thường.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = vanphucDoctor2Id,
                    UserId = vanphucDoctorUser2Id,
                    ClinicId = vanphucClinicId,
                    Gender = "Male",
                    Specialization = "Sinh mổ / sản phụ khoa nguy cơ cao",
                    Certificate = "Bác sĩ Chuyên khoa II",
                    ExperienceYear = 18,
                    WorkPosition = "Bác sĩ sản phụ khoa",
                    Description = "Thực hiện sinh mổ, xử lý sản phụ có nguy cơ cao.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Seed Vạn Phúc City Consultant Users
            var vanphucConsultantUser1Id = Guid.NewGuid();
            var vanphucConsultantUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = vanphucConsultantUser1Id,
                    UserName = "BS Lâm Thị Kim Ngân",
                    Email = "kimngan@gmail.com",
                    PhoneNumber = null,
                    Password = HashPassword("consultant#47"),
                    Address = "Khoa Sản phụ khoa, Vạn Phúc City",
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
                    UserName = "BS Hoàng Thị Minh Hiếu",
                    Email = "minhhieu@gmail.com",
                    PhoneNumber = null,
                    Password = HashPassword("consultant#48"),
                    Address = "Khoa Sản phụ khoa, Vạn Phúc City",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Vạn Phúc City Consultants
            var vanphucConsultant1Id = Guid.NewGuid();
            var vanphucConsultant2Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = vanphucConsultant1Id,
                    UserId = vanphucConsultantUser1Id,
                    ClinicId = vanphucClinicId,
                    Specialization = "Sản phụ khoa",
                    Certificate = "Bác sĩ Chuyên khoa I",
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
                    Specialization = "Sản phụ khoa / khám bệnh sản",
                    Certificate = "Bác sĩ Chuyên khoa I / CKII",
                    Gender = "Female",
                    ExperienceYears = 18,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                }
            );

            // Seed Vạn Phúc City Feedbacks
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
                    Comment = "Khám sản phụ khoa tốt, phòng khám sạch, chi phí hợp lý.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = vanphucFeedback2Id,
                    ClinicId = vanphucClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Sanh thường tại Vạn Phúc 1 ổn, điều dưỡng và bác sĩ tận tâm.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = vanphucFeedback3Id,
                    ClinicId = vanphucClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Siêu âm thai rõ ràng, được tư vấn kỹ, cảm thấy an tâm.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Bệnh viện Đa khoa Mỹ Phước

            // Seed Mỹ Phước Clinic User
            var myphuocClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = myphuocClinicUserId,
                UserName = "Bệnh viện Đa khoa Mỹ Phước",
                Email = "customerservice.mph@gmail.com",
                PhoneNumber = "0274 3535 777",
                Password = HashPassword("clinic#29"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "Đường TC3, Tổ 6, Khu phố 3, Phường Mỹ Phước, Thành phố Bến Cát, tỉnh Bình Dương, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Mỹ Phước Clinic
            var myphuocClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = myphuocClinicId,
                UserId = myphuocClinicUserId,
                Address = "Đường TC3, Tổ 6, Khu phố 3, Phường Mỹ Phước, Thành phố Bến Cát, tỉnh Bình Dương, Việt Nam",
                Description = "Bệnh viện Đa khoa Mỹ Phước (MPH) là bệnh viện tư nhân thuộc Tổng Công ty Becamex IDC, phục vụ cho người dân Bình Dương và vùng lân cận. Bệnh viện có quy mô lớn (giai đoạn II: 489 giường; 16 chuyên khoa, 8 phòng chức năng) với nhiều trang thiết bị hiện đại. Khoa Sản thực hiện các dịch vụ khám thai, sinh thường / sinh mổ, tầm soát dị tật thai nhi, xét nghiệm trước sinh, và chăm sóc sản phụ & trẻ sơ sinh.",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ;Siêu âm sản khoa;Khám phụ khoa;Sinh thường & sinh mổ;Tư vấn tiền sản;Tầm soát dị tật thai nhi;Xét nghiệm trước sinh;Đặt vòng / cấy que tránh thai;Chăm sóc sản phụ & hậu sản;Các dịch vụ dành cho Mẹ & Bé;Khám bệnh BHYT;Cấp cứu sản khoa",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Mỹ Phước Doctor User
            var myphuocDoctorUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = myphuocDoctorUserId,
                UserName = "BS sản phụ khoa Mỹ Phước",
                Email = "myphuocdoctor@gmail.com",
                PhoneNumber = "0274 3535 777",
                Password = HashPassword("doctor#62"),
                Address = "Khoa Phụ sản, Bệnh viện Đa khoa Mỹ Phước",
                CreationDate = new DateTime(2025, 09, 17),
                RoleId = 7,
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Mỹ Phước Doctor
            var myphuocDoctorId = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = myphuocDoctorId,
                UserId = myphuocDoctorUserId,
                ClinicId = myphuocClinicId,
                Gender = "Female",
                Specialization = "Khám thai & dịch vụ Sản phụ khoa",
                Certificate = "Bác sĩ chuyên khoa I",
                ExperienceYear = 10,
                WorkPosition = "Bác sĩ sản phụ khoa",
                Description = "Thực hiện quy trình sinh con tại MPH, khám sản phụ khoa thông thường & dịch vụ mẹ - bé.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 17)
            });

            // Seed Mỹ Phước Consultant User
            var myphuocConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = myphuocConsultantUserId,
                UserName = "BS tư vấn sản phụ khoa Mỹ Phước",
                Email = "tuvanmyphuoc@gmail.com",
                PhoneNumber = "0274 3535 777",
                Password = HashPassword("consultant#49"),
                Address = "Khoa Phụ sản, Bệnh viện Đa khoa Mỹ Phước",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Mỹ Phước Consultant
            var myphuocConsultantId = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = myphuocConsultantId,
                UserId = myphuocConsultantUserId,
                ClinicId = myphuocClinicId,
                Specialization = "Sản phụ khoa / khám thai & siêu âm",
                Certificate = "Bác sĩ chuyên khoa I",
                Gender = "Female",
                ExperienceYears = 10,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Mỹ Phước Feedback
            var myphuocFeedback1Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(new Feedback
            {
                Id = myphuocFeedback1Id,
                ClinicId = myphuocClinicId,
                UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                Rating = 9,
                Comment = "Em cảm thấy mình rất may mắn và hết sức hài lòng khi chọn bệnh viện Mỹ Phước là nơi đồng hành cùng em trong suốt quá trình mang thai và vượt cạn … ”",
                CreationDate = new DateTime(2025, 09, 17)
            });

            // Trung tâm Y tế Bến Cát

            // Add after the last existing seed block in SeedData(ModelBuilder modelBuilder)

            // Seed Trung tâm Y tế Thị xã Bến Cát Clinic User
            var bencatClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = bencatClinicUserId,
                UserName = "Trung tâm Y tế Thị xã Bến Cát",
                Email = "hotro@ttytebencat.com",
                PhoneNumber = "0274 3564 247",
                Password = HashPassword("clinic#30"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "Khu phố 5, Phường Mỹ Phước, Thị xã Bến Cát, Tỉnh Bình Dương, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Trung tâm Y tế Thị xã Bến Cát Clinic
            var bencatClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = bencatClinicId,
                UserId = bencatClinicUserId,
                Address = "Khu phố 5, Phường Mỹ Phước, Thị xã Bến Cát, Tỉnh Bình Dương, Việt Nam",
                Description = "Trung tâm Y tế thị xã Bến Cát là cơ sở khám chữa bệnh tuyến huyện (hạng III) trực thuộc Sở Y tế Bình Dương. Địa phương có khoa Sản, cung cấp các dịch vụ phụ sản, khám phụ khoa, chăm sóc sức khỏe sinh sản cho người dân địa phương. Cơ sở vật chất đang được cải thiện, có giai đoạn 2 mở rộng. Hoạt động 24/7 cho cấp cứu. ([cskh.org.vn](https://cskh.org.vn/trung-tam-y-te-thi-xa-ben-cat/))",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ / Sản phụ khoa;Khám phụ khoa;Chăm sóc sức khỏe sinh sản;Đỡ đẻ / Sinh thường;Siêu âm sản khoa;Xét nghiệm phụ sản;Cấp cứu sản khoa;Khám bệnh bảo hiểm y tế;Khám nội tổng quát;Nhi khoa;Chẩn đoán hình ảnh",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Trung tâm Y tế Thị xã Bến Cát Doctor User (simulated)
            var bencatDoctorUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = bencatDoctorUserId,
                UserName = "Bác sĩ trung tâm y tế Bến Cát",
                Email = "bacsytrungtambencat@gmail.com",
                PhoneNumber = "0274 3564 247",
                Password = HashPassword("doctor#63"),
                Address = "Khoa Sản, Trung tâm Y tế Thị xã Bến Cát",
                CreationDate = new DateTime(2025, 09, 17),
                RoleId = 7,
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Trung tâm Y tế Thị xã Bến Cát Doctor (simulated)
            var bencatDoctorId = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = bencatDoctorId,
                UserId = bencatDoctorUserId,
                ClinicId = bencatClinicId,
                Gender = "Female",
                Specialization = "Sản phụ khoa / đỡ đẻ",
                Certificate = "Bác sĩ chuyên khoa I – Sản phụ khoa",
                ExperienceYear = 20,
                WorkPosition = "Bác sĩ",
                Description = "Thực hiện sinh thường, khám sản phụ khoa tại trung tâm địa phương.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 17)
            });

            // Seed Trung tâm Y tế Thị xã Bến Cát Consultant User (simulated)
            var bencatConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = bencatConsultantUserId,
                UserName = "Tư vấn viên cơ sở y tế Bến Cát",
                Email = "tuvanytebencat@gmail.com",
                PhoneNumber = "0274 3564 247",
                Password = HashPassword("consultant#50"),
                Address = "Khoa Sản, Trung tâm Y tế Thị xã Bến Cát",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Trung tâm Y tế Thị xã Bến Cát Consultant (simulated)
            var bencatConsultantId = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = bencatConsultantId,
                UserId = bencatConsultantUserId,
                ClinicId = bencatClinicId,
                Specialization = "Sản phụ khoa / khám thai",
                Certificate = "Bác sĩ chuyên khoa I – Sản phụ khoa",
                Gender = "Male",
                ExperienceYears = 13,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Trung tâm Y tế Thị xã Bến Cát Feedback
            var bencatFeedback1Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(new Feedback
            {
                Id = bencatFeedback1Id,
                ClinicId = bencatClinicId,
                UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                Rating = 4,
                Comment = "Người dân phản hồi dịch vụ sản phụ khoa có cải thiện; bác sĩ thân thiện nhưng lúc đông phải chờ lâu.",
                CreationDate = new DateTime(2025, 09, 17)
            });

            // Trung tâm Y tế Tân Uyên

            // Add after the last existing seed block in SeedData(ModelBuilder modelBuilder)

            // Seed Trung tâm Y tế Thành phố Tân Uyên Clinic User
            var tanuyenClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = tanuyenClinicUserId,
                UserName = "Trung tâm Y tế Thành phố Tân Uyên",
                Email = "ttytetanuyen@gmail.com",
                PhoneNumber = "(0274) 3656 340",
                Password = HashPassword("clinic#31"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "Đường ĐT 747, Khu phố 7, Phường Uyên Hưng, Thành phố Tân Uyên, Tỉnh Bình Dương, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Trung tâm Y tế Thành phố Tân Uyên Clinic
            var tanuyenClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = tanuyenClinicId,
                UserId = tanuyenClinicUserId,
                Address = "Đường ĐT 747, Khu phố 7, Phường Uyên Hưng, Thành phố Tân Uyên, Tỉnh Bình Dương, Việt Nam",
                Description = "Trung tâm Y tế Thành phố Tân Uyên là cơ sở y tế công lập tuyến thành phố, cung cấp dịch vụ khám chữa bệnh đa khoa, có chuyên khoa sản phụ khoa. Các dịch vụ sản phụ khoa bao gồm khám phụ khoa, khám thai, dịch vụ cấp cứu sản khoa, chăm sóc thai phụ địa phương. Dịch vụ BHYT được chấp nhận.",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ;Sản phụ khoa;Khám phụ khoa;Siêu âm sản khoa;Chăm sóc sức khỏe sinh sản;Cấp cứu sản khoa;Khám bệnh đa khoa;Nhi khoa;Chẩn đoán hình ảnh;Xét nghiệm",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Trung tâm Y tế Thành phố Tân Uyên Doctor User (simulated)
            var tanuyenDoctorUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = tanuyenDoctorUserId,
                UserName = "Bác sĩ trung tâm y tế Tân Uyên",
                Email = "bacsitanuyen@gmail.com",
                PhoneNumber = "(0274) 3656 340",
                Password = HashPassword("doctor#64"),
                Address = "Khoa Sản, Trung tâm Y tế Thành phố Tân Uyên",
                CreationDate = new DateTime(2025, 09, 17),
                RoleId = 7,
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Trung tâm Y tế Thành phố Tân Uyên Doctor (simulated)
            var tanuyenDoctorId = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = tanuyenDoctorId,
                UserId = tanuyenDoctorUserId,
                ClinicId = tanuyenClinicId,
                Gender = "Male",
                Specialization = "Đỡ đẻ / sinh thường",
                Certificate = "Bác sĩ chuyên khoa I – Sản phụ khoa",
                ExperienceYear = 18,
                WorkPosition = "Bác sĩ",
                Description = "Thực hiện sinh thường, chăm sóc sản phụ địa phương và khám thai định kỳ.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 17)
            });

            // Seed Trung tâm Y tế Thành phố Tân Uyên Consultant User (simulated)
            var tanuyenConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = tanuyenConsultantUserId,
                UserName = "Tư vấn viên trung tâm y tế thành phố Tân Uyên",
                Email = "tuvantanuyen@gmail.com",
                PhoneNumber = "(0274) 3656 340",
                Password = HashPassword("consultant#51"),
                Address = "Khoa Sản, Trung tâm Y tế Thành phố Tân Uyên",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Trung tâm Y tế Thành phố Tân Uyên Consultant (simulated)
            var tanuyenConsultantId = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = tanuyenConsultantId,
                UserId = tanuyenConsultantUserId,
                ClinicId = tanuyenClinicId,
                Specialization = "Sản phụ khoa / khám thai & tư vấn sản phụ khoa",
                Certificate = "Bác sĩ chuyên khoa I – Sản phụ khoa",
                Gender = "Male",
                ExperienceYears = 14,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Trung tâm Y tế Thành phố Tân Uyên Feedbacks
            var tanuyenFeedback1Id = Guid.NewGuid();
            var tanuyenFeedback2Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = tanuyenFeedback1Id,
                    ClinicId = tanuyenClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 4,
                    Comment = "Dịch vụ sản phụ khoa ổn; bác sĩ địa phương thân thiện; nhưng bệnh nhân nhiều nên phải chờ.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = tanuyenFeedback2Id,
                    ClinicId = tanuyenClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 4,
                    Comment = "Khám thai bình thường tại trung tâm gần nhà, tiện lợi; trang thiết bị chưa hiện đại lắm.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Trung tâm Y tế Thuận An

            // Seed Trung tâm Y tế Thành phố Thuận An Clinic User
            var thuananClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = thuananClinicUserId,
                UserName = "Trung tâm Y tế Thành phố Thuận An",
                Email = "bvthuanan@binhduong.gov.vn",
                PhoneNumber = "0274 3755 434",
                Password = HashPassword("clinic#32"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "Đường Nguyễn Văn Tiết, Khu phố Đông Tư, Phường Lái Thiêu, Thành phố Thuận An, tỉnh Bình Dương, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Trung tâm Y tế Thành phố Thuận An Clinic
            var thuananClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = thuananClinicId,
                UserId = thuananClinicUserId,
                Address = "Đường Nguyễn Văn Tiết, Khu phố Đông Tư, Phường Lái Thiêu, Thành phố Thuận An, tỉnh Bình Dương, Việt Nam",
                Description = "Trung tâm Y tế TP. Thuận An là bệnh viện hạng II công lập, phục vụ khám chữa bệnh đa khoa cho địa bàn Thuận An. Có khoa Sản – Phụ khoa cung cấp dịch vụ khám thai, mổ lấy thai, phụ sản, khám phụ khoa, phẫu thuật nội soi thai ngoài tử cung. Quy mô khoảng 250 giường bệnh. Được hình thành bằng việc hợp nhất các cơ sở y tế địa phương, Trung tâm Y tế – Bệnh viện – Dân số kế hoạch hóa gia đình.",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ;Sản phụ khoa / khám phụ khoa;Mổ lấy thai / Phẫu thuật sản phụ khoa;Siêu âm sản khoa;Khám dịch vụ sản phụ khoa;Phẫu thuật nội soi thai ngoài tử cung;Khám sức khỏe sinh sản;Cấp cứu sản khoa;Khám bệnh BHYT;Khám đa khoa / nội, ngoại, nhi;Chẩn đoán hình ảnh & xét nghiệm",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Trung tâm Y tế Thành phố Thuận An Doctor User (simulated)
            var thuananDoctorUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = thuananDoctorUserId,
                UserName = "Bác sĩ Trung Tâm Y tế TP.Thuận An",
                Email = "doctortpthuanan@gmail.com",
                PhoneNumber = "0274 3755 434",
                Password = HashPassword("doctor#65"),
                Address = "Khoa Sản, Trung tâm Y tế TP. Thuận An",
                CreationDate = new DateTime(2025, 09, 17),
                RoleId = 7,
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Trung tâm Y tế Thành phố Thuận An Doctor (simulated)
            var thuananDoctorId = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = thuananDoctorId,
                UserId = thuananDoctorUserId,
                ClinicId = thuananClinicId,
                Gender = "Female",
                Specialization = "Khám thai / đỡ đẻ",
                Certificate = "Bác sĩ chuyên khoa I – Sản phụ khoa",
                ExperienceYear = 21,
                WorkPosition = "Bác sĩ",
                Description = "Thực hiện dịch vụ khám thai định kỳ, đỡ đẻ, mổ lấy thai tại Trung tâm Y tế TP. Thuận An.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 17)
            });

            // Seed Trung tâm Y tế Thành phố Thuận An Consultant User (simulated)
            var thuananConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = thuananConsultantUserId,
                UserName = "Tư vấn viên Trung Tâm y tế TP. Thuận An",
                Email = "tuvanvientpthuanan@gmail.com",
                PhoneNumber = "0274 3755 434",
                Password = HashPassword("consultant#52"),
                Address = "Khoa Sản, Trung tâm Y tế TP. Thuận An",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Trung tâm Y tế Thành phố Thuận An Consultant (simulated)
            var thuananConsultantId = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = thuananConsultantId,
                UserId = thuananConsultantUserId,
                ClinicId = thuananClinicId,
                Specialization = "Sản phụ khoa / khám thai",
                Certificate = "Bác sĩ chuyên khoa I – Sản phụ khoa",
                Gender = "Female",
                ExperienceYears = 12,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Trung tâm Y tế Thành phố Thuận An Feedbacks
            var thuananFeedback1Id = Guid.NewGuid();
            var thuananFeedback2Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = thuananFeedback1Id,
                    ClinicId = thuananClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 4,
                    Comment = "Khám sản tại Trung tâm Thuận An tương đối tốt, bác sĩ gần gũi, chi phí hợp lý.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = thuananFeedback2Id,
                    ClinicId = thuananClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 4,
                    Comment = "Dịch vụ khám thai ổn, nhưng buổi sáng thường rất đông, chờ lâu.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Trung tâm Y tế TP. Thủ Dầu Một

            // Seed Trung tâm Y tế Thành phố Thủ Dầu Một Clinic User
            var thudaumotClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = thudaumotClinicUserId,
                UserName = "Trung tâm Y tế Thành phố Thủ Dầu Một",
                Email = "ttytethudaumot@gmail.com",
                PhoneNumber = "0274 3822 054",
                Password = HashPassword("clinic#33"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "03 Văn Công Khai, Phú Cường, Thành phố Thủ Dầu Một, tỉnh Bình Dương, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Trung tâm Y tế Thành phố Thủ Dầu Một Clinic
            var thudaumotClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = thudaumotClinicId,
                UserId = thudaumotClinicUserId,
                Address = "03 Văn Công Khai, Phú Cường, Thành phố Thủ Dầu Một, tỉnh Bình Dương, Việt Nam",
                Description = "Trung tâm Y tế Thành phố Thủ Dầu Một là cơ sở y tế công lập tuyến thành phố, cung cấp khám chữa bệnh đa khoa với các chuyên khoa, trong đó có Sản phụ khoa / Khám thai định kỳ. Trung tâm phục vụ dân cư địa phương và vùng lân cận, chấp nhận BHYT. Các dịch vụ sản phụ khoa có lúc bị đông bệnh nhân do nhu cầu lớn.",
                IsInsuranceAccepted = true,
                Specializations = "Khám sản phụ khoa;Khám thai định kỳ;Khám phụ khoa;Siêu âm sản khoa;Chăm sóc sức khỏe sinh sản;Đỡ đẻ / Sinh thường;Phẫu thuật sản phụ khoa cơ bản;Xét nghiệm phụ sản;Khám BHYT;Khám đa khoa nội ngoại",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Trung tâm Y tế Thành phố Thủ Dầu Một Doctor User (simulated)
            var thudaumotDoctorUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = thudaumotDoctorUserId,
                UserName = "Bác si Thủ Dầu Một",
                Email = "bacsithudaumot@gmail.com",
                PhoneNumber = "0274 3822 054",
                Password = HashPassword("doctor#66"),
                Address = "Khoa Sản, Trung tâm Y tế TP. Thủ Dầu Một",
                CreationDate = new DateTime(2025, 09, 17),
                RoleId = 7,
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Trung tâm Y tế Thành phố Thủ Dầu Một Doctor (simulated)
            var thudaumotDoctorId = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = thudaumotDoctorId,
                UserId = thudaumotDoctorUserId,
                ClinicId = thudaumotClinicId,
                Gender = "Female",
                Specialization = "Sinh thường",
                Certificate = "Bác sĩ chuyên khoa I – Sản phụ khoa",
                ExperienceYear = 12,
                WorkPosition = "Bác sĩ",
                Description = "Thực hiện sinh thường, khám thai định kỳ, chăm sóc mẹ và bé.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 17)
            });

            // Seed Trung tâm Y tế Thành phố Thủ Dầu Một Consultant User (simulated)
            var thudaumotConsultantUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = thudaumotConsultantUserId,
                UserName = "Tư vấn viên TDM",
                Email = "tuvanthudaumot@gmail.com",
                PhoneNumber = "0274 3822 054",
                Password = HashPassword("consultant#53"),
                Address = "Khoa Sản, Trung tâm Y tế TP. Thủ Dầu Một",
                RoleId = 6,
                Avatar = null,
                IsDeleted = false,
                IsStaff = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Trung tâm Y tế Thành phố Thủ Dầu Một Consultant (simulated)
            var thudaumotConsultantId = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(new Consultant
            {
                Id = thudaumotConsultantId,
                UserId = thudaumotConsultantUserId,
                ClinicId = thudaumotClinicId,
                Specialization = "Khám thai & tư vấn sản phụ khoa",
                Certificate = "Sản phụ khoa",
                Gender = "Male",
                ExperienceYears = 10,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Trung tâm Y tế Thành phố Thủ Dầu Một Feedback
            var thudaumotFeedback1Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(new Feedback
            {
                Id = thudaumotFeedback1Id,
                ClinicId = thudaumotClinicId,
                UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                Rating = 4,
                Comment = "Trung tâm khám sản phụ khoa gần nhà, tiện lợi; tuy nhiên có lúc chờ lâu.",
                CreationDate = new DateTime(2025, 09, 17)
            });

            // Bệnh viện Đa khoa Đồng Nai

            // Seed Bệnh viện Đa khoa Đồng Nai Clinic User
            var dongnaiClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = dongnaiClinicUserId,
                UserName = "Bệnh viện Đa khoa Đồng Nai",
                Email = "info@benhviendongnai.com.vn",
                PhoneNumber = "0251 896 9966",
                Password = HashPassword("clinic#34"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "Số 2 Đồng Khởi, Phường Tam Hiệp, TP. Biên Hòa, tỉnh Đồng Nai, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Bệnh viện Đa khoa Đồng Nai Clinic
            var dongnaiClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = dongnaiClinicId,
                UserId = dongnaiClinicUserId,
                Address = "Số 2 Đồng Khởi, Phường Tam Hiệp, TP. Biên Hòa, tỉnh Đồng Nai, Việt Nam",
                Description = "Bệnh viện Đa khoa Đồng Nai là bệnh viện đa khoa tuyến tỉnh, với quy mô lớn (~1100 giường bệnh), cung cấp đa dạng các chuyên khoa trong đó có chuyên khoa Phụ sản mạnh, thực hiện khám thai, siêu âm, đỡ sinh, chăm sóc sức khỏe sinh sản cho phụ nữ địa phương. Địa chỉ, khoa Phụ sản, lịch khám & dịch vụ phụ sản đều được công khai từ trang của bệnh viện.",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ;Phụ sản / sản phụ khoa;Khám phụ khoa;Siêu âm sản khoa;Đỡ sinh / sinh thường & sinh mổ;Tư vấn tiền sản;Tầm soát dị tật thai nhi;Phòng kế hoạch hóa gia đình;Khám phụ nữ dịch vụ;Khám bệnh tổng quát & các chuyên khoa phụ trợ",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Bệnh viện Đa khoa Đồng Nai Doctor User (simulated)
            var dongnaiDoctorUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = dongnaiDoctorUserId,
                UserName = "BSCKI Sản phụ khoa Đồng Nai",
                Email = "khoasanbvdkdn@gmail.com",
                PhoneNumber = "0877.39.38.37",
                Password = HashPassword("doctor#67"),
                Address = "Khoa Phụ sản, BV Đa khoa Đồng Nai",
                CreationDate = new DateTime(2025, 09, 17),
                RoleId = 7,
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Bệnh viện Đa khoa Đồng Nai Doctor (simulated)
            var dongnaiDoctorId = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = dongnaiDoctorId,
                UserId = dongnaiDoctorUserId,
                ClinicId = dongnaiClinicId,
                Gender = "Female",
                Specialization = "Siêu âm sản khoa / khám thai",
                Certificate = "BSCKI",
                ExperienceYear = 10,
                WorkPosition = "Bác sĩ sản phụ khoa",
                Description = "Thực hiện siêu âm thai, khám định kỳ và theo dõi thai kỳ nguy cơ cao tại khoa Phụ sản BVĐK Đồng Nai.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 17)
            });

            // Seed Bệnh viện Đa khoa Đồng Nai Consultant Users
            var dongnaiConsultantUser1Id = Guid.NewGuid();
            var dongnaiConsultantUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = dongnaiConsultantUser1Id,
                    UserName = "Thầy thuốc Ưu tú Ths. BS Nguyễn Mạnh Hoan",
                    Email = "khoasanbvdkdn@gmail.com",
                    PhoneNumber = "0877.39.38.37",
                    Password = HashPassword("consultant#54"),
                    Address = "Khoa Phụ sản – BV Đa khoa Đồng Nai, số 2 Đồng Khởi, P. Tam Hòa, Biên Hòa, Đồng Nai",
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
                    UserName = "BSCKII Hoàng Lê Minh Tuấn",
                    Email = "khoasanbvdkdn@gmail.com",
                    PhoneNumber = "0877.39.38.37",
                    Password = HashPassword("consultant#55"),
                    Address = "Khoa Phụ sản – BV Đa khoa Đồng Nai",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Bệnh viện Đa khoa Đồng Nai Consultants
            var dongnaiConsultant1Id = Guid.NewGuid();
            var dongnaiConsultant2Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = dongnaiConsultant1Id,
                    UserId = dongnaiConsultantUser1Id,
                    ClinicId = dongnaiClinicId,
                    Specialization = "Sản phụ khoa / trưởng khoa phụ sản",
                    Certificate = "Ths., Bác sĩ chuyên khoa cao cấp",
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
                    Specialization = "Sản phụ khoa / phó khoa phụ sản",
                    Certificate = "Bác sĩ chuyên khoa II",
                    Gender = "Male",
                    ExperienceYears = 18,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                }
            );

            // Seed Bệnh viện Đa khoa Đồng Nai Feedbacks
            var dongnaiFeedback1Id = Guid.NewGuid();
            var dongnaiFeedback2Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = dongnaiFeedback1Id,
                    ClinicId = dongnaiClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Khoa phụ sản ở Đồng Nai rất mạnh, bác sĩ giàu kinh nghiệm, thiết bị hiện đại; nhưng buổi sáng bệnh nhân đông nên phải chờ lâu.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = dongnaiFeedback2Id,
                    ClinicId = dongnaiClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Dịch vụ sinh tại đây tốt, phòng sanh tương đối trang bị tốt; nhưng thủ tục hành chính cần cải thiện.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Bệnh viện Đa khoa Thống Nhất

            // Seed Bệnh viện Đa khoa Thống Nhất (Đồng Nai) Clinic User
            var thongnhatDNClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = thongnhatDNClinicUserId,
                UserName = "Bệnh viện Đa khoa Thống Nhất (Đồng Nai)",
                Email = "contact@bvthongnhatdn.vn",
                PhoneNumber = "0251 3883 660",
                Password = HashPassword("clinic#35"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "234 Quốc lộ 1A, Phường Tân Biên, Thành phố Biên Hòa, Tỉnh Đồng Nai, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Bệnh viện Đa khoa Thống Nhất (Đồng Nai) Clinic
            var thongnhatDNClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = thongnhatDNClinicId,
                UserId = thongnhatDNClinicUserId,
                Address = "234 Quốc lộ 1A, Phường Tân Biên, Thành phố Biên Hòa, Tỉnh Đồng Nai, Việt Nam",
                Description = "Bệnh viện Đa khoa Thống Nhất là bệnh viện hạng I tuyến tỉnh, với hơn 1.000 giường bệnh, cung cấp đầy đủ các chuyên khoa đa dạng. Khoa Sản có quy mô lớn, thực hiện khám thai, đỡ sinh, sinh thường & sinh mổ, chăm sóc sau sinh, siêu âm sản khoa, hỗ trợ thai phụ và chăm sóc mẹ & bé. Bệnh viện cũng cung cấp dịch vụ khám phụ sản theo yêu cầu.",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ;Sản phụ khoa;Khám phụ khoa;Sinh thường & Sinh mổ;Siêu âm sản khoa;Tư vấn tiền sản;Chăm sóc sản phụ & trẻ sơ sinh;Khám phụ sản dịch vụ;Khám BHYT;Khám bệnh đa khoa",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Bệnh viện Đa khoa Thống Nhất (Đồng Nai) Doctor User (simulated)
            var thongnhatDoctorUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = thongnhatDoctorUserId,
                UserName = "BS sản phụ khoa Thống Nhất",
                Email = "sbsanphukhoathongnhat@gmail.com",
                PhoneNumber = "0251 3886 099",
                Password = HashPassword("doctor#68"),
                Address = "Khoa Sản, Bệnh viện Đa khoa Thống Nhất, Đồng Nai",
                CreationDate = new DateTime(2025, 09, 17),
                RoleId = 7,
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Bệnh viện Đa khoa Thống Nhất (Đồng Nai) Doctor (simulated)
            var thongnhatDoctorId = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = thongnhatDoctorId,
                UserId = thongnhatDoctorUserId,
                ClinicId = thongnhatDNClinicId,
                Gender = "Female",
                Specialization = "Khám thai định kỳ / đỡ sinh",
                Certificate = "Bác sĩ Đa khoa hướng chuyên sản phụ khoa",
                ExperienceYear = 10,
                WorkPosition = "Bác sĩ sản phụ khoa",
                Description = "Thực hiện khám thai, siêu âm sản, đỡ đẻ bình thường và sinh thường cho thai phụ tại phòng Khoa Sản.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 17)
            });

            // Seed Bệnh viện Đa khoa Thống Nhất (Đồng Nai) Consultant Users
            var thongnhatConsultantUser1Id = Guid.NewGuid();
            var thongnhatConsultantUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = thongnhatConsultantUser1Id,
                    UserName = "BSCKI Lý Thị Xuân Lan",
                    Email = "xuanlan@gmail.com",
                    PhoneNumber = "0251 3886 098",
                    Password = HashPassword("consultant#56"),
                    Address = "Khoa Sản, Bệnh viện Đa khoa Thống Nhất, Đồng Nai",
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
                    UserName = "BSCKI Phạm Thanh Dương",
                    Email = "phamthanhduong@gmail.com",
                    PhoneNumber = "0251 3886 098",
                    Password = HashPassword("consultant#57"),
                    Address = "Khoa Sản, Bệnh viện Đa khoa Thống Nhất, Đồng Nai",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Bệnh viện Đa khoa Thống Nhất (Đồng Nai) Consultants
            var thongnhatConsultant1Id = Guid.NewGuid();
            var thongnhatConsultant2Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = thongnhatConsultant1Id,
                    UserId = thongnhatConsultantUser1Id,
                    ClinicId = thongnhatDNClinicId,
                    Specialization = "Phó khoa Sản / Phụ sản theo yêu cầu",
                    Certificate = "Bác sĩ Chuyên khoa I",
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
                    Specialization = "Phó Khoa Sản",
                    Certificate = "Bác sĩ Chuyên khoa I",
                    Gender = "Male",
                    ExperienceYears = 15,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                }
            );

            // Seed Bệnh viện Đa khoa Thống Nhất (Đồng Nai) Feedbacks
            var thongnhatDNFeedback1Id = Guid.NewGuid();
            var thongnhatDNFeedback2Id = Guid.NewGuid();
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    Id = thongnhatDNFeedback1Id,
                    ClinicId = thongnhatDNClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Khoa Sản rất đông, bác sĩ giỏi, dịch vụ khá tốt. Nhưng thời gian chờ đợi khám có thể lâu nếu không đặt trước.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = thongnhatDNFeedback2Id,
                    ClinicId = thongnhatDNClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Sinh mổ tại đây ổn, phòng sinh sạch, phí hợp lý so với các bệnh viện tư.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Bệnh viện Hoàn Mỹ Đồng Nai

            // Seed Bệnh viện Hoàn Mỹ Đồng Nai Clinic User
            var hoanmyDongnaiClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = hoanmyDongnaiClinicUserId,
                UserName = "Bệnh viện Hoàn Mỹ Đồng Nai",
                Email = "contactus.dongnai@hoanmy.com",
                PhoneNumber = "0251 3955 955",
                Password = HashPassword("clinic#36"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "1048A Phạm Văn Thuận, Phường Tam Hiệp, Thành phố Biên Hòa, Tỉnh Đồng Nai, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Bệnh viện Hoàn Mỹ Đồng Nai Clinic
            var hoanmyDongnaiClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = hoanmyDongnaiClinicId,
                UserId = hoanmyDongnaiClinicUserId,
                Address = "1048A Phạm Văn Thuận, Phường Tam Hiệp, Thành phố Biên Hòa, Tỉnh Đồng Nai, Việt Nam",
                Description = "Bệnh viện Hoàn Mỹ Đồng Nai là một bệnh viện đa khoa quốc tế, có chuyên khoa Sản-Phụ khoa được nhiều thai phụ tin tưởng lựa chọn. Với diện tích ~35.000 m2, trang thiết bị hiện đại, dịch vụ khám sản định kỳ, hỗ trợ sinh mổ & sinh thường, tư vấn thai phụ, chăm sóc mẹ & bé. Đội ngũ bác sĩ chuyên môn cao, đáp ứng cả nhu cầu khám theo BHYT & dịch vụ cao cấp.",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ;Sản phụ khoa / khám phụ sản;Khám phụ khoa;Siêu âm sản khoa;Sinh thường & Sinh mổ;Tư vấn tiền sản;Chăm sóc sản phụ & hậu sản;Khám dịch vụ sản phụ khoa;Chẩn đoán hình ảnh;Xét nghiệm phụ sản;Dịch vụ y tế quốc tế",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Bệnh viện Hoàn Mỹ Đồng Nai Doctor User (simulated)
            var hoanmyDongnaiDoctorUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = hoanmyDongnaiDoctorUserId,
                UserName = "BS sản phụ khoa Hoàn Mỹ Đồng Nai",
                Email = "bssanphukhoahoanmydn@gmail.com",
                PhoneNumber = "0251 3955 955",
                Password = HashPassword("doctor#69"),
                Address = "Khoa Sản, Bệnh viện Hoàn Mỹ Đồng Nai",
                CreationDate = new DateTime(2025, 09, 17),
                RoleId = 7,
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Bệnh viện Hoàn Mỹ Đồng Nai Doctor (simulated)
            var hoanmyDongnaiDoctorId = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = hoanmyDongnaiDoctorId,
                UserId = hoanmyDongnaiDoctorUserId,
                ClinicId = hoanmyDongnaiClinicId,
                Gender = "Female",
                Specialization = "Siêu âm sản khoa / khám thai định kỳ",
                Certificate = "Chuyên khoa I",
                ExperienceYear = 10,
                WorkPosition = "Bác sĩ sản phụ khoa",
                Description = "Thực hiện siêu âm thai, khám thai định kỳ cho sản phụ, theo dõi sức khỏe mẹ & bé.",
                IsDeleted = false,
                CreationDate = new DateTime(2025, 09, 17)
            });

            // Seed Bệnh viện Hoàn Mỹ Đồng Nai Consultant Users
            var hoanmyDongnaiConsultantUser1Id = Guid.NewGuid();
            var hoanmyDongnaiConsultantUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = hoanmyDongnaiConsultantUser1Id,
                    UserName = "BS.CKI Nguyễn Thị Kim Nga",
                    Email = "nguyenthikimnga@gmail.com",
                    PhoneNumber = "0251 3955 955",
                    Password = HashPassword("consultant#58"),
                    Address = "Khoa Sản, Bệnh viện Hoàn Mỹ Đồng Nai",
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
                    UserName = "BS Nguyễn Thị Tình",
                    Email = "nguyenthitinh@gmail.com",
                    PhoneNumber = "0251 3955 955",
                    Password = HashPassword("consultant#59"),
                    Address = "Khoa Sản, Bệnh viện Hoàn Mỹ Đồng Nai",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Bệnh viện Hoàn Mỹ Đồng Nai Consultants
            var hoanmyDongnaiConsultant1Id = Guid.NewGuid();
            var hoanmyDongnaiConsultant2Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = hoanmyDongnaiConsultant1Id,
                    UserId = hoanmyDongnaiConsultantUser1Id,
                    ClinicId = hoanmyDongnaiClinicId,
                    Specialization = "Sản phụ khoa / Trưởng khoa Sản phụ",
                    Certificate = "Chuyên khoa I",
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
                    Specialization = "Sản phụ khoa / khám thai & phụ khoa",
                    Certificate = "Thạc sĩ, BS nội trú Sản phụ khoa",
                    Gender = "Female",
                    ExperienceYears = 16,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                }
            );

            // Seed Bệnh viện Hoàn Mỹ Đồng Nai Feedbacks
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
                    Comment = "Khám sản rất chuyên nghiệp, BS Kim Nga nhẹ nhàng, dịch vụ sạch sẽ.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = hoanmyDongnaiFeedback2Id,
                    ClinicId = hoanmyDongnaiClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Chi phí dịch vụ cao hơn bệnh viện công, nhưng tiện nghi & phục vụ rất tốt.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = hoanmyDongnaiFeedback3Id,
                    ClinicId = hoanmyDongnaiClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Sinh mổ tại đây, cảm giác yên tâm vì phòng mổ hiện đại và nhân viên chu đáo.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Bệnh viện Đa khoa khu vực Long Khánh

            // Seed Bệnh viện Đa khoa khu vực Long Khánh Clinic User
            var longkhanhClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = longkhanhClinicUserId,
                UserName = "Bệnh viện Đa khoa khu vực Long Khánh",
                Email = "contact@bvlongkhanh.vn",
                PhoneNumber = "0251 3781 385",
                Password = HashPassword("clinic#37"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "Số 25, đường Hùng Vương, Phường Xuân Trung, TP. Long Khánh, Đồng Nai, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Bệnh viện Đa khoa khu vực Long Khánh Clinic
            var longkhanhClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = longkhanhClinicId,
                UserId = longkhanhClinicUserId,
                Address = "Số 25, đường Hùng Vương, Phường Xuân Trung, TP. Long Khánh, Đồng Nai, Việt Nam",
                Description = "Bệnh viện Đa khoa khu vực Long Khánh là bệnh viện hạng II trực thuộc Sở Y tế Đồng Nai, phục vụ chăm sóc sức khỏe cho người dân TP. Long Khánh và khu vực lân cận. Trong đó, khoa Sản phụ khoa là một trong những khoa trọng điểm, cung cấp các dịch vụ khám thai, quản lý thai kỳ, sinh thường, sinh mổ, chăm sóc sau sinh và xử trí các bệnh lý phụ khoa.",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ;Quản lý thai kỳ nguy cơ cao;Siêu âm thai;Sinh thường & Sinh mổ;Khám phụ khoa;Điều trị bệnh lý phụ khoa;Kế hoạch hóa gia đình;Chăm sóc sơ sinh",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Bệnh viện Đa khoa khu vực Long Khánh Doctor Users
            var longkhanhDoctorUser1Id = Guid.NewGuid();
            var longkhanhDoctorUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = longkhanhDoctorUser1Id,
                    UserName = "BSCKII Phạm Thị Hồng",
                    Email = "phamthihong@gmail.com",
                    PhoneNumber = "0251 3781 385",
                    Password = HashPassword("doctor#70"),
                    Address = "Khoa Sản – BV ĐKKV Long Khánh",
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
                    UserName = "BSCKI Nguyễn Văn Bình",
                    Email = "nguyenvanbinh@gmail.com",
                    PhoneNumber = "0251 3781 385",
                    Password = HashPassword("doctor#71"),
                    Address = "Khoa Sản – BV ĐKKV Long Khánh",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Bệnh viện Đa khoa khu vực Long Khánh Doctors
            var longkhanhDoctor1Id = Guid.NewGuid();
            var longkhanhDoctor2Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = longkhanhDoctor1Id,
                    UserId = longkhanhDoctorUser1Id,
                    ClinicId = longkhanhClinicId,
                    Gender = "Female",
                    Specialization = "Sản phụ khoa",
                    Certificate = "Bác sĩ chuyên khoa II – Sản",
                    ExperienceYear = 20,
                    WorkPosition = "Trưởng khoa Sản phụ khoa",
                    Description = "Chuyên về theo dõi thai kỳ, đỡ sinh thường và sinh mổ, xử trí sản phụ nguy cơ cao.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = longkhanhDoctor2Id,
                    UserId = longkhanhDoctorUser2Id,
                    ClinicId = longkhanhClinicId,
                    Gender = "Male",
                    Specialization = "Sản phụ khoa",
                    Certificate = "Bác sĩ chuyên khoa I – Sản phụ khoa",
                    ExperienceYear = 10,
                    WorkPosition = "Bác sĩ điều trị",
                    Description = "Khám thai định kỳ, siêu âm, chẩn đoán và điều trị bệnh lý phụ khoa.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Seed Bệnh viện Đa khoa khu vực Long Khánh Consultant Users
            var longkhanhConsultantUser1Id = Guid.NewGuid();
            var longkhanhConsultantUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = longkhanhConsultantUser1Id,
                    UserName = "BSCKI Nguyễn Thị Lan",
                    Email = "nguyenthilan@gmail.com",
                    PhoneNumber = "0251 3781 385",
                    Password = HashPassword("consultant#60"),
                    Address = "Khoa Sản phụ khoa – BV ĐKKV Long Khánh",
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
                    UserName = "ThS.BS Trần Văn Hùng",
                    Email = "tranvanhung@gmail.com",
                    PhoneNumber = "0251 3781 385",
                    Password = HashPassword("consultant#61"),
                    Address = "Khoa Sản phụ khoa – BV ĐKKV Long Khánh",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Bệnh viện Đa khoa khu vực Long Khánh Consultants
            var longkhanhConsultant1Id = Guid.NewGuid();
            var longkhanhConsultant2Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = longkhanhConsultant1Id,
                    UserId = longkhanhConsultantUser1Id,
                    ClinicId = longkhanhClinicId,
                    Specialization = "Tư vấn thai kỳ & sức khỏe sinh sản",
                    Certificate = "Bác sĩ chuyên khoa I – Sản phụ khoa",
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
                    Specialization = "Tư vấn thai sản & bệnh lý sản khoa",
                    Certificate = "Thạc sĩ Y học – Sản phụ khoa",
                    Gender = "Male",
                    ExperienceYears = 12,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                }
            );

            // Seed Bệnh viện Đa khoa khu vực Long Khánh Feedbacks
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
                    Comment = "Bác sĩ sản khoa ở đây khá tận tâm, nhưng đôi khi phải chờ đợi lâu do bệnh nhân đông.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = longkhanhFeedback2Id,
                    ClinicId = longkhanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Khám thai chu đáo, có hướng dẫn chi tiết cho sản phụ, đặc biệt đối với thai kỳ nguy cơ cao.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = longkhanhFeedback3Id,
                    ClinicId = longkhanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Cơ sở vật chất tương đối ổn, nhưng phòng chờ đôi khi đông đúc.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Bệnh viện Đa khoa khu vực Trảng Bom

            // Seed Bệnh viện Đa khoa khu vực Trảng Bom Clinic User
            var trangbomClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = trangbomClinicUserId,
                UserName = "Bệnh viện Đa khoa khu vực Trảng Bom",
                Email = "contact@bvtrangbom.vn",
                PhoneNumber = "0251 3867 115",
                Password = HashPassword("clinic#38"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "Đường 3/2, Khu phố 3, Thị trấn Trảng Bom, Huyện Trảng Bom, Đồng Nai, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Bệnh viện Đa khoa khu vực Trảng Bom Clinic
            var trangbomClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = trangbomClinicId,
                UserId = trangbomClinicUserId,
                Address = "Đường 3/2, Khu phố 3, Thị trấn Trảng Bom, Huyện Trảng Bom, Đồng Nai, Việt Nam",
                Description = "Bệnh viện Đa khoa khu vực Trảng Bom là bệnh viện hạng II trực thuộc Sở Y tế Đồng Nai, cung cấp dịch vụ khám chữa bệnh cho người dân huyện Trảng Bom và vùng phụ cận. Trong đó, khoa Sản phụ khoa đảm nhiệm công tác chăm sóc thai sản, quản lý thai kỳ, sinh thường, sinh mổ, chăm sóc sau sinh và xử trí các bệnh lý sản phụ khoa.",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ;Siêu âm thai;Theo dõi thai kỳ nguy cơ cao;Sinh thường & Sinh mổ;Khám và điều trị bệnh phụ khoa;Kế hoạch hóa gia đình;Chăm sóc sơ sinh",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Bệnh viện Đa khoa khu vực Trảng Bom Doctor Users
            var trangbomDoctorUser1Id = Guid.NewGuid();
            var trangbomDoctorUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = trangbomDoctorUser1Id,
                    UserName = "BSCKII Phạm Thị Mai",
                    Email = "phamthimai@gmail.com",
                    PhoneNumber = "0251 3867 115",
                    Password = HashPassword("doctor#72"),
                    Address = "Khoa Sản – BV ĐKKV Trảng Bom",
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
                    UserName = "BSCKI Nguyễn Văn Hòa",
                    Email = "nguyenvanhoa@gmail.com",
                    PhoneNumber = "0251 3867 115",
                    Password = HashPassword("doctor#73"),
                    Address = "Khoa Sản – BV ĐKKV Trảng Bom",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Bệnh viện Đa khoa khu vực Trảng Bom Doctors
            var trangbomDoctor1Id = Guid.NewGuid();
            var trangbomDoctor2Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = trangbomDoctor1Id,
                    UserId = trangbomDoctorUser1Id,
                    ClinicId = trangbomClinicId,
                    Gender = "Female",
                    Specialization = "Sản phụ khoa",
                    Certificate = "Bác sĩ chuyên khoa II – Sản phụ khoa",
                    ExperienceYear = 18,
                    WorkPosition = "Trưởng khoa Sản phụ khoa",
                    Description = "Chuyên sâu về quản lý thai kỳ nguy cơ cao, đỡ sinh và phẫu thuật sản khoa.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = trangbomDoctor2Id,
                    UserId = trangbomDoctorUser2Id,
                    ClinicId = trangbomClinicId,
                    Gender = "Male",
                    Specialization = "Sản phụ khoa",
                    Certificate = "Bác sĩ chuyên khoa I – Sản phụ khoa",
                    ExperienceYear = 9,
                    WorkPosition = "Bác sĩ điều trị",
                    Description = "Khám thai định kỳ, siêu âm, tư vấn và điều trị các bệnh lý phụ khoa thông thường.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Seed Bệnh viện Đa khoa khu vực Trảng Bom Consultant Users
            var trangbomConsultantUser1Id = Guid.NewGuid();
            var trangbomConsultantUser2Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = trangbomConsultantUser1Id,
                    UserName = "BSCKI Lê Thị Thu",
                    Email = "lethithu@gmail.com",
                    PhoneNumber = "0251 3867 115",
                    Password = HashPassword("consultant#62"),
                    Address = "Khoa Sản phụ khoa – BV ĐKKV Trảng Bom",
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
                    UserName = "ThS.BS Nguyễn Văn An",
                    Email = "nguyenvanan@gmail.com",
                    PhoneNumber = "0251 3867 115",
                    Password = HashPassword("consultant#63"),
                    Address = "Khoa Sản phụ khoa – BV ĐKKV Trảng Bom",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Bệnh viện Đa khoa khu vực Trảng Bom Consultants
            var trangbomConsultant1Id = Guid.NewGuid();
            var trangbomConsultant2Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = trangbomConsultant1Id,
                    UserId = trangbomConsultantUser1Id,
                    ClinicId = trangbomClinicId,
                    Specialization = "Tư vấn thai kỳ & kế hoạch hóa gia đình",
                    Certificate = "Bác sĩ chuyên khoa I – Sản phụ khoa",
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
                    Specialization = "Tư vấn thai sản, bệnh lý phụ khoa",
                    Certificate = "Thạc sĩ Y học – Sản phụ khoa",
                    Gender = "Male",
                    ExperienceYears = 11,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                }
            );

            // Seed Bệnh viện Đa khoa khu vực Trảng Bom Feedbacks
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
                    Comment = "Bác sĩ sản khoa tận tâm, hướng dẫn chu đáo cho sản phụ lần đầu mang thai.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = trangbomFeedback2Id,
                    ClinicId = trangbomClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Dịch vụ khám thai khá tốt, có siêu âm 4D, tuy nhiên phải chờ hơi lâu.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = trangbomFeedback3Id,
                    ClinicId = trangbomClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Cơ sở vật chất tạm ổn, phù hợp với tuyến huyện, bác sĩ dễ gần.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Trung tâm Y tế Huyện Nhơn Trạch

            // Seed Trung tâm Y tế Huyện Nhơn Trạch Clinic User
            var nhontrachClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = nhontrachClinicUserId,
                UserName = "Trung tâm Y tế Huyện Nhơn Trạch",
                Email = "contact@ttyt-nhontrach.vn",
                PhoneNumber = "0251 3561 115",
                Password = HashPassword("clinic#39"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "Thị trấn Hiệp Phước, Huyện Nhơn Trạch, Đồng Nai, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Trung tâm Y tế Huyện Nhơn Trạch Clinic
            var nhontrachClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = nhontrachClinicId,
                UserId = nhontrachClinicUserId,
                Address = "Thị trấn Hiệp Phước, Huyện Nhơn Trạch, Đồng Nai, Việt Nam",
                Description = "Trung tâm Y tế Huyện Nhơn Trạch là cơ sở y tế hạng II trực thuộc Sở Y tế Đồng Nai, chịu trách nhiệm khám chữa bệnh đa khoa cho người dân địa phương. Trong đó, khoa Sản phụ khoa cung cấp dịch vụ quản lý thai kỳ, siêu âm, khám và điều trị bệnh lý phụ khoa, đỡ sinh, phẫu thuật sản khoa và tư vấn kế hoạch hóa gia đình.",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ;Siêu âm 2D/4D;Theo dõi thai kỳ nguy cơ cao;Khám & điều trị bệnh phụ khoa;Đỡ sinh thường;Sinh mổ;Tư vấn kế hoạch hóa gia đình;Chăm sóc sơ sinh",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Trung tâm Y tế Huyện Nhơn Trạch Doctor Users
            var nhontrachDoctorUser1Id = Guid.NewGuid();
            var nhontrachDoctorUser2Id = Guid.NewGuid();
            var nhontrachDoctorUser3Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = nhontrachDoctorUser1Id,
                    UserName = "BSCKII Phạm Thị Ngọc",
                    Email = "phamthingoc@gmail.com",
                    PhoneNumber = "0251 3561 115",
                    Password = HashPassword("doctor#74"),
                    Address = "Khoa Sản – TTYT Nhơn Trạch",
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
                    UserName = "BSCKI Lê Văn Minh",
                    Email = "levanminh@gmail.com",
                    PhoneNumber = "0251 3561 115",
                    Password = HashPassword("doctor#75"),
                    Address = "Khoa Sản – TTYT Nhơn Trạch",
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
                    UserName = "BSCKI Nguyễn Thị Mai",
                    Email = "nguyenthimai@gmail.com",
                    PhoneNumber = "0251 3561 115",
                    Password = HashPassword("doctor#76"),
                    Address = "Khoa Sản – TTYT Nhơn Trạch",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Trung tâm Y tế Huyện Nhơn Trạch Doctors
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
                    Specialization = "Sản phụ khoa",
                    Certificate = "Bác sĩ chuyên khoa II – Sản phụ khoa",
                    ExperienceYear = 20,
                    WorkPosition = "Trưởng khoa Sản phụ khoa",
                    Description = "Chuyên về quản lý thai kỳ nguy cơ cao, xử trí các ca sinh khó, phẫu thuật sản phụ khoa.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = nhontrachDoctor2Id,
                    UserId = nhontrachDoctorUser2Id,
                    ClinicId = nhontrachClinicId,
                    Gender = "Male",
                    Specialization = "Sản phụ khoa",
                    Certificate = "Bác sĩ chuyên khoa I – Sản phụ khoa",
                    ExperienceYear = 12,
                    WorkPosition = "Bác sĩ điều trị",
                    Description = "Khám thai định kỳ, siêu âm thai, tư vấn sinh thường và sinh mổ.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = nhontrachDoctor3Id,
                    UserId = nhontrachDoctorUser3Id,
                    ClinicId = nhontrachClinicId,
                    Gender = "Female",
                    Specialization = "Sản phụ khoa",
                    Certificate = "Bác sĩ chuyên khoa I – Sản phụ khoa",
                    ExperienceYear = 9,
                    WorkPosition = "Bác sĩ điều trị",
                    Description = "Khám phụ khoa, tư vấn tiền sản, theo dõi sau sinh.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Seed Trung tâm Y tế Huyện Nhơn Trạch Consultant Users
            var nhontrachConsultantUser1Id = Guid.NewGuid();
            var nhontrachConsultantUser2Id = Guid.NewGuid();
            var nhontrachConsultantUser3Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = nhontrachConsultantUser1Id,
                    UserName = "BSCKI Trần Thị Hồng",
                    Email = "tranthihong@gmail.com",
                    PhoneNumber = "0251 3561 115",
                    Password = HashPassword("consultant#64"),
                    Address = "Khoa Sản – TTYT Nhơn Trạch",
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
                    UserName = "ThS.BS Nguyễn Văn Dũng",
                    Email = "nguyenvandung@gmail.com",
                    PhoneNumber = "0251 3561 115",
                    Password = HashPassword("consultant#65"),
                    Address = "Khoa Sản – TTYT Nhơn Trạch",
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
                    UserName = "CNHS Lê Thị Lan",
                    Email = "lethilan@gmail.com",
                    PhoneNumber = "0251 3561 115",
                    Password = HashPassword("consultant#66"),
                    Address = "Phòng tư vấn – TTYT Nhơn Trạch",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Trung tâm Y tế Huyện Nhơn Trạch Consultants
            var nhontrachConsultant1Id = Guid.NewGuid();
            var nhontrachConsultant2Id = Guid.NewGuid();
            var nhontrachConsultant3Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = nhontrachConsultant1Id,
                    UserId = nhontrachConsultantUser1Id,
                    ClinicId = nhontrachClinicId,
                    Specialization = "Tư vấn thai kỳ & chăm sóc trước sinh",
                    Certificate = "Bác sĩ chuyên khoa I – Sản phụ khoa",
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
                    Specialization = "Tư vấn bệnh lý phụ khoa, kế hoạch hóa",
                    Certificate = "Thạc sĩ Y học – Sản phụ khoa",
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
                    Specialization = "Điều dưỡng hộ sinh, tư vấn thai sản",
                    Certificate = "Cử nhân Hộ sinh",
                    Gender = "Female",
                    ExperienceYears = 8,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                }
            );

            // Seed Trung tâm Y tế Huyện Nhơn Trạch Feedbacks
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
                    Comment = "Bác sĩ tư vấn kỹ càng, giải thích rõ ràng cho sản phụ.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = nhontrachFeedback2Id,
                    ClinicId = nhontrachClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Khám thai nhanh chóng, nhưng cơ sở vật chất cần nâng cấp thêm.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = nhontrachFeedback3Id,
                    ClinicId = nhontrachClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Điều dưỡng hộ sinh rất nhiệt tình, hướng dẫn chi tiết cách chăm sóc mẹ và bé.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = nhontrachFeedback4Id,
                    ClinicId = nhontrachClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Có hỗ trợ BHYT đầy đủ, nhưng đôi lúc đông bệnh nhân phải chờ khá lâu.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Trung tâm Y tế Huyện Vĩnh Cửu

            // Seed Trung tâm Y tế Huyện Vĩnh Cửu Clinic User
            var vinhcuuClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = vinhcuuClinicUserId,
                UserName = "Trung tâm Y tế Huyện Vĩnh Cửu",
                Email = "contact@ttyt-vinhcuu.vn",
                PhoneNumber = "0251 3860 234",
                Password = HashPassword("clinic#40"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "Thị trấn Vĩnh An, Huyện Vĩnh Cửu, Đồng Nai, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Trung tâm Y tế Huyện Vĩnh Cửu Clinic
            var vinhcuuClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = vinhcuuClinicId,
                UserId = vinhcuuClinicUserId,
                Address = "Thị trấn Vĩnh An, Huyện Vĩnh Cửu, Đồng Nai, Việt Nam",
                Description = "Trung tâm Y tế Huyện Vĩnh Cửu là cơ sở y tế tuyến huyện trực thuộc Sở Y tế Đồng Nai, đảm nhiệm công tác khám chữa bệnh đa khoa và chăm sóc sức khỏe sinh sản. Khoa Sản phụ khoa cung cấp dịch vụ khám thai định kỳ, siêu âm, quản lý thai kỳ nguy cơ cao, khám phụ khoa, tư vấn kế hoạch hóa gia đình và chăm sóc sơ sinh.",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ;Siêu âm thai 2D/4D;Theo dõi và quản lý thai kỳ nguy cơ cao;Khám & điều trị bệnh lý phụ khoa;Đỡ sinh thường;Sinh mổ;Khám sau sinh;Tư vấn kế hoạch hóa gia đình;Chăm sóc sơ sinh",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Trung tâm Y tế Huyện Vĩnh Cửu Doctor Users
            var vinhcuuDoctorUser1Id = Guid.NewGuid();
            var vinhcuuDoctorUser2Id = Guid.NewGuid();
            var vinhcuuDoctorUser3Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = vinhcuuDoctorUser1Id,
                    UserName = "BSCKII Phạm Thị Lan",
                    Email = "phamthilan@gmail.com",
                    PhoneNumber = "0251 3860 234",
                    Password = HashPassword("doctor#77"),
                    Address = "Khoa Sản – TTYT Vĩnh Cửu",
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
                    UserName = "BSCKI Nguyễn Văn Hùng",
                    Email = "nguyenvanhung@gmail.com",
                    PhoneNumber = "0251 3860 234",
                    Password = HashPassword("doctor#78"),
                    Address = "Khoa Sản – TTYT Vĩnh Cửu",
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
                    UserName = "BSCKI Trần Thị Kim Oanh",
                    Email = "kimoanh@gmail.com",
                    PhoneNumber = "0251 3860 234",
                    Password = HashPassword("doctor#79"),
                    Address = "Khoa Sản – TTYT Vĩnh Cửu",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Trung tâm Y tế Huyện Vĩnh Cửu Doctors
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
                    Specialization = "Sản phụ khoa",
                    Certificate = "Bác sĩ chuyên khoa II – Sản phụ khoa",
                    ExperienceYear = 18,
                    WorkPosition = "Trưởng khoa Sản phụ khoa",
                    Description = "Quản lý thai kỳ nguy cơ cao, phẫu thuật sản khoa, xử trí các ca sinh khó.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = vinhcuuDoctor2Id,
                    UserId = vinhcuuDoctorUser2Id,
                    ClinicId = vinhcuuClinicId,
                    Gender = "Male",
                    Specialization = "Sản phụ khoa",
                    Certificate = "Bác sĩ chuyên khoa I – Sản phụ khoa",
                    ExperienceYear = 12,
                    WorkPosition = "Bác sĩ điều trị",
                    Description = "Khám thai định kỳ, siêu âm, tư vấn sinh thường và sinh mổ.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = vinhcuuDoctor3Id,
                    UserId = vinhcuuDoctorUser3Id,
                    ClinicId = vinhcuuClinicId,
                    Gender = "Female",
                    Specialization = "Sản phụ khoa",
                    Certificate = "Bác sĩ chuyên khoa I – Sản phụ khoa",
                    ExperienceYear = 8,
                    WorkPosition = "Bác sĩ điều trị",
                    Description = "Khám phụ khoa, tư vấn tiền sản, chăm sóc mẹ và bé sau sinh.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Seed Trung tâm Y tế Huyện Vĩnh Cửu Consultant Users
            var vinhcuuConsultantUser1Id = Guid.NewGuid();
            var vinhcuuConsultantUser2Id = Guid.NewGuid();
            var vinhcuuConsultantUser3Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = vinhcuuConsultantUser1Id,
                    UserName = "BSCKI Nguyễn Thị Hạnh",
                    Email = "nguyenthihanh@gmail.com",
                    PhoneNumber = "0251 3860 234",
                    Password = HashPassword("consultant#67"),
                    Address = "Khoa Sản – TTYT Vĩnh Cửu",
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
                    UserName = "BSCKI Lê Minh Quang",
                    Email = "leminhquang@gmail.com",
                    PhoneNumber = "0251 3860 234",
                    Password = HashPassword("consultant#68"),
                    Address = "Khoa Sản – TTYT Vĩnh Cửu",
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
                    UserName = "CNHS Trần Thu Thảo",
                    Email = "tranthuthao@gmail.com",
                    PhoneNumber = "0251 3860 234",
                    Password = HashPassword("consultant#69"),
                    Address = "Phòng tư vấn – TTYT Vĩnh Cửu",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Trung tâm Y tế Huyện Vĩnh Cửu Consultants
            var vinhcuuConsultant1Id = Guid.NewGuid();
            var vinhcuuConsultant2Id = Guid.NewGuid();
            var vinhcuuConsultant3Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = vinhcuuConsultant1Id,
                    UserId = vinhcuuConsultantUser1Id,
                    ClinicId = vinhcuuClinicId,
                    Specialization = "Tư vấn thai kỳ & chăm sóc trước sinh",
                    Certificate = "Bác sĩ chuyên khoa I – Sản phụ khoa",
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
                    Specialization = "Tư vấn bệnh phụ khoa, kế hoạch hóa",
                    Certificate = "Bác sĩ chuyên khoa I – Sản phụ khoa",
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
                    Specialization = "Điều dưỡng hộ sinh",
                    Certificate = "Cử nhân Hộ sinh",
                    Gender = "Female",
                    ExperienceYears = 9,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                }
            );

            // Seed Trung tâm Y tế Huyện Vĩnh Cửu Feedbacks
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
                    Comment = "Bác sĩ tận tình, tư vấn kỹ lưỡng cho sản phụ.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = vinhcuuFeedback2Id,
                    ClinicId = vinhcuuClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Khám thai nhanh, có bảo hiểm y tế hỗ trợ đầy đủ.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = vinhcuuFeedback3Id,
                    ClinicId = vinhcuuClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Điều dưỡng và hộ sinh rất chu đáo, hướng dẫn chăm sóc sau sinh chi tiết.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = vinhcuuFeedback4Id,
                    ClinicId = vinhcuuClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Đôi lúc bệnh nhân đông phải chờ lâu, nhưng chất lượng khám ổn định.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Trung tâm Y tế Huyện Long Thành

            // Seed Trung tâm Y tế Huyện Long Thành Clinic User
            var longthanhClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = longthanhClinicUserId,
                UserName = "Trung tâm Y tế Huyện Long Thành",
                Email = "contact@ttyt-longthanh.vn",
                PhoneNumber = "0251 3843 567",
                Password = HashPassword("clinic#41"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "Thị trấn Long Thành, Huyện Long Thành, Đồng Nai, Việt Nam",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Trung tâm Y tế Huyện Long Thành Clinic
            var longthanhClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = longthanhClinicId,
                UserId = longthanhClinicUserId,
                Address = "Thị trấn Long Thành, Huyện Long Thành, Đồng Nai, Việt Nam",
                Description = "Trung tâm Y tế Huyện Long Thành là đơn vị y tế tuyến huyện trực thuộc Sở Y tế Đồng Nai, có nhiệm vụ chăm sóc sức khỏe toàn diện cho người dân. Khoa Sản phụ khoa cung cấp dịch vụ khám thai định kỳ, siêu âm, quản lý thai kỳ, khám phụ khoa, tư vấn kế hoạch hóa gia đình và chăm sóc mẹ - bé sau sinh.",
                IsInsuranceAccepted = true,
                Specializations = "Khám thai định kỳ;Siêu âm thai 2D/4D;Quản lý thai kỳ nguy cơ cao;Khám và điều trị bệnh lý phụ khoa;Đỡ sinh thường;Sinh mổ;Khám sau sinh;Tư vấn tiền sản và hậu sản;Kế hoạch hóa gia đình",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Trung tâm Y tế Huyện Long Thành Doctor Users
            var longthanhDoctorUser1Id = Guid.NewGuid();
            var longthanhDoctorUser2Id = Guid.NewGuid();
            var longthanhDoctorUser3Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = longthanhDoctorUser1Id,
                    UserName = "BSCKII Lê Thị Mai",
                    Email = "lethimai@gmail.com",
                    PhoneNumber = "0251 3843 567",
                    Password = HashPassword("doctor#80"),
                    Address = "Khoa Sản – TTYT Long Thành",
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
                    UserName = "BSCKI Nguyễn Văn Toàn",
                    Email = "nguyenvantoan@gmail.com",
                    PhoneNumber = "0251 3843 567",
                    Password = HashPassword("doctor#81"),
                    Address = "Khoa Sản – TTYT Long Thành",
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
                    UserName = "BSCKI Võ Thị Hồng",
                    Email = "vothihong@gmail.com",
                    PhoneNumber = "0251 3843 567",
                    Password = HashPassword("doctor#82"),
                    Address = "Khoa Sản – TTYT Long Thành",
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    Avatar = null,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Trung tâm Y tế Huyện Long Thành Doctors
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
                    Specialization = "Sản phụ khoa",
                    Certificate = "Bác sĩ chuyên khoa II – Sản phụ khoa",
                    ExperienceYear = 20,
                    WorkPosition = "Trưởng khoa Sản phụ khoa",
                    Description = "Quản lý thai kỳ nguy cơ cao, phẫu thuật sản khoa, đào tạo và hướng dẫn chuyên môn.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = longthanhDoctor2Id,
                    UserId = longthanhDoctorUser2Id,
                    ClinicId = longthanhClinicId,
                    Gender = "Male",
                    Specialization = "Sản phụ khoa",
                    Certificate = "Bác sĩ chuyên khoa I – Sản phụ khoa",
                    ExperienceYear = 10,
                    WorkPosition = "Bác sĩ điều trị",
                    Description = "Khám thai định kỳ, siêu âm, tư vấn sinh thường và sinh mổ.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = longthanhDoctor3Id,
                    UserId = longthanhDoctorUser3Id,
                    ClinicId = longthanhClinicId,
                    Gender = "Female",
                    Specialization = "Sản phụ khoa",
                    Certificate = "Bác sĩ chuyên khoa I – Sản phụ khoa",
                    ExperienceYear = 8,
                    WorkPosition = "Bác sĩ điều trị",
                    Description = "Khám phụ khoa, tư vấn tiền sản, chăm sóc mẹ và bé sau sinh.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Seed Trung tâm Y tế Huyện Long Thành Consultant Users
            var longthanhConsultantUser1Id = Guid.NewGuid();
            var longthanhConsultantUser2Id = Guid.NewGuid();
            var longthanhConsultantUser3Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = longthanhConsultantUser1Id,
                    UserName = "BSCKI Nguyễn Thị Hòa",
                    Email = "nguyenthihoa@gmail.com",
                    PhoneNumber = "0251 3843 567",
                    Password = HashPassword("consultant#70"),
                    Address = "Khoa Sản – TTYT Long Thành",
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
                    UserName = "BSCKI Trần Minh Khôi",
                    Email = "tranminhkhoi@gmail.com",
                    PhoneNumber = "0251 3843 567",
                    Password = HashPassword("consultant#71"),
                    Address = "Khoa Sản – TTYT Long Thành",
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
                    UserName = "CNHS Phạm Thị Thu",
                    Email = "phamthithu@gmailLt.com",
                    PhoneNumber = "0251 3843 567",
                    Password = HashPassword("consultant#72"),
                    Address = "Phòng tư vấn – TTYT Long Thành",
                    RoleId = 6,
                    Avatar = null,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Trung tâm Y tế Huyện Long Thành Consultants
            var longthanhConsultant1Id = Guid.NewGuid();
            var longthanhConsultant2Id = Guid.NewGuid();
            var longthanhConsultant3Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = longthanhConsultant1Id,
                    UserId = longthanhConsultantUser1Id,
                    ClinicId = longthanhClinicId,
                    Specialization = "Khám thai & quản lý sản phụ",
                    Certificate = "Bác sĩ chuyên khoa I – Sản phụ khoa",
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
                    Specialization = "Khám phụ khoa & kế hoạch hóa",
                    Certificate = "Bác sĩ chuyên khoa I – Sản phụ khoa",
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
                    Specialization = "Hộ sinh – tư vấn tiền sản",
                    Certificate = "Cử nhân Hộ sinh",
                    Gender = "Female",
                    ExperienceYears = 9,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                }
            );

            // Seed Trung tâm Y tế Huyện Long Thành Feedbacks
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
                    Comment = "Bác sĩ và điều dưỡng tận tâm, tư vấn kỹ lưỡng cho sản phụ.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = longthanhFeedback2Id,
                    ClinicId = longthanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Có bảo hiểm y tế, thủ tục tương đối nhanh chóng.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = longthanhFeedback3Id,
                    ClinicId = longthanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 9,
                    Comment = "Chăm sóc mẹ và bé sau sinh chu đáo, hộ sinh rất nhiệt tình.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = longthanhFeedback4Id,
                    ClinicId = longthanhClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Lúc cao điểm hơi đông bệnh nhân, nhưng dịch vụ vẫn đảm bảo.",
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Trung tâm Y tế Huyện Xuân Lộc

            // Seed Trung tâm Y tế Huyện Xuân Lộc Clinic User
            var xuanlocClinicUserId = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = xuanlocClinicUserId,
                UserName = "Trung tâm Y tế Huyện Xuân Lộc",
                Email = "contact@ttytxuanloc.vn",
                PhoneNumber = "0251 3874 567",
                Password = HashPassword("clinic#42"),
                Balance = 0,
                RoleId = 5,
                CreationDate = new DateTime(2025, 09, 17),
                Address = "Số 45, đường Nguyễn Huệ, thị trấn Gia Ray, huyện Xuân Lộc, tỉnh Đồng Nai",
                Avatar = null,
                IsDeleted = false,
                IsVerified = true,
                Status = Domain.Enums.StatusEnums.Active
            });

            // Seed Trung tâm Y tế Huyện Xuân Lộc Clinic
            var xuanlocClinicId = Guid.NewGuid();
            modelBuilder.Entity<Clinic>().HasData(new Clinic
            {
                Id = xuanlocClinicId,
                UserId = xuanlocClinicUserId,
                Address = "Số 45, đường Nguyễn Huệ, thị trấn Gia Ray, huyện Xuân Lộc, tỉnh Đồng Nai",
                Description = "Trung tâm Y tế Huyện Xuân Lộc là đơn vị y tế công lập tuyến huyện, cung cấp dịch vụ khám chữa bệnh đa khoa, sản phụ khoa và nhi khoa. Trung tâm đặc biệt chú trọng đến công tác chăm sóc sức khỏe bà mẹ và trẻ em với đội ngũ y bác sĩ giàu kinh nghiệm.",
                IsInsuranceAccepted = true,
                Specializations = "Sản khoa;Nhi khoa;Khám thai định kỳ;Siêu âm thai;Tư vấn dinh dưỡng thai kỳ;Khám phụ khoa",
                IsActive = true,
                CreationDate = new DateTime(2025, 09, 17),
                IsDeleted = false
            });

            // Seed Trung tâm Y tế Huyện Xuân Lộc Doctor Users
            var xuanlocDoctorUser1Id = Guid.NewGuid();
            var xuanlocDoctorUser2Id = Guid.NewGuid();
            var xuanlocDoctorUser3Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = xuanlocDoctorUser1Id,
                    UserName = "Nguyễn Hương Giang",
                    Email = "huonggiang.doctor@ttytxuanloc.vn",
                    PhoneNumber = "0909123456",
                    Password = HashPassword("doctor#83"),
                    Address = "Gia Ray, Xuân Lộc, Đồng Nai",
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
                    UserName = "Trần Minh Tâm",
                    Email = "minhtam.doctor@ttytxuanloc.vn",
                    PhoneNumber = "0978123456",
                    Password = HashPassword("doctor#84"),
                    Address = "Xuân Bắc, Xuân Lộc, Đồng Nai",
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
                    UserName = "Phạm Liên Anh",
                    Email = "lienanh.doctor@ttytxuanloc.vn",
                    PhoneNumber = "0967543210",
                    Password = HashPassword("doctor#85"),
                    Address = "Xuân Thọ, Xuân Lộc, Đồng Nai",
                    Avatar = null,
                    CreationDate = new DateTime(2025, 09, 17),
                    RoleId = 7,
                    IsDeleted = false,
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Trung tâm Y tế Huyện Xuân Lộc Doctors
            var xuanlocDoctor1Id = Guid.NewGuid();
            var xuanlocDoctor2Id = Guid.NewGuid();
            var xuanlocDoctor3Id = Guid.NewGuid();
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = xuanlocDoctor1Id,
                    UserId = xuanlocDoctorUser1Id,
                    ClinicId = xuanlocClinicId,
                    Gender = "Nữ",
                    Specialization = "Sản khoa",
                    Certificate = "Bác sĩ CKI Sản phụ khoa",
                    ExperienceYear = 18,
                    WorkPosition = "Trưởng khoa Sản",
                    Description = "Bác sĩ chuyên sâu về khám thai định kỳ, siêu âm thai và xử lý các ca sản khoa phức tạp.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = xuanlocDoctor2Id,
                    UserId = xuanlocDoctorUser2Id,
                    ClinicId = xuanlocClinicId,
                    Gender = "Nam",
                    Specialization = "Nhi khoa",
                    Certificate = "Bác sĩ CKI Nhi khoa",
                    ExperienceYear = 12,
                    WorkPosition = "Bác sĩ điều trị Nhi",
                    Description = "Chuyên theo dõi và chăm sóc sức khỏe trẻ sơ sinh, đặc biệt là con của các thai phụ sau sinh.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Doctor
                {
                    Id = xuanlocDoctor3Id,
                    UserId = xuanlocDoctorUser3Id,
                    ClinicId = xuanlocClinicId,
                    Gender = "Nữ",
                    Specialization = "Phụ khoa",
                    Certificate = "Bác sĩ chuyên khoa Phụ sản",
                    ExperienceYear = 11,
                    WorkPosition = "Bác sĩ điều trị",
                    Description = "Tập trung vào các vấn đề phụ khoa, tư vấn sức khỏe sinh sản và kế hoạch hóa gia đình.",
                    IsDeleted = false,
                    CreationDate = new DateTime(2025, 09, 17)
                }
            );

            // Seed Trung tâm Y tế Huyện Xuân Lộc Consultant Users
            var xuanlocConsultantUser1Id = Guid.NewGuid();
            var xuanlocConsultantUser2Id = Guid.NewGuid();
            var xuanlocConsultantUser3Id = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = xuanlocConsultantUser1Id,
                    UserName = "Nguyễn Thị Minh Hòa",
                    Email = "minhhoa.consultant@ttytxuanloc.vn",
                    PhoneNumber = "0912345678",
                    Password = HashPassword("consultant#73"),
                    Address = "Xuân Hiệp, Xuân Lộc, Đồng Nai",
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
                    UserName = "Phan Văn Quang",
                    Email = "quangphan.consultant@ttytxuanloc.vn",
                    PhoneNumber = "0912987654",
                    Password = HashPassword("consultant#74"),
                    Address = "Gia Ray, Xuân Lộc, Đồng Nai",
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
                    UserName = "Lê Kim Ngân",
                    Email = "nganle.consultant@ttytxuanloc.vn",
                    PhoneNumber = "0933456789",
                    Password = HashPassword("consultant#75"),
                    Address = "Xuân Hòa, Xuân Lộc, Đồng Nai",
                    Avatar = null,
                    RoleId = 6,
                    IsDeleted = false,
                    IsStaff = true,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsVerified = true,
                    Status = Domain.Enums.StatusEnums.Active
                }
            );

            // Seed Trung tâm Y tế Huyện Xuân Lộc Consultants
            var xuanlocConsultant1Id = Guid.NewGuid();
            var xuanlocConsultant2Id = Guid.NewGuid();
            var xuanlocConsultant3Id = Guid.NewGuid();
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant
                {
                    Id = xuanlocConsultant1Id,
                    UserId = xuanlocConsultantUser1Id,
                    ClinicId = xuanlocClinicId,
                    Specialization = "Tư vấn chăm sóc thai kỳ",
                    Certificate = "Chứng chỉ tư vấn sức khỏe sinh sản",
                    Gender = "Nữ",
                    ExperienceYears = 9,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = xuanlocConsultant2Id,
                    UserId = xuanlocConsultantUser2Id,
                    ClinicId = xuanlocClinicId,
                    Specialization = "Tư vấn dinh dưỡng thai phụ",
                    Certificate = "Chứng chỉ dinh dưỡng lâm sàng",
                    Gender = "Nam",
                    ExperienceYears = 8,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                },
                new Consultant
                {
                    Id = xuanlocConsultant3Id,
                    UserId = xuanlocConsultantUser3Id,
                    ClinicId = xuanlocClinicId,
                    Specialization = "Tư vấn tâm lý thai kỳ",
                    Certificate = "Chứng chỉ tâm lý lâm sàng",
                    Gender = "Nữ",
                    ExperienceYears = 6,
                    CreationDate = new DateTime(2025, 09, 17),
                    IsDeleted = false
                }
            );

            // Seed Trung tâm Y tế Huyện Xuân Lộc Feedbacks
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
                    Comment = "Bác sĩ Giang rất tận tâm, theo dõi thai kỳ của tôi chu đáo từng tuần.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = xuanlocFeedback2Id,
                    ClinicId = xuanlocClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 8,
                    Comment = "Dịch vụ khám thai khá tốt, nhưng đôi lúc phải chờ hơi lâu.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = xuanlocFeedback3Id,
                    ClinicId = xuanlocClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 10,
                    Comment = "Tư vấn dinh dưỡng hữu ích, giúp tôi kiểm soát cân nặng hợp lý trong thai kỳ.",
                    CreationDate = new DateTime(2025, 09, 17)
                },
                new Feedback
                {
                    Id = xuanlocFeedback4Id,
                    ClinicId = xuanlocClinicId,
                    UserId = Guid.Parse("92b1cf94-ae17-478d-b60c-d8b11dd134a1"),
                    Rating = 10,
                    Comment = "Đội ngũ tư vấn tâm lý rất nhiệt tình, giúp tôi giảm lo lắng trong thời gian mang thai.",
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