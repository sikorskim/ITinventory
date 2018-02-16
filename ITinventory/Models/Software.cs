using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITinventory.Models
{
    public class Software
    {
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public int SoftwareType { get; set; }
        public string Name { get; set; }
    }
}
