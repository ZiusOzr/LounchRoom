using LounchRoom.Core.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LounchRoom.Core.Services
{
    public interface ISigninService
    {
        public Task<HttpStatusCode> Signin(string login, string password);
    }
}
