using System.ComponentModel.DataAnnotations;

namespace QuickBootstrap.Entities
{
    /// <summary>
    /// 用户角色表
    /// </summary>
    public class UserRole
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        /// <summary>
        /// 角色编号
        /// </summary>
        [Required]
        public int RoleId { get; set; }
    }
}