using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkFlowUI.ViewModel;
using BLL;
using PdfSharp.Pdf;
using System.Configuration;
using PdfSharp.Pdf.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Security.Permissions;
using Microsoft.Win32.SafeHandles;
using System.Runtime.ConstrainedExecution;
using System.Security;

namespace WorkFlowUI.Areas.User.Controllers
{
    [Authorize(Roles = "ServiceAdmin")]
    public class SendEInvoiceController : Controller
    {

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
       int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);



        SendEInvoiceModel objSEIModel;
        EInvoiceBs objBs;
        string mergePDFFileName;

        string pdfLocation;
        public SendEInvoiceController()
        {
            objSEIModel = new SendEInvoiceModel();
            objBs = new EInvoiceBs();
            pdfLocation = Convert.ToString(ConfigurationManager.AppSettings["EInvoicePath"]);
        }
        // GET: User/SendEInvoice
        public ActionResult Index(string logId, string status)
        {
            //TempData["QryStr"] = "DW9098174852,DW9098174853,DW9098174854,DW9098174855,DW9098174856,DW9098174857,DW9098174858,DW9098174859,DW9098175512,DW9098175513,DW9098175517,DW9098175518,DW9098175950,DW9098175951,DW9098175952,DW9098175953,DW9098175954,DW9098175955,DW9098175956,DW9098175957,DW9098175958,DW9098175959,DW9098175960,DW9098175961,DW9098175962,DW9098175963,DW9098175964,DW9098175965,DW9098175966,DW9098175967,DW9098175968,DW9098175969,DW9098175970,DW9098175971,DW9098175972,DW9098175973,DW9098175974,DW9098175975,DW9098175976,DW9098175977,DW9098175978,DW9098176496,DW9098176497,DW9098176498,DW9098176499,DW9098176500,DW9098176501,DW9098176502,DW9098176503,DW9098176504";

            if (status == "N" && string.IsNullOrEmpty(Convert.ToString(TempData["QryStr"])))
            {
                return RedirectToAction("Index", new { Controller = "Einvoice", status = "N" });
            }
            logId = Convert.ToString(TempData["QryStr"]);
            objSEIModel.logId = logId;
            objSEIModel.maxAttachmentLimitInBytes = Convert.ToString(ConfigurationManager.AppSettings["MaxAttachSizeInBytes"]);
            status = (status == null) ? "N" : status;
            ViewData["Status"] = status;
            ViewData["LogId"] = logId;

            if (status == "N")
            {
                objSEIModel.invoice = objBs.GetServiceTaxInvoiceByID(logId);
                if (objSEIModel.invoice != null && objSEIModel.invoice.Count() > 0)
                {
                    if (objSEIModel.invoice[0].Organization == "Private")
                    {
                        objSEIModel.mailSendBy = Convert.ToString(ConfigurationManager.AppSettings["PrivateEmailFrom"]);
                    }
                    else
                    {
                        objSEIModel.mailSendBy = Convert.ToString(ConfigurationManager.AppSettings["HDBEmailFrom"]);
                    }
                    objSEIModel.attachmentFolderLocation = pdfLocation + "\\merge\\" + objSEIModel.invoice[0].CustomerNo + "_" + DateTime.Now.ToString("ddMMyyyyhhmmss");

                    mergeDocument(objSEIModel.invoice);
                    //if ((objSEIModel.invoice.InvoiceStatus != "Success") && ((objSEIModel.invoice.InvoiceType == "CSSalesOrder") ? true : (objSEIModel.invoice.DocGenStatus == "Success" ? true : false)))
                    //{
                    //    ViewData["Status"] = "E";
                    //    ViewData["Message"] = "Invoice not generatead";
                    //    return View(objSEIModel);
                    //}
                    //else if(objSEIModel.invoice.InvoiceType == "Contract" && objSEIModel.invoice.DocGenStatus != "Success")
                    //{
                    //    ViewData["Status"] = "E";
                    //    ViewData["Message"] = "SIR not generatead";
                    //    return View(objSEIModel);
                    //}
                    var customerEmail = objBs.GetCustomerEmailDetails(objSEIModel.invoice[0].CustomerNo);
                    if (customerEmail != null)
                    {
                        objSEIModel.to = customerEmail.email_address;
                    }

                    BOL.rfqSPResult isGet = objBs.getEmailContent(logId.Split(',')[0]);
                    if (isGet != null)
                    {
                        objSEIModel.body = Convert.ToString(isGet.email).Replace("[InvoiceNo]", getInvoiceDetails(logId)).Replace(@"\n", Environment.NewLine);
                        if (objSEIModel.invoice[0].Organization == "HDB")
                        {
                            objSEIModel.subject = Convert.ToString(isGet.name).Replace("[AddressLine1]", isGet.buyerEmail);
                        }
                        else if (objSEIModel.invoice[0].Organization == "Private")
                        {
                            objSEIModel.subject = Convert.ToString(isGet.name).Replace("[Site]", isGet.buyerName);
                        }
                        else if (objSEIModel.invoice[0].Organization == "MOD")
                        {
                            objSEIModel.subject = Convert.ToString(isGet.name).Replace("[BillingPlanDescription]", isGet.buyerName);
                        }
                        else if (objSEIModel.invoice[0].Organization == "FSP")
                        {
                            objSEIModel.subject = Convert.ToString(isGet.name).Replace("[InvoiceNo]", isGet.buyerName);
                        }
                    }
                }
            }
            return View(objSEIModel);
        }

