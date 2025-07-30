using System.Threading.Tasks;
using BaseTelegramBotApi.Controllers;
using BaseTelegramBotApi.Models;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BaseTelegramBotApi.Services
{
    public class BotService : Controllers.IBotService
    {
        private readonly ITelegramBotClient _botClient;
        private readonly BotDbContext _dbContext;

        public BotService(ITelegramBotClient botClient, BotDbContext dbContext)
        {
            _botClient = botClient;
            _dbContext = dbContext;
        }



        public Task HandleUpdateAsync(TelegramUpdate update)
        {
            throw new NotImplementedException();
        }


    }
}