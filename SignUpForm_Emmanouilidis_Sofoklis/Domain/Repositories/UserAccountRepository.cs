using Domain.Context;
using Domain.DatabaseModels;
using Domain.Infrastructure;
using Domain.ValueModels;

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

        public int Update(UserInformation user)
        {
            var userDto = new Userstable();
            PropertyCopier<UserInformation, Userstable>.Copy(user, userDto);
            

            var script = GetUpdateScript(userDto);

            return ExecDbScripts(script);
        }
    }
}
