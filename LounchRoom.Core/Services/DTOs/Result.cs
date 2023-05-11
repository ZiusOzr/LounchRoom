using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace LounchRoom.Core.Services.DTOs
{
    public class Result
    {
        public string Json { get; set; }
        public StatusCode StatusCode { get; set; }
    }

    public class StatusCode
    {
        public HttpStatusCode Code { get; set; }
        public string Reason { get; set; }
    }

    
}
