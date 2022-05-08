using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Restaurant_Server.Models;

namespace Restaurant_Server
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        public Login()
        {
            InitializeComponent();
        }
        async void OnInregClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddClient
            {
                BindingContext = new Client()
            });
        }
        async void OnLoginClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new Meniu()));
        }
    }
}