using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace QuickBootstrap.Attributes
{
    public abstract class BootstrapInputAttribute : Attribute
    {
        public string CssClass { get; set; }

        public string CssStyle { get; set; }

        public abstract MvcHtmlString Generate(HtmlHelper htmlHelper, string name, object value);

        protected BootstrapInputAttribute()
        {
            CssClass = "form-control";
            CssStyle = "width: 280px;";
        }
    }
}