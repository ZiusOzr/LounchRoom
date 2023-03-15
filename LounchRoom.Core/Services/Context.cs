using System;
using System.Collections.Generic;
using System.Text;

namespace LounchRoom.Core.Services
{
    public static class Context
    {
        public static ILoginService LoginService = Service<ILoginService>.GetInstence();
        public static IOrdersService OrdersService = Service<IOrdersService>.GetInstence();
        public static IMenuService MenuService = Service<IMenuService>.GetInstence();
    }
}
