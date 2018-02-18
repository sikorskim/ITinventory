using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ITinventory.Models
{
    public class Address
    {
        public int Id { get; private set; }
        [DisplayName("Ulica")]
        public string Street { get; private set; }
        [DisplayName("Nr budynku")]
        public string BuldingNumber { get; private set; }
        [DisplayName("Nr lokalu")]
        public string LocalNumber { get; private set; }
        [DisplayName("Kod pocztowy")]
        public string PostalCode { get; private set; }
        [DisplayName("Miejscowość")]
        public string City { get; private set; }

        public Address(string street, string buldingNumber, string localNumber, string postalCode, string city)
        {
            Street = street;
            BuldingNumber = buldingNumber;
            LocalNumber = localNumber;
            PostalCode = postalCode;
            City = city;
        }
    }
}
