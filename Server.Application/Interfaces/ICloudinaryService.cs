using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Server.Application.Abstractions.ThirdPartyService.CloudinaryService;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Interfaces
{
    public interface ICloudinaryService
    {
        Task<DeletionResult> DeleteFileAsync(string publicId);
        Task<CloudinaryResponse> UploadBlogImage(string fileName, IFormFile file, Blog blog);
        Task<CloudinaryResponse> UploadJournalImage(string fileName, IFormFile file, Journal journal);
        Task<CloudinaryResponse> UploadAvatarImage(string fileName, IFormFile file, User avatar);
        Task<CloudinaryResponse> UploadOfflineConsultationAttachment(string fileName, IFormFile file, OfflineConsultation offlineConsultation);
        Task<CloudinaryResponse> UploadOnlineConsultationAttachment(string fileName, IFormFile file, OnlineConsultation onlineConsultation);
        Task<CloudinaryResponse> UploadClinicImage(string fileName, IFormFile file, Clinic clinic);
        Task<CloudinaryResponse> UploadMessageAttachment(string fileName, IFormFile file, Message message);
    }
}
