using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.Bot.Models.Models.Authorization
{
    public enum APIPermissions : long
    {
        None = 0,
        ManageMetrics = 1,
        ManageApplications = 2
    }

    public class APIApplication
    {
        public long ApplicationId { get; set; }
        public long OwnerId { get; set; }
        public long LastResetEpoch { get; set; }
        public Guid ApplicationSecret { get; set; }
        public APIPermissions Permissions { get; set; }
        public double RatelimitMultiplier { get; set; }
        public APIApplicationData Data { get; set; }
    }
}