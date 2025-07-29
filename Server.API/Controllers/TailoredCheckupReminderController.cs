using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Interfaces;
using Server.Application;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.TailoredCheckupReminder;
using Server.API.Validations.CustomChecklist;
using Server.Application.Abstractions.RequestAndResponse.CustomChecklist;
using Server.Application.Services;
using Server.Application.Abstractions.RequestAndResponse.CheckupReminder;
using Server.API.Validations.CheckupReminder;
using Server.Application.Mappers.CheckupReminderExtensions;
using Server.Application.DTOs.UserChecklist;

namespace Server.API.Controllers
{
    [Route("api/tailored-checkup-reminder")]
    [ApiController]
    public class TailoredCheckupReminderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;
        private readonly ITailoredCheckupReminderService _tailoredCheckupReminderService;

        public TailoredCheckupReminderController(IUnitOfWork unitOfWork, IClaimsService claimsService,
            ITailoredCheckupReminderService tailoredCheckupReminderService)
        {
            _unitOfWork = unitOfWork;
            _claimsService = claimsService;
            _tailoredCheckupReminderService = tailoredCheckupReminderService;
        }
        [HttpGet("view-all-tailored-checkup-reminders")]
        [ProducesResponseType(200, Type = typeof(Result<List<ViewTailoredCheckupReminderDTO>>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewAllTailoredCheckupReminders()
        {
            var result = await _tailoredCheckupReminderService.ViewAllReminders();
            return Ok(result);
        }
        [HttpPost("create-new-tailored-checkup-reminder")]
        [ProducesResponseType(200, Type = typeof(Result<ViewTailoredCheckupReminderDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> CreateNewTailoredCheckupReminder([FromForm] CreateNewTailoredCheckupReminderRequest req)
        {
            var validator = new CreateNewTailoredCheckupReminderRequestValidator();
            var validatorResult = validator.Validate(req);
            if (validatorResult.IsValid == false)
            {
                return BadRequest(new Result<object>
                {
                    Error = 1,
                    Message = "Missing value!",
                    Data = validatorResult.Errors.Select(x => x.ErrorMessage),
                });
            }

            var reminder = req.ToCreateTailoredReminderDTO();
            var result = await _tailoredCheckupReminderService.CreateNewTailoredCheckupReminder(reminder);

            return Ok(result);
        }
        [HttpPut("edit-tailored-checkup-reminder")]
        [ProducesResponseType(200, Type = typeof(Result<ViewTailoredCheckupReminderDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> UploadBlog([FromForm] EditTailoredCheckupReminderRequest req)
        {
            var validator = new EditTailoredCheckupReminderRequestValidator();
            var validatorResult = validator.Validate(req);
            if (validatorResult.IsValid == false)
            {
                return BadRequest(new Result<object>
                {
                    Error = 1,
                    Message = "Missing value!",
                    Data = validatorResult.Errors.Select(x => x.ErrorMessage),
                });
            }

            var reminder = req.ToEditTailoredReminderDTO();
            var result = await _tailoredCheckupReminderService.EditTailoredCheckupReminder(reminder);

            return Ok(result);
        }
        [HttpPut("mark-reminder-as-completed")]
        [ProducesResponseType(200, Type = typeof(Result<ViewTailoredCheckupReminderDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> MarkReminderAsComplete(Guid ReminderId)
        {
            var result = await _tailoredCheckupReminderService.MarkReminderAsComplete(ReminderId);
            return Ok(result);
        }
        [HttpPut("mark-reminder-as-scheduled")]
        [ProducesResponseType(200, Type = typeof(Result<ViewTailoredCheckupReminderDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> MarkReminderAsScheduled(Guid ReminderId)
        {
            var result = await _tailoredCheckupReminderService.MarkReminderAsScheduled(ReminderId);
            return Ok(result);
        }
        [HttpDelete("delete-tailored-checkup-reminder")]
        [ProducesResponseType(200, Type = typeof(Result<ViewTailoredCheckupReminderDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> DeleteReminder(Guid ReminderId)
        {
            var result = await _tailoredCheckupReminderService.DeleteReminder(ReminderId);
            return Ok(result);
        }
    }
}
