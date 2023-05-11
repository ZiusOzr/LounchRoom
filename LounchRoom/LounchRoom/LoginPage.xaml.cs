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

            SetState();
            var pageVM = new LoginPageVM(this);
            this.BindingContext = pageVM;

            pageVM.PropertyChanged += PageVM_PropertyChanged;
        }

        private void PageVM_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var pageVM = BindingContext as LoginPageVM;
            if (e.PropertyName == nameof(pageVM.PassIsInvalid))
            {
                VisualStateManager.GoToState(loginEntry, pageVM.PassIsInvalid ? "Invalid" : "Normal");
                VisualStateManager.GoToState(passEntry, pageVM.PassIsInvalid ? "Invalid" : "Normal");
                VisualStateManager.GoToState(loginFrame, pageVM.PassIsInvalid ? "Invalid" : "Normal");
                VisualStateManager.GoToState(passFrame, pageVM.PassIsInvalid ? "Invalid" : "Normal");

            }
        }

        private void SetState()
        {
            VisualStateManager.GoToState(loginEntry, "Normal");
            VisualStateManager.GoToState(passEntry, "Normal");
            VisualStateManager.GoToState(loginFrame, "Normal");
            VisualStateManager.GoToState(passFrame, "Normal");
            VisualStateManager.GoToState(loginButton, "GreenButton");
            VisualStateManager.GoToState(registerButton, "LightGreenButton");
        }

        public void ShowNextPage(string arg)
        {
            switch (arg)
            {
                case "login": 
                    this.Navigation.PushAsync(new ProfilePage());
                    break;
                case "signin": 
                    this.Navigation.PushAsync(new SigninPage());
                    break;
                case "auth":
                    this.Navigation.PushAsync(new AuthPage());
                    break;
            }
        }
    }
}
