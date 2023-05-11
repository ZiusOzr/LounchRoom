using System;
using System.Collections.Generic;
using System.Text;

namespace LounchRoom.Core.Services.DTOs
{
    public class UserForCreationDTO
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
    }
}
