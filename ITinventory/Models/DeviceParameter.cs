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
        public int DeviceCategoryId { get; set; }
        [ForeignKey("DeviceCategoryId")]
        public virtual DeviceType DeviceType { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Wartość")]
        public string Value { get; set; }
    }
}
