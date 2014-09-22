using System;
using System.ComponentModel.DataAnnotations;

namespace QuickBootstrap.Entities
{
    /// <summary>
    /// 菜单表
    /// </summary>
    public class Menu
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(1024)]
        public string Path { get; set; }

        [Required]
        public bool IsEnable { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        [StringLength(50)]
        public string GroupTitle { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }
    }
}