using System.Collections.Generic;

namespace LounchRoom.Core.Services.DTOs
{
    public class KitchenSettingsDTO
    {
        public string LimitingTimeForOrder { get; set; }
        public MenuUpdatePeriod MenuUpdatePeriod { get; set; }
        public MenuFormat MenuFormat { get; set; }
        public List<ShippingArea> ShippingAreas { get; set; }
    }

    public class ShippingArea
    {
        public Polygon Polygon { get; set; }
    }

    public class Polygon
    {
        public string Type { get; set; }
        public List<List<List<int>>> Coordinates { get; set; }
    }

    public enum MenuFormat
    {
        Text = 0,
        Exel = 1
    }

    public enum MenuUpdatePeriod
    {
        Daily = 0,
        Weekly = 1
    }
}