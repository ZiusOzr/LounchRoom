using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using LounchRoom.Core.Services;
using LounchRoom.Core.VeiwModels.LoginPage;
using Newtonsoft.Json;
using Xamarin.Essentials;

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

        private string passEntryText;
        public string PassEntryText
        {
            get
            {
                return passEntryText;
            }
            set
            {
                passEntryText = value;
            }
        }

        public ICommand LoginButton { get; set; }
        public ICommand RegisterButton { get; set; }


        private ILoginPage _loginPage;
        public LoginPageVM(ILoginPage loginPage)
        {
            _loginPage = loginPage;
            LoginButton = new Command(LoginButtonExecute);
            RegisterButton = new Command(RegisterButtonExecute);

        }

        private bool passIsInvalid;
        public bool PassIsInvalid
        {
            get { return passIsInvalid; }
            set
            {
                if (passIsInvalid == value)
                    return;

                passIsInvalid = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PassIsInvalid)));
            }
        }

        private async void LoginButtonExecute()
        {
          ////  var login = loginEntryText;
           // var password = passEntryText;
            var login = "string";
            var password = "string";
            var code = await Context.LoginService.Login(login, password);
            
            if (code == System.Net.HttpStatusCode.OK)
            {
                _loginPage.ShowNextPage("login");
            }
            else
            {
                PassIsInvalid = true; //Затычка
                //Требуется понятный вывод ошибок
            }
        }

        private void RegisterButtonExecute()
        {
            _loginPage.ShowNextPage("signin");
        }
    }
}
