using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITinventory.Models
{
    public class Device
    {
        public int Id { get; set; }
        public int DeviceTypeId { get; set; }
        public int ManufacturerId { get; set; }
        public int ModelId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
    }
}
