using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITinventory.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        [DisplayName("Nazwa")]
        public string Name{ get; set; }
        public string NIP { get; set; }
        public string REGON { get; set; }
        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }
    }
}
