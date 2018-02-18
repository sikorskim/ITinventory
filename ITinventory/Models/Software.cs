using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITinventory.Models
{
    public class Software
    {
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        [ForeignKey("ManufacturerId")]
        public virtual Manufacturer Manufacturer{ get; set; }
        public int SoftwareTypeId { get; set; }
        [ForeignKey("SoftwareTypeId")]
        public virtual SoftwareType SoftwareType{ get; set; }
        [DisplayName("Id")]
        public string Name { get; set; }
    }
}
