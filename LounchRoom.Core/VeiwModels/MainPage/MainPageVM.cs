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
        private ObservableCollection<OrderItemVM> _items = new ObservableCollection<OrderItemVM>();

        public ObservableCollection<OrderItemVM> Items
        {
            get => _items;
            set
            {
                if (_items != value)
                {
                    _items = value;
                    PropertyChanged?.Invoke(Items, new PropertyChangedEventArgs(nameof(Items)));
                }
            }
        }

        public ICommand MakeAnOrderButton { get; set; }

        public MainPageVM()
        {
            LoadOrders();

            Items = new ObservableCollection<OrderItemVM>()
            {
                new OrderItemVM
                {
                    Price = "346 руб.",
                    Order = "Первый заказ. Тут блюда всякие"
                },
                new OrderItemVM
                {
                    Price = "651 руб.",
                    Order = "Второй заказ. Тут блюда всякие"
                },
                new OrderItemVM
                {
                    Price = "54 руб.",
                    Order = "Третий заказ. Тут блюда всякие"
                }
            };

            MakeAnOrderButton = new Command(OnOrder);
        }


        private void LoadOrders()
        {
            //TODO: Загрузка заказов
        }

        private void OnOrder()
        {
            //TODO 
            Console.WriteLine("OnOrder");
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}