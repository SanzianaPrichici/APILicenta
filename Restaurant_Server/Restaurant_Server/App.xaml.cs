using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Restaurant_Server.Data;

namespace Restaurant_Server
{
    public partial class App : Application
    {
        public static LicentaDatabase Database { get; private set; }
        public App()
        {
            Database = new LicentaDatabase(new RestService());
            MainPage = new NavigationPage(new Login());
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
