using Domain.AccountManager;

namespace Domain.Services
{
    public class ServiceBase
    {
        public UserInformation UserInfo => UserIdentity.Instance;
    }
}
