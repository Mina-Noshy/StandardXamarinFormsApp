using MyApplication.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyApplication.MVVM.ViewModels.Users
{
    public class AddUserVM : BaseViewModel
    {
        private bool canSave = false;
        public bool CanSave
        {
            get => ValidateSave();
            set
            {
                CanSave = ValidateSave();
                OnPropertyChanged(nameof(CanSave));
                
            }
        }

        private string userName;
        public string UserName
        {
            get => userName;
            set
            {
                if(userName != value)
                {
                    userName = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(CanSave));
                }
            }
        }
        
        private string password;
        public string Password
        {
            get => password;
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(CanSave));
                }
            }
        }


        public Command SaveCommand { get; }
        public Command CancelCommand { get; }


        public AddUserVM()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel, () => !IsBusy);
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrEmpty(userName)
                && !String.IsNullOrEmpty(password)
                && !IsBusy;
        }


        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            //await Shell.Current.GoToAsync("..");
            await Application.Current.MainPage.DisplayAlert("Error", "error when go back", "ok");
        }

        private async void OnSave()
        {
            User newItem = new User()
            {
                UserName = UserName,
                Password = Password
            };

            IsBusy = true;

            bool result = await UsersDataStore.AddItemAsync(newItem);

            if (result)
                await Application.Current.MainPage.DisplayAlert("Success", $"added user {UserName}, pass {Password} successfully", "ok");
            else
                await Application.Current.MainPage.DisplayAlert("Error", "error when add new item!", "ok");

            IsBusy = false;
            // This will pop the current page off the navigation stack
            //await Shell.Current.GoToAsync("..");
        }
    }
}
