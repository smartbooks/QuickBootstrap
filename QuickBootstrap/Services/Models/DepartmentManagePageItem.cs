using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBootstrap.Services.Models
{
    public class DepartmentManagePageItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsEnable { get; set; }

        public int Order { get; set; }

        public DateTime CreateTime { get; set; }
    }
}