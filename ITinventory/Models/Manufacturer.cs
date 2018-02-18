using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ITinventory.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Sprzęt")]
        public bool Hardware { get; set; }
        [DisplayName("Oprogramowanie")]
        public bool Software { get; set; }
    }
}
