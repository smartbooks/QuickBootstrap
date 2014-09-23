using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuickBootstrap.Entities
{
    /// <summary>
    /// 用户登录历史日志表
    /// </summary>
    public class UserLoginHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(15)]
        public string IpAddress { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }

        public UserLoginHistory()
        {
            Remark = string.Empty;
            UserName = string.Empty;
            IpAddress = string.Empty;
        }
    }
}