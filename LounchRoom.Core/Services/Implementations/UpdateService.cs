using LounchRoom.Core.Services.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace LounchRoom.Core.Services.Implementations
{
    public class UpdateService : IUpdateService
    {
        //UserClient client = new UserClient(new System.Net.Http.HttpClient());
        //HttpRequestMessage request = new HttpRequestMessage();

        public async Task<HttpStatusCode> Update(UserForCreationDTO user)
        {
            var json = JsonConvert.SerializeObject(user);
            var response = await Context.Connection.PostRequest("https://api.lunchroom66.ru/api/User/UpdateUser", json);
            return response.StatusCode.Code;

            /*try
            {
                var token = await SecureStorage.GetAsync("oauthToken");
                if (token != null)
                {
                    request.Headers.Add("Authorization", $"Bearer {token}");
                }
                var response = await client.UpdateUserAsync(user);
                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return HttpStatusCode.BadRequest;
            }*/
        }
    }
}
