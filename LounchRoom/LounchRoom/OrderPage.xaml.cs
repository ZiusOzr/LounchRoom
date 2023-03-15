using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LounchRoom.Core.VeiwModels.OrderPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LounchRoom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage, IOrderPage
    {
        public OrderPage()
        {
            InitializeComponent();
            this.BindingContext = new OrderPageVM(this);
        }

        public void ShowNextPage()
        {
            //TODO: Переход на страницу оплаты
            throw new NotImplementedException();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //Надо скрыть анимацию выбора

            ((ListView)sender).SelectedItem = null;
        }
    }
}