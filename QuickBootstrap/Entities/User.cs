using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        public string UserName { get; set; }

        [Required]
        [MaxLength(32)]
        [DisplayName("登录密码")]
        public string UserPwd { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("昵称")]
        public string Nick { get; set; }

        [Required]
        [DisplayName("是否启用")]
        public bool IsEnable { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }
    }
}