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
    public partial class ListaClienti : ContentPage
    {
        public ListaClienti()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetClientsAsync();
        }
        async void OnAddClientClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddClient
            {
                BindingContext = new Client()
            });
        }
        async void OnUSRClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage( new ListaUseri()));
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AddClient
                {
                    BindingContext = e.SelectedItem as Client
                });
            }
        }
    }
}