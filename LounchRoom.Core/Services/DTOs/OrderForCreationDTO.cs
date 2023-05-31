using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LounchRoom.Core.Services.DTOs
{
    public class OrderForCreationDTO
    {
        public string GroupId { get; set; }
        public Guid MenuId { get; set; }
        public Guid LunchSetId { get; set; }
        public int LunchSetUnits { get; set; }
        public ObservableCollection<OrderOptionForCreationDTO> Options { get; set; }
        public ObservableCollection<OrderDishesForCreationDTO> Dishes { get; set; }

    }
}
