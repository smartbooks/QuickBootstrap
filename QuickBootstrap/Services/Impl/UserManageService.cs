using System.Data.Entity;
using System.Linq;
using EntityFramework.Extensions;
using QuickBootstrap.Entities;
using QuickBootstrap.Services.Models;
using QuickBootstrap.Services.Util;

namespace QuickBootstrap.Services.Impl
{
    public sealed class UserManageService : ServiceContext, IUserManageService
    {
        public PagedResult<UserManagePageItem> GetList(Paging paging)
        {
            var queryPageResult = new PagedResult<UserManagePageItem>
            {
                PageIndex = paging.PageIndex,
                PageSize = paging.PageSize,
            };

            var query = from user in DbContext.User
                        orderby user.CreateTime descending
                        select new UserManagePageItem
                        {
                            UserName = user.UserName,
                            Nick = user.Nick,
                            IsEnable = user.IsEnable,
                            CreateTime = user.CreateTime,
                        };

            queryPageResult.SizeCount = query.Count();
            queryPageResult.Result = query.Skip(paging.PageIndex * paging.PageSize).Take(paging.PageSize).ToList();

            return queryPageResult;
        }

        public bool Create(User model)
        {
            DbContext.User.Add(model);
            return DbContext.SaveChanges() > 0;
        }

        public bool ExistsUser(string username)
        {
            return DbContext.User.FirstOrDefault(p => p.UserName == username) != null;
        }

        public User Get(string username = "")
        {
            return DbContext.User.FirstOrDefault(p => p.UserName == username);
        }

        public bool Edit(User model)
        {
            DbContext.Entry(model).State = EntityState.Modified;
            return DbContext.SaveChanges() > 0;
        }

        public bool Delete(string username)
        {
            return DbContext.User.Delete(p => p.UserName == username) > 0;
        }
    }
}