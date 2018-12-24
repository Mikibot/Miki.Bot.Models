using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.Bot.Models.Models.Authorization
{
    public class APIToken
    {
        public ulong UserId { get; set; }
        public DateTime LastTimeReset { get; set; }
    }
}
