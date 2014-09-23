using System;

namespace QuickBootstrap.Services.Models
{
    public class UserManagePageItem
    {
        public string UserName { get; set; }

        public string Nick { get; set; }

        public bool IsEnable { get; set; }

        public DateTime CreateTime { get; set; }

        public string DepartmentTitle { get; set; }

        public string RoleTitle { get; set; }
    }
}