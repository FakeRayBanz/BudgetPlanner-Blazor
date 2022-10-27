using BudgetPlanner_Blazor.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace BudgetPlanner_Blazor.Shared
{
    public class DataState
    {
        public string ConnectionString { get; set; } = "REDACTED";
        public MongoClient? Client { get; set; }
        public IMongoDatabase? Database { get; set; }
        public IMongoCollection<Account>? AccountsCollection { get; set; }

        public List<Account> AccountList { get; set; } = new List<Account>();
        public async void ConnectToDB()
        {
            Client = new MongoClient(ConnectionString);
            Database = Client.GetDatabase("admin");
            AccountsCollection = Database.GetCollection<Account>("Accounts");
            var test = AccountsCollection.Find(new BsonDocument()).ToList();
            AccountList = test;
            Console.WriteLine("Test");
            //AccountList.Add(BsonSerializer.Deserialize<BsonDocument>());
            //Fetch list of collections in Database
            //Append each to AccountList
        }
    }
}
