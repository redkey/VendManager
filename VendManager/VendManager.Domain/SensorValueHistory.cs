using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendManager.Domain.Common;

namespace VendManager.Domain
{
    public class SensorValueHistory : BaseEntity
    {

        public DateTime DateTimeUTC { get; set; }
        public int SensorID { get; set; }
        public bool HasStock { get; set; }
    }
}
