using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITinventory.Models
{
    public class DeviceModel
    {
        public int Id { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
        [ForeignKey("ManufacturerId")]
        [DisplayName("Producent")]
        public virtual Manufacturer Manufacturer { get; set; }
        public int DeviceTypeId { get; set; }
        [ForeignKey("DeviceTypeId")]
        [DisplayName("Typ")]
        public virtual DeviceType DeviceType { get; set; }

        public DeviceModel()
        { }
    }
}
