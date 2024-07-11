using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendManager.Domain
{
    public class SensorValueHistory
    {
        public int ID { get; set; }
        public DateTime DateTimeUTC { get; set; }
        public int SensorID { get; set; }
        public bool HasStock { get; set; }
    }
}
