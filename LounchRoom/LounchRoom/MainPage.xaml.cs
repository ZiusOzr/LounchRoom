﻿using LounchRoom.Core.VeiwModels.MainPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LounchRoom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage, IMainPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = new MainPageVM(this);
        }

        public void ShowNextPage()
        {
            this.Navigation.PushAsync(new OrderPage());
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //Надо скрыть анимацию выбора

            ((ListView)sender).SelectedItem = null;
        }
    }
}