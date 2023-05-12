using System;
using System.Collections.Generic;
using System.Text;

namespace LounchRoom.Core.Services.DTOs
{
    public class GroupDTO
    {
        public string Id { get; set; }
        public UserDTO Admin { get; set; }
        public string OrganizationName { get; set; }
        public List<Guid> Members { get; set; }
        public GroupReferral Referral { get; set; }
        public GroupKitchenSettingsDTO Settings { get; set; }
        public PaymentInfoDTO PaymentInfo { get; set; }
        public string SelectedKitchenId { get; set; }
    }

    public class GroupReferral
    {
        public string Token { get; set; }
    }
}
