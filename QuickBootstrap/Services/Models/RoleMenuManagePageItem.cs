using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBootstrap.Services.Models
{
    public class RoleMenuManagePageItem
    {
        public int Id { get; set; }
        
        public string RoleTitle { get; set; }
        
        public string MenuTitle { get; set; }

        public string MenuGroupTitle { get; set; }

        public DateTime CreateTime { get; set; }
    }
}