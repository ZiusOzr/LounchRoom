using System.Collections.Generic;
using Xamarin.Forms.Shapes;

namespace LounchRoom.Core.Services.DTOs
{
    public class KitchenSettingsDTO
    {
        public string LimitingTimeForOrder { get; set; }
        public MenuUpdatePeriod MenuUpdatePeriod { get; set; }
        public MenuFormat MenuFormat { get; set; }
        public decimal? MinAmountForSharedOrder { get; set; }
        public List<ShippingArea> ShippingAreas { get; set; }
    }

    public class ShippingArea
    {
        public Polygon Polygon { get; set; }
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