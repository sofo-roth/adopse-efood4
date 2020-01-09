
using Domain.Infrastructure;

namespace Domain.ValueModels
{
    public class UserShopRatingInformation
    {
        public bool isAllowed { get; set; }
        //public int? Rating { get; set; }

        public Rating StarRating { get; set; }
        //public string Description { get; set; }

        public UserShopRatingInformation()
        {
            isAllowed = false;
            StarRating = Rating.None;
        }
    }
}
