using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITinventory.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string NIP { get; set; }
        public string REGON { get; set; }
        public int AddressId { get; set; }
    }
}
