using Domain.API;
using Domain.Infrastructure;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueModels;

namespace Domain.Services
{
    public class ShopResultsService : ServiceBase
    {

        ShopResultsRepository _repository;
        GeolocationAPI _geoLocation;


        public ShopResultsService() 
        {
            _repository = new ShopResultsRepository();
            _geoLocation = new GeolocationAPI(); 

        }

        public IEnumerable<ShopGridViewModel> Read(string address, ref Dictionary<int, string> foodCategories)
        {

            var dto = _repository.Read(address, ref foodCategories);
            
            dto.Update(x => x.Distance = _geoLocation.CalculateDistance(address, x.Address));

            return dto.Where(x => x.Distance < 5000);

        }

        public void RecordClick(int shopId)
        {
            _repository.RecordClick(UserInfo.UserId, shopId);
        }


    }
}
