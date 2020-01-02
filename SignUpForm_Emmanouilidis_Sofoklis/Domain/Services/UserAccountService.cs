using Domain.AccountManager;
using Domain.API;
using Domain.Infrastructure;
using Domain.Repositories;
using Domain.ValueModels;
using Microsoft.AspNet.Identity;
using System;
using PasswordHasher = Domain.AccountManager.PasswordHasher;


namespace Domain.Services
{
    public class UserAccountService : ServiceBase, IUserAccountService
    {
        private readonly PasswordHasher _hasher ;
        private readonly UserAccountRepository _userRepository;
        private readonly ShopRepository _shopRepository;
        private readonly GeolocationAPI _geoLocation;



        public UserAccountService()
        {
            _hasher = new PasswordHasher();
            _userRepository = new UserAccountRepository();
            _shopRepository = new ShopRepository();
            _geoLocation = new GeolocationAPI();
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

        public void CreateUser(UserInformation user)
        {
            int id = 0;

            user.Passwd = RetrieveHash(user.Passwd);
            user.isShopOwner = false;

            id = _userRepository.Create(user);

            if (id <= 0)
                throw new Exception("An unknown error occured. Registration failed.");

            user.UserId = id;
            UserIdentity.SetInstance(user);
        }

        public void CreateUserShopOwner(UserInformation user, ShopInformation shop)
        {
            int id = 0;

            user.Passwd = RetrieveHash(user.Passwd);
            user.isShopOwner = true;

            id = _userRepository.Create(user);

            if (id <= 0)
                throw new Exception("An unknown error occured. Registration failed.");

            user.UserId = id;
            UserIdentity.SetInstance(user);

            shop.OwnerId = id;

            var coords = _geoLocation.CalculateLatLong(shop.Address);
            shop.Latitude = coords.Latitude;
            shop.Longitude = coords.Longitude;

            _shopRepository.Create(shop);

        }

        public void Update(UserInformation user)
        {
            user.UserId = UserInfo.UserId;

            user.Passwd = UserInfo.Passwd;

            _userRepository.Update(user);

            UserIdentity.SetInstance(user);
        }

        public void UpdateWithNewPassword(UserInformation user, string oldPassword)
        {
            var isValid = VerifyUserPassword(oldPassword, UserInfo.Passwd);
            if (!isValid)
                throw new Exception("Wrong password provided.");

            user.UserId = UserInfo.UserId;

            user.Passwd = RetrieveHash(user.Passwd);

            _userRepository.Update(user);
            
            UserIdentity.SetInstance(user);
        }

        public void GetUserOrders()
        {
            //todo return model for a grid with db info
        }

    }
}
