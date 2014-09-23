using System.Collections.Generic;
using System.Linq;
using QuickBootstrap.Entities;
using QuickBootstrap.Services.Models;
using QuickBootstrap.Services.Util;

namespace QuickBootstrap.Services.Impl
{
    public class RoleService : ServiceContext, IRoleService
    {
        public PagedResult<RoleManagePageItem> GetList(Paging paging)
        {
            var queryPageResult = new PagedResult<RoleManagePageItem>()
            {
                PageIndex = paging.PageIndex,
                PageSize = paging.PageSize
            };

            var query = from p in DbContext.Role
                        orderby p.CreateTime descending
                        select new RoleManagePageItem
                        {
                            Id = p.Id,
                            CreateTime = p.CreateTime,
                            IsEnable = p.IsEnable,
                            Order = p.Order,
                            Title = p.Title
                        };

            queryPageResult.SizeCount = query.Count();
            queryPageResult.Result = query.Skip(paging.PageIndex * paging.PageSize).Take(paging.PageSize).ToList();

            return queryPageResult;
        }

        public List<Role> GetAllList()
        {
            return DbContext.Role.OrderByDescending(p => p.CreateTime).ToList();
        }
    }
}