        public string getInvoiceDetails(string logIdList)
        {
            var invoiceList = objBs.GetServiceTaxInvoiceByID(logIdList);
            StringBuilder str = new StringBuilder();
            str.AppendLine("<table class='maintable'><thead><tr><th>Invoice No.</th><th>Amount</th></tr></thead><tbody>");
            if (invoiceList != null)
            {
                invoiceList = invoiceList.OrderBy(x => x.InvoiceNo).ToList();
            }
            foreach (BOL.vw_ERP_ServiceTaxInvoice item in invoiceList)
            {
                str.AppendLine("<tr><td>" + item.InvoiceNo + "</td><td>" + item.Currency + " " + Convert.ToDouble(item.InvoiceAmount).ToString("N") + "</td></tr>");
            }
            str.AppendLine("</tbody></table>");
            return Convert.ToString(str);
        }

        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SendEmail(SendEInvoiceModel objInvoice, IEnumerable<HttpPostedFileBase> files)
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


                                objInvoice.body = objInvoice.body.Replace("\r", "").Replace("\n", "");
                                objInvoice.body = "<html><head><style type='text/css'>.maintable{border:1px solid lightgrey;border-spacing:0px;width:400px}.maintable th{border:1px solid lightgrey;background-color: lightgrey;width:200px;} .maintable td{border-left:1px solid lightgrey;border-top: 1px solid lightgrey;padding-left: 10px;}</style></head><body>" + objInvoice.body + "</body></html>";
                                objInvoice.subject = objInvoice.subject.Replace("\r", " ").Replace("\n", " ");

                                List<string> attachmentList = new List<string>();
                                attachmentList.Add(objInvoice.attachmentFolderLocation + "\\Invoice.pdf");
                                int fileCount = 0;
                                string fileName;
                                if (files != null)
                                {
                                    foreach (var file in files)
                                    {
                                        if (file != null && file.ContentLength > 0)
                                        {
                                            fileCount++;
                                            fileName = Path.GetFileName(file.FileName);
                                            var path = Path.Combine(objInvoice.attachmentFolderLocation + "\\", fileName);
                                            file.SaveAs(path);
                                            attachmentList.Add(path);
                                        }
                                    }
                                }

                                objInvoice.cc = (objInvoice.cc == null) ? objInvoice.mailSendBy : objInvoice.cc + ";" + objInvoice.mailSendBy;

