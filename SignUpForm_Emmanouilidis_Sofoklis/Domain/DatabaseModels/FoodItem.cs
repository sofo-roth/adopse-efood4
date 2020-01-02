using Domain.Infrastructure;

namespace Domain.DatabaseModels
{
    
    internal class FoodItem : IDataTable
    {
        [PrimaryKey]
        public int ItemId { get; set; }
        
        public string ItemName { get; set; }
        
        public int CategoryId { get; set; }

    }
}
