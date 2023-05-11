using LounchRoom.Core.VeiwModels.SigninPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LounchRoom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SigninPage : ContentPage, ISigninPage
    {
        public SigninPage()
        {
            InitializeComponent();

            SetState();
            var pageVM = new SigninPageVM(this);
            this.BindingContext = pageVM;

            pageVM.PropertyChanged += PageVM_PropertyChanged;
        }

        private void PageVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var pageVM = BindingContext as SigninPageVM;
            if (e.PropertyName == nameof(pageVM.PassIsInvalid))
            {
                VisualStateManager.GoToState(loginFrame, pageVM.PassIsInvalid ? "Invalid" : "Normal");
                VisualStateManager.GoToState(passFrame, pageVM.PassIsInvalid ? "Invalid" : "Normal");
                VisualStateManager.GoToState(loginEntry, pageVM.PassIsInvalid ? "Invalid" : "Normal");
                VisualStateManager.GoToState(passEntry, pageVM.PassIsInvalid ? "Invalid" : "Normal");
                VisualStateManager.GoToState(confirmationPassFrame, pageVM.PassIsInvalid ? "Invalid" : "Normal");
                VisualStateManager.GoToState(confirmationPassEntry, pageVM.PassIsInvalid ? "Invalid" : "Normal");
            }
        }
        private void SetState()
        {
            VisualStateManager.GoToState(loginFrame, "Normal");
            VisualStateManager.GoToState(passFrame, "Normal");
            VisualStateManager.GoToState(loginEntry, "Normal");
            VisualStateManager.GoToState(passEntry, "Normal");
            VisualStateManager.GoToState(confirmationPassFrame, "Normal");
            VisualStateManager.GoToState(confirmationPassEntry, "Normal");
            VisualStateManager.GoToState(registerButton, "GreenButton");
        }

        public void ShowNextPage()
        {
            this.Navigation.PushAsync(new AuthPage());
        }
    }
}