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
        private ObservableCollection<OrderItemVM> items;
        public ObservableCollection<OrderItemVM> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
            }
        }

        public MainPageVM()
        {
            LoadOrders();

            Items = new ObservableCollection<OrderItemVM>()
            {
                new OrderItemVM
                {
                    Prise = "346 руб.",
                    Order = "Первый заказ. Тут блюда всякие"
                },
                new OrderItemVM
                {
                    Prise = "651 руб.",
                    Order = "Второй заказ. Тут блюда всякие"
                },
                new OrderItemVM
                {
                    Prise = "54 руб.",
                    Order = "Третий заказ. Тут блюда всякие"
                }
            };


        }


        private void LoadOrders()
        {
            //TODO: Загрузка заказов
        }

        public event PropertyChangedEventHandler PropertyChanged;




    }
}
