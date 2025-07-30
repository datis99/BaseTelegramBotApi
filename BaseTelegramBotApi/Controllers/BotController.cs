using BaseTelegramBotApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types; 
using Telegram.Bot.Types.Enums; 

namespace BaseTelegramBotApi.Controllers
{
    [ApiController]
    [Route("api/bot")]
    public class BotController : ControllerBase
    {
        private readonly IBotService _telegramService;
        private readonly ILogger<BotController> _logger;

        public BotController(IBotService telegramService, ILogger<BotController> logger)
        {
            _telegramService = telegramService;
            _logger = logger;
        }

        [HttpPost("update")]
        public async Task<IActionResult> HandleUpdate([FromBody] TelegramUpdate update)
        {
            try
            {
                _logger.LogInformation($"Received update: {update}");

                await _telegramService.HandleUpdateAsync(update);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in HandleUpdate: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
    // TelegramUpdate.cs
    public class TelegramUpdate
    {
        public int UpdateId { get; set; }
        public TelegramMessage Message { get; set; }
    }

    public class TelegramMessage
    {
        public int MessageId { get; set; }
        public string Text { get; set; }
        public TelegramUser From { get; set; }
    }

    public class TelegramUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
    }

}

