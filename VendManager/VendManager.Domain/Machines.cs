using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendManager.Domain.Common;

namespace VendManager.Domain
{
    public class Machines : BaseEntity
    {
  
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public bool Enabled { get; set; }

    }
}
