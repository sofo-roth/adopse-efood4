using Domain.AccountManager;
using Domain.Context;
using Domain.DatabaseModels;
using Domain.Infrastructure;


namespace Domain.Repositories
{
    class UserAccountRepository : SqlContextBase
    {
        
        public int Create(UserInformation user)
        {
            var userDto = new Userstable();
            PropertyCopier<UserInformation, Userstable>.Copy(user, userDto);

            var script = GetInsertScripts(userDto);

            return ExecDbScripts(script);
        }

        public int Update(UserInformation user,int id)
        {
            var userDto = new Userstable();
            PropertyCopier<UserInformation, Userstable>.Copy(user, userDto);
            userDto.UserId = id;

            var script = GetUpdateScript(userDto);

            return ExecDbScripts(script);
        }
    }
}
