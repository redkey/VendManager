namespace VendManager.BlazorUI.Models
{
    public class SensorBarViewModel
    {
        public long MachineID { get; set; }
        public string? FirmwareVersion { get; set; }
        public DateTime? LastCommunicationDateTimeUTC { get; set; }
    }
}
