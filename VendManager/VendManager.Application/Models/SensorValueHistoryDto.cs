using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendManager.Application.Models
{
    public class SensorValueHistoryDto
    {
        public DateTime DateTimeUTC { get; set; }
        public long SensorID { get; set; }
        public bool HasStock { get; set; }
    }
}
