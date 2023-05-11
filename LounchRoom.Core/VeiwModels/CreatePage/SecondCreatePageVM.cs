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
    public class SecondCreatePageVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<AvailableKitchensDTO> kitchensItems;
        public ObservableCollection<AvailableKitchensDTO> KitchensItems
        {
            get
            {
                return kitchensItems;
            }
            set
            {
                if (kitchensItems != value)
                {
                    kitchensItems = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(KitchensItems)));
                }
            }
        }

        private string kitchenNameLabel;
        public string KitchenNameLabel
        {
            get
            {
                return kitchenNameLabel;
            }
            set
            {
                if (kitchenNameLabel != value)
                {
                    kitchenNameLabel = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(KitchenNameLabel)));
                }
            }
        }

        private string legalNameLabel;
        public string LegalNameLabel
        {
            get
            {
                return legalNameLabel;
            }
            set
            {
                if (legalNameLabel != value)
                {
                    legalNameLabel = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LegalNameLabel)));
                }
            }
        }

        private string phoneLabel;
        public string PhoneLabel
        {
            get
            {
                return phoneLabel;
            }
            set
            {
                if (phoneLabel != value)
                {
                    phoneLabel = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PhoneLabel)));
                }
            }
        }

        private string emailLabel;
        public string EmailLabel
        {
            get
            {
                return emailLabel;
            }
            set
            {
                if (emailLabel != value)
                {
                    phoneLabel = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EmailLabel)));
                }
            }
        }

        private AvailableKitchensDTO selectedKitchen;
        public AvailableKitchensDTO SelectedKitchen
        {
            get
            {
                return selectedKitchen;
            }
            set
            {
                if (selectedKitchen != value)
                {
                    selectedKitchen = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedKitchen)));
                }
            }
        }

        public ICommand NextPageButton { get; set; }
        public ICommand PreviousePageButton { get; set; }
        public ICommand ShowKitchenMenuButton { get; set; }
        public ICommand ShowConditionsOrderButton { get; set; }
        public ICommand ChooseKitchenButton { get; set; }

        private ICreatePage _secondCreatePage;
        public SecondCreatePageVM(ICreatePage secondCreatePage)
        {
            _secondCreatePage = secondCreatePage;

            NextPageButton = new Command(NextPageButtonExecute);
            PreviousePageButton = new Command(PreviousePageButtonExecute);
            LoadKitchens();
            ShowKitchenMenuButton = new Command(ShowKitchenMenuButtonExecute);
            ShowConditionsOrderButton = new Command(ShowConditionsOrderButtonExecute);
            ChooseKitchenButton = new Command(ChooseKitchenButtonExecute);
        }

        private async void ChooseKitchenButtonExecute()
        {
            var groupToken = await SecureStorage.GetAsync("activeGroupToken");
            var kitchenToken = SelectedKitchen.Settings.KitchenId;
            await SecureStorage.SetAsync("kitchenToken", kitchenToken);
           // var responce = await Context.GroupService.SetActiveKitchen(groupToken, kitchenToken);
        }

        private void ShowConditionsOrderButtonExecute()
        {
            _secondCreatePage.ShowNextPage("Conditions");
        }

        private void ShowKitchenMenuButtonExecute()
        {
            _secondCreatePage.ShowNextPage("Menu");
        }

        private async void LoadKitchens()
        {
            var kitchenList = await Context.GroupService.GetAllowedKitchens();
            KitchensItems = kitchenList;
        }

        private void PreviousePageButtonExecute()
        {
            _secondCreatePage.ShowPreviousPage();
        }

        private void NextPageButtonExecute()
        {
            _secondCreatePage.ShowNextPage("Next");
        }
    }
}
