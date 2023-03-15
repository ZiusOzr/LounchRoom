using LounchRoom.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace LounchRoom.Core.VeiwModels.MainPage
{
    public class MainPageVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<OrderItemVM> items;
        public ObservableCollection<OrderItemVM> Items
        {
            get
            {
                return items;
            }
            set
            {
                if (items != value)
                {
                    items = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));
                }
            }
        }

        public ICommand GoToTheMenuButton { get; set; }

        private IMainPage _mainPage;
        public MainPageVM(IMainPage mainPage)
        {
            _mainPage = mainPage;
            Items = new ObservableCollection<OrderItemVM>();
            GoToTheMenuButton = new Command(OnOrder);
            LoadOrders();
        }


        private async void LoadOrders()
        {
            try
            {
                var orders = await Context.OrdersService.LoadOrders();
                foreach (var item in orders)
                {
                    Items.Add(new OrderItemVM 
                    {
                        Price = item.Price,
                        Order = item.Order
                    });
                }
            }
            catch
            {
                Exception ex;
            }
        }

        private async void OnOrder()
        {
            try
            {
                _mainPage.ShowNextPage();
            }
            catch
            {
                Exception ex;
            }
        }

       
    }
}