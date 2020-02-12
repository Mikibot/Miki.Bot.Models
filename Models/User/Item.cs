namespace Miki.Bot.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ItemResource
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int StackSize { get; set; }

    }

    public class Item
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public int Amount { get; set; }

        public ItemResource Resource { get; set; }
    }
}
