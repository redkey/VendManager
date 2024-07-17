namespace VendManager.BlazorUI.Models
{
    public class MachineVM
    {

        public long ID { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public bool Enabled { get; set; }

    }
}
