﻿namespace VendManager.Application.Features.Machines.Query.GetAllMachinesWithSensorDetails
{
    public class SensorBarDto2
    {
        public int MachineID { get; set; }
        public string? FirmwareVersion { get; set; }
        public DateTime? LastCommunicationDateTimeUTC { get; set; }
    }
}
