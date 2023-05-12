using LounchRoom.Core.VeiwModels.CreatePage;
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
    public partial class FirstCreatePage : ContentPage, ICreatePage
    {
        public FirstCreatePage()
        {
            InitializeComponent();
            SetState();

            var pageVM = new FirstCreatePageVM(this);
            this.BindingContext = pageVM;

            pageVM.PropertyChanged += PageVM_PropertyChanged;
        }

        private void PageVM_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var pageVM = BindingContext as FirstCreatePageVM;
            if (e.PropertyName == nameof(pageVM.EntryIsInvalid))
            {
                VisualStateManager.GoToState(nameFrame, pageVM.EntryIsInvalid ? "Invalid" : "Normal");
                VisualStateManager.GoToState(nameEntry, pageVM.EntryIsInvalid ? "Invalid" : "Normal");
                VisualStateManager.GoToState(streetFrame, pageVM.EntryIsInvalid ? "Invalid" : "Normal");
                VisualStateManager.GoToState(streetEntry, pageVM.EntryIsInvalid ? "Invalid" : "Normal");
                VisualStateManager.GoToState(numberFrame, pageVM.EntryIsInvalid ? "Invalid" : "Normal");
                VisualStateManager.GoToState(numberEntry, pageVM.EntryIsInvalid ? "Invalid" : "Normal");
                VisualStateManager.GoToState(officeFrame, pageVM.EntryIsInvalid ? "Invalid" : "Normal");
                VisualStateManager.GoToState(officeEntry, pageVM.EntryIsInvalid ? "Invalid" : "Normal");
                VisualStateManager.GoToState(payLinkFrame, pageVM.EntryIsInvalid ? "Invalid" : "Normal");
                VisualStateManager.GoToState(payLinkEntry, pageVM.EntryIsInvalid ? "Invalid" : "Normal");
            }
        }

        public void ShowNextPage(string arg)
        {
            this.Navigation.PushAsync(new SecondCreatePage());
        }

        public void ShowPreviousPage()
        {
            this.Navigation.PopAsync();
        }

        private void SetState()
        {
            VisualStateManager.GoToState(nameFrame, "Normal");
            VisualStateManager.GoToState(nameEntry, "Normal");
            VisualStateManager.GoToState(streetFrame, "Normal");
            VisualStateManager.GoToState(streetEntry, "Normal");
            VisualStateManager.GoToState(numberFrame, "Normal");
            VisualStateManager.GoToState(numberEntry, "Normal");
            VisualStateManager.GoToState(officeFrame, "Normal");
            VisualStateManager.GoToState(officeEntry, "Normal");
            VisualStateManager.GoToState(payLinkFrame, "Normal");
            VisualStateManager.GoToState(payLinkEntry, "Normal");
            VisualStateManager.GoToState(descriptionFrame, "Normal");
            VisualStateManager.GoToState(descriptionEntry, "Normal");
            VisualStateManager.GoToState(nextPage, "GreenButton");
            VisualStateManager.GoToState(previousePage, "LightGreenButton");
        }

        public void ShowDisplayAlert(string time, string updateMenu)
        {
            throw new NotImplementedException();
        }
    }
}