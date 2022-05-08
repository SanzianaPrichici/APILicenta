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
    public partial class AddClient : ContentPage
    {
        public AddClient()
        {
            InitializeComponent();
        }
        async void OnButtonSave(object sender, EventArgs e)
        {
            try
            {
                var cli = (Client)BindingContext;
                Console.WriteLine(cli.ID.ToString());
                cli.Data_nast = txtdat.Date;
                cli.Nume = txtnume.Text;
                cli.Prenume = txtprenume.Text;
                cli.Telefon = txttlf.Text;
                cli.Adresa = txtadr.Text;
                //await App.Database.SaveClientAsync(cli);
                await Navigation.PushAsync(new AddUser
                {
                    BindingContext = cli
                });
                //await DisplayAlert(cli.ID.ToString(), cli.Nume, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("NEOK", ex.Message, "OK");
            }
        }
    }
}