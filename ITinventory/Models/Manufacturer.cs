using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITinventory.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Hardware { get; set; }
        public bool Software { get; set; }
    }
}
