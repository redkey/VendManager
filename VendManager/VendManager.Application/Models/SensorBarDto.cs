using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendManager.Domain;

namespace VendManager.Application.Models
{
    public class SensorBarDto
    {
        public long ID { get; set; }
        public string MacAddress { get; set; }
        public string? FirmwareVersion { get; set; }
        public DateTime? LastCommunicationDateTimeUTC { get; set; }
        public ICollection<SensorDto> Sensors { get; set; }
    }
}
