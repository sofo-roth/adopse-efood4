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
            var newUser = UserIdentity.Instance;

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
            shop.IsActive = false;

            _repository.Create(shop);

            return id;

        }

        public void Update(UserInformation user)
        {
            user.Passwd = UserInfo.Passwd;

            UpdateUser(user);
        }

        public void UpdateWithNewPassword(UserInformation user, string oldPassword)
        {
            var isValid = VerifyUserPassword(oldPassword, UserInfo.Passwd);
            if (!isValid)
                throw new Exception("Wrong password provided.");

            user.Passwd = RetrieveHash(user.Passwd);

            UpdateUser(user);
        }

        private void UpdateUser(UserInformation user)
        {
            if (UserInfo.UserId <= 0) throw new InvalidOperationException("Can't update user info without loging in.");

            user.UserId = UserInfo.UserId;

            var isNewUsername = !user.Username.Equals(UserInfo.Username);

            _userRepository.Update(user, isNewUsername);

            UserIdentity.SetInstance(user);
        }

        public bool LoginUser(string username, string providedPassword)
        {
            var user = UserIdentity.Instance;

            user = _userRepository.ReadUser(username);

            if (!VerifyUserPassword(providedPassword, user.Passwd)) return false;

            UserIdentity.SetInstance(user);

            return true;
        }

        public List<OrderDetailsGridViewModel> GetUserOrders()
        {
            return _ordersRepository.Read(UserInfo.UserId);
        }

        public List<OrderItemViewModel> GetOrderItems(int orderId)
        {

            return _ordersRepository.ReadLines(orderId);
        }

    }
}
