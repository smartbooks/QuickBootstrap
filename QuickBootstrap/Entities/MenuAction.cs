using System;
using System.ComponentModel.DataAnnotations;

namespace QuickBootstrap.Entities
{
    /// <summary>
    /// 菜单动作表
    /// 常用动作：添加、删除、修改、查询、打印、下载
    /// </summary>
    public class MenuAction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(1024)]
        public string Event { get; set; }

        [Required]
        public bool IsEnable { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }
    }
}