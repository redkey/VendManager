using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendManager.Application.Models.Identity
{
    public class UserDetails
    {
        public long Id { get; set; }
        public int? EmailNotificationIntervalMinutes { get; set; }
        public int? EmailNotificationOnlyOutStockPeriodMinutes { get; set; }
        public DateTime? EmailNotificationLastProcessedAtDateTimeUTC { get; set; }
        public int? SMSNotificationIntervalMinutes { get; set; }
        public int? SMSlNotificationOnlyOutStockPeriodMinutes { get; set; }
        public DateTime? SMSlNotificationLastProcessedAtDateTimeUTC { get; set; }

        public string AspNetUserId { get; set; } // Foreign key to ApplicationUser
        public virtual User AspNetUser { get; set; } // Navigation property for one-to-one relationship
    }
}
