using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBootstrap.Services.Models
{
    public class MenuManagePageItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsEnable { get; set; }

        public string Path { get; set; }

        public int Order { get; set; }

        public string GroupTitle { get; set; }

        public DateTime CreateTime { get; set; }
    }
}