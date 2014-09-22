using System;
using System.ComponentModel.DataAnnotations;

namespace QuickBootstrap.Entities
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public bool IsEnable { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }
    }
}