using MyApplication.MVVM.Models;
using MyApplication.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace MyApplication.MVVM.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<User> UsersDataStore => DependencyService.Get<IDataStore<User>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    OnPropertyChanged(nameof(IsBusy));
                }
            }
        }

        string title = string.Empty;
        public string Title
        {
            get => title;
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
