using LounchRoom.Core.Services;
using LounchRoom.Core.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;

namespace LounchRoom.Core.VeiwModels.CreatePage
{
    public class ThirdCreatePageVM : INotifyPropertyChanged
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

        private string kitchenName;
        public string KitchenName
        {
            get
            {
                return kitchenName;
            }
            set
            {
                kitchenName = value;
            }
        }

        private string referalLink;
        public string ReferalLink
        {
            get
            {
                return referalLink;
            }
            set
            {
                if (referalLink == value)
                    return;

                referalLink = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReferalLink)));
            }
        }

        private ObservableCollection<UserDTO> listParticipants;
        public ObservableCollection<UserDTO> ListParticipants
        {
            get { return listParticipants; }
            set { listParticipants = value; }
        }


        public ICommand ChooseKitchen { get; set; }
        public ICommand CopyLinkButton { get; set; }
        public ICommand EditPageButton { get; set; }
        public ICommand OrderControlPageButton { get; set; }

        private ICreatePage _thirdCreatePage;
        public ThirdCreatePageVM(ICreatePage thirdCreatePage)
        {
            _thirdCreatePage = thirdCreatePage;

            ChooseKitchen = new Command(ChooseKitchenExecute);
            CopyLinkButton = new Command(CopyLinkButtonExecute);
            EditPageButton = new Command(EditPageButtonExecute);
            OrderControlPageButton = new Command(OrderControlPageButtonExecute);
            LoadGroup();
        }

        private async void LoadGroup()
        {
            var groupToken = await SecureStorage.GetAsync("activeGroupToken");
            var group = await Context.GroupService.GetGroupInfo(groupToken);
            GroupName = group.OrganizationName;
            ReferalLink = group.Referral.Token;
            KitchenName = group.OrganizationName;
            foreach (var i in group.Members)
            {
                var user = await Context.UserService.Load(i);
                ListParticipants.Add(user);
            }
        }

        private async void CopyLinkButtonExecute()
        {
            await Clipboard.SetTextAsync(ReferalLink);
        }

        private void OrderControlPageButtonExecute()
        {
            _thirdCreatePage.ShowNextPage("Контроль заказов");
        }

        private void EditPageButtonExecute()
        {
            _thirdCreatePage.ShowNextPage("Редактироваать группу");
        }

        private void ChooseKitchenExecute()
        {
            throw new NotImplementedException();
        }
    }
}
