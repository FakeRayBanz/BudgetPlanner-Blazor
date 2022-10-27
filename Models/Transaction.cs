using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization;

namespace BudgetPlanner_Blazor.Models
{
    public class Transaction
    {
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        public string? TransactionId { get; set; }
        public string? FormattedDate { get; set; }
        public string? Description { get; set; }
        public string? Amount { get; set; }
        public double? AmountNumeric { get; set; }
        public string? Balance { get; set; }
        public double? BalanceNumeric { get; set; }
        public bool IsDebit { get; set; }
        public bool Necessary { get; set; }
    }
}
