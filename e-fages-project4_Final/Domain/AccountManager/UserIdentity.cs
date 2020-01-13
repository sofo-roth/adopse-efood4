using Domain.Infrastructure;
using Domain.ValueModels;

namespace Domain.AccountManager
{
    public sealed class UserIdentity 
    {
        private static UserIdentity _singletonUser = null;
        private static readonly object _padlock = new object();
        
        public UserInformation UserInfo;


        private UserIdentity()
        {

            UserInfo = new UserInformation
            {
                UserId = -1
            };
        }

        
        public static void SetInstance(UserInformation info)
        {
            
            PropertyCopier.Copy(info,_singletonUser.UserInfo);

        }

        public static UserInformation Instance
        {
            get
            {
                if (_singletonUser == null)
                {
                    lock (_padlock)
                    {
                        if (_singletonUser == null)
                            _singletonUser = new UserIdentity();
                        
                    }
                }
                return _singletonUser.UserInfo.Clone();
            }
           
        }
                

    }
}
