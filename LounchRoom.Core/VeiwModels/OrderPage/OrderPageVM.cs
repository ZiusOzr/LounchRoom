using LounchRoom.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace LounchRoom.Core.VeiwModels.OrderPage
{
    public class OrderPageVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IOrderPage _orderPage;
        public OrderPageVM(IOrderPage orderPage)
        {
            _orderPage = orderPage;
            MenuItems = new ObservableCollection<MenuItemVM>();
            PayButton = new Command(ToPay);
            LoadMenu();
        }

        private ObservableCollection<MenuItemVM> menuItems;
        public ObservableCollection<MenuItemVM> MenuItems
        {
            get
            {
                return menuItems;
            }
            set
            {
                if (menuItems != value)
                {
                    menuItems = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MenuItems)));
                }
            }
        }

        public ICommand PayButton { get; set; }

        private async void ToPay()
        {
            try
            {
                _orderPage.ShowNextPage();
            }
            catch
            {
                Exception ex;
            }
        }

        private async void LoadMenu()
        {
            try
            {
                var menu = await Context.MenuService.LoadMenu();
                foreach (var item in menu)
                {
                    MenuItems.Add(new MenuItemVM
                    {
                        Price = item.Price,
                        Dish = item.Dish
                    });
                }
            }
            catch
            {
                Exception ex;
            }
        }
    }
}
