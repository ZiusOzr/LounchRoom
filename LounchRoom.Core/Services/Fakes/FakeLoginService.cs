using LounchRoom.Core.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LounchRoom.Core.Services.Fakes
{
    public class FakeLoginService : ILoginService
    {
        UserDTO userDTO;
        public FakeLoginService()
        {
            userDTO = new UserDTO
            {
                Id = 1,
                Login = "zxc",
                Name = "Name",
                LastName = "LastName"
            };
        }

        async Task<UserDTO> ILoginService.Login(string login)
        {
            return (login == "zxc") ? userDTO : throw new Exception("Почта не подтверждена. *переход на экран подтверждения*");
        }
    }
}
