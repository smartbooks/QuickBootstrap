using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuickBootstrap.Models
{
    public class DepartmentManageEditRequest : DepartmentManageCreateRequest
    {
        [Key]
        [Display(Name = "主键编号")]
        public int Id { get; set; }
    }
}