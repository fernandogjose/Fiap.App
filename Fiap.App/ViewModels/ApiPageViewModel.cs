using Fiap.App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Fiap.App.ViewModels
{
    public class ApiPageViewModel : BaseViewModel
    {
        HttpClient httpClient;

        HttpClient Client => httpClient ?? (httpClient = new HttpClient());

        public ObservableCollection<Models.User> Users { get; }

        public Command GetUsersCommand { get; }

        public ApiPageViewModel()
        {
            Title = "Api e MVVM";
            Users = new ObservableCollection<Models.User>();
            GetUsersCommand = new Command(async () => await GetUsersAsync());
        }

        async Task GetUsersAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                // Busca da api
                string json = await Client.GetStringAsync("https://api-controleacesso-abbc.azurewebsites.net/api/usuario/listar-temp");
                var userApiResponse = JsonConvert.DeserializeObject<UserApiResponse>(json);

                // Popula o objeto da a listview
                Users.Clear();
                foreach (var user in userApiResponse.Users)
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