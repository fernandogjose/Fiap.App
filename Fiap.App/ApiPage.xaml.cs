using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fiap.App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApiPage : ContentPage
    {
        //HttpClient _client;

        public ApiPage()
        {
            InitializeComponent();
            //_client = new HttpClient();
            //ListUsersAsync();
        }

        //private async Task ListUsersAsync()
        //{
        //    UsuarioApi usuarioApi = new UsuarioApi { Usuarios = new List<Usuario>(0) };
        //    var uri = new Uri("https://api-controleacesso-abbc.azurewebsites.net/api/usuario/listar-temp");
        //    var response = await _client.GetAsync(uri).ConfigureAwait(true);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        usuarioApi = JsonConvert.DeserializeObject<UsuarioApi>(content);
        //    }

        //    IEnumerable<Usuario> usuarios = usuarioApi.Usuarios.Where(x => x.Nome.Length > 5);
        //    foreach (var usuario in usuarios)
        //    {
        //        usuario.Status = $"{usuario.Status.ToLower()}.png";
        //    }

        //    lvUsers.ItemsSource = usuarios;
        //}
    }

    //public class UsuarioApi
    //{
    //    public List<Usuario> Usuarios { get; set; }
    //}
}