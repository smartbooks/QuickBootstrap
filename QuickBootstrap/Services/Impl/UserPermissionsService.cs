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
                        where r.UserName == username && r.RoleId == p.RoleId && p.MenuId == m.Id
                        orderby m.Order descending
                        group m by new { m.Title, m.GroupTitle, m.Path } into tempGroup
                        select new UserRoleMenuItem
                        {
                            Title = tempGroup.Key.Title,
                            GroupTitle = tempGroup.Key.GroupTitle,
                            Path = tempGroup.Key.Path
                        };

            return query.ToList();
        }
    }
}