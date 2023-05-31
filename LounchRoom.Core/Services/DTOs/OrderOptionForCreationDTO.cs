using System;

namespace LounchRoom.Core.Services.DTOs
{
    public class OrderOptionForCreationDTO
    {
        public Guid OptionId { get; set; }
        public int Units { get; set; }
    }
}