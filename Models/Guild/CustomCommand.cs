using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.Bot.Models
{
    public class CustomCommand
    {
        public long GuildId { get; set; }

        public string CommandName { get; set; }

        public string CommandBody { get; set; }
    }
}
