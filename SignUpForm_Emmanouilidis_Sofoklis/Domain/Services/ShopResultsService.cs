using Domain.API;
using Domain.Infrastructure;
using Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using Domain.ValueModels;

namespace Domain.Services
{
    public class ShopResultsService : ServiceBase, IShopResultsService
    {

        private readonly GeolocationAPI _geoLocation;

        private readonly UserAccountRepository _userRepository;

        public ShopResultsService() : base()
        {
            _geoLocation = new GeolocationAPI();
            _userRepository = new UserAccountRepository();
        }

        public IEnumerable<ShopGridViewModel> Read(string address, ref Dictionary<int, string> foodCategories)
        {
            var dto = _repository.Read(address, ref foodCategories);
            
            dto.Update(x => x.Distance = _geoLocation.CalculateDistance(address, x)); 

            return dto.Where(x => x.Distance < 5000);
        }

        public void RecordClick(int shopId)
        {
            _userRepository.RecordClick(UserInfo.UserId, shopId);
        }

        

    }
}
