using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using WorkFlowUI.ViewModel;
using System.Web.Script.Serialization;
using System.Messaging;
using System.Configuration;
using System.IO;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Security.Permissions;
using Microsoft.Win32.SafeHandles;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI;

namespace WorkFlowUI.Areas.User.Controllers
{
    [Authorize(Roles = "ServiceAdmin,ServiceEngineer")]
    public class SIRHomeController : Controller
    {
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
       int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);


        public SIRViewModal viewModal;
        public EInvoiceBs objBs;
        public UserBs objUserBs;
        public SIRHomeController()
        {
            viewModal = new SIRViewModal();
            objBs = new EInvoiceBs();
            objUserBs = new UserBs();
        }

        // GET: User/SIRHome
        public ActionResult Index(string status, string site, string period, string customername, string sirStatus, string sortOrder, string sortBy, string page, string pageSize, string salesgroup)
        {

            viewModal.periodList.Add(new SelectListItem { Text = "-- Select --", Value = "-- Select --" });
            viewModal.statusList.Add(new SelectListItem { Text = "-- Select --", Value = "-- Select --" });
            viewModal.salesGroupList.Add(new SelectListItem { Text = "-- Select --", Value = "-- Select --" });

            status = (string.IsNullOrEmpty(status) ? "P" : status);
            page = (string.IsNullOrEmpty(page) ? "1" : page);
            pageSize = (string.IsNullOrEmpty(pageSize) ? "50" : pageSize);

            ViewData["Status"] = status;
            ViewData["Site"] = clsGeneral.searchStringDecrypt(site);
            ViewData["SIRStatus"] = sirStatus;
            ViewData["Period"] = period;
            ViewData["SalesGroup"] = salesgroup;
            ViewData["CustomerName"] = clsGeneral.searchStringDecrypt(customername);
            ViewData["Pagesize"] = pageSize;
            ViewData["Page"] = page;
            ViewData["SortOrder"] = sortOrder;
            ViewData["SortBy"] = sortBy;
            ViewData["Status"] = status;
            ViewData["CurrentPeriod"] = ToShortMonthName(DateTime.Now) + "_" + Convert.ToString(DateTime.Now.Year);
            ViewData["PreviousPeriod"] = ToShortMonthName(DateTime.Now.AddMonths(-1)) + "_" + Convert.ToString(DateTime.Now.AddMonths(-1).Year);
            viewModal.customerName = clsGeneral.searchStringDecrypt(customername);
            viewModal.site = clsGeneral.searchStringDecrypt(site);
            viewModal.sirStatus = sirStatus;
            viewModal.period = period;
            viewModal.salesgroup = clsGeneral.searchStringDecrypt(salesgroup);
            //TempData["QryStr"] = "123";


            viewModal.isServiceAdmin = false;
            var userRole = objUserBs.GetRoleByID(User.Identity.Name);
            if (userRole != null && userRole.Count() > 0)
            {
                foreach (BOL.tbl_UserRoles item in userRole)
                {
                    if (item.Role == "ServiceAdmin")
                    {
                        viewModal.isServiceAdmin = true;
                        break;
                    }
                }
            }
            //viewModal.isServiceAdmin = objBs.isServiceAdminUser(User.Identity.Name);

            if (status == "C" || status == "P")
            {
                var sirList = objBs.getSIRList(status, clsGeneral.checkandReplace(customername), period, sirStatus, clsGeneral.checkandReplace(site), salesgroup, clsGeneral.getLastThreeMonthsPeriod(null));


                var allSIRList = objBs.getALLSIRList(status, clsGeneral.getLastThreeMonthsPeriod(null));

                foreach (string item in allSIRList.Select(x => x.Constatus).Distinct())
                {
                    viewModal.statusList.Add(new SelectListItem { Text = item, Value = item });
                }
                foreach (string item in allSIRList.Select(x => x.SIRMonth).Distinct())
                {
                    viewModal.periodList.Add(new SelectListItem { Text = item, Value = item });
                }
                foreach (string item in allSIRList.Select(x => x.SalesGroup).Distinct())
                {
                    viewModal.salesGroupList.Add(new SelectListItem { Text = item, Value = item });
                }


                
                //switch (sortBy)
                //{
                //    case "BuildingCode":
                //        switch (sortOrder)
                //        {
                //            case "Asc":
                //                sirList = sirList.OrderBy(x => x.BuildingCode).ToList();
                //                break;
                //            case "Desc":
                //                sirList = sirList.OrderByDescending(x => x.BuildingCode).ToList();
                //                break;
                //            default:
                //                break;
                //        }
                //        break;

                //    case "SalesGroup":
                //        {
                //            switch (sortOrder)
                //            {
                //                case "Asc":
                //                    sirList = sirList.OrderBy(x => x.SalesGroup).ToList();
                //                    break;
                //                case "Desc":
                //                    sirList = sirList.OrderByDescending(x => x.SalesGroup).ToList();
                //                    break;
                //                default:
                //                    break;
                //            }

                //        }
                //        break;
                //    case "BillToParty":
                //        {
                //            switch (sortOrder)
                //            {
                //                case "Asc":
                //                    sirList = sirList.OrderBy(x => x.BillToParty).ToList();
                //                    break;
                //                case "Desc":
                //                    sirList = sirList.OrderByDescending(x => x.BillToParty).ToList();
                //                    break;
                //                default:
                //                    break;
                //            }

                //        }
                //        break;



                //    case "OrgName":
                //        {
                //            switch (sortOrder)
                //            {
                //                case "Asc":
                //                    sirList = sirList.OrderBy(x => x.OrgName).ToList();
                //                    break;
                //                case "Desc":
                //                    sirList = sirList.OrderByDescending(x => x.OrgName).ToList();
                //                    break;
                //                default:
                //                    break;
                //            }

                //        }
                //        break;

                //    case "SIRMonth":
                //        {
                //            switch (sortOrder)
                //            {
                //                case "Asc":
                //                    sirList = sirList.OrderBy(x => x.SIRMonth).ToList();
                //                    break;
                //                case "Desc":
                //                    sirList = sirList.OrderByDescending(x => x.SIRMonth).ToList();
                //                    break;
                //                default:
                //                    break;
                //            }

                //        }
                //        break;

                //    case "NoOfUnits":
                //        {
                //            switch (sortOrder)
                //            {
                //                case "Asc":
                //                    sirList = sirList.OrderBy(x => x.NoOfUnits).ToList();
                //                    break;
                //                case "Desc":
                //                    sirList = sirList.OrderByDescending(x => x.NoOfUnits).ToList();
                //                    break;
                //                default:
                //                    break;
                //            }

                //        }
                //        break;

                //    case "NoOfService":
                //        {
                //            switch (sortOrder)
                //            {
                //                case "Asc":
                //                    sirList = sirList.OrderBy(x => x.NoOfService).ToList();
                //                    break;
                //                case "Desc":
                //                    sirList = sirList.OrderByDescending(x => x.NoOfService).ToList();
                //                    break;
                //                default:
                //                    break;
                //            }

                //        }
                //        break;

                //    case "CompletedService":
                //        {
                //            switch (sortOrder)
                //            {
                //                case "Asc":
                //                    sirList = sirList.OrderBy(x => x.CompletedService).ToList();
                //                    break;
                //                case "Desc":
                //                    sirList = sirList.OrderByDescending(x => x.CompletedService).ToList();
                //                    break;
                //                default:
                //                    break;
                //            }

                //        }
                //        break;



                //    case "PendingService":
                //        {
                //            switch (sortOrder)
                //            {
                //                case "Asc":
                //                    sirList = sirList.OrderBy(x => (x.NoOfService - x.CompletedService)).ToList();
                //                    break;
                //                case "Desc":
                //                    sirList = sirList.OrderByDescending(x => (x.NoOfService - x.CompletedService)).ToList();
                //                    break;
                //                default:
                //                    break;
                //            }

                //        }
                //        break;


                //    case "ConsBy":
                //        {
                //            switch (sortOrder)
                //            {
                //                case "Asc":
                //                    sirList = sirList.OrderBy(x => x.ConsBy).ToList();
                //                    break;
                //                case "Desc":
                //                    sirList = sirList.OrderByDescending(x => x.ConsBy).ToList();
                //                    break;
                //                default:
                //                    break;
                //            }

                //        }
                //        break;

                //    case "Constatus":
                //        {
                //            switch (sortOrder)
                //            {
                //                case "Asc":
                //                    sirList = sirList.OrderBy(x => x.Constatus).ToList();
                //                    break;
                //                case "Desc":
                //                    sirList = sirList.OrderByDescending(x => x.Constatus).ToList();
                //                    break;
                //                default:
                //                    break;
                //            }

                //        }
                //        break;
                //    case "ConsDate":
                //        {
                //            switch (sortOrder)
                //            {
                //                case "Asc":
                //                    sirList = sirList.OrderBy(x => x.ConsDate).ToList();
                //                    break;
                //                case "Desc":
                //                    sirList = sirList.OrderByDescending(x => x.ConsDate).ToList();
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
                //                    sirList = sirList.OrderBy(x => x.UpdateBy).ToList();
                //                    break;
                //                case "Desc":
                //                    sirList = sirList.OrderByDescending(x => x.UpdateBy).ToList();
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
                //                    sirList = sirList.OrderBy(x => x.UpdateDate).ToList();
                //                    break;
                //                case "Desc":
                //                    sirList = sirList.OrderByDescending(x => x.UpdateDate).ToList();
                //                    break;
                //                default:
                //                    break;
                //            }

                //        }
                //        break;

                //    default:
                //        sirList = sirList.OrderBy(x => x.BuildingCode).ToList();
                //        break;
                //}


                ViewData["Totalpages"] = Math.Ceiling(sirList.ToList().Count() / Convert.ToDecimal(pageSize));
                int pageNo = int.Parse(page == null ? "1" : page);
                ViewData["Page"] = pageNo;
                sirList = sirList.Skip((pageNo - 1) * Convert.ToInt32(pageSize)).Take(Convert.ToInt32(pageSize)).ToList();
                viewModal.sirList = sirList;
                BOL.spResult isGet = objBs.getLastConsolidatedOn();
                if (isGet != null)
                {
                    viewModal.lastConsolidationOn = isGet.message;
                }
            }
            return View(viewModal);
        }

