using LoveChat.DataAccess.Utils;
using LoveChat.Domain.Entities.Messages;
using LoveChat.Service.Dtos.Messages;
using LoveChat.Service.Interfaces.Messages;
using LoveChat.Service.Validators.Dtos.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoveChat.WebApi.Controllers
{
    [Route("api/Messages")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessagesService _messagesService;
        private readonly int maxPageSize = 30;

        public MessagesController(IMessagesService messagesService)
        {
            this._messagesService = messagesService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _messagesService.GetAllAsync(new PaginationParams(page, maxPageSize)));


        [HttpGet("count")]
        [AllowAnonymous]
        public async Task<IActionResult> CountAsync()
      => Ok(await _messagesService.CountAsync());


        [HttpGet("{messageId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(long MessageId)
        => Ok(await _messagesService.GetByIdAsync(MessageId));

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreateAsync([FromForm] MessageCreateDto dto)
        {
            var validator = new MessageCreateValidator();
            var result = validator.Validate(dto);
            if (result.IsValid) return Ok(await _messagesService.CreateAsync(dto));
            else return BadRequest(result.Errors);
        }

        [HttpPut("{MessageId}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateAsync(long MessageId, [FromForm] MessageUpdateDto dto)
        {
            var validator = new MessageUpdateValidator();
            var validationResult = validator.Validate(dto);
            if (validationResult.IsValid) return Ok(await _messagesService.UpdateAsync(MessageId, dto));
            else return BadRequest(validationResult.Errors);
        }

        [HttpDelete("{MessageId}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteAsync(long MessageId)
    => Ok(await _messagesService.DeleteAsync(MessageId));
    }
}
