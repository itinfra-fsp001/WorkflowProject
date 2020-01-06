using BLL;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WorkFlowUI.ViewModel;

namespace WorkFlowUI.Areas.User.Controllers
{
    [Authorize(Roles = "ServiceAdmin")]
    public class StatementOfAccountController : Controller
    {
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
       int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);

        public SOAViewModel viewModal;
        public SOABs objBs;
        public StatementOfAccountController()
        {
            viewModal = new SOAViewModel();
            objBs = new SOABs();
        }


        // GET: User/StatementOfAccount
        public ActionResult Index(string customerName, string organization, string status, string parentOrganization, string customerType, string sortOrder, string sortBy, string page, string pageSize, string period)
        {

            viewModal.organizationList.Add(new SelectListItem { Text = "-- Select --", Value = "-- Select --" });
            viewModal.parentOrganizationList.Add(new SelectListItem { Text = "-- Select --", Value = "-- Select --" });
            viewModal.customerTypeList.Add(new SelectListItem { Text = "-- Select --", Value = "-- Select --" });

            
            status = (string.IsNullOrEmpty(status) ? "P" : status);
            if (status == "C")
            {
                viewModal.periodList.Add(new SelectListItem { Text = "", Value = "" });
            }
            page = (string.IsNullOrEmpty(page) ? "1" : page);
            pageSize = (string.IsNullOrEmpty(pageSize) ? "50" : pageSize);
            if (status == "P")
            {
                period = (string.IsNullOrEmpty(period) ? DateTime.ParseExact("01-" + DateTime.Now.ToString("MM-yyyy"), "dd-MM-yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo).AddDays(-1).ToString("dd-MM-yyyy") : period);
            }
            else
            {
                period = (string.IsNullOrEmpty(period) ? "" : period);
            }

            ViewData["Status"] = status;
            ViewData["Organization"] = organization;
            ViewData["ParentOrganization"] = parentOrganization;
            ViewData["CustomerName"] = clsGeneral.searchStringDecrypt(customerName);
            ViewData["CustomerType"] = customerType;
            ViewData["Pagesize"] = pageSize;
            ViewData["Page"] = page;
            ViewData["SortOrder"] = sortOrder;
            ViewData["SortBy"] = sortBy;
            ViewData["Period"] = period;

            viewModal.organization = organization;
            viewModal.parentOrganization = parentOrganization;
            viewModal.customerType = customerType;
            viewModal.customerName = clsGeneral.searchStringDecrypt(customerName);
            viewModal.period = period;

            if (status == "C" || status == "P")
            {
                var soaList = objBs.GetSOAList(status, clsGeneral.checkandReplace(customerName), organization, customerType, parentOrganization, period);
                var allSOAList = objBs.getALLSOAList(status);
                foreach (string item in allSOAList.Select(x => x.OrganizationName).Distinct())
                {
                    viewModal.organizationList.Add(new SelectListItem { Text = item, Value = item });
                }
                foreach (string item in allSOAList.Select(x => x.ParentCustomerName).Distinct())
                {
                    viewModal.parentOrganizationList.Add(new SelectListItem { Text = item, Value = item });
                }
                foreach (string item in allSOAList.Select(x => x.CustomerType).Distinct())
                {
                    viewModal.customerTypeList.Add(new SelectListItem { Text = item, Value = item });
                }
                foreach (DateTime item in allSOAList.Select(x => x.CutoffDate).Distinct())
                {
                    viewModal.periodList.Add(new SelectListItem { Text = item.ToString("dd-MM-yyyy"), Value = item.ToString("dd-MM-yyyy") });
                }

                //switch (sortBy)
                //{
                //    case "OrganizationName":
                //        switch (sortOrder)
                //        {
                //            case "Asc":
                //                soaList = soaList.OrderBy(x => x.OrganizationName).ToList();
                //                break;
                //            case "Desc":
                //                soaList = soaList.OrderByDescending(x => x.OrganizationName).ToList();
                //                break;
                //            default:
                //                break;
                //        }
                //        break;

                //    case "CustomerType":
                //        {
                //            switch (sortOrder)
                //            {
                //                case "Asc":
                //                    soaList = soaList.OrderBy(x => x.CustomerType).ToList();
                //                    break;
                //                case "Desc":
                //                    soaList = soaList.OrderByDescending(x => x.CustomerType).ToList();
                //                    break;
                //                default:
                //                    break;
                //            }

                //        }
                //        break;
                //    case "CustomerName":
                //        {
                //            switch (sortOrder)
                //            {
                //                case "Asc":
                //                    soaList = soaList.OrderBy(x => x.CustomerName).ToList();
                //                    break;
                //                case "Desc":
                //                    soaList = soaList.OrderByDescending(x => x.CustomerName).ToList();
                //                    break;
                //                default:
                //                    break;
                //            }

                //        }
                //        break;
                //    case "CutoffDate":
                //        {
                //            switch (sortOrder)
                //            {
                //                case "Asc":
                //                    soaList = soaList.OrderBy(x => x.CutoffDate).ToList();
                //                    break;
                //                case "Desc":
                //                    soaList = soaList.OrderByDescending(x => x.CutoffDate).ToList();
                //                    break;
                //                default:
                //                    break;
                //            }

                //        }
                //        break;
                //    case "ParentCustomerName":
                //        {
                //            switch (sortOrder)
                //            {
                //                case "Asc":
                //                    soaList = soaList.OrderBy(x => x.ParentCustomerName).ToList();
                //                    break;
                //                case "Desc":
                //                    soaList = soaList.OrderByDescending(x => x.ParentCustomerName).ToList();
                //                    break;
                //                default:
                //                    break;
                //            }

                //        }
                //        break;

                //    case "SOAStatus":
                //        {
                //            switch (sortOrder)
                //            {
                //                case "Asc":
                //                    soaList = soaList.OrderBy(x => x.SOAStatus).ToList();
                //                    break;
                //                case "Desc":
                //                    soaList = soaList.OrderByDescending(x => x.SOAStatus).ToList();
                //                    break;
                //                default:
                //                    break;
                //            }

                //        }
                //        break;

                //    case "UpdatedBy":
                //        {
                //            switch (sortOrder)
                //            {
                //                case "Asc":
                //                    soaList = soaList.OrderBy(x => x.UpdateBy).ToList();
                //                    break;
                //                case "Desc":
                //                    soaList = soaList.OrderByDescending(x => x.UpdateBy).ToList();
                //                    break;
                //                default:
                //                    break;
                //            }

                //        }
                //        break;                    
                //    case "UpdatedDate":
                //        {
                //            switch (sortOrder)
                //            {
                //                case "Asc":
                //                    soaList = soaList.OrderBy(x => x.UpdateDate).ToList();
                //                    break;
                //                case "Desc":
                //                    soaList = soaList.OrderByDescending(x => x.UpdateDate).ToList();
                //                    break;
                //                default:
                //                    break;
                //            }

                //        }
                //        break;

                //    default:
                //        soaList = soaList.OrderBy(x => x.OrganizationName).ToList();
                //        break;
                //}

                ViewData["Totalpages"] = Math.Ceiling(soaList.ToList().Count() / Convert.ToDecimal(pageSize));
                int pageNo = int.Parse(page == null ? "1" : page);
                ViewData["Page"] = pageNo;
                soaList = soaList.Skip((pageNo - 1) * Convert.ToInt32(pageSize)).Take(Convert.ToInt32(pageSize)).ToList();
                viewModal.soaList = soaList;
            }

            return View(viewModal);
        }

        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        public ActionResult GetAttachment(string Ids)
        {
            try
            {
                SafeTokenHandle safeTokenHandle;
                const int LOGON32_PROVIDER_DEFAULT = 0;
                const int LOGON32_LOGON_INTERACTIVE = 2;

                bool returnValue = LogonUser(ConfigurationManager.AppSettings["NetWorkUserID"], ConfigurationManager.AppSettings["NetWorkDomain"], ConfigurationManager.AppSettings["NetWorkPassword"], LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, out safeTokenHandle);

                if (returnValue)
                {
                    using (safeTokenHandle)
                    {
                        using (WindowsIdentity newId = new WindowsIdentity(safeTokenHandle.DangerousGetHandle()))
                        {
                            using (WindowsImpersonationContext impersonatedUser = newId.Impersonate())
                            {

                                var getSOA = objBs.GetSOAByID(Convert.ToInt32(Ids));

                                if (getSOA != null && !string.IsNullOrEmpty(getSOA.SOAFileName))
                                {
                                    string filePath = getSOA.SOAFileName;
                                    string docName = DateTime.Now.ToString("ddMMyyyyhhmmsstt") + ".pdf";
                                    if (filePath.Contains("\\"))
                                    {
                                        docName = filePath.Split('\\')[filePath.Split('\\').Length - 1];
                                    }
                                    if (!System.IO.File.Exists(filePath))
                                    {
                                        return new EmptyResult();
                                    }

                                    byte[] filedata = System.IO.File.ReadAllBytes(filePath);

                                    string mimeType = MimeMapping.GetMimeMapping(filePath);

                                    return File(filedata, mimeType, docName);
                                }
                                else
                                {
                                    TempData["Msg"] = "Unable to get file";
                                    return RedirectToAction("Index", new { status = "E" });
                                }

                            }
                        }
                    }
                }
                else
                {
                    TempData["Msg"] = "Unable to get file";
                    return RedirectToAction("Index", new { status = "E" });
                }
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "StatementOfAccount", "GetAttachment", clsGeneral.errorMessage(ex));
                return null;
            }

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProcessSOA(SOAViewModel soaVM, string Command, List<BOL.vw_ERP_ServiceSOA> soaList)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<int> lt = js.Deserialize<List<int>>(soaVM.soaSelectedList);
                var idList = "";
                foreach (int docId in lt)
                {
                    idList = (string.IsNullOrEmpty(idList)) ? Convert.ToString(docId) : idList + "," + Convert.ToString(docId);
                }

                if (Command == "Send E-SOA")
                {
                    objBs.sendSOA(string.Join(",", idList), User.Identity.Name, soaVM.soaList);

                    MessageQueue MtlCEQ = new System.Messaging.MessageQueue();
                    MtlCEQ.Path = "FormatName:DIRECT=OS:" + ConfigurationManager.AppSettings["EInvoiceQueuePath"] + "\\private$\\" + ConfigurationManager.AppSettings["SOAQueueName"];
                    MtlCEQ.Send(string.Join(",", idList) + "^" + User.Identity.Name + "^Send");


                    TempData["Msg"] = "E-SOA submitted to JOB QUEUE successfully";
                }
                else if (Command == "Mark as Exception")
                {
                    objBs.markAsException(string.Join(",", idList), User.Identity.Name);
                    TempData["Msg"] = "Selected SOA marked as exception successfully";
                }
                return RedirectToAction("Index", new { status = "S", logId = "" });

            }
            catch (Exception ex)
            {
                TempData["Msg"] = Convert.ToString(ex.Message);
                return RedirectToAction("Index", new { status = "E", logId = "" });
            }

        }
    }
}