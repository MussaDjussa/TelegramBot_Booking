using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    
    
    [ApiController]
    [Route("api/message")]
    public class TelegramBotController : ControllerBase
    {
        
        private readonly TelegramBotClient _tgBotClient;
        private readonly DataContext _context;
        

        public TelegramBotController(TelegramBot telegramBot)
        {
            _tgBotClient = telegramBot.GetBot().Result;
        }
        
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody]Update update)
        {
            var upd = JsonConvert.DeserializeObject<Update>(update.ToString());
            
            var chat = update.Message?.Chat;

            var appuser = new AppUser
            {
                Username = chat?.Username,
                ChatId = chat.Id,
                CreateTime = DateTime.UtcNow,
                FirstName = chat.FirstName,
                LastName = chat.LastName,
            };
            var result = await _context.Users.AddAsync(appuser);
            await _context.SaveChangesAsync();

            _tgBotClient.SendTextMessageAsync(chat.Id, "😊", ParseMode.Markdown);
            return Ok();
        }
    }
}
