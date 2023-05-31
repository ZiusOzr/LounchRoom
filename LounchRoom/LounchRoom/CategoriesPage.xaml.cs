using LounchRoom.Core.Services;
using LounchRoom.Core.VeiwModels.MenuPage;
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
    public partial class CategoriesPage : ContentPage, ICategoriesPage
    {
        public CategoriesPage()
        {
            InitializeComponent();

            var pageVM = new CategoriesPageVM(this);
            this.BindingContext = pageVM;
        }

        public void ShowNextPage()
        {
            throw new Exception();
        }
    }
}