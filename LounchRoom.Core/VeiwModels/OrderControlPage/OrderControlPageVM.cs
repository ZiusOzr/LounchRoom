using LounchRoom.Core.Services;
using LounchRoom.Core.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;

namespace LounchRoom.Core.VeiwModels.OrderControlPage
{
    public class OrderControlPageVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string groupName;
        public string GroupName
        {
            get
            {
                return groupName;
            }
            set
            {
                groupName = value;
            }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set 
            {
                if (date == value)
                    return;

                date = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Date)));
            }
        }

        private ObservableCollection<OrderReportDTO> orderItems;
        public ObservableCollection<OrderReportDTO> OrderItems
        {
            get
            {
                return orderItems;
            }
            set
            {
                if (orderItems != value)
                {
                    orderItems = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OrderItems)));
                }
            }
        }

        public ICommand EditGroup { get; set; }
        public ICommand OnDate { get; set; }

        private IOrderControlPage _orderControlPage;
        public OrderControlPageVM(IOrderControlPage orderControlPage)
        {
            _orderControlPage = orderControlPage;

            LoadGroup();

            PropertyChanged += DateChanged_PropertyChanged;
        }

        private async void DateChanged_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var groupToken = await SecureStorage.GetAsync("activeGroupToken");
            var orderList = await Context.OrdersService.GetOrdersReportByDay(Date, groupToken);
            OrderItems = orderList;
        }

        private async void LoadGroup()
        {
            var groupToken = await SecureStorage.GetAsync("activeGroupToken");
            var group = await Context.GroupService.GetGroupInfo(groupToken);
            GroupName = group.OrganizationName;
        }
    }
}
