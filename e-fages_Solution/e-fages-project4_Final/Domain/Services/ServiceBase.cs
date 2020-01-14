using Domain.AccountManager;
using Domain.Repositories;
using Domain.ValueModels;
using System;
using System.Diagnostics;

namespace Domain.Services
{
    public abstract class ServiceBase
    {
        public UserInformation UserInfo => UserIdentity.Instance;

        
        private protected readonly ShopRepository _repository;

        public ServiceBase()
        {
            try
            {
                _repository = new ShopRepository();
            }
            catch (TypeInitializationException ex)
            {
                Trace.WriteLine(ex.InnerException);
                throw;
            }
           
        }

        

        public virtual void LogoutUser()
        {
            UserIdentity.SetInstance(new UserInformation());
            
        }

        

    }
}
