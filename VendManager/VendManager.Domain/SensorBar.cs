using System.Reflection.PortableExecutable;
using VendManager.Domain.Common;

namespace VendManager.Domain
{
    public class SensorBar : BaseEntity
    {

        public long MachineID { get; set; }
        public Machines Machine { get; set; }
        public string MacAddress { get; set; }
        public string? FirmwareVersion { get; set; }
        public DateTime? LastCommunicationDateTimeUTC { get; set; }
        public ICollection<Sensor> Sensors { get; set; }
    }
}
