using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LounchRoom.Core.Services.DTOs
{
    public class UserGroupDTO : INotifyPropertyChanged
    {
        public string  GroupId { get; set; }
        public string GroupName { get; set; }
        public string TextColor { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }
    }
}
