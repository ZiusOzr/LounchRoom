using System;
using System.Collections.Generic;
using System.Text;

namespace LounchRoom.Core.Services
{
    public static class Context
    {
        public static ILoginService LoginService = Service<ILoginService>.GetInstence();
    }
}
