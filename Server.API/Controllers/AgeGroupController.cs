using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs.AgeGroup;
using Server.Application.Interfaces;
using Server.Domain.Entities;

namespace Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiController]
    [Route("api/[controller]")]
    public class AgeGroupController : ControllerBase
    {
        private readonly IAgeGroupService _ageGroupService;

        public AgeGroupController(IAgeGroupService ageGroupService)
        {
            _ageGroupService = ageGroupService;
        }

        [HttpGet("view-all-age-groups")]
        public async Task<IActionResult> Gets()
        {
            return Ok(await _ageGroupService.GetAgeGroupsAsync());
        }

        [HttpGet("view-age-group-by-id")]
        public async Task<IActionResult> GetById([FromQuery] Guid ageGroupId)
        {
            if (ageGroupId == Guid.Empty)
                return BadRequest("AgeGroup Id is null or empty");

            return Ok(await _ageGroupService.GetAgeGroupByIdAsync(ageGroupId));
        }

        [HttpPost("add-age-group")]
        public async Task<IActionResult> Create([FromBody] CreateAgeGroupRequest request)
        {
            if (request.FromAge <= 0)
                return BadRequest("FromAge must be greater than 0");

            if (request.ToAge <= 0 || request.ToAge < request.FromAge)
                return BadRequest("ToAge must be greater than or equal to FromAge");

            try
            {
                var result = await _ageGroupService.CreateAgeGroup(request);
                if (result.Error == 1)
                    return BadRequest(result.Message);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update-age-group")]
        public async Task<IActionResult> Update([FromBody] UpdateAgeGroupRequest request)
        {
            if (request.AgeGroupId == Guid.Empty)
                return BadRequest("AgeGroup Id is null or empty");

            if (request.FromAge <= 0)
                return BadRequest("FromAge must be greater than 0");

            if (request.ToAge <= 0 || request.ToAge < request.FromAge)
                return BadRequest("ToAge must be greater than or equal to FromAge");

            try
            {
                var result = await _ageGroupService.UpdateAgeGroup(request);
                if (result.Error == 1)
                    return BadRequest(result.Message);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("soft-delete-age-group-by-id")]
        public async Task<IActionResult> SoftDelete([FromQuery] Guid ageGroupId)
        {
            if (ageGroupId == Guid.Empty)
                return BadRequest("AgeGroup Id is null or empty");

            try
            {
                var result = await _ageGroupService.SoftDeleteAgeGroup(ageGroupId);
                if (result.Error == 1)
                    return BadRequest(result.Message);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("delete-age-group-by-id")]
        public async Task<IActionResult> Delete([FromQuery] Guid ageGroupId)
        {
            if (ageGroupId == Guid.Empty)
                return BadRequest("AgeGroup Id is null or empty");

            try
            {
                var result = await _ageGroupService.DeleteAgeGroup(ageGroupId);
                if (result.Error == 1)
                    return BadRequest(result.Message);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
