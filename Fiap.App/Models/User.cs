using Newtonsoft.Json;
using System.Collections.Generic;

namespace Fiap.App.Models
{
    public class User
    {
        [JsonProperty("nome")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class UserApiResponse
    {
        [JsonProperty("QuantidadeDeUsuarios")]
        public string Total { get; set; }

        [JsonProperty("usuarios")]
        public List<User> Users { get; set; }
    }
}
