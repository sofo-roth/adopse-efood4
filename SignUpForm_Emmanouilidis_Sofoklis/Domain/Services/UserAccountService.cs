using Domain.AccountManager;
using Domain.API;
using Domain.Infrastructure;
using Domain.Repositories;
using Domain.ValueModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using PasswordHasher = Domain.AccountManager.PasswordHasher;


namespace Domain.Services
{
    public class UserAccountService : UserCartService, IUserAccountService
    {
        private readonly PasswordHasher _hasher ;

        private readonly UserAccountRepository _userRepository;
        
        private readonly GeolocationAPI _geoLocation;



        public UserAccountService() : base()
        {
            _hasher = new PasswordHasher();
            _userRepository = new UserAccountRepository();
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

        public int CreateUser(UserInformation user)
        {
            int id = 0;

            user.Passwd = RetrieveHash(user.Passwd);
            

            id = _userRepository.Create(user);

            if (id <= 0)
                throw new Exception("An unknown error occured. Registration failed.");

            user.UserId = id;
            UserIdentity.SetInstance(user);

            return id;
        }

        public int CreateUserShopOwner(UserInformation user, ShopInformation shop)
        {
            user.IsShopOwner = true;
            var id = CreateUser(user);

            shop.OwnerId = id;

            var coords = _geoLocation.CalculateLatLong(shop.Address);
            shop.Latitude = coords.Latitude;
            shop.Longitude = coords.Longitude;

            _repository.Create(shop);

            return id;

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

        public bool LoginUser(string username, string providedPassword)
        {
            var user = _userRepository.ReadUser(username);

            if (!VerifyUserPassword(providedPassword, user.Passwd)) return false;

            UserIdentity.SetInstance(user);

            return true;
        }

        public IEnumerable<OrderDetails> GetUserOrders()
        {
            return _ordersRepository.Read(UserInfo.UserId);
        }

        public void GetOrderItems(int orderId)
        {
            //todo return model for a grid with db info
        }

    }
}
