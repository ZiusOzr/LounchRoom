using LounchRoom.Core.VeiwModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LounchRoom
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            
            this.BindingContext = new LoginPageVM();
        }

        private void loginButtonClicked(object sebder, EventArgs e)
        {
            this.Navigation.PushAsync(new AuthPage());
        }
    }
}
