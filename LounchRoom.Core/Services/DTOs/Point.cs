using System;
using System.Collections.Generic;
using System.Text;

namespace LounchRoom.Core.Services.DTOs
{
    public class Point
    {
        public string Type { get; set; }
        public List<float> Coordinates { get; set; }
    }
}
