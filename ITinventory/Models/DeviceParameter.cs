using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITinventory.Models
{
    public class DeviceParameter
    {
        public int Id { get; set; }
        public int DeviceTypeId { get; set; }
        [ForeignKey("DeviceTypeId")]
        public virtual DeviceType DeviceType { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }

        public DeviceParameter()
        { }
    }
}
