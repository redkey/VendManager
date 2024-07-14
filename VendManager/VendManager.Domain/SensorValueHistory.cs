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
