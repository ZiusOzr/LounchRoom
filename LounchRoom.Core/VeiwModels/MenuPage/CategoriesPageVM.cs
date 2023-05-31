using LounchRoom.Core.Services;
using LounchRoom.Core.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;

namespace LounchRoom.Core.VeiwModels.MenuPage
{

    public class CategoriesPageVM: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<CategoryDTO> dishTypes;
        public ObservableCollection<CategoryDTO> DishTypes
        {
            get
            {
                return dishTypes;
            }
            set
            {
                dishTypes = value;
            }
        }

        private CategoryDTO selectedItem;
        public CategoryDTO SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
                }
            }
        }

        private ICategoriesPage _categoriesPage;
        public CategoriesPageVM(ICategoriesPage categoriesPage)
        {
            _categoriesPage = categoriesPage;
            LoadCategory();

            PropertyChanged += SelectedItem_Prop;
        }

        private void SelectedItem_Prop(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedItem))
            {
                if (SelectedItem.LunchSets != null)
                {

                }
                _categoriesPage.ShowNextPage();
            }
        }

        private async void LoadCategory()
        {
            var groupId = await SecureStorage.GetAsync("activeGroupToken");
            var menu = await Context.MenuService.LoadMenu(groupId);
            if (menu.LunchSets != null)
            {
                DishTypes.Add(new CategoryDTO { LunchSets = menu.LunchSets});
            }
            foreach (var i in menu.Dishes)
            {
                var item = new CategoryDTO { Type = i.Type };
                if (!DishTypes.Contains(item))
                {
                    DishTypes.Add(item);
                }
            }
        }





        
        
    }
}
