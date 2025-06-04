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
    }
}
