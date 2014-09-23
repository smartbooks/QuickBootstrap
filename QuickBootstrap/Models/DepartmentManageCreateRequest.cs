using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuickBootstrap.Models
{
    public class DepartmentManageCreateRequest
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "部门名称")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "是否启用")]
        public bool IsEnable { get; set; }

        [Required]
        [Display(Name = "排序")]
        public int Order { get; set; }
    }
}