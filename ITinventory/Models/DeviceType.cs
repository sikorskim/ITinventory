using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ITinventory.Models
{
    public class DeviceType
    {
        public int Id{ get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
    }
}
