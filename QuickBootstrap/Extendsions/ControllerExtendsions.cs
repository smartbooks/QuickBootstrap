using System.Web.Mvc;
using QuickBootstrap.Filters;

namespace QuickBootstrap.Extendsions
{
    public static class ControllerExtendsions
    {
        public static string GetCookieUserName(this Controller controller)
        {
            var username = string.Empty;

            if (controller.Request.Cookies[UserAuthorizationAttribute.CookieUserName] != null)
            {
                username = controller.Request.Cookies[UserAuthorizationAttribute.CookieUserName].Value;
            }

            return username;
        }
    }
}