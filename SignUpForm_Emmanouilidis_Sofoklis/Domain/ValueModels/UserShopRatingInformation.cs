
using Domain.Infrastructure;

namespace Domain.ValueModels
{
    public class UserShopRatingInformation
    {
        public bool isAllowed { get; set; }
        //public int? Rating { get; set; }

        public Rating UserRating { get; set; }
        //public string Description { get; set; }

        public UserShopRatingInformation()
        {
            isAllowed = false;
            UserRating = Rating.None;
        }
    }
}
