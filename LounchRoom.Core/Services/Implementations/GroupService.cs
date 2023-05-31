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
            var response = await Context.Connection.PostRequest("https://api.lunchroom66.ru/api/Group/ConfigurePaymentInfo?groupId=" + Id, json);
            return response.StatusCode.Code;
        }

        public async Task<ObservableCollection<AvailableKitchensDTO>> GetAllowedKitchens(string groupToken)
        {
            
            var response = await Context.Connection.GetRequest($"https://api.lunchroom66.ru/api/Group/GetAvailableKitchens?groupId={groupToken}");
            if (response.StatusCode.Code == HttpStatusCode.OK)
            {
                try
                {
                    var allowedKitchens = JsonConvert.DeserializeObject<ObservableCollection<AvailableKitchensDTO>>(response.Json);
                    return allowedKitchens;
                }
                catch (Exception ex)
                {
                    throw ex; //Нельзя выбрасывать
                }
            }
            else
            {
                throw new Exception("Unknow error"); //Нельзя выбрасывать
            }
        }

        public async Task<HttpStatusCode> ConfigureGroupLocation(GroupConfigByAddressDTO address)
        {
            var json = JsonConvert.SerializeObject(address);
            var response = await Context.Connection.PostRequest("https://api.lunchroom66.ru/api/Group/ConfigureGroupLocation", json);
            return response.StatusCode.Code;
        }

        public async Task<HttpStatusCode> SetActiveKitchen(string groupToken, string kitchenToken)
        {
            var response = await Context.Connection.PostRequest($"https://api.lunchroom66.ru/api/Group/SetActiveKitchen?groupId={groupToken}&kitchenId={kitchenToken}", null);
            return response.StatusCode.Code;
        }

        public async Task<GroupDTO> GetGroupInfo(string token)
        {
            var response = await Context.Connection.GetRequest($"https://api.lunchroom66.ru/api/Group/GetGroup?groupId={token}");
            if (response.StatusCode.Code == HttpStatusCode.OK)
            {
                var DTO = JsonConvert.DeserializeObject<GroupDTO>(response.Json);
                return DTO;
            }
            else
            {
                throw new Exception("Unknow");
            }
        }
    }
}
