using System;

namespace LounchRoom.Core.Services.DTOs
{
    public class DishTypeDTO : ICategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}