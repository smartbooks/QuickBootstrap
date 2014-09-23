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
                Nick = "王亚", 
                DepartmentId = 1,
                RoleId = 1}
            }.ForEach(m => context.User.Add(m));

            //部门
            new List<Department>
            {
                new Department{CreateTime = DateTime.Now,Title = "默认部门",IsEnable = true,Order = 100}
            }.ForEach(m => context.Department.Add(m));

            //角色
            new List<Role>
            {
                new Role{CreateTime = DateTime.Now,IsEnable = true,Order = 100,Title = "超级管理员"},
                new Role{CreateTime = DateTime.Now,IsEnable = true,Order = 99,Title = "来宾"}
            }.ForEach(m => context.Role.Add(m));

            //菜单
            new List<Menu>
            {
                new Menu{CreateTime = DateTime.Now,IsEnable = true,Order = 100,Title = "用户浏览",Path = "/UserManage",GroupTitle = "用户管理"}
            }.ForEach(m => context.Menu.Add(m));

            //菜单动作表
            new List<MenuAction>
            {
                new MenuAction{CreateTime = DateTime.Now,IsEnable = true,Order = 100, MenuId = 1, Title = "查询", Event = "Click"},
                new MenuAction{CreateTime = DateTime.Now,IsEnable = true,Order = 99, MenuId = 1, Title = "添加用户", Event = "Create"},
                new MenuAction{CreateTime = DateTime.Now,IsEnable = true,Order = 98, MenuId = 1, Title = "删除用户", Event = "Delete"},
                new MenuAction{CreateTime = DateTime.Now,IsEnable = true,Order = 97, MenuId = 1, Title = "导出", Event = "Export"},
            }.ForEach(m => context.MenuAction.Add(m));

            //角色菜单
            new List<RoleMenu>
            {
                new RoleMenu{MenuId = 1, RoleId = 1, CreateTime = DateTime.Now}
            }.ForEach(m => context.RoleMenu.Add(m));
        }
    }
}
