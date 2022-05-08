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
    public partial class ListaUseri : ContentPage
    {
        public ListaUseri()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //NavigationPage.SetHasNavigationBar(this, false);
            listView.ItemsSource = await App.Database.GetUsersAsync();
        }
        async void OnAddUserClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddUser
            {
                BindingContext = new User()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AddUser
                {
                    BindingContext = e.SelectedItem as User
                });
            }
        }
    }
}