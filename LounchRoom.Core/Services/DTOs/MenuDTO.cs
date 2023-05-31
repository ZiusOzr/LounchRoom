using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LounchRoom.Core.Services.DTOs
{
    public class MenuDTO
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public ObservableCollection<DishDTO> Dishes { get; set; }
        public ObservableCollection<LunchSetDTO> LunchSets { get; set; }
        public ObservableCollection<OptionDTO> Options { get; set; }
    }
}
