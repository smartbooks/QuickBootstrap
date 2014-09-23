using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBootstrap.Services.Models
{
    public class UserLoginHistoryPageItem
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string IpAddress { get; set; }

        public string Remark { get; set; }

        public DateTime CreateTime { get; set; }
    }
}