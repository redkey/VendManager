using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendManager.Domain
{
    public class User
    {
        public long Id { get; set; }
        public int? EmailNotificationIntervalMinutes { get; set; }
        public int? EmailNotificationOnlyOutStockPeriodMinutes { get; set; }
        public DateTime? EmailNotificationLastProcessedAtDateTimeUTC { get; set; }
        public int? SMSNotificationIntervalMinutes { get; set; }
        public int? SMSlNotificationOnlyOutStockPeriodMinutes { get; set; }
        public DateTime? SMSlNotificationLastProcessedAtDateTimeUTC { get; set; }
    }
}
