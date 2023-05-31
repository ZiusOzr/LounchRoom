using System;
using System.Collections.ObjectModel;

namespace LounchRoom.Core.Services.DTOs
{
    public class LunchSetDTO : ICategory
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Guid> DishIds { get; set; }
    }
}