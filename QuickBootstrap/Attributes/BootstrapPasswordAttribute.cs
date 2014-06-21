using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace QuickBootstrap.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,AllowMultiple = false)]
    public class BootstrapPasswordAttribute : BootstrapInputAttribute
    {
        public override MvcHtmlString Generate(HtmlHelper htmlHelper, string name, object value)
        {
            return htmlHelper.Password(name, value, new { @class = CssClass, style = CssStyle });
        }
    }
}