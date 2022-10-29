using BudgetPlanner_Blazor.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace BudgetPlanner_Blazor.Shared
{
    public class DataState
    {
        [Required]
        public string? DBUserName { get; set; }
        [Required]
        public string? DBPassword { get; set; }
        [Required]
        public string? DBServerAddress { get; set; }
        public string? ConnectionString { get; set; }
        public bool? ConnectionSuccess { get; set; } = null;
        public MongoClient? Client { get; set; }
        public IMongoDatabase? Database { get; set; }
        public IMongoCollection<Account>? AccountsCollection { get; set; }

        public List<Account> AccountList { get; set; } = new List<Account>();
        public Account GlobalAccount { get; set; } = new Account();
        public async Task ConnectToDB()
        {
            try
            {
                ConnectionString = $"mongodb://{DBUserName}:{DBPassword}@{DBServerAddress}";
                Client = new MongoClient(ConnectionString);
                Database = Client.GetDatabase("admin");
                AccountsCollection = Database.GetCollection<Account>("Accounts");
                AccountList = AccountsCollection.Find(new BsonDocument()).ToList();
                ConnectionSuccess = true;
            }

            catch (MongoAuthenticationException)
            {
                ConnectionSuccess = false;
            }
            
        }
        public void GenerateGlobalAccount()
        {
            Account globalAccount = new Account();
            globalAccount.Transactions = JsonSerializer.Deserialize<List<Transaction>>(JsonSerializer.Serialize(AccountList[1].Transactions));
            //globalAccount.Transactions = dataState.AccountList[1].Transactions;
            foreach (var transaction in globalAccount.Transactions)
            {
                foreach (var secondTransaction in AccountList[0].Transactions)
                {
                    if (transaction.FormattedDate == secondTransaction.FormattedDate)
                    {
                        transaction.BalanceNumeric += secondTransaction.BalanceNumeric;
                        break;
                    }
                }
            }
            GlobalAccount = globalAccount;
        }
    }
}
