using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITinventory.Models
{
    public class License
    {
        public int Id { get; set; }
        public int LicenseTypeId { get; set; }
        public int SoftwareId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
