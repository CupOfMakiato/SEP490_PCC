using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.API.Validations.Journal;
using Server.Application.Abstractions.RequestAndResponse.Journal;
using Server.Application.Abstractions.Shared;
using Server.Application.DTOs.Journal;
using Server.Application.Interfaces;
using Server.Application.Mappers.JournalExtensions;
using Server.Application.Services;

namespace Server.API.Controllers
{
    [Route("api/journal")]
    [ApiController]
    public class JournalController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IJournalService _journalService;

        public JournalController(IMapper mapper, IJournalService journalService)
        {
            _mapper = mapper;
            _journalService = journalService;
        }
        [HttpGet("view-all-journals")]
        [ProducesResponseType(200, Type = typeof(Result<List<ViewJournalDTO>>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewAllJournals()
        {
            var result = await _journalService.ViewAllJournals();
            return Ok(result);
        }
        [HttpGet("view-journal-by-id")]
        [ProducesResponseType(200, Type = typeof(ViewJournalDTO))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewJournalById(Guid journalId)
        {
            var result = await _journalService.ViewJournalById(journalId);
            return Ok(result);
        }
        [HttpGet("view-journal-by-growthdata-id/{growthDataId}")]
        [ProducesResponseType(200, Type = typeof(ViewJournalDTO))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> ViewJournalsByGrowthDataId(Guid growthDataId)
        {
            var result = await _journalService.ViewJournalsByGrowthDataId(growthDataId);
            return Ok(result);
        }

        [HttpPost("create-new-journal-entry")]
        [ProducesResponseType(200, Type = typeof(Result<ViewJournalDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> CreateNewJournalEntry([FromForm] CreateNewJournalEntryForCurrentWeekRequest req)
        {
            var validator = new CreateNewJournalEntryRequestValidator();
            var validationResult = validator.Validate(req);
            if (validationResult.IsValid == false)
            {
                return BadRequest(new Result<object>
                {
                    Error = 1,
                    Message = "Missing value!",
                    Data = validationResult.Errors.Select(x => x.ErrorMessage),
                });
            }
            req.Id = Guid.NewGuid();

            var dto = req.ToCreateNewJournalEntryForCurrentWeekDTO();
            var result = await _journalService.CreateNewJournalEntryForCurrentWeek(dto);
            return Ok(result);
        }
        [HttpPut("edit-journal-entry")]
        [ProducesResponseType(200, Type = typeof(Result<ViewJournalDTO>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> EditJournalEntry([FromForm] EditJournalEntryRequest req)
        {
            var validator = new EditJournalEntryRequestValidator();
            var validationResult = validator.Validate(req);
            if (validationResult.IsValid == false)
            {
                return BadRequest(new Result<object>
                {
                    Error = 1,
                    Message = "Missing value!",
                    Data = validationResult.Errors.Select(x => x.ErrorMessage),
                });
            }
            var dto = req.ToEditJournalEntryDTO();
            var result = await _journalService.EditJournalEntry(dto);
            return Ok(result);
        }
        [HttpDelete("delete-journal")]
        [ProducesResponseType(200, Type = typeof(Result<object>))]
        [ProducesResponseType(400, Type = typeof(Result<object>))]
        public async Task<IActionResult> DeleteJournal(Guid journalId)
        {
            var result = await _journalService.DeleteJournal(journalId);
            return Ok(result);
        }
    }
}
