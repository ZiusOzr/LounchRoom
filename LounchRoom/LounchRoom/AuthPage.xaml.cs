using LounchRoom.Core.VeiwModels.AuthPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LounchRoom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthPage : ContentPage, IAuthPage
    {
        public AuthPage()
        {
            InitializeComponent();

            var pageVM = new AuthPageVM(this);
            this.BindingContext = pageVM;

        }

        public void ShowNextPage()
        {
            this.Navigation.PopToRootAsync();
        }
    }
}