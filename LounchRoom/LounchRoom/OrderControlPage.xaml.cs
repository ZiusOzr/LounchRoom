using LounchRoom.Core.VeiwModels.OrderControlPage;
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
    public partial class OrderControlPage : ContentPage, IOrderControlPage
    {
        public OrderControlPage()
        {
            InitializeComponent();

            var pageVM = new OrderControlPageVM(this);
            this.BindingContext = pageVM;

            PropertyChanged += OrdersReport_Property;
        }

        private void OrdersReport_Property(object sender, PropertyChangedEventArgs e)
        {
            var pageVM = BindingContext as OrderControlPageVM;
            if (e.PropertyName == nameof(pageVM.OrderItems))
            {
                orderReportList.ItemsSource = pageVM.OrderItems;
            }
        }

        void OnDateSelected(object sender, DateChangedEventArgs args)
        {
            var pageVM = BindingContext as OrderControlPageVM;

            pageVM.Date = datePicker.Date;
        }
    }
}