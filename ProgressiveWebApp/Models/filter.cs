using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgressiveWebApp.Models
{
    public class filter: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (HttpContext.Current.Session["LogedIn"] == null)
            {
                filterContext.Result = new RedirectResult("~/Home/LogIn");
            }
            base.OnActionExecuted(filterContext);
        }
    }
}