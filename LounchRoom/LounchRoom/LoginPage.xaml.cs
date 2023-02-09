using LounchRoom.Core.VeiwModels;
using LounchRoom.Core.VeiwModels.LoginPage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LounchRoom
{
    public partial class LoginPage : ContentPage, ILoginPage
    {
        public LoginPage()
        {
            InitializeComponent();
            
            this.BindingContext = new LoginPageVM(this);
        }

        public void ShowNextPage()
        {
            this.Navigation.PushAsync(new MainPage());
        }

    }
}
