﻿using LounchRoom.Core.Services.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace LounchRoom.Core.Services.Implementations
{
    public class ConnectionService : IConnectionService
    {
        //public HttpClient Сlient = new HttpClient();
        public async Task<Result> GetRequest(string url)
        {
            try
            {
                using var client = new HttpClient();
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri(url);
                request.Method = HttpMethod.Get;
                var token = await SecureStorage.GetAsync("oauthToken");
                if (token != null)
                {
                    request.Headers.Add("Authorization", $"Bearer {token}");
                }
                var response = await client.SendAsync(request);
                var newJson = await response.Content.ReadAsStringAsync();
                var code = response.StatusCode;
                var reason = response.ReasonPhrase;
                var statusCode = new StatusCode
                {
                    Code = code,
                    Reason = reason
                };
                var result = new Result
                {
                    Json = newJson,
                    StatusCode = statusCode
                };
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result> PostRequest(string url, string json)
        {
            try
            {
                using var client = new HttpClient();
                var request = new HttpRequestMessage();
                if (json != null)
                {
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    request.Content = content;
                }
                

                
                request.RequestUri = new Uri(url);
                request.Method = HttpMethod.Post;
                request.Headers.Add("accept", "application/json");
                var token = await SecureStorage.GetAsync("oauthToken");
                if (token != null)
                {
                    request.Headers.Add("Authorization", $"Bearer {token}");
                }
                
                
                var response = await client.SendAsync(request);
                var newJson = await response.Content.ReadAsStringAsync();
                var code = response.StatusCode;
                var reason = response.ReasonPhrase;
                var statusCode = new StatusCode
                {
                    Code = code,
                    Reason = reason
                };
                var result = new Result
                {
                    Json = newJson,
                    StatusCode = statusCode
                };
                return result;
            }
            catch
            {
                return new Result
                {
                    Json = null,
                    StatusCode =
                    {
                        Code = System.Net.HttpStatusCode.Conflict,
                        Reason = "Unckown error"
                    }
                };
            }
        }

        
    }
}
