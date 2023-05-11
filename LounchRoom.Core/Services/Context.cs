using System;
using System.Collections.Generic;
using System.Text;

namespace LounchRoom.Core.Services
{
    public static class Context
    {
        public static ILoginService LoginService = Service<ILoginService>.GetInstence();
        public static ISigninService SigninService = Service<ISigninService>.GetInstence();
        public static IOrdersService OrdersService = Service<IOrdersService>.GetInstence();
        public static IMenuService MenuService = Service<IMenuService>.GetInstence();
        public static IConnectionService Connection = Service<IConnectionService>.GetInstence();
        public static IUserServiсe UserService = Service<IUserServiсe>.GetInstence();
        public static IUpdateService UpdateService = Service<IUpdateService>.GetInstence();
        public static IGroupService GroupService = Service<IGroupService>.GetInstence();
    }
}
