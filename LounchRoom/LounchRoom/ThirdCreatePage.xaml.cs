using LounchRoom.Core.VeiwModels.CreatePage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LounchRoom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThirdCreatePage : ContentPage, ICreatePage
    {
        public ThirdCreatePage()
        {
            InitializeComponent();

            var pageVM = new ThirdCreatePageVM(this);
            this.BindingContext = pageVM;

            pageVM.PropertyChanged += PageVM_PropertyChanged_EntryText;
        }

        private void PageVM_PropertyChanged_EntryText(object sender, PropertyChangedEventArgs e)
        {
            var pageVM = BindingContext as ThirdCreatePageVM;

            if (e.PropertyName == nameof(pageVM.ReferalLink))
            {
                referalLink.Text = pageVM.ReferalLink;
            }
        }

        public void ShowDisplayAlert(string time, string updateMenu, decimal? price)
        {
            throw new NotImplementedException();
        }

        public void ShowNextPage(string arg)
        {
            switch (arg)
            {
                case "Контроль заказов": 
                    Navigation.PushAsync(new OrderControlPage());
                    break;
                case "Редактировать группу":
                    Navigation.PushAsync(new FirstCreatePage());
                    break;
            }
            
        }

        public void ShowPreviousPage()
        {
            throw new NotImplementedException();
        }
    }
}