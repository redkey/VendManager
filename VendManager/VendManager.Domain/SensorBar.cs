using VendManager.Domain.Common;

namespace VendManager.Domain
{
    public class SensorBar : BaseEntity
    {
  
        public int MachineID { get; set; }  
        public string? FirmwareVersion { get; set; }
        public DateTime? LastCommunicationDateTimeUTC { get; set; }
    }
}
