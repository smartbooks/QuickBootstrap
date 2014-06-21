// 
// Copyright (c) 2014,SmartBooks
// All rights reserved.
// 
// 文件名称：UserManageService.cs
// 项目名称：QuickBootstrap
// 摘      要：简要描述本文件的内容
// 
// 当前版本：1.0
// 作      者：ya wang
// 完成日期：2014年05月14日
// 

using System.Data.Entity;
using System.Linq;
using QuickBootstrap.Entities;
using QuickBootstrap.Services.Util;

namespace QuickBootstrap.Services.Impl
{
    public sealed class UserManageService : ServiceContext, IUserManageService
    {
        public PagedResult<User> GetAll()
        {
            var result = new PagedResult<User>
            {
                Result = DbContext.User.OrderByDescending(p => p.CreateTime).ToList()
            };

            return result;
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
            var model = Get(username);
            if (model != null)
            {
                DbContext.Entry(model).State = EntityState.Deleted;
                return DbContext.SaveChanges() > 0;
            }
            return false;
        }
    }
}