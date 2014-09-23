using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuickBootstrap.Util;

namespace QuickBootstrap.Models
{
    public class TestQueryRequest : BasePermissionsModel
    {
        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string Event { get; set; }
    }
}