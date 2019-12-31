using Domain.Infrastructure;


namespace Domain.DatabaseModels
{
    internal class OrderLines
    {
        [PrimaryKey]
        public int LineId { get; set; }

        public int OrderId { get; set; }
        public int? IngredientId { get; set; }
        public int? FoodItemId { get; set; }
        public int? ParentId { get; set; }
    }
}
