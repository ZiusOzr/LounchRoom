using LounchRoom.Core.Services.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace LounchRoom.Core.Services.Implementations
{
    public class MenuService : IMenuService
    {
        public async Task<MenuDTO> GetMenuByDateForKitchen(string kitchenId)
        {
            var response = await Context.Connection.GetRequest($"https://api.lunchroom66.ru/api/Menu/GetMenuByDateForKitchen?date={DateTime.Today}&kitchenId={kitchenId}");
            if (response.StatusCode.Code == System.Net.HttpStatusCode.OK)
            {
                var menu = JsonConvert.DeserializeObject<MenuDTO>(response.Json);
                return menu;
            }
            else
            {
                throw new Exception($"{response.StatusCode.Reason}");
            }
        }

        public async Task<MenuDTO> LoadMenu(string groupId)
        {
            var response = await Context.Connection.GetRequest($"https://api.lunchroom66.ru/api/Menu/GetTodayMenuForGroup?groupId={groupId}");
            if (response.StatusCode.Code == System.Net.HttpStatusCode.OK)
            {
                var menuDTO = JsonConvert.DeserializeObject<MenuDTO>(response.Json);
                return menuDTO;
            }
            else
            {
                throw new Exception("Unknown");
            }
        }
    }
}
