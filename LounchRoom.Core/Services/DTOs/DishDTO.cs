using System;

namespace LounchRoom.Core.Services.DTOs
{
    public class DishDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DishTypeDTO Type { get; set; }
    }
}