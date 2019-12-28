using Domain.Infrastructure;


namespace Domain.DatabaseModels
{
    internal class FoodItemCategories
    {
        [PrimaryKey]
        public int CategoryId { get; set; }

        public string FoodType { get; set; }
        
    }
}
