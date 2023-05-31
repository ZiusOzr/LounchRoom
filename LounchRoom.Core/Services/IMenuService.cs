using LounchRoom.Core.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace LounchRoom.Core.Services
{
    public interface IMenuService
    {
        public Task<MenuDTO> LoadMenu(string groupId);
        public Task<MenuDTO> GetMenuByDateForKitchen(string kitchenId);
    }
}
