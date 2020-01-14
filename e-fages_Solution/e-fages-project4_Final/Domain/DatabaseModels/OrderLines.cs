using Domain.Infrastructure;


namespace Domain.DatabaseModels
{
    internal class OrderLines : IDataTable
    {
        [PrimaryKey]
        public int LineId { get; set; }

        public int OrderId { get; set; }
        public int? IngId { get; set; }
        public int? FoodItemId { get; set; }
        public int? ParentId { get; set; }
    }
}
