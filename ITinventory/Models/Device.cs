using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITinventory.Models
{
    public class Device
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        [ForeignKey("ModelId")]
        public virtual DeviceModel DeviceModel { get; set; }
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }
        public string UserId { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Nr faktury")]
        public string InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }
        public int LocalizationId { get; set; }
        [ForeignKey("LocalizationId")]
        public virtual Localization Localization { get; set; }
    }
}
