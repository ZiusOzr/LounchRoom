using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LounchRoom.Core.VeiwModels.AuthPage
{
    public class AuthPageVM
    {
        public ICommand СonfirmationButton { get; set; }

        private IAuthPage _authPage;
        public AuthPageVM(IAuthPage authPage)
        {
            _authPage = authPage;
            СonfirmationButton = new Command(СonfirmationButtonExecute);

        }

        private void СonfirmationButtonExecute()
        {
            _authPage.ShowNextPage();
        }
    }
}
