using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Restaurant_Server.Models;

namespace Restaurant_Server.Data
{
    public interface IRestService
    {
        Task<List<Client>> RefreshDataAsyncCLI();
        Task SaveClientAsync(Client item, bool isNewItem);
        Task DeleteClientAsync(int id);
        Task<List<User>> RefreshDataAsyncUSR();
        Task SaveUserAsync(User item, bool isNewItem);
        Task DeleteUserAsync(int id);
    }
}
