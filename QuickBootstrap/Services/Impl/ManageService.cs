// 
// Copyright (c) 2014,SmartBooks
// All rights reserved.
// 
// 文件名称：ManageService.cs
// 项目名称：QuickBootstrap
// 摘      要：简要描述本文件的内容
// 
// 当前版本：1.0
// 作      者：ya wang
// 完成日期：2014年05月14日
// 

using System;
using System.Linq;
using QuickBootstrap.Entities;
using QuickBootstrap.Services.Util;
using QuickBootstrap.Sessions;

namespace QuickBootstrap.Services.Impl
{
    public sealed class ManageService : ServiceContext, IManageService
    {
        private readonly IUserLoginHistoryService _userLoginHistoryService = new UserLoginHistoryService();

        public void LoginOut(string username, string ipAddress)
        {
            //记录注销日志
            _userLoginHistoryService.Appent(new UserLoginHistory
            {
                CreateTime = DateTime.Now,
                IpAddress = ipAddress,
                UserName = username,
                Remark = "注销登录"
            });
        }

        public UserSession GetUserSession(string username, string password, string ipAddress)
        {
            var model = DbContext.User.Where(p => p.UserName == username && p.UserPwd == password && p.IsEnable)
                .Select(p => new UserSession
                {
                    UserName = p.UserName,
                    UserNick = p.Nick,
                    LoginIpAddress = ipAddress,
                    LoginDateTime = DateTime.Now,
                    DepartmentId = p.DepartmentId,
                    RoleId = p.RoleId
                })
                .FirstOrDefault();

            //记录日志
            _userLoginHistoryService.Appent(new UserLoginHistory
            {
                CreateTime = DateTime.Now,
                IpAddress = ipAddress,
                UserName = username,
                Remark = model == null ? "登录失败" : "登录成功"
            });

            return model;
        }
    }
}