using System;
using System.Collections.Generic;
using System.Text;

namespace LounchRoom.Core.Services.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public bool IsEmailChecked { get; set; }
        public bool NameFill { get; set; }
        public string Phone { get; set; }
        public List<string> Groups { get; set; }
        public List<string> Kitchens { get; set; }
    }
}



