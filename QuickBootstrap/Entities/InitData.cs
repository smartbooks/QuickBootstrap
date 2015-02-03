using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace QuickBootstrap.Entities
{
    /// <summary>
    /// 数据库初始化种子
    /// </summary>
    public sealed class InitData : CreateDatabaseIfNotExists<DefaultDbContext>
    {
        protected override void Seed(DefaultDbContext context)
        {
            //默认用户
            new List<User>
            {
                new User{
                UserName="mr.wangya@qq.com", 
                UserPwd= "670b14728ad9902aecba32e22fa4f6bd", 
                CreateTime = DateTime.Now, 
                IsEnable = true,
                Nick = "SmartBooks"}
            }.ForEach(m => context.User.Add(m));
        }
    }
}
