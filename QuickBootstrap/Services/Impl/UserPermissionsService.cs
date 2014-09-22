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
            var query = from r in DbContext.UserRole
                        from p in DbContext.RoleMenuAction
                        from m in DbContext.Menu
                        where r.UserName == username &&
                              r.RoleId == p.RoleId &&
                              p.MenuId == m.Id
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