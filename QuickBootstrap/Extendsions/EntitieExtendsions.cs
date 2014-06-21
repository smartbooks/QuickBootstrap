using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using QuickBootstrap.Attributes;
using System.Reflection;

namespace QuickBootstrap.Extendsions
{
    public static class EntitieExtendsions
    {
        public static MvcHtmlString ToHtmlInput<T>(this HtmlHelper htmlHelper, T t) where T : class
        {
            var htmlResult = new StringBuilder();
            var properties = t.GetType().GetProperties();

            foreach (var propertyInfo in properties)
            {
                var attribs = propertyInfo.GetCustomAttributes(typeof(BootstrapInputAttribute));
                foreach (var attrib in attribs)
                {
                    var htmlTypeAttrib = attrib as BootstrapInputAttribute;
                    if (htmlTypeAttrib != null)
                    {
                        htmlResult.Append(htmlTypeAttrib.Generate(
                            htmlHelper,
                            propertyInfo.Name,
                            propertyInfo.GetValue(t)));
                    }
                }
            }

            return new MvcHtmlString(htmlResult.ToString());
        }

        public static MvcHtmlString ToHtmlInputItem<T>(this HtmlHelper htmlHelper, T t) where T : class
        {
            var stringBuilder = new StringBuilder();
            var properties = t.GetType().GetProperties();

            foreach (var propertyInfo in properties)
            {
                stringBuilder.Append("<div class='form-group'>");

                //label
                var displayNameAttribute = propertyInfo.GetCustomAttributes(typeof(DisplayNameAttribute)).FirstOrDefault() as DisplayNameAttribute;
                if (displayNameAttribute != null)
                {
                    stringBuilder.Append(htmlHelper.LabelForModel(
                        string.IsNullOrEmpty(displayNameAttribute.DisplayName) ? propertyInfo.Name : displayNameAttribute.DisplayName,
                        new { @class = "col-md-2 control-label", @for = propertyInfo.Name }));
                }

                //input
                var bootstrapInput = propertyInfo.GetCustomAttributes(typeof(BootstrapInputAttribute)).FirstOrDefault() as BootstrapInputAttribute;
                if (bootstrapInput != null)
                {
                    stringBuilder.Append("<div class='col-md-10'>");
                    stringBuilder.Append(bootstrapInput.Generate(htmlHelper, propertyInfo.Name, propertyInfo.GetValue(t)));
                    stringBuilder.Append("</div>");
                }

                stringBuilder.Append("</div>");
            }

            return new MvcHtmlString(stringBuilder.ToString());
        }
    }
}