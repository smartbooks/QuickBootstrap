using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuickBootstrap.Entities;
using QuickBootstrap.Services.Models;
using QuickBootstrap.Services.Util;

namespace QuickBootstrap.Services.Impl
{
    public class UserLoginHistoryService : ServiceContext, IUserLoginHistoryService
    {
        public void Appent(UserLoginHistory model)
        {
            DbContext.UserLoginHistory.Add(model);
            DbContext.SaveChanges();
        }

        public PagedResult<UserLoginHistoryPageItem> GetList(Paging paging)
        {
            var queryPageResult = new PagedResult<UserLoginHistoryPageItem>()
            {
                PageIndex = paging.PageIndex,
                PageSize = paging.PageSize
            };

            var query = from p in DbContext.UserLoginHistory
                        orderby p.CreateTime descending
                        select new UserLoginHistoryPageItem
                        {
                            Id = p.Id,
                            UserName = p.UserName,
                            IpAddress = p.IpAddress,
                            Remark = p.Remark,
                            CreateTime = p.CreateTime,
                        };

            queryPageResult.SizeCount = query.Count();
            queryPageResult.Result = query.Skip(paging.PageIndex * paging.PageSize).Take(paging.PageSize).ToList();


            return queryPageResult;
        }
    }
}