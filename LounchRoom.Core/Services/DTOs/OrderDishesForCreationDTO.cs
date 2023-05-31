using System;

namespace LounchRoom.Core.Services.DTOs
{
    public class OrderDishesForCreationDTO
    {
        public Guid OptionId { get; set; }
        public int Units { get; set; }
    }
}