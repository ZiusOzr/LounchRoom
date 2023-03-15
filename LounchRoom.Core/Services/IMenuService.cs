using LounchRoom.Core.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LounchRoom.Core.Services
{
    public interface IMenuService
    {
        Task<List<MenuDTO>> LoadMenu();
    }
}
