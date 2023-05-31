using LounchRoom.Core.VeiwModels.CreatePage;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LounchRoom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuExamplePage : ContentPage, IMenuExamplePage
    {

        public MenuExamplePage()
        {
            InitializeComponent();

            var pageVM = new MenuExamplePageVM(this);
            this.BindingContext = pageVM;
        }
    }
}
