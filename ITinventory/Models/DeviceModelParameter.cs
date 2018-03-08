using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITinventory.Models
{
    public class DeviceModelParameter
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        [ForeignKey("ModelId")]
        public virtual DeviceModel DeviceModel { get; set; }
        public int ParameterId { get; set; }
        [ForeignKey("ParameterId")]
        public virtual DeviceParameter DeviceParameter { get; set; }
        [DisplayName("Wartość")]
        public string Value { get; set; }

        public DeviceModelParameter()
        { }
    }
}
