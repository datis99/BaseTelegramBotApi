

using Microsoft.EntityFrameworkCore;

namespace BaseTelegramBotApi.Models
{
    public class BotDbContext : DbContext
    {
        public BotDbContext(DbContextOptions<BotDbContext> options) : base(options) { }

        //dbset
    }
}
