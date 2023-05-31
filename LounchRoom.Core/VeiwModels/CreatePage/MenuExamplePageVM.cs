using LounchRoom.Core.Services;
using LounchRoom.Core.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace LounchRoom.Core.VeiwModels.CreatePage
{
    public class MenuExamplePageVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<DishTypeDTO> categories;
        public ObservableCollection<DishTypeDTO> Categories
        {
            get
            {
                return categories;
            }
            set
            {
                categories = value;
            }
        }

        private IMenuExamplePage _menuExamplePage;
        public MenuExamplePageVM(IMenuExamplePage menuExamplePage)
        {
            _menuExamplePage = menuExamplePage;
            LoadMenu();
        }

        private async void LoadMenu()
        {
            var kitchenId = await SecureStorage.GetAsync("activeKitchenToken");
            var menu = await Context.MenuService.GetMenuByDateForKitchen(kitchenId);
            
            if (menu.LunchSets != null)
            {
                Categories.Add(new DishTypeDTO { Name = "Комбо наборы" });
            }
            var categoryList = menu.Dishes.Select(x => x.Type).ToList();
            Categories.Concat(categoryList);
        }
    }
}
