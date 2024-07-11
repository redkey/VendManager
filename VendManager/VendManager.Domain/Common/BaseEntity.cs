using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendManager.Domain.Common
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public DateTime? CreatedDateTimeUTC { get; set; }
        public DateTime? ModifiedDateTimeUTC { get; set; }
    }
}
        