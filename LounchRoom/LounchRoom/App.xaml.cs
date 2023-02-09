using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using LounchRoom.Core.Services;
using LounchRoom.Core.Services.Fakes;
using LounchRoom.Core.Services.Implementations;

namespace LounchRoom
{
    public partial class App : Application
    {
        public App()
        {
            RegisterServices(true);
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
            var np = Application.Current.MainPage as NavigationPage;
            np.BarBackgroundColor = Color.White;
            
        }

        private void RegisterServices(bool enableFakes)
        {
            if (enableFakes)
                Service<ILoginService>.Register(new FakeLoginService());
            else Service<ILoginService>.Register(new LoginService());


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
