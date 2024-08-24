using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendManager.Application.Models;

namespace VendManager.Application.Features.Machines.Query.GetAllMachinesWithSensorHistory
{
    public class GetAllMachinesWithSensorHistoryDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public bool Enabled { get; set; }
        public ICollection<SensorBarDto> SensorBar { get; set; }
    }
}
