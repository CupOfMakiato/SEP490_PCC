using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Server.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Domain.Entities;
using Server.Application.Settings.CloudinaryService;
using Server.Application.Abstractions.ThirdPartyService.CloudinaryService;

namespace Server.Infrastructure.ThirdPartyServices
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly CloudinarySetting _cloudinarySetting;
        private readonly Cloudinary _cloudinary;
        public CloudinaryService(IOptions<CloudinarySetting> cloudinaryConfig)
        {
            var account = new Account(cloudinaryConfig.Value.CloudName,
                cloudinaryConfig.Value.ApiKey,
                cloudinaryConfig.Value.ApiSecret);

            _cloudinary = new Cloudinary(account);
            _cloudinarySetting = cloudinaryConfig.Value;
        }

        public async Task<DeletionResult> DeleteFileAsync(string publicId)
        {
            var deletionParams = new DeletionParams(publicId);
            return await _cloudinary.DestroyAsync(deletionParams);
        }
        public async Task<CloudinaryResponse> UploadBlogImage(string fileName, IFormFile file, Blog blog)
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(fileName, file.OpenReadStream()),
                PublicId = $"/{blog.Id}/{Path.GetFileNameWithoutExtension(fileName)}",
                Overwrite = true,
                Folder = "blogs"
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
            {
                return null; // Handle upload failure
            }

            return new CloudinaryResponse
            {
                FileUrl = uploadResult.SecureUrl.ToString(),
                PublicFileId = uploadResult.PublicId
            };
        }
        public async Task<CloudinaryResponse> UploadJournalImage(string fileName, IFormFile file, Journal journal)
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(fileName, file.OpenReadStream()),
                PublicId = $"/{journal.Id}/{Path.GetFileNameWithoutExtension(fileName)}",
                Overwrite = true,
                Folder = "journals"
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
            {
                return null; // Handle upload failure
            }

            return new CloudinaryResponse
            {
                FileUrl = uploadResult.SecureUrl.ToString(),
                PublicFileId = uploadResult.PublicId
            };
        }
        public async Task<CloudinaryResponse> UploadAvatarImage(string fileName, IFormFile file, User avatar)
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(fileName, file.OpenReadStream()),
                PublicId = $"{avatar.Id}/{Path.GetFileNameWithoutExtension(fileName)}",
                Overwrite = true,
                Folder = "avatar"
            };
            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            if (uploadResult.Error != null)
            {
                return null; // Handle upload failure
            }
            return new CloudinaryResponse
            {
                FileUrl = uploadResult.SecureUrl.ToString(),
                PublicFileId = uploadResult.PublicId
            };
        }

        public async Task<CloudinaryResponse> UploadOfflineConsultationAttachment(string fileName, IFormFile file, OfflineConsultation offlineConsultation)
        {
            if (file == null || file.Length == 0)
                return null;

            var extension = Path.GetExtension(fileName).ToLowerInvariant();

            var imageExtensions = new[] { ".jpg", ".jpeg", ".png", ".docx", ".bmp", ".xls", ".pdf", ".xlsx" };

            UploadResult uploadResult;

            if (imageExtensions.Contains(extension))
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(fileName, file.OpenReadStream()),
                    PublicId = $"{offlineConsultation.Id}/{Path.GetFileNameWithoutExtension(fileName)}",
                    Overwrite = true,
                    Folder = "offline_consultation"
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            else
            {
                var uploadParams = new RawUploadParams
                {
                    File = new FileDescription(fileName, file.OpenReadStream()),
                    PublicId = $"{offlineConsultation.Id}/{Path.GetFileNameWithoutExtension(fileName)}",
                    Overwrite = true,
                    Folder = "offline_consultation"
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            if (uploadResult.Error != null ||
                uploadResult.StatusCode != System.Net.HttpStatusCode.OK ||
                uploadResult.SecureUrl == null)
            {
                return null;
            }

            return new CloudinaryResponse
            {
                FileUrl = uploadResult.SecureUrl.ToString(),
                PublicFileId = uploadResult.PublicId
            };
        }

        public async Task<CloudinaryResponse> UploadOnlineConsultationAttachment(string fileName, IFormFile file, OnlineConsultation onlineConsultation)
        {
            if (file == null || file.Length == 0)
                return null;

            var extension = Path.GetExtension(fileName).ToLowerInvariant();

            var imageExtensions = new[] { ".jpg", ".jpeg", ".png", ".docx", ".bmp", ".xls", ".pdf", ".xlsx" };

            UploadResult uploadResult;

            if (imageExtensions.Contains(extension))
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(fileName, file.OpenReadStream()),
                    PublicId = $"{onlineConsultation.Id}/{Path.GetFileNameWithoutExtension(fileName)}",
                    Overwrite = true,
                    Folder = "online_consultation"
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            else
            {
                var uploadParams = new RawUploadParams
                {
                    File = new FileDescription(fileName, file.OpenReadStream()),
                    PublicId = $"{onlineConsultation.Id}/{Path.GetFileNameWithoutExtension(fileName)}",
                    Overwrite = true,
                    Folder = "online_consultation"
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            if (uploadResult.Error != null ||
                uploadResult.StatusCode != System.Net.HttpStatusCode.OK ||
                uploadResult.SecureUrl == null)
            {
                return null;
            }

            return new CloudinaryResponse
            {
                FileUrl = uploadResult.SecureUrl.ToString(),
                PublicFileId = uploadResult.PublicId
            };
        }

        public async Task<CloudinaryResponse> UploadClinicImage(string fileName, IFormFile file, Clinic clinic)
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(fileName, file.OpenReadStream()),
                PublicId = $"/{clinic.Id}/{Path.GetFileNameWithoutExtension(fileName)}",
                Overwrite = true,
                Folder = "clinic"
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
            {
                return null; // Handle upload failure
            }

            return new CloudinaryResponse
            {
                FileUrl = uploadResult.SecureUrl.ToString(),
                PublicFileId = uploadResult.PublicId
            };
        }

        public async Task<CloudinaryResponse> UploadMessageAttachment(string fileName, IFormFile file, Message message)
        {
            if (file == null || file.Length == 0)
                return null;

            var extension = Path.GetExtension(fileName).ToLowerInvariant();

            var imageExtensions = new[] { ".jpg", ".jpeg", ".png", ".docx", ".bmp", ".xls", ".pdf", ".xlsx" };

            UploadResult uploadResult;

            if (imageExtensions.Contains(extension))
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(fileName, file.OpenReadStream()),
                    PublicId = $"{message.Id}/{Path.GetFileNameWithoutExtension(fileName)}",
                    Overwrite = true,
                    Folder = "message"
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            else
            {
                var uploadParams = new RawUploadParams
                {
                    File = new FileDescription(fileName, file.OpenReadStream()),
                    PublicId = $"{message.Id}/{Path.GetFileNameWithoutExtension(fileName)}",
                    Overwrite = true,
                    Folder = "message"
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            if (uploadResult.Error != null ||
                uploadResult.StatusCode != System.Net.HttpStatusCode.OK ||
                uploadResult.SecureUrl == null)
            {
                return null;
            }

            return new CloudinaryResponse
            {
                FileUrl = uploadResult.SecureUrl.ToString(),
                PublicFileId = uploadResult.PublicId
            };
        }

        public async Task<CloudinaryResponse> UploadImage(IFormFile file, string folderName)
        {
            if (file is null)
                return null;
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                PublicId = $"/{Guid.NewGuid()}/{Path.GetFileNameWithoutExtension(file.FileName)}",
                Overwrite = true,
                Folder = folderName
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
            {
                return null; // Handle upload failure
            }

            return new CloudinaryResponse
            {
                FileUrl = uploadResult.SecureUrl.ToString(),
            };
        }
    }
}