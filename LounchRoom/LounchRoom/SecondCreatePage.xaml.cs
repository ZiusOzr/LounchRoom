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

        public async void ShowDisplayAlert(string time, string updateMenu, decimal? price)
        {
            await DisplayAlert("Условия заказа", $"Крайнее время заказа: {time}\nМеню обновляется: {updateMenu}\nМинимальная сумма заказа: {price}", "Назад");
        }

        public void ShowNextPage(string arg)
        {
            switch (arg)
            {
                case "Next":
                    this.Navigation.PushAsync(new ThirdCreatePage());
                    break;
                case "Menu":
                    this.Navigation.PushAsync(new MenuExamplePage());
                    break;
            }

            
        }

        public void ShowPreviousPage()
        {
            this.Navigation.PopAsync();
        }
    }
}