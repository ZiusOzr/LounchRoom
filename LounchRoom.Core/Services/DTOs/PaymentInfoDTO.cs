using System;

namespace LounchRoom.Core.Services.DTOs
{
    public class PaymentInfoDTO
    {
        public string GroupId { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Qr { get; set; }
    }
}