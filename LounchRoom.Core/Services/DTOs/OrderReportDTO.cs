using System;
using System.Collections.Generic;
using System.Text;

namespace LounchRoom.Core.Services.DTOs
{
    public class OrderReportDTO
    {
        public int LunchSetUnits { get; set; }
        public string UserName { get; set; }
        public string LunchSetPrise { get; set; }
        public string OptionsPrice { get; set; }
        public decimal Summary { get; set; }
        public bool Payment { get; set; }
    }
}
