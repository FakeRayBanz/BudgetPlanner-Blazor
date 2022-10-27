using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BudgetPlanner_Blazor.Models
{
    public class Account
    {
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        public string? AccountGlobalId { get; set; }
        public string? AccountName { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
