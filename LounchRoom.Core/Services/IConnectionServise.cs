using LounchRoom.Core.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LounchRoom.Core.Services
{
    public interface IConnectionService
    {
        public Task<Result> GetRequest(string url);
        public Task<Result> PostRequest(string url, string json);
    }
}
