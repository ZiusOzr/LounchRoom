using LounchRoom.Core.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LounchRoom.Core.Services
{
    public interface IUpdateService
    {
        public Task<HttpStatusCode> Update(UserForCreationDTO user);
    }
}
