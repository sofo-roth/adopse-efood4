using Domain.Context;
using Domain.DatabaseModels;
using Domain.Infrastructure;
using Domain.ValueModels;
using MySql.Data.MySqlClient;


namespace Domain.Repositories
{
    internal sealed class UserAccountRepository : SqlContextBase
    {

        public int Create(UserInformation user)
        {
            if (CheckIfExists(user.Username)) throw new System.Exception("Username already exists");

            var userDto = new Userstable();
            PropertyCopier<UserInformation, Userstable>.Copy(user, userDto);

            var script = GetInsertScripts(userDto);

            return ExecDbScripts(script);
        }

        public int Update(UserInformation user)
        {
            var userDto = new Userstable();
            PropertyCopier<UserInformation, Userstable>.Copy(user, userDto);


            var script = GetUpdateScript(userDto);

            return ExecDbScripts(script);
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

            return user.UserId <= 0;
        }

    }
}
