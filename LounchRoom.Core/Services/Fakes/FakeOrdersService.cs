using LounchRoom.Core.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace LounchRoom.Core.Services.Fakes
{
    public class FakeOrdersService : IOrdersService
    {
        public List<OrdersDTO> Orders;
        public FakeOrdersService()
        {
            Orders = new List<OrdersDTO>()
            {
                new OrdersDTO
                {
                    Price = "346 руб.",
                    Order = "Первый заказ. Тут блюда всякие"
                },
                new OrdersDTO
                {
                    Price = "651 руб.",
                    Order = "Второй заказ. Тут блюда всякие"
                },
                new OrdersDTO
                {
                    Price = "54 руб.",
                    Order = "Третий заказ. Тут блюда всякие"
                },
                new OrdersDTO
                {
                    Price = "54 руб.",
                    Order = "Третий заказ. Тут блюда всякие"
                },
                new OrdersDTO
                {
                    Price = "54 руб.",
                    Order = "Третий заказ. Тут блюда всякие"
                },
                new OrdersDTO
                {
                    Price = "54 руб.",
                    Order = "Третий заказ. Тут блюда всякие"
                }
            };

        }
        public async Task<List<OrdersDTO>> LoadOrders()
        {
            return Orders;
        }
    }
}
