using Domain.AccountManager;
using Domain.Repositories;
using Microsoft.AspNet.Identity;
using System;
using PasswordHasher = Domain.AccountManager.PasswordHasher;


namespace Domain.Services
{
    public class UserAccountService : ServiceBase
    {
        private readonly PasswordHasher _hasher ;
        private readonly UserAccountRepository _repository;

        

        public UserAccountService()
        {
            _hasher = new PasswordHasher();
            _repository = new UserAccountRepository();
        }

        public string RetrieveHash(string pwd)
        {
            return _hasher.HashPassword(pwd);
        }

        public void SetUserInfo(UserInformation info)
        {
            UserIdentity.SetInstance(info);
        }

        public bool VerifyUserPassword(string providedPassword, string databasePassword)
        {
                        
            var verificationResult = _hasher.VerifyHashedPassword(databasePassword, providedPassword);

            return verificationResult == PasswordVerificationResult.Success;
        }

        public void Create(UserInformation user)
        {
            int id = 0;

            id = _repository.Create(user);

            user.UserId = id;

            if (id <= 0)
                throw new Exception("An unknown error occured. Registration failed.");

            UserIdentity.SetInstance(user);
        }

        public void Update(UserInformation user)
        {
            var id = UserInfo.UserId;

             _repository.Update(user, id);

            user.UserId = id;
            UserIdentity.SetInstance(user);
        }

        public void LogoutUser()
        {
            UserIdentity.SetInstance(new UserInformation());
        }

    }
}
