using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITinventory.Models
{
    public class Invoice
    {      
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Numer faktury")]
        public string Number { get; set; }
        [Required]
        [DisplayName("Data wystawienia")]
        public DateTime DateOfIssue { get; set; }
        [Required]
        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        [DisplayName("Dostawca")]
        public virtual Supplier Supplier { get; set; }

        public Invoice()
        { }
    }
}
