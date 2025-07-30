

namespace BaseTelegramBotApi.Controllers
{
    public interface IBotService
    {
        Task HandleUpdateAsync(TelegramUpdate update);
    }
}