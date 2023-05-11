using LounchRoom.Core.Services;
using LounchRoom.Core.VeiwModels.ProfilePage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LounchRoom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage, IProfilePage
    {
        public ProfilePage()
        {
            InitializeComponent();
            SetState();

            var pageVM = new ProfilePageVM(this);
            this.BindingContext = pageVM;


            pageVM.PropertyChanged += PageVM_PropertyChanged;
            pageVM.PropertyChanged += PageVM_PropertyChanged_EntryText;
        }


        private void PageVM_PropertyChanged_EntryText(object sender, PropertyChangedEventArgs e)
        {
            var pageVM = BindingContext as ProfilePageVM;

            if (e.PropertyName == nameof(pageVM.SurnameEntryText))
            {
                surnameEntry.Text = pageVM.SurnameEntryText;
            }
            if (e.PropertyName == nameof(pageVM.NameEntryText))
            {
                nameEntry.Text = pageVM.NameEntryText;
            }
            if (e.PropertyName == nameof(pageVM.PatronymicEntryText))
            {
                patronymicEntry.Text = pageVM.PatronymicEntryText;
            }
            if (e.PropertyName == nameof(pageVM.PhoneEntryText))
            {
                phoneEntry.Text = pageVM.PhoneEntryText;
            }
        }

        private void PageVM_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var pageVM = BindingContext as ProfilePageVM;
            if (e.PropertyName == nameof(pageVM.ButtonIsSaveState))
            {
                VisualStateManager.GoToState(editSaveButton, pageVM.ButtonIsSaveState ? "LightGreenButton" : "GreenButton");
                editSaveButton.Text = pageVM.ButtonIsSaveState ? "Изменить" : "Сохранить";
                VisualStateManager.GoToState(surnameFrame, pageVM.ButtonIsSaveState ? "Disabled" : "Normal");
                VisualStateManager.GoToState(surnameEntry, pageVM.ButtonIsSaveState ? "Disabled" : "Normal");
                VisualStateManager.GoToState(nameFrame, pageVM.ButtonIsSaveState ? "Disabled" : "Normal");
                VisualStateManager.GoToState(nameEntry, pageVM.ButtonIsSaveState ? "Disabled" : "Normal");
                VisualStateManager.GoToState(patronymicFrame, pageVM.ButtonIsSaveState ? "Disabled" : "Normal");
                VisualStateManager.GoToState(patronymicEntry, pageVM.ButtonIsSaveState ? "Disabled" : "Normal");
                VisualStateManager.GoToState(phoneFrame, pageVM.ButtonIsSaveState ? "Disabled" : "Normal");
                VisualStateManager.GoToState(phoneEntry, pageVM.ButtonIsSaveState ? "Disabled" : "Normal");
            }
        }

        public void ShowNextPage()
        {
            this.Navigation.PushAsync(new FirstCreatePage());
        }

        private void SetState()
        {
            var pageVM = BindingContext as ProfilePageVM;
            VisualStateManager.GoToState(surnameFrame, "Normal");
            VisualStateManager.GoToState(surnameEntry, "Normal");
            VisualStateManager.GoToState(nameFrame, "Normal");
            VisualStateManager.GoToState(nameEntry, "Normal");
            VisualStateManager.GoToState(patronymicFrame, "Normal");
            VisualStateManager.GoToState(patronymicEntry, "Normal");
            VisualStateManager.GoToState(phoneFrame, "Normal");
            VisualStateManager.GoToState(phoneEntry, "Normal");
            VisualStateManager.GoToState(editSaveButton, "GreenButton");
            VisualStateManager.GoToState(createGroupButton, "LightGreenButton");
            editSaveButton.Text = "Сохранить";
            
        }
    }
}