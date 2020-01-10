using Domain.API;
using Domain.Infrastructure;
using Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using Domain.ValueModels;
using System;

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
            var dto = _repository.Read(address, ref foodCategories).ToList();
            var addressCoords = _geoLocation.CalculateLatLong(address);
            
            dto.Update(x => x.Distance = Math.Round(_geoLocation.CalculateDistance(address, addressCoords, x))); 

            return dto.Where(x => x.Distance < 10000);
        }

        public void RecordClick(int shopId)
        {
            var id = UserInfo.UserId;
            if (id <= 0) return;
            _userRepository.RecordClick(id, shopId);
        }

        

    }
}