        public ActionResult ForceConsolidation(string Ids)
        {
            try
            {
                return ProceedAsException(Ids, "Force Consolidation");

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "SIRHome", "ForceConsolidation", clsGeneral.errorMessage(ex));
                return null;
            }

        }

        public ActionResult ForceConsolidationAndClose(string Ids)
        {
            try
            {
                return ProceedAsException(Ids, "Force Consolidation And Closed");
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "SIRHome", "ForceConsolidationAndClose", clsGeneral.errorMessage(ex));
                return null;
            }

        }

        public ActionResult ExportReport(string period, string status)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("BuildingCode", typeof(string));
            dt.Columns.Add("SalesGroup", typeof(string));
            dt.Columns.Add("SoldToParty", typeof(string));
            dt.Columns.Add("BillToParty", typeof(string));
            dt.Columns.Add("NoOfUnits", typeof(string));
            dt.Columns.Add("NoOfService", typeof(string));
            dt.Columns.Add("CompletedService", typeof(string));
            dt.Columns.Add("Completed(%)", typeof(string));
            dt.Columns.Add("Pending", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("Remark", typeof(string));

            string itemStatus;
            var sirList = objBs.GetSIRDocumentsForExport(period);
            if (sirList != null && sirList.Count > 0)
            {
                foreach (BOL.tbl_SIRDocuments item in sirList)
                {
                    itemStatus = "";
                    if (item.Constatus == "Consolidation Closed" || item.Constatus == "Force Consolidation And Closed" || item.Constatus == "Force Consolidation")
                    {
                        itemStatus = "Completed";
                    }
                    else if(item.ConsRemark.ToLower().Contains("no sir received"))
                    {
                        itemStatus = "Not Completed";
                    }
                    else if (item.ConsRemark.ToLower().Contains("no active contract"))
                    {
                        itemStatus = "Not Required";
                    }
                    else if (!string.IsNullOrEmpty(item.ConsRemark))
                    {
                        itemStatus = "Incomplete";
                    }
                    dt.Rows.Add(
                        item.BuildingCode,
                        item.SalesGroup,
                        item.SoldToParty,
                        item.BillToParty,
                        item.NoOfUnits,
                        item.NoOfService,
                        item.CompletedService,
                        Math.Round(Convert.ToDouble((Convert.ToInt16(item.CompletedService) / Convert.ToInt16(item.NoOfService)) * 100), 0),
                        Convert.ToInt16(item.NoOfService) - Convert.ToInt16(item.CompletedService),
                        itemStatus,
                        item.ConsRemark
                        );
                }
            }
            var grid = new GridView();
            grid.DataSource = dt;
            grid.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=SIR Report of "+period+" "+DateTime.Now.ToString("ddMMyyyyhhmmsstt")+".xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            return RedirectToAction("Index", new { status = status });
        }
        //public void processRequest(string Ids, string mode)
        //{
        //    try
        //    {
        //        JavaScriptSerializer js = new JavaScriptSerializer();
        //        List<int> lt = js.Deserialize<List<int>>(Ids);
        //        var quoteList = "";
        //        foreach (int docId in lt)
        //        {
        //            if (string.IsNullOrEmpty(quoteList))
        //                quoteList = Convert.ToString(docId) + ",";
        //            else
        //                quoteList = quoteList + "," + Convert.ToString(docId) + ",";
        //        }
        //        //var spResult = combs.cancelQuote(quoteList, User.Identity.Name, mode, "", "", "");

        //        if (spResult == "Success")
        //        {
        //            if (mode == "Cancel RFQ")
        //            {
        //                TempData["Msg"] = "RFQ Cancelled Successfully";
        //            }
        //            else if (mode == "Delete RFQ")
        //            {
        //                TempData["Msg"] = "RFQ Deleted Successfully";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        BLL.clsLog.insertLog(User.Identity.Name, "SIRHome", "processRequest", clsGeneral.errorMessage(ex));
        //        //return null;
        //    }
        //}

        public ActionResult ProceedAsException(string transIds, string mode)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<string> lt = js.Deserialize<List<string>>(transIds);
                string userId = User.Identity.Name;
                BOL.spResult isGet = objBs.proceedAsException(string.Join(",", lt.ToArray()), userId);
                if (isGet.result)
                {
                    TempData["Status"] = "Success";
                    MessageQueue MtlCEQ = new System.Messaging.MessageQueue();
                    MtlCEQ.Path = "FormatName:DIRECT=OS:" + ConfigurationManager.AppSettings["EInvoiceQueuePath"] + "\\private$\\" + ConfigurationManager.AppSettings["EInvoiceQueueName"];
                    MtlCEQ.Send(string.Join(",", lt.ToArray()) + "^" + userId + "^" + mode);
                    TempData["Status"] = "All Success";
                    TempData["Msg"] = "Successfully consolidated.";
                }
                else
                {
                    TempData["Status"] = "Failed";
                    TempData["Msg"] = "Unable to Consolidate : " + isGet.message;
                }
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "SIRHome", "ProceedAsException", clsGeneral.errorMessage(ex));
                TempData["Msg"] = Convert.ToString(TempData["Msg"]) + " <br> " + ex.Message;
            }
            return RedirectToAction("Index", new { status = "S" });
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

                                var getSIR = objBs.GetSIRDocumentByID(Convert.ToInt32(Ids));

                                if (getSIR != null && !string.IsNullOrEmpty(getSIR.SIRFileName))
                                {
                                    string filePath = getSIR.SIRFileName;
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
                BLL.clsLog.insertLog(User.Identity.Name, "RequestForQuote", "GetAttachment", clsGeneral.errorMessage(ex));
                return null;
            }

        }

        string ToShortMonthName(DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(dateTime.Month);
        }
    }

    public sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeTokenHandle()
            : base(true)
        {
        }

        [DllImport("kernel32.dll")]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr handle);

        protected override bool ReleaseHandle()
        {
            return CloseHandle(handle);
        }
    }
}