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
            var kitchenToken = SelectedKitchen.KitchenId;
            var responce = await Context.GroupService.SetActiveKitchen(groupToken, kitchenToken);
            if (responce == System.Net.HttpStatusCode.OK)
            {
                await SecureStorage.SetAsync("kitchenToken", kitchenToken);
            }
            else
            {
                throw new Exception("Unknow error"); //Нельзя выбрасывать
            }
        }

        private void ShowConditionsOrderButtonExecute()
        {
            var menuUpdate = SelectedKitchen.Settings.MenuUpdatePeriod == 0 ? "Раз в день" : "Раз в неделю";
            _secondCreatePage.ShowDisplayAlert(SelectedKitchen.Settings.LimitingTimeForOrder, menuUpdate); //Добавить минимальную сумму
        }

        private void ShowKitchenMenuButtonExecute()
        {
            _secondCreatePage.ShowNextPage("Menu");
        }

        private async void LoadKitchens()
        {
            var groupToken = await SecureStorage.GetAsync("activeGroupToken");
            var kitchenList = await Context.GroupService.GetAllowedKitchens(groupToken);
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
