using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LounchRoom.Core.Services.DTOs
{
    public class CategoryDTO
    {
        public DishTypeDTO Type { get; set; }
        public ObservableCollection<LunchSetDTO> LunchSets { get; set; }
    }
}
