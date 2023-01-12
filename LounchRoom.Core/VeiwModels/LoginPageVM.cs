using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;

namespace LounchRoom.Core.VeiwModels
{
    public class LoginPageVM  : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string loginEntryText;
        public string LoginEntryText 
        {
            get 
            {
                return loginEntryText;
            }
            set 
            {
                loginEntryText = value;
            } 
        }

        public ICommand LoginButton { get; set; }

        public LoginPageVM()
        {
            LoginButton = new Command(LoginButtonExecute);

        }

        private void LoginButtonExecute()
        {
            var login = LoginEntryText;
        }
    }
}
