using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using LounchRoom.Core.Services;
using LounchRoom.Core.Services.Implementations;

namespace LounchRoom
{
    public partial class App : Application
    {
        public App()
        {
            RegisterServices();
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
            
            
        }

        private void RegisterServices()
        {
            Service<ILoginService>.Register(new LoginService());
            Service<ISigninService>.Register(new SigninService());
            Service<IOrdersService>.Register(new OrdersService());
            Service<IMenuService>.Register(new MenuService());
            Service<IConnectionService>.Register(new ConnectionService());
            Service<IUpdateService>.Register(new UpdateService());
            Service<IUserServiсe>.Register(new UserService());
            Service<IGroupService>.Register(new GroupService());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
