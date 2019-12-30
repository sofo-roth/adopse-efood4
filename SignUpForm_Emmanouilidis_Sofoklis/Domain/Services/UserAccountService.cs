using Domain.AccountManager;
using Domain.Repositories;
using Domain.ValueModels;
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

        public bool VerifyUserPassword(string providedPassword, string hashedPassword)
        {
                        
            var verificationResult = _hasher.VerifyHashedPassword(hashedPassword, providedPassword);

            return verificationResult == PasswordVerificationResult.Success;
        }

        public void Create(UserInformation user)
        {
            int id = 0;

            user.Passwd = RetrieveHash(user.Passwd);

            id = _repository.Create(user);

            if (id <= 0)
                throw new Exception("An unknown error occured. Registration failed.");

            user.UserId = id;
            UserIdentity.SetInstance(user);
        }

        public void Update(UserInformation user)
        {
            user.UserId = UserInfo.UserId;

            user.Passwd = UserInfo.Passwd; 

             _repository.Update(user);

            UserIdentity.SetInstance(user);
        }

        public void UpdateWithNewPassword(UserInformation user, string oldPassword)
        {
            var isValid = VerifyUserPassword(oldPassword, UserInfo.Passwd);
            if (!isValid)
                throw new Exception("Wrong password provided.");

            user.UserId = UserInfo.UserId;

            user.Passwd = RetrieveHash(user.Passwd);

            _repository.Update(user);
            
            UserIdentity.SetInstance(user);
        }

    }
}
