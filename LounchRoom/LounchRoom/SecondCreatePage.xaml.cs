using LounchRoom.Core.VeiwModels.CreatePage;
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
    public partial class SecondCreatePage : ContentPage, ICreatePage
    {
        public SecondCreatePage()
        {
            InitializeComponent();

            var pageVM = new SecondCreatePageVM(this);
            this.BindingContext = pageVM;
        }

        public void ShowNextPage(string arg)
        {
            throw new NotImplementedException();
        }

        public void ShowPreviousPage()
        {
            throw new NotImplementedException();
        }
    }
}