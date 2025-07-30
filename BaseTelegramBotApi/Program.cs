using BaseTelegramBotApi.Controllers;
using BaseTelegramBotApi.Models;
using BaseTelegramBotApi.Services;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;

namespace BaseTelegramBotApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Program.cs
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BotDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Telegram Bot
            builder.Services.AddSingleton<ITelegramBotClient>(_ =>
                new TelegramBotClient(builder.Configuration["TelegramBot:Token"]));



            builder.Services.AddScoped<Controllers.IBotService, BotService>();
            builder.Services.AddScoped<Services.IBotExtraService, BotExtraService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpClient();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
