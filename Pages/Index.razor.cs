using BudgetPlanner_Blazor.Models;
using MongoDB.Bson.Serialization.Serializers;

namespace BudgetPlanner_Blazor.Pages
{
    public partial class Index
    {
        public class ObjectSerializer : ClassSerializerBase<Account>
        {

        }
    }
}
