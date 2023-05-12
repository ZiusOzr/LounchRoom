using LounchRoom.Core.Services;
using LounchRoom.Core.Services.DTOs;
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

        private string streetEntryText;
        public string StreetEntryText
        {
            get { return streetEntryText; }
            set { streetEntryText = value; }
        }

        private string numberEntryText;
        public string NumberEntryText
        {
            get { return numberEntryText; }
            set { numberEntryText = value; }
        }

        private string officeEntryText;
        public string OfficeEntryText
        {
            get { return officeEntryText; }
            set { officeEntryText = value; }
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
            //var name = NameEntryText;
            var name = "Группа";
            //var street = StreetEntryText;
            //var number = NumberEntryText;
            //var office = OfficeEntryText;
            var street = "Комсомольская";
            var number = "4б";
            var office = "17";
            var address = new GroupConfigByAddressDTO
            {
                Address = new AddressDTO
                {
                    Street = street,
                    Number = number,
                    Office = office
                }
            };
            //var payLink = PayLinkEntryText;
            var payLink = "goo.gl";
            var description = DescriptionEntryText;

            if (name == null || address == null || payLink == null)
            {
                EntryIsInvalid = true;
            }
            else
            {
                //var group = await Context.GroupService.Create(name);
                //await SecureStorage.SetAsync("activeGroupToken", group.Id);
                await SecureStorage.SetAsync("activeGroupToken", "b8dd02aa-52ce-45d2-b57b-a00fb8fc6ac1"); //затычка
                //address.GroupId = group.Id;
                //var configureGroupLocation = await Context.GroupService.ConfigureGroupLocation(address);
                //var configurePaymentInfo = await Context.GroupService.ConfigurePaymentInfo(payLink, description, group.Id);
                //if (configureGroupLocation == System.Net.HttpStatusCode.OK && configurePaymentInfo == System.Net.HttpStatusCode.OK)
                //{
                //    _firstCreatePage.ShowNextPage(null);
                //}
                //else
                //{
                //    EntryIsInvalid = true;
                //}
                _firstCreatePage.ShowNextPage(null); //затычка
            }
        }
    }
}
