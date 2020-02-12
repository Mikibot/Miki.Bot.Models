namespace Miki.Bot.Models.Models.Authorization
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public enum APIPermissions : long
    {
        Default = 0,
        ManageMetrics = 1,
        ManageApplications = 2,
        WriteDefault = 4
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