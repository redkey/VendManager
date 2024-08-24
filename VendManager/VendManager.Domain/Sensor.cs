using VendManager.Domain.Common;

namespace VendManager.Domain
{
    public class Sensor : BaseEntity
    {

        public long SensorBarID { get; set; }
        public SensorBar SensorBar { get; set; }
        public int ThresholdValue { get; set; }
        public int? CurrentValue { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }  
        public int ChuteNumber { get; set; }
        public bool Enabled { get; set; }
        public SensorValueHistory SensorValueHistory { get; set; }

    }

   

}
