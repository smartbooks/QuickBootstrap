using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuickBootstrap.Services.Models;
using QuickBootstrap.Services.Util;

namespace QuickBootstrap.Services.Impl
{
    public class MenuService : ServiceContext, IMenuService
    {
        public PagedResult<MenuManagePageItem> GetList(Paging paging)
        {
            var queryPageResult = new PagedResult<MenuManagePageItem>()
            {
                PageIndex = paging.PageIndex,
                PageSize = paging.PageSize
            };


            var query = from p in DbContext.Menu
                        orderby p.CreateTime descending
                        select new MenuManagePageItem
                        {
                            Id = p.Id,
                            CreateTime = p.CreateTime,
                            IsEnable = p.IsEnable,
                            Order = p.Order,
                            Title = p.Title,
                            Path = p.Path,
                            GroupTitle = p.GroupTitle
                        };

            queryPageResult.SizeCount = query.Count();
            queryPageResult.Result = query.Skip(paging.PageIndex * paging.PageSize).Take(paging.PageSize).ToList();


            return queryPageResult;
        }
    }
}