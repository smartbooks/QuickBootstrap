using System.Collections.Generic;
using System.Linq;
using QuickBootstrap.Services.Models;
using QuickBootstrap.Services.Util;

namespace QuickBootstrap.Services.Impl
{
    public class UserPermissionsService : ServiceContext, IUserPermissionsService
    {
        public List<UserRoleMenuItem> GetUserRoleMenu(string username)
        {
            var query = from u in DbContext.User
                        from p in DbContext.RoleMenu
                        from m in DbContext.Menu
                        where u.UserName == username && u.RoleId == p.RoleId && p.MenuId == m.Id
                        orderby m.Order descending
                        select new UserRoleMenuItem
                        {
                            Title = m.Title,
                            GroupTitle = m.GroupTitle,
                            Path = m.Path
                        };

            return query.ToList();
        }
    }
}