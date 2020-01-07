using Domain.Context;
using Domain.DatabaseModels;
using Domain.Infrastructure;
using Domain.ValueModels;
using MySql.Data.MySqlClient;
using System;

namespace Domain.Repositories
{
    internal sealed class UserAccountRepository : SqlContextBase
    {

        public int Create(UserInformation user)
        {
            if (CheckIfExists(user.Username)) return -1;

            var userDto = new Userstable();
            PropertyCopier<UserInformation, Userstable>.Copy(user, userDto);

            var script = GetInsertScript(userDto);

            return ExecDbScripts(script);
        }

        public int Update(UserInformation user)
        {
            var userDto = new Userstable();
            PropertyCopier<UserInformation, Userstable>.Copy(user, userDto);


            var script = GetUpdateScript(userDto);

            return ExecDbScripts(script);
        }

        public void RecordClick(int userId, int shopId)
        {
            var dto = new UserClicks
            {
                ClickDate = DateTime.Now,
                ShopId = shopId,
                UserId = userId
            };

            var script = GetInsertScript(dto);

            ExecDbScripts(script);

        }

        public UserInformation ReadUser(string username)
        {
            var user = GetUserInfo(username);

            var userModel = new UserInformation();
            PropertyCopier<Userstable, UserInformation>.Copy(user, userModel);

            return userModel;
        }


        private Userstable GetUserInfo(string username)
        {
            var user = new Userstable();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var sql = @"SELECT * FROM UsersTable WHERE Username=@username";

                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    var reader = command.ExecuteReader();
                    user = CreateInstance<Userstable>(reader);


                }
                connection.Close();
            }
            return user;
        }

        private bool CheckIfExists(string username)
        {
            var user = GetUserInfo(username);

            return user.UserId > 0;
        }

    }
}
