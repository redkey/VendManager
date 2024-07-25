using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendManager.Application.Models
{
    public class SensorDto
    {
        public long ID { get; set; }
        public int ThresholdValue { get; set; }
        public int? CurrentValue { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
        public int ChuteNumber { get; set; }
        public bool Enabled { get; set; }
    }
}
