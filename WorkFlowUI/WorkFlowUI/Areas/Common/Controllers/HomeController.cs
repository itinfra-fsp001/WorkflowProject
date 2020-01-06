using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WorkFlowUI.Areas.Common
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Common/Home
        public  ActionResult Index()
        {
            //if (Session["exception"] != null)
            //{
            //    Exception exception = Session["exception"] as Exception;
            //    System.Diagnostics.Debug.WriteLine(exception);
            //    ViewBag.Error = exception;
            //    return View();
            //}
            return View();
        }





    }
}