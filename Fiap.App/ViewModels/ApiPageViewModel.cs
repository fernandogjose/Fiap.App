using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Linq;
using Fiap.App.Models;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;

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

        async Task GetUserCommand(string name)
        {
            Users = Users.Where(x=>x.name == name);
        }

        async Task GetUsersAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                string json = await Client.GetStringAsync("https://api-controleacesso-abbc.azurewebsites.net/api/usuario/listar-temp");
                var users = User.FromJson(json);

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