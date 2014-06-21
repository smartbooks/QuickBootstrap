// 
// Copyright (c) 2014,SmartBooks
// All rights reserved.
// 
// 文件名称：ProfileService.cs
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
    public sealed class ProfileService : ServiceContext, IProfileService
    {
        public User GetUserInfo(string username = "")
        {
            return DbContext.User.FirstOrDefault(p => p.UserName == username);
        }

        public bool ChangePassword(string username = "", string newPassword = "")
        {
            var userInfo = GetUserInfo(username);

            if (userInfo == null) return false;

            userInfo.UserPwd = newPassword;
            DbContext.Entry(userInfo).State = EntityState.Modified;
            return DbContext.SaveChanges() > 0;
        }
    }
}