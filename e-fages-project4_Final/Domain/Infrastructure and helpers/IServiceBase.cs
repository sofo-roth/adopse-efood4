using Domain.ValueModels;


namespace Domain.Infrastructure
{
    public interface IServiceBase
    {

        UserInformation UserInfo { get; }

        void LogoutUser();

        
    }
}
