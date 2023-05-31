using LounchRoom.Core.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace LounchRoom.Core.Services
{
    public interface IOrdersService
    {
        Task<ObservableCollection<OrderReportDTO>> GetOrdersReportByDay(DateTime date, string groupToken);
    }
}
