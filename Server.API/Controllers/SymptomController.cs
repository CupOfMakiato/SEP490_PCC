﻿using Microsoft.AspNetCore.Mvc;
using Server.Application.Abstractions.Shared;
using Server.Application;
using Server.Application.Interfaces;
using Server.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Application.DTOs.User;
using Server.Application.DTOs.Symptom;
using Server.Application.DTOs.Tag;
using Server.Application.Services;
using Server.Application.Abstractions.RequestAndResponse.Symptom;
using Server.API.Validations.Symptom;
using Server.Application.Mappers.SymptomExtensions;

namespace Server.API.Controllers
{
    [ApiController]
    [Route("api/symptom")]
    public class SymptomController : ControllerBase
    {
        private readonly ISymptomService _symptomService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;

        public SymptomController(ISymptomService symptomService, IUnitOfWork unitOfWork, IClaimsService claimsService)
        {
            _symptomService = symptomService;
            _unitOfWork = unitOfWork;
            _claimsService = claimsService;
        }

        [HttpGet("view-all-symptoms")]
        [ProducesResponseType(200, Type = typeof(Result<ViewTagDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewAllSymptoms()
        {
            var result = await _symptomService.ViewAllSymptoms();
            return Ok(result);
        }

        [HttpGet("view-symptom-by-id")]
        [ProducesResponseType(200, Type = typeof(Result<ViewSymptomDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewSymptomById(Guid symptomId)
        {
            var result = await _symptomService.ViewSymptomById(symptomId);
            return Ok(result);
        }

        [HttpGet("view-all-symptoms-for-user")]
        [ProducesResponseType(200, Type = typeof(Result<List<ViewSymptomDTO>>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewAllSymptomsForUser()
        {
            var user = _claimsService.GetCurrentUserId;
            var result = await _symptomService.ViewAllSymptomsForUser(user);
            return Ok(result);
        }

        [HttpPost("add-new-custom-symptom")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> AddNewCustomSymptom([FromForm] AddSymptomRequest req)
        {
            var validator = new AddSymptomRequestValidator();
            var validationResult = validator.Validate(req);

            if (!validationResult.IsValid)
            {
                return BadRequest(new Result<object>
                {
                    Error = 1,
                    Message = "Missing or invalid value!",
                    Data = validationResult.Errors.Select(e => e.ErrorMessage)
                });
            }

            var dto = req.ToAddSymptomDTO();
            var result = await _symptomService.AddNewCustomSymptom(dto);

            return Ok(result);
        }

    }
}
