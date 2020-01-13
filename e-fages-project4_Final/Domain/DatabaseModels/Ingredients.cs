using Domain.Infrastructure;

namespace Domain.DatabaseModels
{
    internal class Ingredients : IDataTable
    {
        [PrimaryKey]
        public int IngId { get; set; }

        public string IName { get; set; }
    }
}
