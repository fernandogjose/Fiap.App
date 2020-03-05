using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Fiap.App.ViewModels
{
    public class ApiPageViewModel : BaseViewModel
    {
        HttpClient httpClient;

        HttpClient Client => httpClient ?? (httpClient = new HttpClient());

        public ObservableCollection<User> Users { get; }

        public Command GetUsersCommand { get; }

        public Command GetUserCommand { get; }

        public ApiPageViewModel()
        {
            Title = "Api e MVVM";
            Users = new ObservableCollection<User>();
            GetUsersCommand = new Command(async () => await GetUsersAsync());
            GetUserCommand = new Command(async () => await GetUsersAsync());
        }

        public void GetUser(string name)
        {
            // Buscar do cache
            var users = Users.Where(x => x.Name == name).ToList();

            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }

        async Task GetUsersAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                string json = await Client.GetStringAsync("https://api-controleacesso-abbc.azurewebsites.net/api/usuario/listar-temp");
                var users = JsonConvert.DeserializeObject<List<User>>(json);
                // var users = User.FromJson(json);

                // Gravar no cache

                Users.Clear();
                foreach (var user in users)
                {
                    Users.Add(user);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get users: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}