using System;
using System.Collections.Generic;
using System.Text;

namespace LounchRoom.Core.VeiwModels.CreatePage
{
    public interface ICreatePage
    {
        public void ShowNextPage(string arg);
        public void ShowPreviousPage();
        public void ShowDisplayAlert(string time, string updateMenu);
    }
}
