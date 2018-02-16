using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITinventory.Models
{
    public class Address
    {
        public int AddressId { get; private set; }
        public string Street { get; private set; }
        public string BuldingNumber { get; private set; }
        public string LocalNumber { get; private set; }
        public string PostalCode { get; private set; }
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
