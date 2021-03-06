using MyApplication.MVVM.Views.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyApplication
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new AddUserPage());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new AppShell();
        }
    }
}
