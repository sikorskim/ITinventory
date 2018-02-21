using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITinventory.Models
{
    public class LicenseDevice
    {
        public int Id { get; set; }
        public int LicenseId { get; set; }
        [ForeignKey("LicenseId")]
        public virtual License License { get; set; }
        public int DeviceId { get; set; }
        [ForeignKey("DeviceId")]
        public virtual Device Device { get; set; }
    }
}
