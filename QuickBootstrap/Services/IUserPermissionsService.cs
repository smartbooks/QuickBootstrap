
using System.Collections.Generic;
using QuickBootstrap.Services.Models;

namespace QuickBootstrap.Services
{
    public interface IUserPermissionsService
    {
        List<UserRoleMenuItem> GetUserRoleMenu(string username);
    }
}
