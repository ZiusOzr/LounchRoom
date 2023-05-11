using LounchRoom.Core.Services.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LounchRoom.Core.Services.Implementations
{
    public class SigninService : ISigninService
    {

        public async Task<HttpStatusCode> Signin(string login, string password)
        {
            var userRegisterDTO = new UserRegisterDTO
            {
                Email = login,
                Password = password,
                RoleDTO = 0
            };
            var json = JsonConvert.SerializeObject(userRegisterDTO);
            var response = await Context.Connection.PostRequest("https://api.lunchroom66.ru/api/Auth/RegisterUser", json);
            return response.StatusCode.Code;
            
        }
    }
}


