using LounchRoom.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;

namespace LounchRoom.Core.VeiwModels.CreatePage
{
    public class FirstCreatePageVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string nameEntryText;
        public string NameEntryText
        {
            get { return nameEntryText; }
            set { nameEntryText = value; }
        }

        private string addressEntryText;
        public string AddressEntryText
        {
            get { return addressEntryText; }
            set { addressEntryText = value; }
        }

        private string payLinkEntryText;
        public string PayLinkEntryText
        {
            get { return payLinkEntryText; }
            set { payLinkEntryText = value; }
        }

        private string descriptionEntryText;
        public string DescriptionEntryText
        {
            get { return descriptionEntryText; }
            set { descriptionEntryText = value; }
        }

        public ICommand NextPageButton { get; set; }
        public ICommand PreviousePageButton { get; set; }

        private ICreatePage _firstCreatePage;
        public FirstCreatePageVM (ICreatePage firstCreatePage)
        {
            _firstCreatePage = firstCreatePage;

            NextPageButton = new Command(NextPageButtonExecute);
            PreviousePageButton = new Command(PreviousePageButtonExecute);
        }

        private bool entryIsInvalid;
        public bool EntryIsInvalid
        {
            get { return entryIsInvalid; }
            set
            {
                if (entryIsInvalid == value)
                    return;

                entryIsInvalid = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EntryIsInvalid)));
            }
        }

        private void PreviousePageButtonExecute()
        {
            _firstCreatePage.ShowPreviousPage();
        }

        private async void NextPageButtonExecute()
        {
            var name = NameEntryText;
            var address = AddressEntryText;
            var payLink = PayLinkEntryText;
            var description = DescriptionEntryText;

            if (name == null || address == null || payLink == null)
            {
                EntryIsInvalid = true;
            }
            else
            {
                var group = await Context.GroupService.Create(name);
                await SecureStorage.SetAsync("activeGroupToken", group.Id);
                var configureCitchen = await Context.GroupService.ConfigureKitchen(address, group.Id);
                var configurePaymentInfo = await Context.GroupService.ConfigurePaymentInfo(payLink, description, group.Id);
                if (configureCitchen == System.Net.HttpStatusCode.OK && configurePaymentInfo == System.Net.HttpStatusCode.OK)
                {
                    _firstCreatePage.ShowNextPage(null);
                }
                else
                {
                    EntryIsInvalid = true;
                }
            }
        }
    }
}
