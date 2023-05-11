using LounchRoom.Core.Services.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace LounchRoom.Core.Services.Implementations
{
    public class LoginService : ILoginService
    {

        public async Task<HttpStatusCode> Login(string login, string password)
        {
            var userLoginDTO = new UserLoginDTO
            {
                Email = login,
                Password = password
            };
            var json = JsonConvert.SerializeObject(userLoginDTO);
            /*var client = new AuthClient(new System.Net.Http.HttpClient());
            try
            {
                var token = await client.AuthAsync(userLoginDTO);
                await SecureStorage.SetAsync("oauthToken", token);
                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return HttpStatusCode.BadRequest;
            }*/


            var response = await Context.Connection.PostRequest("https://api.lunchroom66.ru/api/Auth/Auth", json);

            if (response.StatusCode.Code == HttpStatusCode.OK)
            {
                try 
                {
                    var token = JsonConvert.DeserializeObject<string>(response.Json);
                    await SecureStorage.SetAsync("oauthToken", token);
                    return response.StatusCode.Code;
                }
                catch
                {
                    throw new Exception("Unckown error"); //Нельзя выбрасывать
                }
            }
            else
            {
                return response.StatusCode.Code;
            }
        }
    }
}
