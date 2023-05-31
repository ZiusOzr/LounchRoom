using System;

namespace LounchRoom.Core.Services.DTOs
{
    public class OptionDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid DishId { get; set; }
    }
}