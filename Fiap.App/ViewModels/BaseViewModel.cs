using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fiap.App.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class MonkeyViewModel : BaseViewModel
    {
        HttpClient httpClient;

        HttpClient HttpClient => httpClient ?? (httpClient = new HttpClient());

        public ObservableCollection<Monkey> Monkeys { get; }

        public MonkeyViewModel()
        {
            Title = "Monkey Finder";
            Monkeys = new ObservableCollection<Monkey>();
        }

        async Task GetMonkeysAsync()
        {
            try
            {
                var json = await HttpClient.GetStringAsync("");
                var monkeys = Monkey.From
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
