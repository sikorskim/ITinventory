using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITinventory.Models
{
    public class License
    {
        public int Id { get; set; }
        public int LicenseTypeId { get; set; }
        [ForeignKey("LicenseTypeId")]
        public LicenseType LicenseType { get; set; }
        public int SoftwareId { get; set; }
        [ForeignKey("SoftwareId")]
        public virtual Software Software { get; set; }
        [DisplayName("Ważność od")]
        public DateTime ValidFrom { get; set; }
        [DisplayName("Ważność do")]
        public DateTime ValidTo { get; set; }
    }
}
