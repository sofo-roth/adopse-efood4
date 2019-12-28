using Domain.Infrastructure;


namespace Domain.AccountManager
{
    public sealed class UserIdentity 
    {
        private static UserIdentity _singletonUser = new UserIdentity();
        private static readonly object _lock = new object();
        
        public UserInformation UserInfo = new UserInformation();


        private UserIdentity() { }



        public static void SetInstance(UserInformation info)
        {
            
            PropertyCopier.Copy(info,_singletonUser.UserInfo);

        }

        public static UserInformation Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_singletonUser == null)
                    {
                        _singletonUser = new UserIdentity();
                    }

                }
                return _singletonUser.UserInfo.Clone();
            }
           
        }
        
        

    }
}
