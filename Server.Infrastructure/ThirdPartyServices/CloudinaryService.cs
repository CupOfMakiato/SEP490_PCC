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

    }
}