                                BOL.spResult isGet = objBs.issueInvoice(objInvoice.logId, objInvoice.to, objInvoice.cc, objInvoice.subject, objInvoice.body, objInvoice.attachmentFolderLocation, User.Identity.Name, string.Join(",", attachmentList.ToArray()), objInvoice.mailSendBy);
                                if (isGet.result)
                                {
                                    BLL.MailService.MailResult isGetEmail = SendMailService.SendIssueInvoice(Convert.ToInt32(isGet.message), objInvoice.logId, User.Identity.Name);
                                    if (isGetEmail.status)
                                    {
                                        return RedirectToAction("Index", new { status = "I", logId = Convert.ToString(ViewData["LogId"]) });
                                    }
                                    else
                                    {
                                        TempData["Msg"] = "Unable to send Email : " + isGetEmail.message;
                                        return RedirectToAction("Index", new { status = "E", logId = Convert.ToString(ViewData["LogId"]) });
                                    }
                                }
                                else
                                {
                                    TempData["Msg"] = "Unable to Issue Invoice";
                                    return RedirectToAction("Index", new { status = "E", logId = Convert.ToString(ViewData["LogId"]) });
                                }



                            }
                        }
                    }
                }
                else
                {
                    TempData["Msg"] = "Unable to Issue Invoice : Access denied";
                    return RedirectToAction("Index", new { status = "E" });
                }


            }
            catch (Exception ex)
            {

                TempData["Msg"] = "Unable to Issue Invoice : Error : " + ex.Message;
                return RedirectToAction("Index", new { status = "E", logId = Convert.ToString(ViewData["LogId"]) });
            }

        }


        void CopyPages(PdfDocument from, PdfDocument to)
        {
            for (int i = 0; i < from.PageCount; i++)
            {
                to.AddPage(from.Pages[i]);
            }
        }


        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        void mergeDocument(List<BOL.vw_ERP_ServiceTaxInvoice> invoiceList)
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

                            PdfDocument pdfArr;


                            using (PdfDocument outPdf = new PdfDocument())
                            {

                                string cuFilePath;
                                for (int j = 0; j < invoiceList.Count; j++)
                                {
                                    cuFilePath = pdfLocation + "\\" + invoiceList[j].Period.Split('_')[1] + "\\" + invoiceList[j].Period + "\\" + invoiceList[j].InvoiceNo + "\\" + invoiceList[j].InvoiceNo + ".pdf";
                                    if (System.IO.File.Exists(cuFilePath))
                                    {
                                        pdfArr = PdfReader.Open(cuFilePath, PdfDocumentOpenMode.Import);
                                        CopyPages(pdfArr, outPdf);
                                    }
                                }

                                if (!System.IO.Directory.Exists(objSEIModel.attachmentFolderLocation))
                                {
                                    System.IO.Directory.CreateDirectory(objSEIModel.attachmentFolderLocation);
                                }

                                mergePDFFileName = objSEIModel.attachmentFolderLocation + "\\Invoice.pdf";
                                outPdf.Save(mergePDFFileName);
                                objSEIModel.invoiceFileSize = Convert.ToString(outPdf.FileSize);
                                ViewData["InvoiceFilePath"] = mergePDFFileName;
                            }

                        }
                    }
                }
            }

        }

        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        public ActionResult GetAttachment(string fileName, string type)
        {
            try
            {


                //string filePath;

                //filePath = Path.Combine(Server.MapPath("~/Upload Documents/"), docName);


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

                                if (!System.IO.File.Exists(fileName))
                                {
                                    return new EmptyResult();
                                }

                                byte[] filedata = System.IO.File.ReadAllBytes(fileName);

                                string mimeType = MimeMapping.GetMimeMapping(fileName);

                                return File(filedata, mimeType, fileName);

                            }
                        }
                    }
                }
                else
                {
                    TempData["Msg"] = "Unable to Download Invoice : Access denied";
                    return RedirectToAction("Index", new { status = "E" });
                }
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "RequestForQuote", "GetAttachment", clsGeneral.errorMessage(ex));
                return null;
            }

        }
    }




}