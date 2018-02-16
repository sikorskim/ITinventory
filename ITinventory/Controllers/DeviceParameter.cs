using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITinventory.Controllers
{
    public class DeviceParameter
    {
        public int Id { get; set; }
        public int DeviceCategoryId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
