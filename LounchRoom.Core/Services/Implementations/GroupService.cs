using LounchRoom.Core.Services.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LounchRoom.Core.Services.Implementations
{
    public class GroupService : IGroupService
    {
        public async Task<GroupDTO> Create(string name)
        {
            var groupForCreateDTO = new GroupForCreationDTO
            {
                OrganizationName = name
            };
            var json = JsonConvert.SerializeObject(groupForCreateDTO);
            var response = await Context.Connection.PostRequest("https://api.lunchroom66.ru/api/Group/Create", json);
            if (response.StatusCode.Code == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    var groupDTO = JsonConvert.DeserializeObject<GroupDTO>(response.Json);
                    return groupDTO;
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

        public async Task<HttpStatusCode> ConfigureKitchen(string address, string Id)
        {
            //to do: получить координаты
            var groupConfigDTO = new GroupConfigDTO
            {
                Address = address,
                GroupId = Id,
                Location = new Point
                {
                    Type = "Point",
                    //Coordinates =
                }
            };
            var json = JsonConvert.SerializeObject(groupConfigDTO);
            var response = await Context.Connection.PostRequest("", json);
            return response.StatusCode.Code;

        }

        public async Task<HttpStatusCode> ConfigurePaymentInfo(string link, string description, string Id)
        {
            var qr = Convert.ToBase64String(Encoding.UTF8.GetBytes(link));
            var paymentInfoDTO = new PaymentInfoDTO
            {
                GroupId = Id,
                Link = link,
                Description = description,
                Qr = qr
            };
            var json = JsonConvert.SerializeObject(paymentInfoDTO);
            var response = await Context.Connection.PostRequest("https://api.lunchroom66.ru/api/Group/ConfigurePaymentInfo", json);
            return response.StatusCode.Code;
        }

        public async Task<ObservableCollection<AvailableKitchensDTO>> GetAllowedKitchens()
        {
            var response = await Context.Connection.GetRequest("https://api.lunchroom66.ru/api/Group/GetAllowedKitchens", "activeGroupToken");
            if (response.StatusCode.Code == HttpStatusCode.OK)
            {
                try
                {
                    var allowedGroups = JsonConvert.DeserializeObject<ObservableCollection<AvailableKitchensDTO>>(response.Json);
                    return allowedGroups;
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

        public async Task<HttpStatusCode> SetActiveKitchen(string groupToken, string kitchenToken)
        {
            throw new Exception();
        }
    }
}
