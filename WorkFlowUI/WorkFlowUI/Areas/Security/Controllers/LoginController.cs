using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WorkFlowUI.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Security/Login
        public ActionResult Index(string type)
        {
            try
            {
                if (type == "SignOut")
                    return View();
                if (string.IsNullOrEmpty(type))
                {
                    string user_name = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                    user_name = user_name.Substring(user_name.LastIndexOf("\\") + 1);

                    //user_name = "john";
                    if (Membership.ValidateUser(user_name, "Admin@123"))
                    {
                        FormsAuthentication.SetAuthCookie(user_name, false);
                        return RedirectToAction("Index", "ApproveDocument", new { area = "Admin" });
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "Login", "Index", clsGeneral.errorMessage(ex));
                return View();
            }            
        }

        [HttpPost]
        public ActionResult SignIn(vw_ERP_UserDetails user)
        {
            try
            {
                //FormsAuthentication.SetAuthCookie(user.UserId.ToUpper(), false);
                //return RedirectToAction("INdex", "BrowseDocument", new { area = "User" });

                if (string.IsNullOrEmpty(user.UserId) || string.IsNullOrEmpty(user.Password))
                {
                    TempData["Msg"] = "Login Failed : User Id / Password shouldn't be blank";
                    return RedirectToAction("INdex");
                }
                if (Membership.ValidateUser(user.UserId.ToUpper(), user.Password))
                {                                     
                    FormsAuthentication.SetAuthCookie(user.UserId.ToUpper(), false);
                    return RedirectToAction("INdex", "BrowseDocument", new { area = "User" });
                }
                else
                {
                    TempData["Msg"] = "Login Failed : Incorrect UserId or Password";
                    return RedirectToAction("INdex");
                }
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "Login", "SignIn", clsGeneral.errorMessage(ex));
                TempData["Msg"] = "Login Failed : " + clsGeneral.errorMessage(ex);
                return RedirectToAction("Index");

            }

        }

        public ActionResult WindowLogin(string user,bool IsAlterNative)
        {
            
            if (!IsAlterNative)
            {
                Session["IsAlternative"] = false;
            }
            else
            {
                Session["IsAlternative"] = true;
            }

        


            try
            {

                //string user_name  = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                string user_name = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                user_name = user_name.Substring(user_name.LastIndexOf("\\") + 1);

                //user_name = "tsuchihata";
                string User_password = "Admin@123";

                if (Membership.ValidateUser(user_name, User_password))
                {
                    FormsAuthentication.SetAuthCookie(user_name, false);
                    if(!IsAlterNative)
                    return RedirectToAction("INdex", "ApproveDocument", new { area = "Admin" });
                    else
                        return RedirectToAction("Index", "AltApproveDocument", new { area = "Admin" });
                }
                else
                {
                    TempData["Msg"] = "Login Failed  " + System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                    return RedirectToAction("INdex");
                }
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "Login", "WindowLogin", clsGeneral.errorMessage(ex));
                TempData["Msg"] = "Login Failed : " + clsGeneral.errorMessage(ex);
                return RedirectToAction("Index");

            }



            //string user_name;
            //user_name = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            //if (user_name == "FSP\\John")
            //{
            //    user_name = user_name.Substring(user_name.LastIndexOf("\\") + 1);
            //    FormsAuthentication.SetAuthCookie("shweta@gmail.com", false);
            //    return RedirectToAction("Index", "Home", new { area = "Common" });
            //}
            //else
            //{

            //    TempData["Msg"] = "Window Authentication failed!";
            //    return RedirectToAction("Index");
            //}
        }

        public ActionResult SignOut()
        {            
            try
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Login", new { area = "Security", type = "SignOut" });
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "Login", "SignOut", clsGeneral.errorMessage(ex));
                return null;
            }
        }
    }
}