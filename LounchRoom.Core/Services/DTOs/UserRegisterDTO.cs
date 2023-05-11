using System;
using System.Collections.Generic;
using System.Text;

namespace LounchRoom.Core.Services.DTOs
{
    public class UserRegisterDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public RoleDTO RoleDTO { get; set; }
    }

    public enum RoleDTO
    {
        Customer = 0,
        KitchenOperator = 1
    }
}
