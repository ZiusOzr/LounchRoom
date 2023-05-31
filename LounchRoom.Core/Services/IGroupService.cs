using LounchRoom.Core.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LounchRoom.Core.Services
{
    public interface IGroupService
    {
        public Task<GroupDTO> Create(string name);
        public Task<HttpStatusCode> ConfigurePaymentInfo(string link, string description, string Id);
        public Task<ObservableCollection<AvailableKitchensDTO>> GetAllowedKitchens(string groupToken);
        public Task<HttpStatusCode> ConfigureGroupLocation(GroupConfigByAddressDTO address);
        public Task<HttpStatusCode> SetActiveKitchen(string groupToken, string kitchenToken);
        public Task<GroupDTO> GetGroupInfo(string groupToken);
    }
}
