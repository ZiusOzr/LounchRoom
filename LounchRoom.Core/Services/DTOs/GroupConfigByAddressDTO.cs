using System;
using System.Collections.Generic;
using System.Text;

namespace LounchRoom.Core.Services.DTOs
{
    public class GroupConfigByAddressDTO
    {
        public string GroupId { get; set; }
        public AddressDTO Address { get; set; }
    }

    public class AddressDTO
    {
        public string Country { get; set; } = "Россия";
        public string State { get; set; } = "Свердловская обл.";
        public string City { get; set; } = "Екатеринбург";
        public string Street { get; set; }
        public string Number { get; set; }
        public string Office { get; set; }
    }
}
