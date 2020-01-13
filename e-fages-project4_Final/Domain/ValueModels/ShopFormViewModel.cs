using System.Collections.Generic;


namespace Domain.ValueModels
{
    public class ShopFormViewModel
    {
        public ShopInformation Info { get; set; }
        public UserShopRatingInformation UserRating { get; set; }

        public Dictionary<string,List<FoodItemViewModel>> FoodItems { get; set; } //key:  category name, string |value: list of food items of the category avaliable in the current shop. 
    }
}
