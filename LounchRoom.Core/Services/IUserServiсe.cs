using LounchRoom.Core.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace LounchRoom.Core.Services
{
    public interface IUserServiсe
    {
        public Task<UserDTO> Load(string UserId);
        public Task<ObservableCollection<UserGroupDTO>> LoadGroupList();
        //public Task LoadGroupList();
    }
}
