namespace Domain.ValueModels
{
    public class UserInformation
    {

        public string Username { get; set; }
        public string Passwd { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public bool IsShopOwner { get; set; }

        public bool AllowDataUsage { get; set; }
        public int UserId { get; set; }


        public UserInformation Clone()
        {
           return MemberwiseClone() as UserInformation;
        }
    }
}
