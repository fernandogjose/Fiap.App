using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fiap.App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MongoDbPage : ContentPage
    {
        public IMongoDatabase MongoDatabase;
        private readonly IMongoCollection<BsonDocument> _collection;

        public MongoDbPage()
        {
            InitializeComponent();
            CreateMongoDatabase();
            List();
        }

        private void CreateMongoDatabase()
        {
            // Usando a base de horas extras (temporário para o trabalho da FIAP) remover depois
            //MongoClient client = new MongoClient("mongodb+srv://userDbHorasExtra:g716iso2@cluster0-i6gzm.azure.mongodb.net/test?retryWrites=true&w=majority");
            //MongoDatabase = client.GetDatabase("HorasExtra");
        }

        private void List()
        {
            //FilterDefinitionBuilder<BsonDocument> builder = Builders<BsonDocument>.Filter;
            //FilterDefinition<BsonDocument> filter = builder.Empty;
            //List<BsonDocument> bsonDocuments = _collection.Find(filter).ToList();

            //List<User> users = Map(bsonDocuments);

            List<User> users = new List<User>
            {
                new User { Name = "Fernando José"},
                new User { Name = "José" },
                new User { Name = "Gabriel" },
                new User { Name = "Antunes" },
                new User { Name = "Priscila" },
                new User { Name = "Gonçalves" },
            };

            lvUsers.ItemsSource = users;
        }

        private List<User> Map(List<BsonDocument> bsonDocuments)
        {
            List<User> response = new List<User>();
            foreach (var bsonDocument in bsonDocuments)
            {
                User user = Map(bsonDocument);
                response.Add(user);
            }
            return response;
        }

        private User Map(BsonDocument bsonDocument)
        {
            if (bsonDocument == null)
            {
                return new User();
            }

            User response = new User();
            response.Name = bsonDocument.GetValue("Nome").ToString();
            return response;
        }
    }

    public class User
    {
        public string Name { get; set; }
    }
}