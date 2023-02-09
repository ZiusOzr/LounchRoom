using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using LounchRoom.Core.Services;
using LounchRoom.Core.VeiwModels.LoginPage;

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


        private ILoginPage _loginPage;
        public LoginPageVM(ILoginPage loginPage)
        {
            _loginPage = loginPage;
            LoginButton = new Command(LoginButtonExecute);

        }

        private async void LoginButtonExecute()
        {
            var login = LoginEntryText;

            try 
            {
                //TODO: работа с лоадинг идентификатором
                var user = await Context.LoginService.Login(login);
                _loginPage.ShowNextPage();
            }
            catch
            {
                Exception exception;
                //TODO: Подтверждение почты
            }
        }
    }
}
