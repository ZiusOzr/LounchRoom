using LounchRoom.Core.VeiwModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace LounchRoom.Core.Services.DTOs
{
    public class AvailableKitchensDTO
    {
        public string KitchenId { get; set; }
        public string OrganizationName { get; set; }
        public string Address { get; set; }
        public Contacts Contacts { get; set; }
        public KitchenSettingsDTO Settings { get; set; }
    }

    public class Contacts
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        
    }
}
