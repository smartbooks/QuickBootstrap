using System.Data.Entity;

namespace QuickBootstrap.Entities
{
    /// <summary>
    /// 默认数据上下文
    /// </summary>
    public class DefaultDbContext : DbContext
    {
        /// <summary>
        /// 用户表
        /// </summary>
        public DbSet<User> User { get; set; }

        /// <summary>
        /// 部门表
        /// </summary>
        public DbSet<Department> Department { get; set; }

        /// <summary>
        /// 菜单表
        /// </summary>
        public DbSet<Menu> Menu { get; set; }

        /// <summary>
        /// 菜单动作表
        /// </summary>
        public DbSet<MenuAction> MenuAction { get; set; }

        /// <summary>
        /// 角色表
        /// </summary>
        public DbSet<Role> Role { get; set; }

        /// <summary>
        /// 角色菜单动作表
        /// </summary>
        public DbSet<RoleMenuAction> RoleMenuAction { get; set; }

        /// <summary>
        /// 用户角色表
        /// </summary>
        public DbSet<UserRole> UserRole { get; set; }
    }
}