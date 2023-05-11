﻿using LounchRoom.Core.Services.DTOs;
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
        public Task<HttpStatusCode> ConfigureKitchen(string address, string Id);
        public Task<HttpStatusCode> ConfigurePaymentInfo(string link, string description, string Id);
        public Task<ObservableCollection<AvailableKitchensDTO>> GetAllowedKitchens();
    }
}