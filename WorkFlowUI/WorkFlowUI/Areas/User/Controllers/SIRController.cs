using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkFlowUI.ViewModel;
using BLL;
using System.Messaging;
using System.Configuration;
using System.IO;
using System.Globalization;

namespace WorkFlowUI.Areas.User.Controllers
{
    public class SIRController : Controller
    {
        public SIRViewModal viewModal;
        public EInvoiceBs objBs;
        public SIRController()
        {
            viewModal = new SIRViewModal();
            objBs = new EInvoiceBs();
        }
        // GET: User/SIR
        public ActionResult Index(string period, string customerNo, string status, string invoiceType, string organization)
        {
            invoiceType = invoiceType.Replace(" ", "");
            ViewData["Status"] = status;
            ViewData["Period"] = period;
            ViewData["CustomerNo"] = customerNo;
            ViewData["InvoiceType"] = invoiceType;
            ViewData["Organization"] = organization;

            if (!string.IsNullOrEmpty(period) && !string.IsNullOrEmpty(customerNo))
            {
                viewModal.sirDoc = objBs.GetSIRDocList(period, customerNo);
                viewModal.customerName = objBs.GetBillToPartyName(customerNo);
                viewModal.period = period;
                viewModal.customerNo = customerNo;
                if (viewModal.sirDoc != null)
                {
                    viewModal.soldCustomerName = objBs.GetSoldToPartyName(viewModal.sirDoc.SoldToParty);
                }
                if (invoiceType == "Contract")
                {
                    viewModal.activeContract = objBs.GetActiveContracts(customerNo);
                }
                else if (invoiceType == "CSSalesOrder")
                {
                    string driveLocation = null;
                    driveLocation = (organization == "Private" ? Convert.ToString(ConfigurationManager.AppSettings["PrivateDrive"]) : ConfigurationManager.AppSettings["HDBDrive"]);
                    if (!string.IsNullOrEmpty(driveLocation))
                    {
                        driveLocation = driveLocation + "Job Sheet\\" + Convert.ToString(viewModal.sirDoc.BuildingCode) + "\\" + Convert.ToString(viewModal.sirDoc.SIRYear) + "\\" + Convert.ToString(viewModal.sirDoc.SIRYear) + "_" + getMonthNumber(viewModal.sirDoc.SIRMonth.Split('_')[0]);
                        if (Directory.Exists(driveLocation))
                        {
                            viewModal.jobSheet = Directory.GetFiles(driveLocation).ToList();

                            viewModal.driveLocation = driveLocation + "\\";

                            viewModal.jobSheet.RemoveAll(item => item == viewModal.driveLocation + "desktop.ini");
                        }
                    }
                }
            }
            return View(viewModal);
        }


        string getMonthNumber(string monthName)
        {
            int month = DateTime.ParseExact(monthName, "MMMM", CultureInfo.CurrentCulture).Month;
            if (month < 10)
                return "0" + Convert.ToString(month);

            return Convert.ToString(month);

        }
        public ActionResult ProceedAsException(string transId)
        {
            try
            {
                string userId = User.Identity.Name;
                BOL.spResult isGet = objBs.proceedAsException(transId, userId);
                if (isGet.result)
                {
                    TempData["Status"] = "Success";
                    MessageQueue MtlCEQ = new System.Messaging.MessageQueue();
                    MtlCEQ.Path = "FormatName:DIRECT=OS:" + ConfigurationManager.AppSettings["EInvoiceQueuePath"] + "\\private$\\" + ConfigurationManager.AppSettings["EInvoiceQueueName"];
                    MtlCEQ.Send(transId + "^" + userId);
                    TempData["Status"] = "All Success";
                }
                else
                {
                    TempData["Status"] = "Failed";
                    TempData["Msg"] = isGet.message;
                }
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "SIR", "ProceedAsException", clsGeneral.errorMessage(ex));
                TempData["Msg"] = Convert.ToString(TempData["Msg"]) + " <br> " + ex.Message;
            }

            return RedirectToAction("Index", new { status = "I" });
        }
    }
}