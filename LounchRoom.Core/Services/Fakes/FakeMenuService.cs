using LounchRoom.Core.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LounchRoom.Core.Services.Fakes
{
    public class FakeMenuService : IMenuService
    {
        public List<MenuDTO> Dishes;
        public FakeMenuService()
        {
            Dishes = new List<MenuDTO>()
            {
                new MenuDTO
                {
                    Price = "10 руб.",
                    Dish = "Первое блюдо"
                },
                new MenuDTO
                {
                    Price = "62 руб.",
                    Dish = "Второе блюдо"
                },
                new MenuDTO
                {
                    Price = "12 руб.",
                    Dish = "Третье блюдо"
                },
                new MenuDTO
                {
                    Price = "62 руб.",
                    Dish = "Четвертое блюдо"
                },
                new MenuDTO
                {
                    Price = "51 руб.",
                    Dish = "Пятое блюдо"
                }
            };

        }
        public async Task<List<MenuDTO>> LoadMenu()
        {
            return Dishes;
        }
    }
}
