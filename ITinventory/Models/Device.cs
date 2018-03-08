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
        [DisplayName("Model")]
        public int ModelId { get; set; }
        [ForeignKey("ModelId")]
        [DisplayName("Model")]
        public virtual DeviceModel DeviceModel { get; set; }
        [DisplayName("Status")]
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }
        [DisplayName("Właściciel")]
        public string UserId { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Numer faktury")]
        public int InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        [DisplayName("Numer faktury")]
        public virtual Invoice Invoice { get; set; }
        [DisplayName("Lokalizacja")]
        public int LocalizationId { get; set; }
        [ForeignKey("LocalizationId")]
        [DisplayName("Lokalizacja")]
        public virtual Localization Localization { get; set; }

        public Device()
        {
        }
    }
}
