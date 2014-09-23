using System.Linq;
using QuickBootstrap.Services.Models;
using QuickBootstrap.Services.Util;

namespace QuickBootstrap.Services.Impl
{
    public class RoleMenuService : ServiceContext, IRoleMenuService
    {
        public PagedResult<RoleMenuManagePageItem> GetList(Paging paging)
        {
            var queryPageResult = new PagedResult<RoleMenuManagePageItem>()
            {
                PageIndex = paging.PageIndex,
                PageSize = paging.PageSize
            };

            var query = from menu in DbContext.Menu
                        from role in DbContext.Role
                        from roleMenu in DbContext.RoleMenu
                        where roleMenu.MenuId == menu.Id && roleMenu.RoleId == role.Id
                        orderby roleMenu.CreateTime, role.Title, menu.GroupTitle, menu.Title descending
                        select new RoleMenuManagePageItem
                        {
                            Id = roleMenu.Id,
                            CreateTime = roleMenu.CreateTime,
                            RoleTitle = role.Title,
                            MenuTitle = menu.Title,
                            MenuGroupTitle = menu.GroupTitle
                        };

            queryPageResult.SizeCount = query.Count();
            queryPageResult.Result = query.Skip(paging.PageIndex * paging.PageSize).Take(paging.PageSize).ToList();

            return queryPageResult;
        }
    }
}