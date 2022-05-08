using Restaurant_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant_Server
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddUser : ContentPage
    {
        public AddUser()
        {
            InitializeComponent();
        }
        async void OnButtonSave(object sender, EventArgs e)
        {
            try
            {
                var user = new User();
                user.Mail=txtmail.Text;
                user.Parola = txtparola.Text;
                user.Username = txtusr.Text;
                user.Cli = (Client)BindingContext;
                //user.Cli.Nume = txtmail.Text;
                //await App.Database.SaveClientAsync(user.Cli);
                Console.WriteLine(@"CEVA");
                Console.WriteLine(user.Cli.Nume.ToString());
                await App.Database.SaveClientAsync(user.Cli);
                //Console.WriteLine("@AICI ID-UL");
                //Console.WriteLine(user.Cli.ID);
                await App.Database.SaveUserAsync(user); 
                await Navigation.PopToRootAsync();
                await DisplayAlert("URAA", user.ID.ToString(), "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("NEOK", ex.Message, "OK");
            }
        }
    }
}