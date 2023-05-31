using LounchRoom.Core.Services;
using LounchRoom.Core.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;

namespace LounchRoom.Core.VeiwModels.CreatePage
{
    public class SecondCreatePageVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<KitchenItemVM> kitchensItems;
        public ObservableCollection<KitchenItemVM> KitchensItems
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

        public ICommand ShowKitchenMenuButton { get; set; }
        public ICommand ShowConditionsOrderButton { get; set; }
        public ICommand ChooseKitchenButton { get; set; }

        public ICommand NextPageButton { get; set; }
        public ICommand PreviousePageButton { get; set; }

        private ICreatePage _secondCreatePage;
        public SecondCreatePageVM(ICreatePage secondCreatePage)
        {
            _secondCreatePage = secondCreatePage;

            NextPageButton = new Command(NextPageButtonExecute);
            PreviousePageButton = new Command(PreviousePageButtonExecute);

            LoadKitchens();


        }

        

        private async void ChooseKitchenButtonExecute(KitchenItemVM kitchenItem)
        {
            var groupToken = await SecureStorage.GetAsync("activeGroupToken");
            var kitchenToken = kitchenItem.KitchenId;
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

        private void ShowConditionsOrderButtonExecute(KitchenItemVM kitchenItem)
        {
            var menuUpdate = kitchenItem.Settings.MenuUpdatePeriod == 0 ? "Раз в день" : "Раз в неделю";
            _secondCreatePage.ShowDisplayAlert(kitchenItem.Settings.LimitingTimeForOrder, menuUpdate, kitchenItem.Settings.MinAmountForSharedOrder);
        }

        private async void ShowKitchenMenuButtonExecute(KitchenItemVM kitchenItem)
        {
            await SecureStorage.SetAsync("activeKitchenToken", kitchenItem.KitchenId);
            _secondCreatePage.ShowNextPage("Menu");
        }

        private async void LoadKitchens()
        {
            var groupToken = await SecureStorage.GetAsync("activeGroupToken");
            var kitchenList = await Context.GroupService.GetAllowedKitchens(groupToken);
            KitchensItems = new ObservableCollection<KitchenItemVM>(kitchenList.Select(x => new KitchenItemVM(x, ChooseKitchenButtonExecute, ShowConditionsOrderButtonExecute, ShowKitchenMenuButtonExecute)));
        }

        private void PreviousePageButtonExecute()
        {
            _secondCreatePage.ShowPreviousPage();
        }

        private void NextPageButtonExecute()
        {
            _secondCreatePage.ShowNextPage("Next");
        }

        //class SomeItemVM
        //{
        //    private readonly Action<SomeItemVM> previousePageButtonExecute;
        //    ICommand c;
        //    public SomeItemVM(AvailableKitchensDTO dto, Action<SomeItemVM> previousePageButtonExecute)
        //    {
        //        this.previousePageButtonExecute = previousePageButtonExecute;

        //        c = new Command(ExecuteCommand);
        //    }

        //    void ExecuteCommand()
        //    {
        //        previousePageButtonExecute?.Invoke(this);
        //    }
        //}
    }
}
