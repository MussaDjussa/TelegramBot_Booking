using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Telegram.Bot;

namespace WebApplication1.Controllers
{
    public class TelegramBot
    {
        private readonly IConfiguration _configuration;
        public async Task<TelegramBotClient> GetBot()
        {
            var telegramBot = new TelegramBotClient(_configuration["Token"]);
            var hook = $"{_configuration["Url"]}api/message/update";
            await telegramBot.SetWebhookAsync(hook);
            return telegramBot;
        }
    }
}