using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/message")]
    public class TelegramBotController : ControllerBase
    {
        [HttpPost("update")]
        public IActionResult Update(Update update)
        {
            // /start = register user
            return Ok();
        }
    }
}
