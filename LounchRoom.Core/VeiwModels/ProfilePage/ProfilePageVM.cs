using LounchRoom.Core.Services;
using LounchRoom.Core.Services.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LounchRoom.Core.VeiwModels.ProfilePage
{
    public class ProfilePageVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string nameEntryText;
        public string NameEntryText
        {
            get
            {
                return nameEntryText;
            }
            set
            {
                if (nameEntryText == value)
                    return;

                nameEntryText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NameEntryText)));
            }
        }

        private string surnameEntryText;
        public string SurnameEntryText
        {
            get
            {
                return surnameEntryText;
            }
            set
            {
                if (surnameEntryText == value)
                    return;

                surnameEntryText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SurnameEntryText)));
            }
        }

        private string patronymicEntryText;
        public string PatronymicEntryText
        {
            get
            {
                return patronymicEntryText;
            }
            set
            {
                if (patronymicEntryText == value)
                    return;

                patronymicEntryText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PatronymicEntryText)));
            }
        }

        private string phoneEntryText;
        public string PhoneEntryText
        {
            get
            {
                return phoneEntryText;
            }
            set
            {
                if (phoneEntryText == value)
                    return;

                phoneEntryText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PhoneEntryText)));
            }
        }

        private ObservableCollection<UserGroupDTO> groupItems;
        public ObservableCollection<UserGroupDTO> GroupItems
        {
            get
            {
                return groupItems;
            }
            set
            {
                if (groupItems != value)
                {
                    groupItems = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GroupItems)));
                }
            }
        }

        private UserGroupDTO selectedGroupItem;
        public UserGroupDTO SelectedGroupItem
        {
            get
            {
                return selectedGroupItem;
            }
            set
            {
                if (selectedGroupItem != value)
                {
                    selectedGroupItem = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedGroupItem)));
                }
            }
        }

        public ICommand EditSaveButton { get; set; }
        public ICommand CreateGroupButton { get; set; }

        private IProfilePage _profilePage;
        public ProfilePageVM (IProfilePage profilePage)
        {
            _profilePage = profilePage;
            
            EditSaveButton = new Command(EditSaveButtonExecute);
            CreateGroupButton = new Command(CreateGroupButtonExecute);
            UpdateUser();

            PropertyChanged += SelectedGroupItem_PropertyChanged;
        }

        private async void SelectedGroupItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedGroupItem))
            {
                await SecureStorage.SetAsync("activeGroupToken", SelectedGroupItem?.GroupId ?? "");
                
                SelectedGroupItem.OnPropertyChanged();
            }
        }

        private async void UpdateUser()
        {
            try
            {
                var userDTO = await Context.UserService.Load(null);
                NameEntryText = userDTO.Name;
                SurnameEntryText = userDTO.Surname;
                PatronymicEntryText = userDTO.Patronymic;
                PhoneEntryText = userDTO.Phone;
                if (nameEntryText != null)
                    ButtonIsSaveState = true;
                GroupItems = await Context.UserService.LoadGroupList();
            }
            catch
            {
            }
            
        }

        private bool buttonIsSaveState;
        public bool ButtonIsSaveState
        {
            get { return buttonIsSaveState; }
            set
            {
                if (buttonIsSaveState == value)
                    return;

                buttonIsSaveState = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ButtonIsSaveState)));
            }
        }

        private void CreateGroupButtonExecute()
        {
            _profilePage.ShowNextPage();
        }

        private async void EditSaveButtonExecute()
        {
            var name = NameEntryText;
            var surname = SurnameEntryText;
            var patronymic = PatronymicEntryText;
            var phone = PhoneEntryText; //Проверить на валидность

            if (buttonIsSaveState)
            {
                ButtonIsSaveState = false;
            }
            else
            {
                var userForCreationDTO = new UserForCreationDTO
                {
                    Name = name,
                    Surname = surname,
                    Patronymic = patronymic,
                    Phone = phone
                };
                var response = await Context.UpdateService.Update(userForCreationDTO);
                if (response == System.Net.HttpStatusCode.OK)
                {
                    ButtonIsSaveState = true;
                    UpdateUser();
                }
            }
        }
    }
}
