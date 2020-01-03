using Domain.AccountManager;
using Domain.Repositories;
using Domain.ValueModels;


namespace Domain.Services
{
    public abstract class ServiceBase
    {
        public UserInformation UserInfo => UserIdentity.Instance;

        
        private protected readonly ShopRepository _repository;

        public ServiceBase()
        {
            _repository = new ShopRepository();
        }

        

        public virtual void LogoutUser()
        {
            UserIdentity.SetInstance(new UserInformation());
            
        }

        

    }
}
