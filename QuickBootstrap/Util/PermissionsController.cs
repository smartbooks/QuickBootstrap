using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickBootstrap.Util
{
    public abstract class PermissionsController : Controller
    {
        public virtual ActionResult Query(BasePermissionsModel model)
        {
            throw new NotImplementedException();
        }
    }
}