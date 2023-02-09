using LounchRoom.Core.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LounchRoom.Core.Services.Implementations
{
    public class LoginService : ILoginService
    {

        Task<UserDTO> ILoginService.Login(string login)
        {
            throw new NotImplementedException();
        }
    }
}
