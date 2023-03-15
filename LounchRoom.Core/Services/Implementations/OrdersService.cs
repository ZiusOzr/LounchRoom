using LounchRoom.Core.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace LounchRoom.Core.Services.Implementations
{
    public class OrdersService : IOrdersService
    {
        public Task<List<OrdersDTO>> LoadOrders()
        {
            throw new NotImplementedException();
        }
    }
}
