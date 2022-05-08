using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Restaurant_Server.Models;
using System.Net.Http;

namespace Restaurant_Server.Data
{
    public class RestService : IRestService
    {
        readonly HttpClient client;
        readonly string RestUrlCLI = "https://192.168.1.160:45455/api/Clients/";
        readonly string RestUrlUSR = "https://192.168.1.160:45455/api/Users/";
        public List<Client> Clients { get; private set; }
        public List<User> Users { get; private set; }
        public RestService()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };
            client = new HttpClient(httpClientHandler);
        }
        //Afisare lista clienti
        public async Task<List<Client>> RefreshDataAsyncCLI()
        {
            Clients = new List<Client>();
            Uri uri = new Uri(string.Format(RestUrlCLI, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Clients = JsonConvert.DeserializeObject<List<Client>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Eroare afisare clienti", ex.Message);
            }
            return Clients;
        }
        //Afisare lista useri
        public async Task<List<User>> RefreshDataAsyncUSR()
        {
            Console.WriteLine(@"Am ajuns in baza de date sa afisez userii");
            Users = new List<User>();
            Uri uri = new Uri(string.Format(RestUrlUSR, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Users = JsonConvert.DeserializeObject<List<User>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Eroare afisare useri", ex.Message);
            }
            return Users;
        }
        // Salvare Client
        public async Task SaveClientAsync(Client item, bool isNewItem = true)
        {
            Console.WriteLine(@"Am ajuns la URL");
            Uri uri = new Uri(string.Format(RestUrlCLI, string.Empty));
            try
            {
                string json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }
                Console.WriteLine(response.IsSuccessStatusCode.ToString());
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"S-a salvat clientul.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Clientul nu poate fi salvat", ex.Message);
            }
            Console.WriteLine(item.ID);
        }
        // Salvare User
        public async Task SaveUserAsync(User item, bool isNewItem = true)
        {
            Console.WriteLine(@"Am ajuns la URLul pt user");
            Uri uri = new Uri(string.Format(RestUrlUSR, string.Empty));
            try
            {
                string json = JsonConvert.SerializeObject(item);
                Console.WriteLine(json);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    Console.WriteLine(@"Ceva POST.");
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    Console.WriteLine(@"Ceva PUT.");
                    response = await client.PutAsync(uri, content);
                }
                Console.WriteLine(response.IsSuccessStatusCode.ToString());
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"S-a salvat userul.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Userul nu poate fi salvat", ex.Message);
            }
        }
        //Stergere Client
        public async Task DeleteClientAsync(int id)
        {
            Uri uri = new Uri(string.Format(RestUrlCLI, id));
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"Clientul a fost sters");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Clientul nu poate fi sters", ex.Message);
            }
        }
        //Stergere User
        public async Task DeleteUserAsync(int id)
        {
            Uri uri = new Uri(string.Format(RestUrlUSR, id));
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"Clientul a fost sters");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Clientul nu poate fi sters", ex.Message);
            }
        }
    }
}
