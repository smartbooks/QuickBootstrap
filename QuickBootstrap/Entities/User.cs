using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using QuickBootstrap.Attributes;

namespace QuickBootstrap.Entities
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class User
    {
        [Key]
        [MaxLength(50)]
        [DisplayName("登录账号")]
        [BootstrapTextBox]
        public string UserName { get; set; }

        [Required]
        [MaxLength(32)]
        [DisplayName("登录密码")]
        [BootstrapPassword]
        public string UserPwd { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("昵称")]
        [BootstrapTextBox]
        public string Nick { get; set; }

        [Required]
        [DisplayName("是否启用")]
        [BootstrapCheckBox]
        public bool IsEnable { get; set; }

        [Required]
        [BootstrapHidden]
        public DateTime CreateTime { get; set; }

        [Required]
        [DisplayName("所属部门")]
        public int DepartmentId { get; set; }

        /// <summary>
        /// 角色编号
        /// </summary>
        [Required]
        public int RoleId { get; set; }
    }
}