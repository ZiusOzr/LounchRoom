using LounchRoom.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace LounchRoom.Core.VeiwModels.SigninPage
{
    public class SigninPageVM : INotifyPropertyChanged
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

        private string сonfirmationPassEntryText;
        public string СonfirmationPassEntryText
        {
            get
            {
                return сonfirmationPassEntryText;
            }
            set
            {
                
                сonfirmationPassEntryText = value;
            }
        }

        private bool _passIsInvalid;
        public bool PassIsInvalid
        {
            get { return _passIsInvalid; }
            set
            {
                if (_passIsInvalid == value)
                    return;

                _passIsInvalid = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PassIsInvalid)));
            }
        }

        public ICommand RegisterButton { get; set; }

        private ISigninPage _signPage;
        public SigninPageVM(ISigninPage signinPage)
        {
            _signPage = signinPage;
            RegisterButton = new Command(RegisterButtonExecute);

        }

        private async void RegisterButtonExecute()
        {
            var login = LoginEntryText;
            var password = PassEntryText;
            var сonfirmationPass = СonfirmationPassEntryText;

            if (password == сonfirmationPass)
            {
                var user = await Context.SigninService.Signin(login, password);
                if (user == System.Net.HttpStatusCode.OK)
                {
                    _signPage.ShowNextPage();
                }
                else
                {
                    PassIsInvalid = true; //Затычка
                    //Требуется понятный вывод ошибок
                }
            }
            else
            {
                PassIsInvalid = true;
            }

            
        }
    }
}
