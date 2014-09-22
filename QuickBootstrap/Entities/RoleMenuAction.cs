using System.ComponentModel.DataAnnotations;

namespace QuickBootstrap.Entities
{
    /// <summary>
    /// 角色菜单动作表
    /// </summary>
    public class RoleMenuAction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public int MenuId { get; set; }

        [Required]
        public int MenuActionId { get; set; }
    }
}