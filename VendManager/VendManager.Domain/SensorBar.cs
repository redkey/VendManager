﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
