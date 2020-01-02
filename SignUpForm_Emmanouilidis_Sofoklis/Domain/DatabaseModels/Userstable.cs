using Domain.Infrastructure;


namespace Domain.DatabaseModels
{
    internal class Userstable : IDataTable
    {
        [PrimaryKey]
        public int UserId { get; set; }

        public string Username { get; set; }
        public string Passwd { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        
        public bool AllowDataUsage { get; set; }


    }
}
