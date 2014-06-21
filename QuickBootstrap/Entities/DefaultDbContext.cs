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

    }
}