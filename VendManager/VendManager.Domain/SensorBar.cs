using VendManager.Domain.Common;

namespace VendManager.Domain
{
    public class SensorBar : BaseEntity
    {
  
        public long MachineID { get; set; }
        public Machines Machine { get; set; }  // Navigation property
        public string? FirmwareVersion { get; set; }
        public DateTime? LastCommunicationDateTimeUTC { get; set; }
    }
}
