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
                new User{UserName="mr.wangya@qq.com", UserPwd= "670b14728ad9902aecba32e22fa4f6bd", CreateTime = DateTime.Now, Nick = "王亚", DepartmentId = 1}
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
                new Menu{CreateTime = DateTime.Now,IsEnable = true,Order = 100,Title = "用户浏览",Path = "/UserManage",GroupTitle = "用户管理"},
                new Menu{CreateTime = DateTime.Now,IsEnable = true,Order = 99,Title = "添加用户",Path = "/UserManage/Create",GroupTitle = "用户管理"},
                new Menu{CreateTime = DateTime.Now,IsEnable = true,Order = 99,Title = "删除用户",Path = "/UserManage/Delete",GroupTitle = "用户管理"}
            }.ForEach(m => context.Menu.Add(m));

            //菜单动作表
            new List<MenuAction>
            {
                new MenuAction{CreateTime = DateTime.Now,IsEnable = true,Order = 100,Title = "查询",Event = "Click"},
                new MenuAction{CreateTime = DateTime.Now,IsEnable = true,Order = 99,Title = "添加",Event = "Create"},
                new MenuAction{CreateTime = DateTime.Now,IsEnable = true,Order = 98,Title = "删除",Event = "Delete"},
                new MenuAction{CreateTime = DateTime.Now,IsEnable = true,Order = 97,Title = "导出",Event = "Export"},
            }.ForEach(m => context.MenuAction.Add(m));

            //菜单动作表
            new List<RoleMenuAction>
            {
                new RoleMenuAction{RoleId = 1, MenuId = 1, MenuActionId = 1},
                new RoleMenuAction{RoleId = 1, MenuId = 1, MenuActionId = 2},
                new RoleMenuAction{RoleId = 1, MenuId = 1, MenuActionId = 3},
                new RoleMenuAction{RoleId = 1, MenuId = 1, MenuActionId = 4},
                new RoleMenuAction{RoleId = 1, MenuId = 2, MenuActionId = 2},
                new RoleMenuAction{RoleId = 1, MenuId = 3, MenuActionId = 3},
            }.ForEach(m => context.RoleMenuAction.Add(m));

            //用户角色表
            new List<UserRole>
            {
                new UserRole{UserName="mr.wangya@qq.com", RoleId = 1}
            }.ForEach(m => context.UserRole.Add(m));
        }
    }
}
