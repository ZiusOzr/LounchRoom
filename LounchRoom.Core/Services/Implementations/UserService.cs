using LounchRoom.Core.Services.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;


namespace LounchRoom.Core.Services.Implementations
{
    public class UserService : IUserServiсe
    {
        public async Task<UserDTO> Load()
        {
            var response = await Context.Connection.GetRequest("https://api.lunchroom66.ru/api/User/GetUser");
            if (response.StatusCode.Code == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    var userDTO = JsonConvert.DeserializeObject<UserDTO>(response.Json);
                    return userDTO;
                }
                catch 
                { 
                    throw new Exception("Unknow error"); //Нельзя выбрасывать
                }
            }
            else 
            {
                throw new Exception("Unknow error"); //Нельзя выбрасывать
            }
        }

        public async Task<ObservableCollection<UserGroupDTO>> LoadGroupList()
        {
            var response = await Context.Connection.GetRequest("https://api.lunchroom66.ru/api/User/GetUser");
            if (response.StatusCode.Code == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    var fake = new UserGroupDTO() { GroupId = "1", GroupName = "group 1" };
                    var fake2 = new UserGroupDTO() { GroupId = "2", GroupName = "group 2" };

                    // var userGroupDTO = JsonConvert.DeserializeObject<ObservableCollection<UserGroupDTO>>(response.Json);
                    var t = new ObservableCollection<UserGroupDTO>();
                    t.Add(fake);
                    t.Add(fake2);
                    return t;
                }
                catch
                {
                    throw new Exception("Unknow error"); //Нельзя выбрасывать
                }
            }
            else
            {
                throw new Exception("Unknow error"); //Нельзя выбрасывать
            }
        }
    }
}
