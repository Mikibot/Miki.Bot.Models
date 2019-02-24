using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.Bot.Models
{
    public class CustomCommand
    {
        public long guildId { get; set; }

        public string commandName { get; set; }

        public string commandBody { get; set; }
    }
}
