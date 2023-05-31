using LounchRoom.Core.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LounchRoom.Core.VeiwModels.CreatePage
{
    public class KitchenItemVM
    {
        public string KitchenId { get; set; }
        public string OrganizationName { get; set; }
        public string Address { get; set; }
        public Contacts Contacts { get; set; }
        public KitchenSettingsDTO Settings { get; set; }

        private ICreatePage _secondCreatePage;

        public AvailableKitchensDTO availableKitchens;
        private Action<KitchenItemVM> chooseKitchenButtonExecute;
        private Action<KitchenItemVM> showConditionsOrderButtonExecute;
        private Action<KitchenItemVM> showKitchenMenuButtonExecute;
        public ICommand ShowKitchenMenuButton { get; set; }
        public ICommand ShowConditionsOrderButton { get; set; }
        public ICommand ChooseKitchenButton { get; set; }

        public KitchenItemVM(AvailableKitchensDTO availableKitchens, Action<KitchenItemVM> chooseKitchenButtonExecute, Action<KitchenItemVM> showConditionsOrderButtonExecute, Action<KitchenItemVM> showKitchenMenuButtonExecute)
        {
            KitchenId = availableKitchens.KitchenId;
            OrganizationName = availableKitchens.OrganizationName;
            Address = availableKitchens.Address;
            Contacts = availableKitchens.Contacts;
            Settings = availableKitchens.Settings;


            this.chooseKitchenButtonExecute = chooseKitchenButtonExecute;
            this.showConditionsOrderButtonExecute = showConditionsOrderButtonExecute;
            this.showKitchenMenuButtonExecute = showKitchenMenuButtonExecute;
            ShowKitchenMenuButton = new Command(ShowKitchenMenuEx);
            ShowConditionsOrderButton = new Command(ShowConditionsOrderEx);
            ChooseKitchenButton = new Command(ChooseKitchenEx);
        }

        private void ChooseKitchenEx()
        {
            chooseKitchenButtonExecute?.Invoke(this);
        }

        private void ShowConditionsOrderEx()
        {
            showConditionsOrderButtonExecute?.Invoke(this);
        }

        private void ShowKitchenMenuEx()
        {
            showKitchenMenuButtonExecute?.Invoke(this);
        }
    }
}
