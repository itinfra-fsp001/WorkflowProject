using BLL.MailService;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace BLL
{
    public class SendMailService
    {
        public static void SendStatusToService(tbl_DocumentWorkFlow Document)
        {
            string reqType = GetReqType(Document.Status);
            if (!string.IsNullOrEmpty(reqType))
            {
                MailServiceClient _mailClient = new MailServiceClient();
                MailService.MailContract mc = new MailService.MailContract()
                {
                    DocId = Convert.ToString(Document.DocID),
                    ReqType = reqType,
                    WorkflowId = Convert.ToString(Document.WorkFlowID)
                };
                _mailClient.SendMail(mc);
            }
        }
        public static void SendStatusToService(tbl_Documents Document, string status)
        {
            string reqType = GetReqType(status);
            if (!string.IsNullOrEmpty(reqType))
            {
                MailServiceClient _mailClient = new MailServiceClient();
                MailService.MailContract mc = new MailService.MailContract()
                {
                    DocId = Convert.ToString(Document.DocID),
                    ReqType = reqType

                };
                _mailClient.SendMail(mc);
            }
        }
        public static bool SentPOMail(tbl_PurchaseOrder purchase, string body, string subject, bool isException = false)
        {
            //Subject = string.Format("Purchase Order By Fujitec Singapore:{0} issued to {1}", purchase.PurchaseOrderNo, purchase.VendorName),
            MailServiceClient _mailClient = new MailServiceClient();
            PoMailInfoContract mic = new PoMailInfoContract
            {
                DocId = purchase.DocID.ToString(),
                Subject = subject,
                PoNumber = purchase.PurchaseOrderNo,
                Body = body,
                BuyerName = purchase.BuyerName,
                POManageremailID = purchase.POManageremailID,
                IsException = isException,
                ToListAddress = purchase.Vendoremail == null ? null : purchase.Vendoremail.Split(',')
                //{
                //    purchase.Vendoremail.Split(',')[0]
                //}


            };
            return _mailClient.SendPoMail(mic);
            //mic.ToListAddress = new List<string>().Add(purchase.Vendoremail);
            //mic.PoNumber = purchase.PurchaseOrderNo;

        }
        public static void SendStatusToService(tbl_DocumentWorkFlow AppWorkflow, tbl_DocumentWorkFlow SubmitWorkFlow)
        {
            SendStatusToService(AppWorkflow);
            // SendStatusToService(SubmitWorkFlow);
        }

        private static string GetReqType(string status)
        {
            string reqType = string.Empty;
            switch (status)
            {
                case "A":
                    reqType = "Approve"; break;
                case "R":
                    reqType = "Reject"; break;
                case "P":
                    reqType = "Submit"; break;
                case "H":
                    reqType = "Hold"; break;
                case "U":
                    reqType = "Update"; break;
                case "V":
                    reqType = "Approve"; break;
                default:
                    reqType = ""; break;
            }
            return reqType;
        }
        private static Object thisLock = new Object();

        public static string GetMailBody()
        {
            string body = string.Empty;
            string bodyLocation = ConfigurationManager.AppSettings["MailBodyLocation"].ToString();
            lock (thisLock)
            {
                body = File.ReadAllText(bodyLocation);
            }
            return body;
        }

        public static MailResult SendIssueInvoice(Int32 notificationID,string invoiceList,string issuedBy)
        {
            MailServiceClient _mailClient = new MailServiceClient();
            MailResult isRet = _mailClient.SendInvoiceIssueMail(notificationID,invoiceList,issuedBy);
            return isRet;
        }
    }
}
