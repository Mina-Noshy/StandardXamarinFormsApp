using MyApplication.Services;
using MyApplication.SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApplication
{
    public partial class App : Application
    {
        private static SQLiteHelper _context;
        public static SQLiteHelper context
        {
            get
            {
                if (_context == null)
                    _context = new SQLiteHelper();

                return _context;
            }
        }

        public App()
        {
            InitializeComponent();
            DependencyService.Register<UserServices>();

            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = (Color)Application.Current.Resources["primary"],
                BarTextColor = (Color)Application.Current.Resources["light"]
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
