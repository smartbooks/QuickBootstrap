using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBootstrap.Entities
{
    /// <summary>
    /// 数据库初始化种子
    /// </summary>
    public sealed class InitData : CreateDatabaseIfNotExists<DefaultDbContext>
    {
        protected override void Seed(DefaultDbContext context)
        {
            new List<User>
            {
                new User
                {
                    UserName="mr.wangya@qq.com", 
                    UserPwd= "670b14728ad9902aecba32e22fa4f6bd", //000000
                    CreateTime = DateTime.Now,
                    Nick = "王亚",
                }
            }.ForEach(m => context.User.Add(m));
        }
    }
}
