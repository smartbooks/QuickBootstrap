using QuickBootstrap.Sessions;

namespace QuickBootstrap.Services
{
    public interface IManageService
    {
        void LoginOut(string username, string ipAddress);

        UserSession GetUserSession(string username, string password, string ipAddress);
    }
}