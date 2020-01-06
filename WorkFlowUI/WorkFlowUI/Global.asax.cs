using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace WorkFlowUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {            
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
        }
        protected void Application_Error(object sender, EventArgs e)
        {
         //   Exception exception = Server.GetLastError();
       //     Session["Exception"] = exception;
            //  System.Diagnostics.Debug.WriteLine(exception);
            //return RedirectToAction("dasdas")
          // Response.Redirect("/Common/Home");
        }

      
    }


}
