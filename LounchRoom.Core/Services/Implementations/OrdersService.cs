using LounchRoom.Core.Services.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace LounchRoom.Core.Services.Implementations
{
    public class OrdersService : IOrdersService
    {
        public async Task<ObservableCollection<OrderReportDTO>> GetOrdersReportByDay(DateTime date, string groupToken)
        {
            var response = await Context.Connection.GetRequest($"https://api.lunchroom66.ru/api/Orders/GetOrdersReportByDay?date={date}&groupId={groupToken}");
            if (response.StatusCode.Code == System.Net.HttpStatusCode.OK)
            {
                var orderList = JsonConvert.DeserializeObject<ObservableCollection<OrderReportDTO>>(response.Json);
                return orderList;
            }
            else
            {
                throw new Exception("Unknown");
            }
        }
    }
}
